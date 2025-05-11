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

            return Ok(new
            {
                status_code = 200,
                success = true,
                data = engagements
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
        try
        {
            JsonElement json = (JsonElement)entity;

            int clientID = 0;
            if (json.TryGetProperty("tierID", out JsonElement clientElement) && clientElement.ValueKind == JsonValueKind.String)
            {
                int.TryParse(clientElement.GetString(), out clientID);
            }

            if (!json.TryGetProperty("engagement", out JsonElement engagementElement))
            {
                return BadRequest("Engagement manquant.");
            }

            var engagement = JsonSerializer.Deserialize<BankCommitmentsCharges>(engagementElement.ToString());

            if (clientID == 0 || engagement == null)
                return BadRequest("ClientID ou engagement invalide.");

            // Check for existing engagement
            var existing = await _context.BankCommitmentsCharges
                .FirstOrDefaultAsync(e => e.ClientID == clientID);

            if (existing != null)
            {
                // Update existing
                existing.NatureCommitmentID = engagement.NatureCommitmentID;
                existing.AgencyBankID = engagement.AgencyBankID;
                existing.OtherAgency = engagement.OtherAgency;
                existing.Maturity = engagement.Maturity;
                existing.Outstanding = engagement.Outstanding;
                existing.RepayableEarly = engagement.RepayableEarly;
            }
            else
            {
                // New engagement
                engagement.ClientID = clientID;
                _context.BankCommitmentsCharges.Add(engagement);
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                status_code = 200,
                success = true,
                message = "Engagement enregistré avec succès."
            });
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

            var result = new
            {
                objetCredit = lign?.ObjectCreditID,
                montantCredit = lign?.MontantCredit,
                dureeCredit = lign?.DureeCredit,
                frequenceRemboursement = lign?.FrequenceRemboursement,
                dureeFranchise = lign?.DureeFranchise,
                tauxCredit = lign?.TauxCredit,
                derogationSouhaitee = lign?.DerogationSouhaite,
                assurance = lign?.AssuranceDeczsInvalidite,
                commentCredit = lign?.CommentCredit,
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

            lign.CommentCredit = planElement.TryGetProperty("commentCredit", out JsonElement toto) && toto.ValueKind == JsonValueKind.String ? toto.GetString() : null;
            
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