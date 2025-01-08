using credirect_api.Data;
using credirect_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CredirectController : ControllerBase
{
    private readonly StudentContext _context;

    public CredirectController(StudentContext context)
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
}