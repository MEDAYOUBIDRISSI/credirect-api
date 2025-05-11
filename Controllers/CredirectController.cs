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
            var Tier = await _context.Client.Where(b => b.CIN == CIN).Select(s => new
            {
                s.ClientID,
                s.CIN,
                s.LastName,
                s.FirstName,
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
                montantSollicite = "500,000 MAD"
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
                is_complete = false,
                tier_interv = 20,
                role = s.Client.Role.RoleLabel,
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
                CreditTypeLabel = s.Credit.CreditType.TypeLabel

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
                montantSollicite = "500,000 MAD"

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
        var folders = await _context.Credit.Select(s => new
        {
            idDossier = s.CreditID,
            id = s.Matricule,
            client = _context.LignCreditClient.AsNoTracking().Where(b => b.CreditID == s.CreditID).Select(s => s.Client.FirstName + " " + s.Client.LastName).FirstOrDefault(),
            type= s.CreditType.TypeLabel,
            montant= s.amount,
            statut = "Refusé",
            dateCreation = "2023-10-25",
            conseiller = "Youssef Benali",
            banque = "Société Générale Maroc",
            progression= 100

        }).ToListAsync();

        return Ok(new
        {
            success = true,
            status_code = 200,
            data = folders
        });
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



}