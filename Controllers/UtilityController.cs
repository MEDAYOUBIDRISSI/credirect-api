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
public class UtilityController : ControllerBase
{
    private readonly CredirectContext _context;

    public UtilityController(CredirectContext context)
    {
        _context = context;
    }

    /////////////////////////////////////////////////
    ///
    [HttpPost, Route("getAllCreditType"), Produces("application/json")]
    public async Task<IActionResult> getAllCreditType([FromBody] JsonElement fromFront)
    {
        var entity = await _context.CreditType
            .Select(t => new { code = t.TypeID, name = t.TypeLabel })
            .AsNoTracking()
            .ToListAsync();

        if (entity == null || !entity.Any())
        {
            return Ok(new
            {
                success = true,
                status_code = 401,
                message = "not found."
            });
        }

        return Ok(new
        {
            success = true,
            status_code = 200,
            message = "Type Credit found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

}