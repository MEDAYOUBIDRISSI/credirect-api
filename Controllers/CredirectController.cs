using credirect_api.Data;
using credirect_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
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
                .FirstOrDefaultAsync(x => x.ClientID == entity.ClientID);

            if (existingClient != null)
            {
                // Update existing client
                UpdateClient(existingClient, entity);
            }
            else
            {
                // Create new client
                var newClient = new Client
                {
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
                    MobilePhone = entity.MobilePhone,
                    LandlinePhone = entity.LandlinePhone,
                    WorkPhone = entity.WorkPhone,
                    Address = entity.Address,

                    ResidencyStatusID = entity.ResidencyStatusID,
                    RequestedAmount = entity.RequestedAmount,
                    
                };

                await _context.Client.AddAsync(newClient);
                await _context.SaveChangesAsync();
                return Ok(newClient.ClientID);
            }

            // Save changes for updates
            await _context.SaveChangesAsync();
            return Ok(existingClient.ClientID);
        }
        catch (Exception ex)
        {
            // Log exception (Assumes a logging mechanism is in place)
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }

    private void UpdateClient(Client existingClient, Client newClientData)
    {
        existingClient.LastName = newClientData.LastName;
        existingClient.FirstName = newClientData.FirstName;
        existingClient.Matricule = newClientData.Matricule;
        existingClient.BirthDate = newClientData.BirthDate;
        existingClient.ClientTitleID = newClientData.ClientTitleID;
        existingClient.Email = newClientData.Email;
        existingClient.Nationality = newClientData.Nationality;
        existingClient.IdentityID = newClientData.IdentityID;
    }

}