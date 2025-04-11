using credirect_api.Data;
using credirect_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[EnableCors("AllowSpecificOrigins")]
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
    [HttpGet("getAllClient")]
    public async Task<dynamic> GetAllClient()
    {
        var entity = await _context.Client.Select(t => new { t.LastName, t.FirstName, t.Matricule } ).AsNoTracking().ToListAsync();
        if (entity == null)
        {
            return NotFound();
        }
        return entity;
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
                // Create new client
                var newClient = new Client
                {
                    //ClientID = 1010,
                    Matricule = entity.Matricule,
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
                    ResidenceCountry = entity.ResidenceCountry,
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
        existingClient.Matricule = newClientData.Matricule;
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
        existingClient.ResidenceCountry = newClientData.ResidenceCountry;
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
                Id_ManagerMaritalStatus = managerInformation.Id_ManagerMaritalStatus
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

            _context.ManagerInformation.Update(existingManagerInfo);
            await _context.SaveChangesAsync();
            return existingManagerInfo;
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

}