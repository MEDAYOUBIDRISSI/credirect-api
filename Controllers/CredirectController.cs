using credirect_api.Data;
using credirect_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
[EnableCors("AllowSpecificOrigins")] // Apply CORS policy to this controller
public class CredirectController : ControllerBase
{
    private readonly CredirectContext _context;

    public CredirectController(CredirectContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAll()
    {
        return await _context.Set<Client>().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetById(int id)
    {
        var entity = await _context.Set<Client>().FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return entity;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Create(Client entity)
    {
        _context.Set<Client>().Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetById", new { id = (entity as dynamic).Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Client entity)
    {
        if ((entity as dynamic).Id != id)
        {
            return BadRequest();
        }

        _context.Entry(entity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.Set<Client>().FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        _context.Set<Client>().Remove(entity);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /////////////////////////////////////////////////
    ///
    //[HttpGet("getAllClient")]
    //public async Task<dynamic> GetAllClient()
    //{
    //    var entity = await _context.Client.Select(t => new { t.LastName, t.FirstName, t.Matricule } ).AsNoTracking().ToListAsync();
    //    if (entity == null)
    //    {
    //        return NotFound();
    //    }
    //    return entity;
    //}

    [HttpGet("getAllClient")]
    public async Task<ActionResult<IEnumerable<object>>> GetAllClient()
    {
        var clients = await _context.Client
            .Include(c => c.ClientTitle)
            .Include(c => c.Role)
            .Include(c => c.MaritalStatus)
            .Include(c => c.Country)
            .Include(c => c.ResidenceCountry)
            .Include(c => c.Origin)
            .Include(c => c.ResidencyStatus)
            .Include(c => c.ClientIdentity)
            .Include(c => c.ClientLegalForm)
            .Include(c => c.BusinessActivity)
            .Include(c => c.CompanyCountry)
            .Include(c => c.ClientManagers)
                .ThenInclude(cm => cm.ManagerInformation)
                    .ThenInclude(mi => mi.ManagerTitle)
            .Include(c => c.ClientManagers)
                .ThenInclude(cm => cm.ManagerInformation)
                    .ThenInclude(mi => mi.ManagerCountry)
            .Include(c => c.ClientManagers)
                .ThenInclude(cm => cm.ManagerInformation)
                    .ThenInclude(mi => mi.ManagerResidenceCountry)
            .Include(c => c.ClientManagers)
                .ThenInclude(cm => cm.ManagerInformation)
                    .ThenInclude(mi => mi.ManagerMaritalStatus)
            .Include(c => c.ClientManagers)
                .ThenInclude(cm => cm.ManagerInformation)
                    .ThenInclude(mi => mi.Identity)
            .OrderByDescending(c => c.ClientID)
            .Select(c => new
            {
            // Basic Information
            c.ClientID,
                c.Matricule,
                c.VIP,
                c.is_individual,
                c.is_organisation,

            // Role Information
            Role = c.Role != null ? new
                {
                    c.Role.RoleID,
                    c.Role.RoleLabel
                } : null,

            // Personal Information
            c.LastName,
                c.FirstName,
                c.BirthDate,
                ClientTitle = c.ClientTitle != null ? new
                {
                    c.ClientTitle.ClientTitleID,
                    c.ClientTitle.ClientTitleLabel
                } : null,
                c.Nationality,
                c.Email,
                ClientIdentity = c.ClientIdentity != null ? new
                {
                    c.ClientIdentity.IdentityID,
                    c.ClientIdentity.IdentityLabel
                } : null,
                c.CIN,
                c.PassportNumber,
                c.ResidencePermit,

            // Contact Information
            c.Address,
                c.City,
                Country = c.Country != null ? new
                {
                    c.Country.ClientCountryID,
                    c.Country.ClientCountryLabel,
                } : null,
                ResidenceCountry = c.ResidenceCountry != null ? new
                {
                    c.ResidenceCountry.ClientCountryID,
                    c.ResidenceCountry.ClientCountryLabel,
                } : null,
                c.MobilePhone,
                c.LandlinePhone,
                c.WorkPhone,

            // Marital Status
            MaritalStatus = c.MaritalStatus != null ? new
                {
                    c.MaritalStatus.MaritalStatusID,
                    c.MaritalStatus.MaritalStatusLabel
                } : null,

            // Residence Information
            ResidencyStatus = c.ResidencyStatus != null ? new
                {
                    c.ResidencyStatus.ResidencyStatusID,
                    c.ResidencyStatus.ResidencyStatusLabel
                } : null,
                c.IsOwner,
                c.IsTenant,
                c.RequestedAmount,

            // Origin Information
            Origin = c.Origin != null ? new
                {
                    c.Origin.OriginID,
                    c.Origin.OriginLabel
                } : null,
                c.OriginDetails,

            // Company Information
            c.CompanyName,
                LegalForm = c.ClientLegalForm != null ? new
                {
                    c.ClientLegalForm.LegalFormID,
                    c.ClientLegalForm.LegalFormLabel
                } : null,
                c.CreationDate,
                c.RegistrationNumber,
                BusinessActivity = c.BusinessActivity != null ? new
                {
                    c.BusinessActivity.BusinessActivityID,
                    c.BusinessActivity.BusinessActivityLabel
                } : null,
                c.SocialCapital,
                c.CompanyAddress,
                c.CompanyCity,
                CompanyCountry = c.CompanyCountry != null ? new
                {
                    c.CompanyCountry.ClientCountryID,
                    c.CompanyCountry.ClientCountryLabel,
                } : null,

            // Managers Information
            Managers = c.ClientManagers.Select(cm => new
                {
                    cm.ClientManagerID,
                    cm.ManagerID,
                    ManagerInformation = cm.ManagerInformation != null ? new
                    {
                        cm.ManagerInformation.ManagerID,
                        ManagerTitle = cm.ManagerInformation.ManagerTitle != null ? new
                        {
                            cm.ManagerInformation.ManagerTitle.ClientTitleID,
                            cm.ManagerInformation.ManagerTitle.ClientTitleLabel
                        } : null,
                        cm.ManagerInformation.ManagerLastName,
                        cm.ManagerInformation.ManagerFirstName,
                        cm.ManagerInformation.ManagerBirthDate,
                        cm.ManagerInformation.ManagerNationality,
                        Identity = cm.ManagerInformation.Identity != null ? new
                        {
                            cm.ManagerInformation.Identity.IdentityID,
                            cm.ManagerInformation.Identity.IdentityLabel
                        } : null,
                        cm.ManagerInformation.Id_Identity,
                        cm.ManagerInformation.ManagerAddress,
                        cm.ManagerInformation.ManagerCity,
                        ManagerCountry = cm.ManagerInformation.ManagerCountry != null ? new
                        {
                            cm.ManagerInformation.ManagerCountry.ClientCountryID,
                            cm.ManagerInformation.ManagerCountry.ClientCountryLabel,
                        } : null,
                        ManagerResidenceCountry = cm.ManagerInformation.ManagerResidenceCountry != null ? new
                        {
                            cm.ManagerInformation.ManagerResidenceCountry.ClientCountryID,
                            cm.ManagerInformation.ManagerResidenceCountry.ClientCountryLabel,
                        } : null,
                        ManagerMaritalStatus = cm.ManagerInformation.ManagerMaritalStatus != null ? new
                        {
                            cm.ManagerInformation.ManagerMaritalStatus.MaritalStatusID,
                            cm.ManagerInformation.ManagerMaritalStatus.MaritalStatusLabel
                        } : null,
                        cm.ManagerInformation.CIN,
                        cm.ManagerInformation.CarteSejour,
                        cm.ManagerInformation.Passeport
                    } : null
                }).ToList(),

            // Utility Fields
            HasCreditFiles = _context.LignCreditClient.Any(l => l.ClientID == c.ClientID),
                CreatedDate = c.CreationDate ?? DateTime.Now
            })
            .AsNoTracking()
            .ToListAsync();

        return Ok(clients);
    }

    /////////////////////////////////////////////////
    ///
    [HttpGet("getAllClientTest")]
    public async Task<dynamic> GetAllClientTest()
    {
        return Ok(new { message = "CORS test successful!" });
    }

    [HttpPost("addTier")]
    public async Task<IActionResult> CreateOrUpdateTier([FromBody] Client entity)
    {
        if (entity == null)
        {
            return BadRequest("Client entity cannot be null.");
        }

        try
        {
            var existingClient = await _context.Client
            .Include(c => c.ClientManagers)
            .ThenInclude(cm => cm.ManagerInformation)
            .FirstOrDefaultAsync(x => x.ClientID == entity.ClientID);

            if (existingClient != null)
            {
                // Update existing client
                UpdateClient(existingClient, entity);

                // Handle ManagerInformation updates
                await UpdateClientManagers(existingClient, entity.ClientManagers);

            }
            else
            {
                string generatedMatricule = await GenerateUniqueMatriculeTiere();
                // Create new client
                var newClient = new Client
                {
                    //ClientID = 1010,
                    Matricule = generatedMatricule,
                    is_individual = entity.is_individual,
                    is_organisation = entity.is_organisation,
                    RoleID = entity.RoleID,

                    LastName = entity.LastName,
                    FirstName = entity.FirstName,
                    BirthDate = entity.BirthDate,
                    ClientTitleID = entity.ClientTitleID, //civilite
                    Nationality = entity.Nationality,
                    Email = entity.Email,
                    IdentityID = entity.IdentityID,
                    CIN = entity.CIN,
                    PassportNumber = entity.PassportNumber,
                    ResidencePermit = entity.ResidencePermit,

                    City = entity.City,
                    CountryID = entity.CountryID,
                    ResidenceCountryID = entity.ResidenceCountryID,
                    MaritalStatusID = entity.MaritalStatusID,
                    MobilePhone = entity.MobilePhone,
                    LandlinePhone = entity.LandlinePhone,
                    WorkPhone = entity.WorkPhone,
                    Address = entity.Address,

                    ResidencyStatusID = entity.ResidencyStatusID,
                    IsOwner = entity.IsOwner,
                    IsTenant = entity.IsTenant,
                    RequestedAmount = entity.RequestedAmount,
                    OriginID = entity.OriginID, //provenance
                    OriginDetails = entity.OriginDetails,

                    CompanyName = entity.CompanyName,
                    LegalFormID = entity.LegalFormID,
                    CreationDate = entity.CreationDate,
                    RegistrationNumber = entity.RegistrationNumber,
                    BusinessActivityID = entity.BusinessActivityID,

                    SocialCapital = entity.SocialCapital,
                    CompanyAddress = entity.CompanyAddress,
                    CompanyCity = entity.CompanyCity,
                    CompanyCountryID = entity.CompanyCountryID,

                };

                // Add new client to the context

                await _context.Client.AddAsync(newClient);
                await _context.SaveChangesAsync();

                // Handle ManagerInformation for the new client
                await UpdateClientManagers(newClient, entity.ClientManagers);

                return Ok(newClient.ClientID);
            }

            // Save changes for updates
            await _context.SaveChangesAsync();
            return Ok(existingClient.ClientID);
        }
        catch (Exception ex)
        {
            // Log the exception details
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
        }
    }

    private void UpdateClient(Client existingClient, Client newClientData)
    {
        existingClient.VIP = newClientData.VIP;
        existingClient.is_individual = newClientData.is_individual;
        existingClient.is_organisation = newClientData.is_organisation;
        existingClient.RoleID = newClientData.RoleID;

        existingClient.LastName = newClientData.LastName;
        existingClient.FirstName = newClientData.FirstName;
        existingClient.BirthDate = newClientData.BirthDate;
        existingClient.ClientTitleID = newClientData.ClientTitleID; //civilite
        existingClient.Nationality = newClientData.Nationality;
        existingClient.Email = newClientData.Email;
        existingClient.IdentityID = newClientData.IdentityID;
        existingClient.CIN = newClientData.CIN;
        existingClient.PassportNumber = newClientData.PassportNumber;
        existingClient.ResidencePermit = newClientData.ResidencePermit;

        existingClient.City = newClientData.City;
        existingClient.CountryID = newClientData.CountryID;
        existingClient.ResidenceCountryID = newClientData.ResidenceCountryID;
        existingClient.MaritalStatusID = newClientData.MaritalStatusID;
        existingClient.MobilePhone = newClientData.MobilePhone;
        existingClient.LandlinePhone = newClientData.LandlinePhone;
        existingClient.WorkPhone = newClientData.WorkPhone;
        existingClient.Address = newClientData.Address;

        existingClient.ResidencyStatusID = newClientData.ResidencyStatusID;
        existingClient.IsOwner = newClientData.IsOwner;
        existingClient.IsTenant = newClientData.IsTenant;
        existingClient.RequestedAmount = newClientData.RequestedAmount;
        existingClient.OriginID = newClientData.OriginID; //provenance
        existingClient.OriginDetails = newClientData.OriginDetails;

        existingClient.CompanyName = newClientData.CompanyName;
        existingClient.LegalFormID = newClientData.LegalFormID;
        existingClient.CreationDate = newClientData.CreationDate;
        existingClient.RegistrationNumber = newClientData.RegistrationNumber;
        existingClient.BusinessActivityID = newClientData.BusinessActivityID;

        existingClient.SocialCapital = newClientData.SocialCapital;
        existingClient.CompanyAddress = newClientData.CompanyAddress;
        existingClient.CompanyCity = newClientData.CompanyCity;
        existingClient.CompanyCountryID = newClientData.CompanyCountryID;
    }

    private async Task UpdateClientManagers(Client client, ICollection<ClientManager> clientManagers)
    {
        if (clientManagers == null || !clientManagers.Any())
        {
            return; // No managers to update
        }

        // Remove existing managers not in the new list
        var existingManagers = client.ClientManagers.ToList();
        foreach (var existingManager in existingManagers)
        {
            if (!clientManagers.Any(cm => cm.ManagerID == existingManager.ManagerID))
            {
                _context.ClientManager.Remove(existingManager);
            }
        }

        // Add or update managers
        foreach (var clientManager in clientManagers)
        {
            var existingManager = client.ClientManagers
                .FirstOrDefault(cm => cm.ManagerID == clientManager.ManagerID);

            if (existingManager == null)
            {
                // Add new manager
                var newManager = new ClientManager
                {
                    ManagerID = clientManager.ManagerID,
                    ManagerInformation = await UpdateOrCreateManagerInformation(clientManager.ManagerInformation)
                };
                client.ClientManagers.Add(newManager);
            }
            else
            {
                // Update existing manager information
                existingManager.ManagerInformation = await UpdateOrCreateManagerInformation(clientManager.ManagerInformation);
            }
        }
        await _context.SaveChangesAsync();
    }

    private async Task<ManagerInformation> UpdateOrCreateManagerInformation(ManagerInformation managerInformation)
    {
        if (managerInformation == null)
        {
            return null;
        }

        var existingManagerInfo = await _context.ManagerInformation
            .FirstOrDefaultAsync(mi => mi.ManagerID == managerInformation.ManagerID);

        if (existingManagerInfo == null)
        {
            // Create new ManagerInformation
            var newManagerInfo = new ManagerInformation
            {
                ManagerTitleID = managerInformation.ManagerTitleID,
                ManagerLastName = managerInformation.ManagerLastName,
                ManagerFirstName = managerInformation.ManagerFirstName,
                ManagerBirthDate = managerInformation.ManagerBirthDate,
                ManagerNationality = managerInformation.ManagerNationality,
                Id_Identity = managerInformation.Id_Identity,
                ManagerAddress = managerInformation.ManagerAddress,
                ManagerCity = managerInformation.ManagerCity,
                ManagerCountryID = managerInformation.ManagerCountryID,
                ManagerResidenceCountryID = managerInformation.ManagerResidenceCountryID,
                Id_ManagerMaritalStatus = managerInformation.Id_ManagerMaritalStatus,
                CIN = managerInformation.CIN,
                Passeport = managerInformation.Passeport,
                CarteSejour = managerInformation.CarteSejour,
            };

            _context.ManagerInformation.Add(newManagerInfo);
            await _context.SaveChangesAsync();
            return newManagerInfo;
        }
        else
        {
            // Update existing ManagerInformation
            existingManagerInfo.ManagerTitleID = managerInformation.ManagerTitleID;
            existingManagerInfo.ManagerLastName = managerInformation.ManagerLastName;
            existingManagerInfo.ManagerFirstName = managerInformation.ManagerFirstName;
            existingManagerInfo.ManagerBirthDate = managerInformation.ManagerBirthDate;
            existingManagerInfo.ManagerNationality = managerInformation.ManagerNationality;
            existingManagerInfo.Id_Identity = managerInformation.Id_Identity;
            existingManagerInfo.ManagerAddress = managerInformation.ManagerAddress;
            existingManagerInfo.ManagerCity = managerInformation.ManagerCity;
            existingManagerInfo.ManagerCountryID = managerInformation.ManagerCountryID;
            existingManagerInfo.ManagerResidenceCountryID = managerInformation.ManagerResidenceCountryID;
            existingManagerInfo.Id_ManagerMaritalStatus = managerInformation.Id_ManagerMaritalStatus;
            existingManagerInfo.CIN = managerInformation.CIN;
            existingManagerInfo.CarteSejour = managerInformation.CarteSejour;
            existingManagerInfo.Passeport = managerInformation.Passeport;

            _context.ManagerInformation.Update(existingManagerInfo);
            await _context.SaveChangesAsync();
            return existingManagerInfo;
        }
    }

    [HttpGet("findClientById/{id}")]
    public async Task<ActionResult<dynamic>> FindClientById(int id)
    {
        try
        {
            var client = await _context.Client
                .Include(c => c.ClientTitle)
                .Include(c => c.Role)
                .Include(c => c.MaritalStatus)
                .Include(c => c.Country)
                .Include(c => c.ResidenceCountry)
                .Include(c => c.Origin)
                .Include(c => c.ResidencyStatus)
                .Include(c => c.ClientIdentity)
                .Include(c => c.ClientLegalForm)
                .Include(c => c.BusinessActivity)
                .Include(c => c.CompanyCountry)
                .Include(c => c.ClientManagers)
                    .ThenInclude(cm => cm.ManagerInformation)
                        .ThenInclude(mi => mi.ManagerTitle)
                .Include(c => c.ClientManagers)
                    .ThenInclude(cm => cm.ManagerInformation)
                        .ThenInclude(mi => mi.ManagerCountry)
                .Include(c => c.ClientManagers)
                    .ThenInclude(cm => cm.ManagerInformation)
                        .ThenInclude(mi => mi.ManagerResidenceCountry)
                .Include(c => c.ClientManagers)
                    .ThenInclude(cm => cm.ManagerInformation)
                        .ThenInclude(mi => mi.ManagerMaritalStatus)
                .FirstOrDefaultAsync(c => c.ClientID == id);

            if (client == null)
            {
                return NotFound(new { success = false, message = "Client not found" });
            }

            // Map to a DTO or anonymous object to avoid circular references
            var result = new
            {
                // Client Information
                ClientID = client.ClientID,
                Matricule = client.Matricule,
                is_individual = client.is_individual,
                is_organisation = client.is_organisation,
                Role = client.Role?.RoleLabel,
                RoleID = client.RoleID,

                // Personal/Company Info
                LastName = client.LastName,
                FirstName = client.FirstName,
                CompanyName = client.CompanyName,
                BirthDate = client.BirthDate,
                Title = client.ClientTitle?.ClientTitleLabel,
                ClientTitleID = client.ClientTitleID,
                Nationality = client.Nationality,
                Email = client.Email,
                Identity = client.ClientIdentity?.IdentityLabel,
                IdentityID = client.IdentityID,
                CIN = client.CIN,
                PassportNumber = client.PassportNumber,
                ResidencePermit = client.ResidencePermit,

                // Contact Info
                City = client.City,
                Country = client.Country?.ClientCountryLabel,
                CountryID = client.CountryID,
                ResidenceCountry = client.ResidenceCountry?.ClientCountryLabel,
                ResidenceCountryID = client.ResidenceCountryID,
                MaritalStatus = client.MaritalStatus?.MaritalStatusLabel,
                MaritalStatusID = client.MaritalStatusID,
                MobilePhone = client.MobilePhone,
                LandlinePhone = client.LandlinePhone,
                WorkPhone = client.WorkPhone,
                Address = client.Address,

                // Company Specific Info
                LegalForm = client.ClientLegalForm?.LegalFormLabel,
                LegalFormID = client.LegalFormID,
                CreationDate = client.CreationDate,
                RegistrationNumber = client.RegistrationNumber,
                BusinessActivity = client.BusinessActivity?.BusinessActivityLabel,
                BusinessActivityID = client.BusinessActivityID,
                SocialCapital = client.SocialCapital,
                CompanyAddress = client.CompanyAddress,
                CompanyCity = client.CompanyCity,
                CompanyCountry = client.CompanyCountry?.ClientCountryLabel,
                CompanyCountryID = client.CompanyCountryID,

                // Managers Information
                Managers = client.ClientManagers?.Select(cm => new
                {
                    ManagerID = cm.ManagerID,
                    Title = cm.ManagerInformation?.ManagerTitle?.ClientTitleLabel,
                    ManagerTitleID = cm.ManagerInformation?.ManagerTitleID,
                    LastName = cm.ManagerInformation?.ManagerLastName,
                    FirstName = cm.ManagerInformation?.ManagerFirstName,
                    BirthDate = cm.ManagerInformation?.ManagerBirthDate,
                    Nationality = cm.ManagerInformation?.ManagerNationality,
                    IdentityType = cm.ManagerInformation?.Id_Identity,
                    CIN = cm.ManagerInformation?.CIN,
                    CarteSejour = cm.ManagerInformation?.CarteSejour,
                    Passeport = cm.ManagerInformation?.Passeport,
                    Address = cm.ManagerInformation?.ManagerAddress,
                    City = cm.ManagerInformation?.ManagerCity,
                    Country = cm.ManagerInformation?.ManagerCountry?.ClientCountryLabel,
                    CountryID = cm.ManagerInformation?.ManagerCountryID,
                    ResidenceCountry = cm.ManagerInformation?.ManagerResidenceCountry?.ClientCountryLabel,
                    ResidenceCountryID = cm.ManagerInformation?.ManagerResidenceCountryID,
                    MaritalStatus = cm.ManagerInformation?.ManagerMaritalStatus?.MaritalStatusLabel,
                    MaritalStatusID = cm.ManagerInformation?.Id_ManagerMaritalStatus
                }).ToList()
            };

            return Ok(new
            {
                success = true,
                data = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = $"Internal server error: {ex.Message}",
                stackTrace = ex.StackTrace
            });
        }
    }

    [HttpGet("lookups/client-titles")]
    public async Task<ActionResult<IEnumerable<ClientTitle>>> GetClientTitles()
    {
        return await _context.ClientTitle.ToListAsync();
    }

    [HttpGet("lookups/marital-statuses")]
    public async Task<ActionResult<IEnumerable<MaritalStatus>>> GetMaritalStatuses()
    {
        return await _context.MaritalStatus.ToListAsync();
    }

    [HttpGet("lookups/client-roles")]
    public async Task<ActionResult<IEnumerable<ClientRole>>> GetClientRoles()
    {
        return await _context.ClientRole.ToListAsync();
    }

    [HttpGet("lookups/legal-forms")]
    public async Task<ActionResult<IEnumerable<ClientLegalForm>>> GetLegalForms()
    {
        return await _context.ClientLegalForm.ToListAsync();
    }

    [HttpGet("lookups/business-activities")]
    public async Task<ActionResult<IEnumerable<BusinessActivity>>> GetBusinessActivities()
    {
        return await _context.BusinessActivity.ToListAsync();
    }

    [HttpGet("lookups/client-origins")]
    public async Task<ActionResult<IEnumerable<ClientOrigin>>> GetClientOrigins()
    {
        return await _context.ClientOrigin.ToListAsync();
    }

    [HttpGet("lookups/countries")]
    public async Task<ActionResult<IEnumerable<ClientCountry>>> GetCountries()
    {
        return await _context.ClientCountry.ToListAsync();
    }

    [HttpGet("lookups/residency-statuses")]
    public async Task<ActionResult<IEnumerable<ResidencyStatus>>> GetResidencyStatuses()
    {
        return await _context.ResidencyStatus.ToListAsync();
    }
    [HttpGet("lookups/identities")]
    public async Task<ActionResult<IEnumerable<ClientIdentity>>> GetIdentities()
    {
        return await _context.ClientIdentity.ToListAsync();
    }


    [HttpPost, Route("GetTierByCIN"), Produces("application/json")]
    public async Task<IActionResult> getTierByCIN(Client entity)
    {

        var CIN = entity.CIN;

        if (CIN != null)
        {
            var Tier = await _context.Client.Where(b => b.CIN == CIN || b.RegistrationNumber == CIN || b.NRC == CIN || b.ResidencePermit == CIN || b.PassportNumber == CIN || b.NRC == CIN).Select(s => new
            {
                s.ClientID,
                s.CIN,
                s.LastName,
                s.FirstName,
                denomination = s.CompanyName,
                s.NRC,
                s.RegistrationNumber,
                is_complete = false,
                tier_interv = 20,
                role = s.is_organisation == true ? "Organisation" : s.Role.RoleLabel,
                tel = s.MobilePhone,
                civilite = s.ClientTitle.ClientTitleLabel,
                dateNaissance = s.BirthDate,
                nationalite = s.Nationality,
                identite = s.ClientIdentity.IdentityLabel,
                adresse = s.Address,
                ville = s.City,
                pays = s.Country.ClientCountryLabel,
                paysResidence = s.ResidenceCountry.ClientCountryLabel,
                situationFamiliale = "Celibataire",
                telephoneMobile = s.MobilePhone,
                telephoneFixe = s.LandlinePhone,
                telephoneProfessionnel = s.WorkPhone,
                email = s.Email,
                statut = s.MaritalStatus.MaritalStatusLabel,
                statutOccupation = "Locataire",
                provenanceClient = "Agence immobilière",
                origin = s.Origin.OriginLabel,
                montantSollicite = "500,000 MAD",
                s.is_organisation,
                s.is_individual,
                managers = _context.ManagerInformation.Where(b => b.ManagerTitleID == s.ClientID).ToList()
            }).FirstOrDefaultAsync();
            if (Tier == null)
            {
                return Ok(new
                {
                    success = true,
                    status_code = 401,
                    message = "not found."
                });
            }
            else
            {
                return Ok(new
                {
                    success = true,
                    status_code = 200,
                    message = "Tier found.",
                    data = Tier
                });
            }
        }
        return Ok(new
        {
            success = true,
            status_code = 401,
            message = "not found."
        });
    }

    [HttpPost, Route("getTiresByIDFromFicheClient"), Produces("application/json")]
    public async Task<IActionResult> getTiresByIDFromFicheClient(Client entity)
    {

        var clientID = entity.ClientID;

        if (clientID != null)
        {
            var Tier = await _context.Client.Where(b => b.ClientID == clientID).Select(s => new
            {
                s.ClientID,
                s.CIN,
                s.LastName,
                s.FirstName,
                denomination = s.CompanyName,
                s.NRC,
                s.RegistrationNumber,
                is_complete = false,
                tier_interv = 20,
                role = s.Role.RoleLabel,
                tel = s.MobilePhone,
                civilite = s.ClientTitle.ClientTitleLabel,
                dateNaissance = s.BirthDate,
                nationalite = s.Nationality,
                identite = s.ClientIdentity.IdentityLabel,
                adresse = s.Address,
                ville = s.City,
                pays = s.Country.ClientCountryLabel,
                paysResidence = s.ResidenceCountry.ClientCountryLabel,
                situationFamiliale = "Celibataire",
                telephoneMobile = s.MobilePhone,
                telephoneFixe = s.LandlinePhone,
                telephoneProfessionnel = s.WorkPhone,
                email = s.Email,
                statut = s.MaritalStatus.MaritalStatusLabel,
                statutOccupation = "Locataire",
                provenanceClient = "Agence immobilière",
                origin = s.Origin.OriginLabel,
                montantSollicite = "500,000 MAD",
                s.is_organisation,
                s.is_individual,
                managers = _context.ManagerInformation.Where(b => b.ManagerTitleID == s.ClientID).ToList()
            }).FirstOrDefaultAsync();
            if (Tier == null)
            {
                return Ok(new
                {
                    success = true,
                    status_code = 401,
                    message = "not found."
                });
            }
            else
            {
                return Ok(new
                {
                    success = true,
                    status_code = 200,
                    message = "Tier found.",
                    data = Tier
                });
            }
        }
        return Ok(new
        {
            success = true,
            status_code = 401,
            message = "not found."
        });
    }

    [HttpPost, Route("addOrUpdateFolder"), Produces("application/json")]
    public async Task<IActionResult> addOrUpdateFolder(dynamic entity)
    {
        JsonElement json = (JsonElement)entity;

        var folder = json.TryGetProperty("folderID", out JsonElement folderElement) && folderElement.ValueKind != JsonValueKind.Null
            ? folderElement.GetString()
            : null;

        if (string.IsNullOrEmpty(folder))
        {
            // Générer matricule
            string generatedMatricule = await GenerateUniqueMatricule();

            int CreditTypeID = json.TryGetProperty("creditType", out JsonElement creditTypeElement) && creditTypeElement.ValueKind != JsonValueKind.Null
                                ? creditTypeElement.GetInt32()
                                : 0;
            var newfolder = new Credit
            {
                Matricule = generatedMatricule,
                CreditTypeID = CreditTypeID
            };

            await _context.Credit.AddAsync(newfolder);
            await _context.SaveChangesAsync();

            // Ajout des lignes LignCreditClient à partir des tiers
            if (entity.TryGetProperty("tiers", out JsonElement tiersElement) && tiersElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement tier in tiersElement.EnumerateArray())
                {
                    int clientID = tier.GetProperty("clientID").GetInt32();
                    string role = tier.GetProperty("role").GetString();

                    var lign = new LignCreditClient
                    {
                        ClientID = clientID,
                        CreditID = newfolder.CreditID,
                        IsPrincipal = role == "Emprunteur", // Emprunteur = principal
                        PercentageClient = role == "Emprunteur" ? 100 : 0 // à ajuster selon la logique
                    };

                    await _context.LignCreditClient.AddAsync(lign);
                }

                await _context.SaveChangesAsync();
            }

            return Ok(newfolder.CreditID);
        }

        return Ok(new
        {
            success = true,
            status_code = 401,
            message = "not found."
        });
    }

    [HttpPost, Route("getTiersByFolderID"), Produces("application/json")]
    public async Task<IActionResult> getTiersByFolderID(dynamic entity)
    {
        JsonElement json = (JsonElement)entity;

        int folder = 0;
        if (json.TryGetProperty("folderID", out JsonElement folderElement) && folderElement.ValueKind == JsonValueKind.String)
        {
            int.TryParse(folderElement.GetString(), out folder);
        }

        if (folder != null)
        {
            // Générer matricule
            var Tier = await _context.LignCreditClient.Where(b => b.CreditID == folder).Select(s => new
            {
                s.Client.ClientID,
                s.Client.CIN,
                s.Client.LastName,
                s.Client.FirstName,
                denomination = s.Client.CompanyName,
                s.Client.NRC,
                s.Client.RegistrationNumber,
                is_complete = false,
                tier_interv = 20,
                role = s.Client.is_organisation == true ? "Organisation" : s.Client.Role.RoleLabel,
                tel = s.Client.MobilePhone,
                civilite = s.Client.ClientTitle.ClientTitleLabel,
                dateNaissance = s.Client.BirthDate,
                nationalite = s.Client.Nationality,
                identite = s.Client.ClientIdentity.IdentityLabel,
                adresse = s.Client.Address,
                ville = s.Client.City,
                pays = s.Client.Country.ClientCountryLabel,
                paysResidence = s.Client.ResidenceCountry.ClientCountryLabel,
                situationFamiliale = "Celibataire",
                telephoneMobile = s.Client.MobilePhone,
                telephoneFixe = s.Client.LandlinePhone,
                telephoneProfessionnel = s.Client.WorkPhone,
                email = s.Client.Email,
                statut = s.Client.MaritalStatus.MaritalStatusLabel,
                statutOccupation = "Locataire",
                provenanceClient = "Agence immobilière",
                origin = s.Client.Origin.OriginLabel,
                montantSollicite = "500,000 MAD",
                CreditID = s.CreditID,
                Matricule = s.Credit.Matricule,
                CreditTypeID = s.Credit.CreditType.TypeID,
                CreditTypeLabel = s.Credit.CreditType.TypeLabel,
                s.Client.is_organisation,
                s.Client.is_individual,
                managers = _context.ManagerInformation.Where(b => b.ManagerTitleID == s.ClientID).ToList()

            }).ToListAsync();

            return Ok(new
            {
                success = true,
                status_code = 200,
                data = Tier
            });
        }

        return Ok(new
        {
            success = true,
            status_code = 401,
            message = "not found."
        });
    }

    // Méthode pour générer un matricule unique au format "DOS-001"
    private async Task<string> GenerateUniqueMatricule()
    {
        // Récupérer le dernier matricule
        var lastMatricule = await _context.Credit
            .Where(c => c.Matricule.StartsWith("DOS-"))
            .OrderByDescending(c => c.CreditID)
            .Select(c => c.Matricule)
            .FirstOrDefaultAsync();

        int nextNumber = 1;

        if (!string.IsNullOrEmpty(lastMatricule))
        {
            var numericPart = lastMatricule.Replace("DOS-", "");
            if (int.TryParse(numericPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }

        return $"DOS-{nextNumber.ToString("D3")}";
    }

    // Méthode pour générer un matricule unique au format "DOS-001"
    private async Task<string> GenerateUniqueMatriculeTiere()
    {
        // Récupérer le dernier matricule
        var lastMatricule = await _context.Client
            .Where(c => c.Matricule.StartsWith("Client-"))
            .OrderByDescending(c => c.ClientID)
            .Select(c => c.Matricule)
            .FirstOrDefaultAsync();

        int nextNumber = 1;

        if (!string.IsNullOrEmpty(lastMatricule))
        {
            var numericPart = lastMatricule.Replace("Client-", "");
            if (int.TryParse(numericPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }

        return $"Client-{nextNumber.ToString("D3")}";
    }

    [HttpPost, Route("getTierByID"), Produces("application/json")]
    public async Task<IActionResult> getTierByID(dynamic entity)
    {
        JsonElement json = (JsonElement)entity;

        int tierID = 0;
        if (json.TryGetProperty("tierID", out JsonElement folderElement) && folderElement.ValueKind == JsonValueKind.String)
        {
            int.TryParse(folderElement.GetString(), out tierID);
        }

        if (tierID != null)
        {
            // Get pensions
            var pensions = await _context.Pensionnaire
                .Where(p => p.ClientID == tierID)
                .Select(p => new
                {
                    p.Id,
                    p.NaturePension,
                    p.OrganismePension,
                    p.TypePension,
                    p.Montant
                })
                .ToListAsync();
            // Générer matricule
            var Tier = await _context.Client.Where(b => b.ClientID == tierID).Select(s => new
            {
                s.ClientID,
                s.CIN,
                s.LastName,
                s.FirstName,
                nomPrenom = s.LastName + " " + s.FirstName,
                is_complete = false,
                tier_interv = 20,
                role = s.Role.RoleLabel,
                tel = s.MobilePhone,
                civilite = s.ClientTitle.ClientTitleLabel,
                dateNaissance = s.BirthDate,
                nationalite = s.Nationality,
                identite = s.ClientIdentity.IdentityLabel,
                adresse = s.Address,
                ville = s.City,
                pays = s.Country.ClientCountryLabel,
                paysResidence = s.ResidenceCountry.ClientCountryLabel,
                situationFamiliale = "Celibataire",
                telephoneMobile = s.MobilePhone,
                telephoneFixe = s.LandlinePhone,
                telephoneProfessionnel = s.WorkPhone,
                email = s.Email,
                statut = s.MaritalStatus.MaritalStatusLabel,
                statutOccupation = "Locataire",
                provenanceClient = "Agence immobilière",
                origin = s.Origin.OriginLabel,
                montantSollicite = "500,000 MAD",
                // New fields
                Profession = s.Profession,
                Nature_activity = s.Nature_activity,
                IfOrTp = s.IfOrTp,
                Adress_activity = s.Adress_activity,
                Honoraires = s.Honoraires,
                Date_debut_exercice = s.Date_debut_exercice,
                Fonction = s.Fonction,
                Employeur = s.Employeur,
                Date_Embauche = s.Date_Embauche,
                Salaire = s.Salaire,
                NRC = s.NRC,
                Date_Creation_RC = s.Date_Creation_RC,
                Revenu = s.Revenu,
                Denomination = s.Denomination,
                Date_Creation_Company = s.Date_Creation_Company,
                ActivityCompany = s.ActivityCompany,
                Capital_Social = s.Capital_Social,
                ResultatYearN = s.ResultatYearN,
                ChiffreAffaireYearN = s.ChiffreAffaireYearN,
                ResultatYearN_1 = s.ResultatYearN_1,
                ChiffreAffaireYearN_1 = s.ChiffreAffaireYearN_1,
                PartsParticipationSociete = s.PartsParticipationSociete,
                Nature_Bail = s.Nature_Bail,
                Rent = s.Rent,
                pensions = pensions

            }).ToListAsync();

            return Ok(new
            {
                success = true,
                status_code = 200,
                data = Tier
            });
        }

        return Ok(new
        {
            success = true,
            status_code = 401,
            message = "not found."
        });
    }

    [HttpPost, Route("getFoldersList"), Produces("application/json")]
    public async Task<IActionResult> getFoldersList(dynamic entity)
    {
        var folders = await _context.Credit.OrderByDescending(c => c.CreditID).Select(s => new
        {
            idDossier = s.CreditID,
            id = s.Matricule,
            client = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == s.CreditID).Select(s => s.Client.FirstName + " " + s.Client.LastName).FirstOrDefault(),
            companyName = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == s.CreditID).Select(s => s.Client.CompanyName).FirstOrDefault(),
            type = s.CreditType.TypeLabel,
            montant= s.amount,
            statut = "Refusé",
            dateCreation = "2025-05-14",
            conseiller = "Youssef Benali",
            banque = _context.CreditDepot.AsNoTracking().Where(b => b.id_credit == s.CreditID).Count(),
            progression= 100,
            is_organisation = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == s.CreditID).Select(d => d.Client.is_organisation).FirstOrDefault(),

        }).ToListAsync();

        return Ok(new
        {
            success = true,
            status_code = 200,
            data = folders
        });
    }

    [HttpPost("saveTierInfoProf")]
    public async Task<IActionResult> saveTierInfoProf(dynamic entity)
    {
        JsonElement json = (JsonElement)entity;

        int tierID = 0;
        //if (entity == null)
        //{
        //    return BadRequest("Client entity cannot be null.");
        //}

        if (json.TryGetProperty("tierID", out JsonElement folderElement) && folderElement.ValueKind == JsonValueKind.String)
        {
            int.TryParse(folderElement.GetString(), out tierID);
        }

        try
        {
            var existingClient = await _context.Client.Where(b => b.ClientID == tierID).FirstOrDefaultAsync();

            if (existingClient != null)
            {
                // Update existing client
                // Deserialize the user part
                var userJson = json.GetProperty("user").ToString();
                var user = JsonSerializer.Deserialize<Client>(userJson);
                // Update based on profession
                int profession = json.GetProperty("Profession").GetInt32();
                existingClient.Profession = profession;
                switch (profession)
                {
                    case 1: // Salarié
                        existingClient.Fonction = user.Fonction;
                        existingClient.Employeur = user.Employeur;
                        existingClient.Date_Embauche = user.Date_Embauche;
                        existingClient.Salaire = user.Salaire;
                        break;

                    case 2: // Commerçant personne physique
                        existingClient.NRC = user.NRC;
                        existingClient.Date_Creation_RC = user.Date_Creation_RC;
                        existingClient.Nature_activity = user.Nature_activity;
                        existingClient.Adress_activity = user.Adress_activity;
                        existingClient.Revenu = user.Revenu;
                        break;

                    case 3: // Profession libérale
                        existingClient.Nature_activity = user.Nature_activity;
                        existingClient.IfOrTp = user.IfOrTp;
                        existingClient.Adress_activity = user.Adress_activity;
                        existingClient.Date_debut_exercice = user.Date_debut_exercice;
                        existingClient.Honoraires = user.Honoraires;
                        break;

                    case 4: // Gérant de société
                        existingClient.Denomination = user.Denomination;
                        existingClient.NRC = user.NRC;
                        existingClient.Date_Creation_Company = user.Date_Creation_Company;
                        existingClient.Capital_Social = user.Capital_Social;
                        existingClient.ActivityCompany = user.ActivityCompany;
                        existingClient.Adress_activity = user.Adress_activity;
                        existingClient.ResultatYearN = user.ResultatYearN;
                        existingClient.ResultatYearN_1 = user.ResultatYearN_1;
                        existingClient.ChiffreAffaireYearN = user.ChiffreAffaireYearN;
                        existingClient.ChiffreAffaireYearN_1 = user.ChiffreAffaireYearN_1;
                        existingClient.PartsParticipationSociete = user.PartsParticipationSociete;
                        existingClient.Revenu = user.Revenu;
                        break;

                    case 5: // Retraité ou pensionnaire (if needed)
                        if (json.TryGetProperty("user", out JsonElement userElement) && userElement.TryGetProperty("Pension", out JsonElement pensionList))
                        {
                            var pensionnaires = JsonSerializer.Deserialize<List<Pensionnaire>>(pensionList.ToString());

                            // Get existing pensions from DB
                            var existingPensions = await _context.Pensionnaire
                                .Where(p => p.ClientID == tierID)
                                .ToListAsync();

                            // Update or add new pensions
                            foreach (var pension in pensionnaires)
                            {
                                if (pension.Id > 0)
                                {
                                    // Update existing
                                    var existing = existingPensions.FirstOrDefault(p => p.Id == pension.Id);
                                    if (existing != null)
                                    {
                                        existing.NaturePension = pension.NaturePension;
                                        existing.OrganismePension = pension.OrganismePension;
                                        existing.TypePension = pension.TypePension;
                                        existing.Montant = pension.Montant;
                                    }
                                }
                                else
                                {
                                    // New pension
                                    pension.ClientID = tierID;
                                    _context.Pensionnaire.Add(pension);
                                }
                            }

                            // Delete pensions not in the updated list
                            var updatedIds = pensionnaires.Where(p => p.Id > 0).Select(p => p.Id).ToList();
                            var toDelete = existingPensions.Where(p => !updatedIds.Contains(p.Id)).ToList();
                            _context.Pensionnaire.RemoveRange(toDelete);
                        }
                        break;

                    case 6: // Profession libérale
                        existingClient.Nature_Bail = user.Nature_Bail;
                        existingClient.Rent = user.Rent;
                        break;
                }

                // Save changes
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    status_code = 200,
                    data = existingClient
                });

            }
            else
            {
                return Ok(new
                {
                    success = true,
                    status_code = 401,
                    message = "not found."
                });
            }
        }
        catch (Exception ex)
        {
            // Log the exception details
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
        }
    }

    [HttpPost("getInfosBank")]
    public async Task<IActionResult> GetInfosBank(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;

            int clientID = 0;
            if (json.TryGetProperty("tierID", out JsonElement clientElement) && clientElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(clientElement.GetString(), out clientID);
            }

            if (clientID == 0)
                return BadRequest("clientID est requis.");

            var infosBankList = await _context.InfosBank
                .Where(i => i.ClientID == clientID)
                .ToListAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = infosBankList
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("saveInfosBank")]
    public async Task<IActionResult> saveInfosBank(dynamic entity)
    {
        JsonElement json = (JsonElement)entity;

        int clientID = 0;
        if (json.TryGetProperty("tierID", out JsonElement clientElement) && clientElement.ValueKind == JsonValueKind.String)
        {
            int.TryParse(clientElement.GetString(), out clientID);
        }

        if (clientID == 0)
            return BadRequest("ClientID manquant ou invalide.");

        try
        {
            // Deserialize infosBank list
            if (json.TryGetProperty("infoBank", out JsonElement infosElement))
            {
                var infosBankList = JsonSerializer.Deserialize<List<InfosBank>>(infosElement.ToString());

                // Get existing records
                var existingInfos = await _context.InfosBank
                    .Where(i => i.ClientID == clientID)
                    .ToListAsync();

                // Update or add
                foreach (var info in infosBankList)
                {
                    if (info.InfoBankID > 0)
                    {
                        var existing = existingInfos.FirstOrDefault(x => x.InfoBankID == info.InfoBankID);
                        if (existing != null)
                        {
                            existing.AgencyBankID = info.AgencyBankID;
                            existing.AgencyName = info.AgencyName;
                            existing.Balance = info.Balance;
                            existing.CumulativeCreditMovement = info.CumulativeCreditMovement;
                            existing.IsPrincipal = info.IsPrincipal;
                        }
                    }
                    else
                    {
                        info.ClientID = clientID;
                        _context.InfosBank.Add(info);
                    }
                }

                // Delete removed rows
                var updatedIds = infosBankList.Where(x => x.InfoBankID > 0).Select(x => x.InfoBankID).ToList();
                var toDelete = existingInfos.Where(x => !updatedIds.Contains(x.InfoBankID)).ToList();
                _context.InfosBank.RemoveRange(toDelete);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    status_code = 200,
                    message = "Mise à jour effectuée avec succès"
                });
            }

            return BadRequest("Liste infosBank manquante.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("getEngagement")]
    public async Task<IActionResult> GetEngagement(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;
            int clientID = 0;

            if (json.TryGetProperty("tierID", out JsonElement clientElement) && clientElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(clientElement.GetString(), out clientID);
            }

            if (clientID == 0)
                return BadRequest("ClientID est requis.");

            var engagements = await _context.BankCommitmentsCharges
                .Where(e => e.ClientID == clientID)
                .ToListAsync();

            var engagements_ClientInfo = await _context.Client
                .Where(e => e.ClientID == clientID)
                .FirstOrDefaultAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = engagements,
                data_info = engagements_ClientInfo
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("saveEngagement")]
    public async Task<IActionResult> SaveEngagement(dynamic entity)
    {
        //try
        //{
        //    JsonElement json = (JsonElement)entity;
        //    int clientID = 0;
        //    if (json.TryGetProperty("tierID", out JsonElement clientElement) && clientElement.ValueKind == JsonValueKind.String)
        //    {
        //        int.TryParse(clientElement.GetString(), out clientID);
        //    }

        //    if (!json.TryGetProperty("engagement", out JsonElement engagementElement))
        //    {
        //        return BadRequest("Engagement manquant.");
        //    }

        //    var engagement = JsonSerializer.Deserialize<BankCommitmentsCharges>(engagementElement.ToString());

        //    if (clientID == 0 || engagement == null)
        //        return BadRequest("ClientID ou engagement invalide.");

        //    // Check for existing engagement
        //    var existing = await _context.BankCommitmentsCharges
        //        .FirstOrDefaultAsync(e => e.ClientID == clientID);

        //    if (existing != null)
        //    {
        //        // Update existing
        //        existing.NatureCommitmentID = engagement.NatureCommitmentID;
        //        existing.AgencyBankID = engagement.AgencyBankID;
        //        existing.OtherAgency = engagement.OtherAgency;
        //        existing.Maturity = engagement.Maturity;
        //        existing.Outstanding = engagement.Outstanding;
        //        existing.RepayableEarly = engagement.RepayableEarly;
        //    }
        //    else
        //    {
        //        // New engagement
        //        engagement.ClientID = clientID;
        //        _context.BankCommitmentsCharges.Add(engagement);
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok(new
        //    {
        //        status_code = 200,
        //        success = true,
        //        message = "Engagement enregistré avec succès."
        //    });
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Erreur : {ex.Message}");
        //    return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        //}



        JsonElement json = (JsonElement)entity;

        int clientID = 0;
        if (json.TryGetProperty("tierID", out JsonElement clientElement) && clientElement.ValueKind == JsonValueKind.String)
        {
            int.TryParse(clientElement.GetString(), out clientID);
        }

        if (clientID == 0)
            return BadRequest("ClientID manquant ou invalide.");

        try
        {
            // Deserialize infosBank list
            if (json.TryGetProperty("engagement", out JsonElement infosElement))
            {
                var infosBankList = JsonSerializer.Deserialize<List<BankCommitmentsCharges>>(infosElement.ToString());

                // Get existing records
                var existingInfos = await _context.BankCommitmentsCharges
                    .Where(i => i.ClientID == clientID)
                    .ToListAsync();

                // Update or add
                foreach (var info in infosBankList)
                {
                    if (info.BankCommitmentChargeID > 0)
                    {
                        var existing = existingInfos.FirstOrDefault(x => x.BankCommitmentChargeID == info.BankCommitmentChargeID);
                        if (existing != null)
                        {
                            existing.NatureCommitmentID = info.NatureCommitmentID;
                            existing.AgencyBankID = info.AgencyBankID;
                            existing.OtherAgency = info.OtherAgency;
                            existing.Maturity = info.Maturity;
                            existing.Outstanding = info.Outstanding;
                            existing.RepayableEarly = info.RepayableEarly;
                        }
                    }
                    else
                    {
                        info.ClientID = clientID;
                        _context.BankCommitmentsCharges.Add(info);
                    }
                }

                // Delete removed rows
                var updatedIds = infosBankList.Where(x => x.BankCommitmentChargeID > 0).Select(x => x.BankCommitmentChargeID).ToList();
                var toDelete = existingInfos.Where(x => !updatedIds.Contains(x.BankCommitmentChargeID)).ToList();
                _context.BankCommitmentsCharges.RemoveRange(toDelete);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    status_code = 200,
                    message = "Mise à jour effectuée avec succès"
                });
            }

            return BadRequest("Liste Engagement manquante.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("getPlanFinancement")]
    public async Task<IActionResult> GetPlanFinancement(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;
            int creditID = 0;

            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (creditID == 0)
                return BadRequest("dossierID est requis.");

            var lign = await _context.LignCreditProperty
                .FirstOrDefaultAsync(x => x.CreditID == creditID);

            var properties = await _context.Property
                .Where(p => p.CreditID == creditID)
                .ToListAsync();

            var CreditType = await _context.Credit
                .FirstOrDefaultAsync(x => x.CreditID == creditID);

            var result = new
            {
                typeCredit = CreditType?.CreditTypeID,
                objetCredit = lign?.ObjectCreditID,
                montantCredit = lign?.MontantCredit,
                dureeCredit = lign?.DureeCredit,
                frequenceRemboursement = lign?.FrequenceRemboursement,
                dureeFranchise = lign?.DureeFranchise,
                tauxCredit = lign?.TauxCredit,
                derogationSouhaitee = lign?.DerogationSouhaite,
                assurance = lign?.AssuranceDeczsInvalidite,
                commentCredit = lign?.CommentCredit,
                derogationSouhaiteeText = lign?.DerogationSouhaiteeText,
                honorairesFactures = lign?.honorairesFactures,
                biens = properties.Select(p => new
                {
                    nature = p.NaturePropertyID,
                    affectation = p.AssignmentPropertyID,
                    usage = p.UsePropertyID,
                    etat = p.ConditionPropertyID,
                    adresse = p.Adress,
                    propertyArea = p.PropertyArea,
                    titreFoncier = p.LandTitle,
                    prixVente = p.SalePriceProperty,
                    valeurReelle = p.RealValueProperty,
                    montantTravaux = p.AmountWork
                }).ToList()
            };

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = new[] { result }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("getAllPlanFinancementForPrint")]
    public async Task<IActionResult> getAllPlanFinancementForPrint(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;
            int creditID = 0;

            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (creditID == 0)
                return BadRequest("dossierID est requis.");


            var credit = await _context.Credit
                .Select(
                    g => new
                    {
                        g.CreditID,
                        g.Matricule,
                        g.CreditType.TypeLabel,
                        g.amount
                    }
                )
                .FirstOrDefaultAsync(x => x.CreditID == creditID);

            var clients = await _context.LignCreditClient
                .Select(
                    g => new
                    {
                        g.CreditID,
                        client = g.Client,
                        is_principal = g.IsPrincipal,
                        percentageClient = g.PercentageClient,
                        g.Client.ClientID,
                        g.Client.CIN,
                        g.Client.LastName,
                        g.Client.FirstName,
                        nomPrenom = g.Client.LastName + " " + g.Client.FirstName,
                        is_complete = false,
                        tier_interv = 20,
                        role = g.Client.Role.RoleLabel,
                        tel = g.Client.MobilePhone,
                        civilite = g.Client.ClientTitle.ClientTitleLabel,
                        dateNaissance = g.Client.BirthDate,
                        nationalite = g.Client.Nationality,
                        identite = g.Client.ClientIdentity.IdentityLabel,
                        adresse = g.Client.Address,
                        ville = g.Client.City,
                        pays = g.Client.Country.ClientCountryLabel,
                        paysResidence = g.Client.ResidenceCountry.ClientCountryLabel,
                        situationFamiliale = "Celibataire",
                        telephoneMobile = g.Client.MobilePhone,
                        telephoneFixe = g.Client.LandlinePhone,
                        telephoneProfessionnel = g.Client.WorkPhone,
                        email = g.Client.Email,
                        statut = g.Client.MaritalStatus.MaritalStatusLabel,
                        statutOccupation = "Locataire",
                        provenanceClient = "Agence immobilière",
                        origin = g.Client.Origin.OriginLabel,
                        montantSollicite = "500,000 MAD",
                        // New fields
                        Profession = g.Client.Profession,
                        Nature_activity = g.Client.Nature_activity,
                        IfOrTp = g.Client.IfOrTp,
                        Adress_activity = g.Client.Adress_activity,
                        Honoraires = g.Client.Honoraires,
                        Date_debut_exercice = g.Client.Date_debut_exercice,
                        Fonction = g.Client.Fonction,
                        Employeur = g.Client.Employeur,
                        Date_Embauche = g.Client.Date_Embauche,
                        Salaire = g.Client.Salaire,
                        NRC = g.Client.NRC,
                        Date_Creation_RC = g.Client.Date_Creation_RC,
                        Revenu = g.Client.Revenu,
                        Denomination = g.Client.Denomination,
                        Date_Creation_Company = g.Client.Date_Creation_Company,
                        ActivityCompany = g.Client.ActivityCompany,
                        Capital_Social = g.Client.Capital_Social,
                        ResultatYearN = g.Client.ResultatYearN,
                        ChiffreAffaireYearN = g.Client.ChiffreAffaireYearN,
                        ResultatYearN_1 = g.Client.ResultatYearN_1,
                        ChiffreAffaireYearN_1 = g.Client.ChiffreAffaireYearN_1,
                        PartsParticipationSociete = g.Client.PartsParticipationSociete,
                        Nature_Bail = g.Client.Nature_Bail,
                        Rent = g.Client.Rent,
                        pensions = _context.Pensionnaire
                            .Where(p => p.ClientID == g.ClientID)
                            .Select(p => new
                            {
                                p.Id,
                                p.NaturePension,
                                p.OrganismePension,
                                p.TypePension,
                                p.Montant
                            })
                            .ToList()
                    }
                )
                .Where(p => p.CreditID == creditID)
                .ToListAsync();

            var lign = await _context.LignCreditProperty
                .FirstOrDefaultAsync(x => x.CreditID == creditID);

            var properties = await _context.Property
                .Where(p => p.CreditID == creditID)
                .ToListAsync();

            var garantie = await _context.GarantieCredit
                .Where(p => p.CreditID == creditID)
                .ToListAsync();

            var result = new
            {
                credit = credit,
                clients = clients,
                objetCredit = lign?.ObjectCreditID,
                montantCredit = lign?.MontantCredit,
                dureeCredit = lign?.DureeCredit,
                frequenceRemboursement = lign?.FrequenceRemboursement,
                dureeFranchise = lign?.DureeFranchise,
                tauxCredit = lign?.TauxCredit,
                derogationSouhaitee = lign?.DerogationSouhaite,
                assurance = lign?.AssuranceDeczsInvalidite,
                commentCredit = lign?.CommentCredit,
                derogationSouhaiteeText = lign?.DerogationSouhaiteeText,
                honorairesFactures = lign?.honorairesFactures,
                biens = properties.Select(p => new
                {
                    nature = p.NaturePropertyID,
                    affectation = p.AssignmentPropertyID,
                    usage = p.UsePropertyID,
                    etat = p.ConditionPropertyID,
                    adresse = p.Adress,
                    propertyArea = p.PropertyArea,
                    titreFoncier = p.LandTitle,
                    prixVente = p.SalePriceProperty,
                    valeurReelle = p.RealValueProperty,
                    montantTravaux = p.AmountWork
                }).ToList(),
                garantie = garantie
            };

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = new[] { result }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("savePlanFinancement")]
    public async Task<IActionResult> SavePlanFinancement(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;

            int creditID = 0;
            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (!json.TryGetProperty("planFinancement", out JsonElement planElement))
                return BadRequest("planFinancement manquant.");

            if (creditID == 0)
                return BadRequest("dossierID est requis.");

            // Get objetCredit
            int? objetCreditID = null;
            if (planElement.TryGetProperty("objetCredit", out JsonElement objCreditEl) && objCreditEl.ValueKind == JsonValueKind.Number)
            {
                objetCreditID = objCreditEl.GetInt32();
            }

            // Save or update LignCreditProperty
            var lign = await _context.LignCreditProperty
                .FirstOrDefaultAsync(x => x.CreditID == creditID);

            if (lign == null)
            {
                lign = new LignCreditProperty { CreditID = creditID };
                _context.LignCreditProperty.Add(lign);
            }

            lign.ObjectCreditID = objetCreditID;

            if (planElement.TryGetProperty("montantCredit", out JsonElement mcEl) && mcEl.ValueKind == JsonValueKind.Number)
                lign.MontantCredit = mcEl.GetDecimal();

            if (planElement.TryGetProperty("dureeCredit", out JsonElement dcEl) && dcEl.ValueKind == JsonValueKind.Number)
                lign.DureeCredit = dcEl.GetDecimal();

            if (planElement.TryGetProperty("frequenceRemboursement", out JsonElement frEl) && frEl.ValueKind == JsonValueKind.Number)
                lign.FrequenceRemboursement = frEl.GetInt32();

            if (planElement.TryGetProperty("dureeFranchise", out JsonElement dfEl) && dfEl.ValueKind == JsonValueKind.Number)
                lign.DureeFranchise = dfEl.GetDecimal();

            if (planElement.TryGetProperty("tauxCredit", out JsonElement tcEl) && tcEl.ValueKind == JsonValueKind.Number)
                lign.TauxCredit = tcEl.GetDecimal();

            if (planElement.TryGetProperty("derogationSouhaitee", out JsonElement dsEl) && dsEl.ValueKind == JsonValueKind.True || dsEl.ValueKind == JsonValueKind.False)
                lign.DerogationSouhaite = dsEl.GetBoolean();

            if (planElement.TryGetProperty("assurance", out JsonElement assEl) && assEl.ValueKind == JsonValueKind.Number)
                lign.AssuranceDeczsInvalidite = assEl.GetInt32();

            if (planElement.TryGetProperty("honorairesFactures", out JsonElement ore) && ore.ValueKind == JsonValueKind.Number)
                lign.honorairesFactures = ore.GetDecimal();

            lign.CommentCredit = planElement.TryGetProperty("commentCredit", out JsonElement toto) && toto.ValueKind == JsonValueKind.String ? toto.GetString() : null;

            lign.DerogationSouhaiteeText = planElement.TryGetProperty("derogationSouhaiteeText", out JsonElement dsElText) && dsElText.ValueKind == JsonValueKind.String ? dsElText.GetString() : null;

            // Remove old Properties
            var oldProps = await _context.Property
                .Where(p => p.CreditID == creditID)
                .ToListAsync();
            _context.Property.RemoveRange(oldProps);

            // Insert new properties
            if (planElement.TryGetProperty("biens", out JsonElement biensElement) && biensElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement bien in biensElement.EnumerateArray())
                {
                    var newProp = new Property
                    {
                        CreditID = creditID,
                        NaturePropertyID = bien.TryGetProperty("nature", out JsonElement natEl) && natEl.ValueKind == JsonValueKind.Number ? natEl.GetInt32() : (int?)null,
                        AssignmentPropertyID = bien.TryGetProperty("affectation", out JsonElement affEl) && affEl.ValueKind == JsonValueKind.Number ? affEl.GetInt32() : (int?)null,
                        UsePropertyID = bien.TryGetProperty("usage", out JsonElement useEl) && useEl.ValueKind == JsonValueKind.Number ? useEl.GetInt32() : (int?)null,
                        ConditionPropertyID = bien.TryGetProperty("etat", out JsonElement etatEl) && etatEl.ValueKind == JsonValueKind.Number ? etatEl.GetInt32() : (int?)null,
                        Adress = bien.TryGetProperty("adresse", out JsonElement adrEl) && adrEl.ValueKind == JsonValueKind.String ? adrEl.GetString() : null,
                        PropertyArea = bien.TryGetProperty("propertyArea", out JsonElement supEl) && supEl.ValueKind == JsonValueKind.String ? supEl.GetString() : null,
                        LandTitle = bien.TryGetProperty("titreFoncier", out JsonElement tfEl) && tfEl.ValueKind == JsonValueKind.String ? tfEl.GetString() : null,
                        SalePriceProperty = bien.TryGetProperty("prixVente", out JsonElement pvEl) && pvEl.ValueKind == JsonValueKind.Number ? pvEl.GetDecimal() : (decimal?)null,
                        RealValueProperty = bien.TryGetProperty("valeurReelle", out JsonElement vrEl) && vrEl.ValueKind == JsonValueKind.Number ? vrEl.GetDecimal() : (decimal?)null,
                        AmountWork = bien.TryGetProperty("montantTravaux", out JsonElement mtEl) && mtEl.ValueKind == JsonValueKind.Number ? mtEl.GetDecimal() : (decimal?)null
                    };

                    _context.Property.Add(newProp);
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                message = "Plan de financement enregistré avec succès."
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("getGarantie")]
    public async Task<IActionResult> GetGarantie(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;
            int creditID = 0;

            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (creditID == 0)
                return BadRequest("dossierID est requis.");

            var garanties = await _context.GarantieCredit
                .Where(g => g.CreditID == creditID)
                .ToListAsync();

            var result = garanties.Select(g => new
            {
                id = g.GarantieCreditID,
                name = g.Label
            }).ToList();

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = result
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("saveGarantie")]
    public async Task<IActionResult> SaveGarantie(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;

            int creditID = 0;
            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (!json.TryGetProperty("canauxVentes", out JsonElement garantiesElement) || garantiesElement.ValueKind != JsonValueKind.Array)
                return BadRequest("canauxVentes manquants.");

            // Remove existing garanties
            var oldGaranties = await _context.GarantieCredit
                .Where(g => g.CreditID == creditID)
                .ToListAsync();
            _context.GarantieCredit.RemoveRange(oldGaranties);

            // Add new ones
            foreach (var garantie in garantiesElement.EnumerateArray())
            {
                if (garantie.TryGetProperty("name", out JsonElement nameEl) && nameEl.ValueKind == JsonValueKind.String)
                {
                    var g = new GarantieCredit
                    {
                        CreditID = creditID,
                        Label = nameEl.GetString()
                    };
                    _context.GarantieCredit.Add(g);
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                message = "Garanties enregistrées avec succès."
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("getDepot")]
    public async Task<IActionResult> GetDepot(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;
            int creditID = 0;

            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (creditID == 0)
                return BadRequest("dossierID est requis.");

            var depots = await _context.CreditDepot
                .Where(d => d.id_credit == creditID)
                .ToListAsync();

            var result = depots.Select(d => new
            {
                banque = d.id_agency_bank,
                interlocuteur = d.interlocutor,
                agence = d.agence,
                dateEnvoi = d.date_sent
            }).ToList();

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = result
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("saveDepot")]
    public async Task<IActionResult> SaveDepot(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;

            int creditID = 0;
            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (!json.TryGetProperty("depots", out JsonElement depotsElement) || depotsElement.ValueKind != JsonValueKind.Array)
            {
                return BadRequest("Liste des dépôts manquante.");
            }

            // Delete existing deposits
            var oldDepots = await _context.CreditDepot
                .Where(d => d.id_credit == creditID)
                .ToListAsync();
            _context.CreditDepot.RemoveRange(oldDepots);

            // Add new deposits
            foreach (var depot in depotsElement.EnumerateArray())
            {
                var newDepot = new CreditDepot
                {
                    id_credit = creditID,
                    id_agency_bank = depot.TryGetProperty("banque", out var bankEl) && bankEl.ValueKind == JsonValueKind.Number ? bankEl.GetInt32() : 0,
                    interlocutor = depot.TryGetProperty("interlocuteur", out var intEl) && intEl.ValueKind == JsonValueKind.String ? intEl.GetString() : null,
                    agence = depot.TryGetProperty("agence", out var agEl) && agEl.ValueKind == JsonValueKind.String ? agEl.GetString() : null,
                    date_sent = depot.TryGetProperty("dateEnvoi", out var dateEl) && dateEl.ValueKind == JsonValueKind.String
                                ? DateTime.Parse(dateEl.GetString()!)
                                : (DateTime?)null,
                    created_at = DateTime.Now // optional
                };

                _context.CreditDepot.Add(newDepot);
            }

            await _context.SaveChangesAsync();

            // Save or update LignCreditProperty
            var lign = await _context.LignCreditProperty
                .FirstOrDefaultAsync(x => x.CreditID == creditID);

            if (lign == null)
            {
                lign = new LignCreditProperty { CreditID = creditID };
                _context.LignCreditProperty.Add(lign);
            }

            if (json.TryGetProperty("honorairesFactures", out JsonElement ore))
                lign.honorairesFactures = ore.GetDecimal();

            await _context.SaveChangesAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                message = "Dépôts enregistrés avec succès."
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }


    [HttpDelete("deleteClient/{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound(new { success = false, message = "Client not found." });
            }

            // Manually delete related records (if needed)
            var managers = await _context.ClientManager
                .Where(cm => cm.ClientID == id)
                .Include(cm => cm.ManagerInformation)
                .ToListAsync();

            foreach (var manager in managers)
            {
                if (manager.ManagerInformation != null)
                {
                    _context.ManagerInformation.Remove(manager.ManagerInformation);
                }
                _context.ClientManager.Remove(manager);
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Client deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    [HttpPost("getCreditTimeline")]
    public async Task<IActionResult> GetCreditTimeline(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;
            int creditID = 0;

            if (json.TryGetProperty("dossierID", out JsonElement creditElement) && creditElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(creditElement.GetString(), out creditID);
            }

            if (creditID == 0)
                return BadRequest("dossierID est requis.");

            var depot = await _context.CreditDepot
                .Where(d => d.id_credit == creditID)
                .OrderBy(d => d.created_at)
                .FirstOrDefaultAsync();

            var timeline = new List<object>();

            if (depot != null)
            {
                timeline.Add(new
                {
                    statusID = 1,
                    statusDB = 0,
                    status = "Dépôt créé",
                    date = depot.created_at?.ToString("dd/MM/yyyy HH:mm"),
                    icon = "pi pi-play",
                    color = "#8ecae6",
                    is_accord = 0,
                    @return = ""
                });

                timeline.Add(new
                {
                    statusID = 2,
                    statusDB = 0,
                    status = "Envoyer à la banque",
                    date = depot.date_sent?.ToString("dd/MM/yyyy HH:mm"),
                    icon = "pi pi-send",
                    color = "#219ebc",
                    is_accord = 1,
                    @return = ""
                });
            }

            var statuses = await _context.CreditStatus
                .Where(s => s.id_credit == creditID)
                .OrderBy(s => s.created_at)
                .ToListAsync();

            foreach (var s in statuses)
            {
                string icon = s.status switch
                {
                    2 => "pi pi-cog",
                    3 => "pi pi-gift",
                    4 => "pi pi-gift",
                    5 => "pi pi-gift",
                    6 => "pi pi-user-edit",
                    7 => "pi pi-spinner",
                    8 => "pi pi-user-edit",
                    9 => "pi pi-check",
                    _ => "pi pi-question"
                };

                string color = s.status switch
                {
                    2 => "#FF9800", // En étude bancaire
                    3 => "#e63946", // Refus
                    4 => "#023e8a", // Accord
                    5 => "#023e8a", // Accordé sous condition
                    6 => "#2dc653", // Rép client
                    7 => "#FF9800", // En attente client
                    8 => "#2dc653",
                    9 => "#607D8B", // Livré
                    _ => "#90A4AE"
                };

                timeline.Add(new
                {
                    statusID = s.status,
                    statusDB = s.CreditStatusID,
                    status = GetStatusLabel(s.status),
                    date = s.created_at?.ToString("dd/MM/yyyy HH:mm"),
                    icon = icon,
                    color = color,
                    is_accord = s.is_accord,
                    is_accord_client = s.is_accord_client,
                    @return = s.message
                });
            }

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = timeline
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    private string GetStatusLabel(int? status)
    {
        return status switch
        {
            3 => "Envoyer à la banque",
            4 => "En étude bancaire",
            5 => "Réponse de la banque",
            9 => "En attente de la réponse du client",
            10 => "Réponse du client",
            11 => "Livré",
            _ => "Statut inconnu"
        };
    }

    [HttpPost("saveCreditStatus")]
    public async Task<IActionResult> SaveCreditStatus(dynamic entity)
    {
        try
        {
            JsonElement json = (JsonElement)entity;

            int creditID = 0;
            int depotID = 0;

            if (json.TryGetProperty("id_credit", out JsonElement idCreditEl) && idCreditEl.ValueKind == JsonValueKind.Number)
                creditID = idCreditEl.GetInt32();

            if (json.TryGetProperty("id_depot", out JsonElement idDepotEl) && idDepotEl.ValueKind == JsonValueKind.Number)
                depotID = idDepotEl.GetInt32();

            int? status = null;
            int? is_accord = null;
            int? is_accord_client = null;
            string? message = null;

            if (json.TryGetProperty("status", out JsonElement statusEl) && statusEl.ValueKind == JsonValueKind.Number)
                status = statusEl.GetInt32();

            if (json.TryGetProperty("is_accord", out JsonElement akkan) && akkan.ValueKind == JsonValueKind.Number)
                is_accord = akkan.GetInt32();

            if (json.TryGetProperty("is_accord_client", out JsonElement cfc) && cfc.ValueKind == JsonValueKind.Number)
                is_accord_client = cfc.GetInt32();

            if (json.TryGetProperty("message", out JsonElement msgEl) && msgEl.ValueKind == JsonValueKind.String)
                message = msgEl.GetString();

            if (creditID == 0 || depotID == 0 || status == null)
                return BadRequest("Informations manquantes pour l'enregistrement du statut.");

            var creditStatus = new CreditStatus
            {
                id_credit = creditID,
                id_depot = depotID,
                is_accord = is_accord,
                is_accord_client = is_accord_client,
                status = status,
                message = message,
                created_at = DateTime.Now
            };

            _context.CreditStatus.Add(creditStatus);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                message = "Statut ajouté avec succès."
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur serveur : {ex.Message}");
        }
    }

    [HttpPost("getDossiersByDepots")]
    public async Task<IActionResult> getDossiersByDepots()
    {
        try
        {
            var depots = await (
                from depot in _context.CreditDepot
                join credit in _context.Credit on depot.id_credit equals credit.CreditID
                join client in _context.Client on credit.Matricule equals client.Matricule into clientJoin
                from client in clientJoin.DefaultIfEmpty()
                join type in _context.CreditType on credit.CreditTypeID equals type.TypeID into typeJoin
                from type in typeJoin.DefaultIfEmpty()
                join bank in _context.AgencyBank on depot.id_agency_bank equals bank.AgencyBankID into bankJoin
                from bank in bankJoin.DefaultIfEmpty()

                select new
                {
                    depotId = depot.CreditDepotId,
                    depotDate = depot.created_at,
                    creditId = credit.CreditID,
                    creditMatricule = credit.Matricule,
                    creditAmount = credit.amount ?? 0,
                    clientFullName = client.FirstName + " " + client.LastName,
                    typeLabel = type != null ? type.TypeLabel : "Type inconnu",
                    banqueLabel = bank != null ? bank.AgencyBankLabel : "Banque inconnue",
                    companyName = client.CompanyName,
                    is_organisation = client.is_organisation
                }
            ).ToListAsync();

            var result = new List<object>();

            foreach (var d in depots)
            {
                // Get latest status for this specific depot
                var lastStatus = await _context.CreditStatus
                    .Where(cs => cs.id_depot == d.depotId)
                    .OrderByDescending(cs => cs.created_at)
                    .Select(cs => cs.status)
                    .FirstOrDefaultAsync();

                string statusLabel = lastStatus switch
                {
                    2 => "En étude bancaire",
                    3 => "Refusé",
                    4 => "Accordé",
                    5 => "Accordé sous condition",
                    6 => "Réponse client",
                    7 => "En attente client",
                    8 => "Refus client",
                    9 => "Livré",
                    _ => "Dépôt créé"
                };

                int progression = lastStatus switch
                {
                    4 or 9 => 100,
                    2 => 50,
                    3 or 5 or 6 or 7 or 8 => 75,
                    _ => 10
                };

                result.Add(new
                {
                    id = d.creditMatricule,
                    creditId = d.creditId,
                    depotId = d.depotId,
                    client = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == d.creditId).Select(s => s.Client.FirstName + " " + s.Client.LastName).FirstOrDefault(),
                    type = d.typeLabel,
                    montant = d.creditAmount,
                    statut = statusLabel,
                    dateCreation = d.depotDate,
                    conseiller = (string?)null,
                    banque = d.banqueLabel,
                    progression = progression,
                    companyName = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == d.creditId).Select(s => s.Client.CompanyName).FirstOrDefault(),
                    is_organisation = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == d.creditId).Select(s => s.Client.is_organisation).FirstOrDefault(),
                    panelMenuItems = new List<string>() // you can build dynamically if needed
                });
            }

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = result
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur : " + ex.Message);
            return StatusCode(500, new { message = "Erreur serveur", detail = ex.Message });
        }
    }

    //public async Task<DataOutput> editEventCalendar(object record, int user_id)
    //{
    //    // On déclare les variables
    //    DataOutput data_output = new DataOutput();
    //    CheckRoleHelper checkrolehelper = new CheckRoleHelper(_context);
    //    UploadHelper upload_helper = new UploadHelper(_context);
    //    NotificationHelper notificationHelper = new NotificationHelper(_context);

    //    dynamic body = "";
    //    int id_user = 0;
    //    int id_event = 0;

    //    List<object> echec_user = new List<object>();
    //    List<object> echec_event = new List<object>();

    //    try
    //    {
    //        // On vérifie que record est plein
    //        if (record == null || record.ToString().Length == 0)
    //        {
    //            // On définit le retour avec le détail de l'erreur
    //            data_output.status_code = CodeReponse.error_missing_all_params;
    //            data_output.message = MessageResponse.error_missing_all_params;
    //        }
    //        else
    //        {
    //            // On récupère les données envoyées dans le body
    //            body = JObject.Parse(record.ToString());

    //            // On valide l'existence de l'ensemble des champs attendus dans le body
    //            if (!ValidationHelper.is_valid_add_event(body))
    //            {
    //                // On définit le résultat à retourner
    //                data_output.status_code = CodeReponse.error_invalid_missing_params;
    //                data_output.message = MessageResponse.error_invalid_missing_params;
    //            }
    //            else
    //            {
    //                // On extrait l'identifiant de l'utilisateur
    //                id_user = user_id != 0 ? user_id : CryptageHelper.get_id((string)body.id_user);

    //                // On extrait l'identifiant de l'événement
    //                id_event = CryptageHelper.get_id((string)body.id_event);

    //                // On extrait l'identifiant de la campagne
    //                id_campaign = CryptageHelper.get_id((string)body.id_campaign);

    //                id_organization = await _context.UserOrganization
    //                    .Where(b => b.id_user == id_user && b.organization.is_verif && b.accepted == true && b.deleted_at == null)
    //                    .Select(s => s.id_organization)
    //                    .FirstOrDefaultAsync();

    //                // On extrait le nom de la campagne
    //                campaign_name = (string)body.campaign_name;

    //                // On valide l'existence de la liaison entre l'utilisateur et l'organisation
    //                if (!await checkrolehelper.is_valid_user_company(id_user, id_organization))
    //                {
    //                    // On définit le résultat à retourner
    //                    data_output.status_code = CodeReponse.bad_request;
    //                    data_output.message = MessageResponse.bad_request;
    //                }
    //                else
    //                {
    //                    // On recherche l'événement
    //                    var _event = await _context.Event.Where(c => c.id == id_event).FirstOrDefaultAsync();

    //                    if (_event != null)
    //                    {
    //                        _event.name = body.name;
    //                        _event.description = body.description;
    //                        _event.start_date = (DateTime)body.start_date;
    //                        _event.end_date = (DateTime)body.end_date;
    //                        _event.is_all_day = (bool)body.is_all_day;
    //                        _event.is_public = (bool)body.is_public;
    //                        _event.id_category_event = body.id_category;
    //                        _event.id_type = body.id_type;

    //                        if (body.meet_link != null && body.meet_link.ToString().Length > 0)
    //                        {
    //                            _event.meet_link = body.meet_link;
    //                        }

    //                        if (body.location_address != null && body.location_address.ToString().Length > 0)
    //                        {
    //                            _event.location_address = body.location_address;
    //                        }

    //                        // On sauvegarde les données
    //                        await _context.SaveChangesAsync();

    //                        var user = await _context.User.FindAsync(user_id);
    //                        if (user == null)
    //                        {
    //                            data_output.status_code = CodeReponse.bad_request;
    //                            data_output.message = "User not found.";
    //                            return data_output;
    //                        }

    //                        bool isGoogleSyncEnabled = user.allow_async_calendar;
    //                        var refreshToken = user.token_google_calendar;


    //                        if (isGoogleSyncEnabled)
    //                        {
    //                            try
    //                            {
    //                                // Retrieve access token
    //                                var accessToken = await GetAccessToken(refreshToken);
    //                                if (string.IsNullOrEmpty(accessToken))
    //                                {
    //                                    data_output.message = "Error: Failed to retrieve a valid access token.";
    //                                    return data_output;
    //                                }

    //                                // Prepare event data for Google Calendar
    //                                var googleEventData = new Dictionary<string, object>
    //                                        {
    //                                            { "summary", _event.name },
    //                                            { "start", new Dictionary<string, object> { { "dateTime", _event.start_date.ToString("yyyy-MM-ddTHH:mm:ssZ") }, { "timeZone", "Africa/Casablanca" } } },
    //                                            { "end", new Dictionary<string, object> { { "dateTime", _event.end_date.ToString("yyyy-MM-ddTHH:mm:ssZ") }, { "timeZone", "Africa/Casablanca" } } }
    //                                        };

    //                                // Sync the event with Google Calendar
    //                                await UpdateEventInGoogleCalendar(_event.hash_calendar, googleEventData, accessToken);
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                data_output.message = "Event updated in database, but failed to sync with Google Calendar.";
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Debug.WriteLine("Google sync is disabled. Event updated only in the database.");
    //                        }



    //                        var guests = new List<Object>();

    //                        // On boucle sur les experts
    //                        foreach (var e in body.experts)
    //                        {
    //                            int id_expert = 0;
    //                            id_expert = CryptageHelper.get_id((string)e.id);
    //                            bool is_required = (bool)e.required;

    //                            if ((bool)e.deleted)
    //                            {
    //                                var exists = await _context.EventUserCampaign
    //                                    .Where(b => b.id_event == id_event && b.is_required == is_required && b.id_user == id_expert && b.deleted_at == null)
    //                                    .FirstOrDefaultAsync();

    //                                if (exists != null)
    //                                {
    //                                    exists.deleted_at = DateTime.UtcNow;
    //                                    exists.deleted_by = id_user.ToString();
    //                                }
    //                            }
    //                            else
    //                            {
    //                                var exists = await _context.EventUserCampaign
    //                                    .AnyAsync(b => b.id_event == id_event && b.is_required == is_required && b.id_user == id_expert && b.deleted_at == null);

    //                                if (!exists)
    //                                {
    //                                    var existUserEvaluator = await _context.CampaignEvaluator.AnyAsync(b => b.id_user == id_expert && b.id_campaign == id_campaign && b.deleted_at == null);

    //                                    var existUser = await _context.User.AnyAsync(b => b.id == id_expert && !b.blocked && (b.is_expert || existUserEvaluator) && b.deleted_at == null);

    //                                    if (existUser)
    //                                    {
    //                                        // On initialise l'entité
    //                                        EventUserCampaign event_user_campaign = new EventUserCampaign
    //                                        {
    //                                            id_event = _event.id,
    //                                            id_campaign = id_campaign,
    //                                            id_user = id_expert,
    //                                            id_role = (int?)RoleId.expert,
    //                                            is_required = e.required
    //                                        };

    //                                        // On ajoute l'entité
    //                                        await _context.EventUserCampaign.AddAsync(event_user_campaign);

    //                                        // On sauvegarde les données
    //                                        await _context.SaveChangesAsync();

    //                                        guests.Add(e);
    //                                    }
    //                                    else
    //                                    {
    //                                        // On définit le résultat à retourner
    //                                        data_output.status_code = CodeReponse.bad_request;
    //                                        data_output.message = MessageResponse.bad_request;
    //                                    }
    //                                }
    //                            }
    //                        }

    //                        // On boucle sur les participants
    //                        foreach (var e in body.participants)
    //                        {
    //                            int id_participant = 0;
    //                            id_participant = CryptageHelper.get_id((string)e.id);
    //                            e.id = id_participant;
    //                            bool is_required = (bool)e.required;

    //                            if ((bool)e.deleted)
    //                            {
    //                                var exists = await _context.EventUserCampaign
    //                                    .Where(b => b.id_event == id_event && b.is_required == is_required && b.id_user == id_participant && b.deleted_at == null)
    //                                    .FirstOrDefaultAsync();

    //                                if (exists != null)
    //                                {
    //                                    exists.deleted_at = DateTime.UtcNow;
    //                                    exists.deleted_by = id_user.ToString();
    //                                }
    //                            }
    //                            else
    //                            {
    //                                //if (await checkrolehelper.is_valid_user_company(id_participant, id_organization))
    //                                //{
    //                                var exists = await _context.EventUserCampaign
    //                                    .Where(b => b.id_event == id_event && b.is_required == is_required && b.id_user == id_participant)
    //                                    .FirstOrDefaultAsync();

    //                                if (exists == null)
    //                                {
    //                                    // On initialise l'entité
    //                                    EventUserCampaign event_user_campaign = new EventUserCampaign
    //                                    {
    //                                        id_event = _event.id,
    //                                        id_campaign = id_campaign,
    //                                        id_user = id_participant,
    //                                        id_role = (int?)RoleId.membre_orga,
    //                                        is_required = e.required
    //                                    };

    //                                    // On ajoute l'entité
    //                                    await _context.EventUserCampaign.AddAsync(event_user_campaign);

    //                                    // On sauvegarde les données
    //                                    await _context.SaveChangesAsync();

    //                                    guests.Add(e);
    //                                }
    //                                else
    //                                {
    //                                    exists.deleted_at = null;
    //                                    exists.deleted_by = null;
    //                                }
    //                                //}
    //                                //else
    //                                //{
    //                                //    // On définit le résultat à retourner
    //                                //    data_output.status_code = CodeReponse.bad_request;
    //                                //    data_output.message = MessageResponse.bad_request;
    //                                //}
    //                            }
    //                        }

    //                        // On sauvegarde les données
    //                        await _context.SaveChangesAsync();

    //                        // On envoie un email aux invités
    //                        var notification_body = new
    //                        {
    //                            guests = guests,
    //                            id_invitation = CommModelCode.InvToCampaignEvent,
    //                            id_user = id_user,
    //                            id_campaign = id_campaign,
    //                            campaign_name = campaign_name,
    //                            event_name = body.name,
    //                            id_event = _event.id
    //                        };

    //                        var output = await notificationHelper.campaign_send(notification_body);

    //                        var exist_event = await _context.Event
    //                       .Where(b => b.id == _event.id && b.deleted_at == null).Select(x => x.name)
    //                       .FirstOrDefaultAsync();

    //                        if (body.po != null)
    //                        {

    //                            var pos = new List<Object>();

    //                            // On boucle sur les porteurs de projets
    //                            foreach (var user_po in body.po)
    //                            {
    //                                // On extrait l'identifiant du porteur de projets
    //                                var id_po = CryptageHelper.get_id((string)user_po);

    //                                var exist_po = await _context.CampaignProject.AnyAsync(b => b.id_po == id_po && b.deleted_at == null && b.po.is_project_owner);
    //                                var exist_po_in_event = await _context.EventUserCampaign.AnyAsync(b => b.id_user == id_po && b.deleted_at == null && b.id_event == id_event);

    //                                var po = await _context.User
    //                                    .Where(b => b.id == id_po && b.deleted_at == null)
    //                                    .Select(x => new
    //                                    {
    //                                        id = x.id,
    //                                        full_name = x.first_name + " " + x.last_name,
    //                                        email = x.email,
    //                                        username = x.username
    //                                    })
    //                                    .FirstOrDefaultAsync();

    //                                if (exist_po && !exist_po_in_event)
    //                                {
    //                                    EventUserCampaign event_user_campaign = new EventUserCampaign
    //                                    {
    //                                        id_event = id_event,
    //                                        id_campaign = id_campaign,
    //                                        id_user = id_po,
    //                                        id_role = (int)RoleId.project_owner
    //                                    };

    //                                    // On ajoute l'entité
    //                                    await _context.EventUserCampaign.AddAsync(event_user_campaign);

    //                                    // On sauvegarde les données
    //                                    await _context.SaveChangesAsync();

    //                                    pos.Add(po);
    //                                }
    //                                else
    //                                {
    //                                    if (!exist_po)
    //                                    {
    //                                        echec_user.Add(new { name_event = exist_event, name_po = po.full_name, message = "PO Not Found" });
    //                                    }
    //                                    if (exist_po_in_event)
    //                                    {
    //                                        echec_user.Add(new { name_event = exist_event, name_po = po.full_name, message = "Project Already exist in event" });
    //                                    }
    //                                }
    //                            }

    //                            // On envoie un email aux invités
    //                            var notification_body_ = new
    //                            {
    //                                guests = pos,
    //                                id_invitation = CommModelCode.InvToCampaignEvent,
    //                                id_user = id_user,
    //                                id_campaign = id_campaign,
    //                                campaign_name = campaign_name,
    //                                event_name = exist_event,
    //                                id_event = id_event
    //                            };

    //                            var output_ = await notificationHelper.campaign_send(notification_body_);
    //                        }

    //                        //object resultat = new { echec_user = echec_user };


    //                        // On définit le résultat à retourner
    //                        data_output.status_code = CodeReponse.ok;
    //                        data_output.message = MessageResponse.ok;
    //                        data_output.data = new List<object> { CryptageHelper.set_id(_event.id) };
    //                    }
    //                    else
    //                    {
    //                        // On définit le retour avec le détail de l'erreur
    //                        data_output.status_code = CodeReponse.not_found;
    //                        data_output.message = MessageResponse.not_found;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        // On définit le retour avec le détail de l'erreur
    //        data_output.status_code = CodeReponse.error;
    //        data_output.message = (e.InnerException == null) ? e.Message : e.InnerException.Message;

    //        // On log l'erreur
    //        await new Log(e, this.GetType().Name, MethodBase.GetCurrentMethod().ReflectedType.Name).log_exception(_context);
    //    }
    //    finally
    //    {

    //    }

    //    // On retourne le résultat
    //    return data_output;
    //}





}