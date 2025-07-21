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

    [HttpPost, Route("getAllBanks"), Produces("application/json")]
    public async Task<IActionResult> getAllBanks([FromBody] JsonElement fromFront)
    {
        var entity = await _context.AgencyBank
            .Select(t => new { label = t.AgencyBankLabel, value = t.AgencyBankID })
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
            message = "Banks found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

    [HttpPost, Route("getAllRoles"), Produces("application/json")]
    public async Task<IActionResult> getAllRoles([FromBody] JsonElement fromFront)
    {
        var entity = await _context.RoleBO
            .Select(t => new { label = t.Libelle, value = t.Id })
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
            message = "Roles found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

    [HttpPost, Route("getAllObjectCredit"), Produces("application/json")]
    public async Task<IActionResult> getAllObjectCredit([FromBody] JsonElement fromFront)
    {
        var entity = await _context.ObjectCredit
            .Select(t => new { label = t.ObjectCreditLabel, value = t.ObjectCreditID })
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
            message = "Objects found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

    [HttpPost, Route("getAllNatureProperty"), Produces("application/json")]
    public async Task<IActionResult> getAllNatureProperty([FromBody] JsonElement fromFront)
    {
        var entity = await _context.NatureProperty
            .Select(t => new { label = t.NaturePropertyLabel, value = t.NaturePropertyID })
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
            message = "Objects found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

    [HttpPost, Route("getAllAssignmentProperty"), Produces("application/json")]
    public async Task<IActionResult> getAllAssignmentProperty([FromBody] JsonElement fromFront)
    {
        var entity = await _context.AssignmentProperty
            .Select(t => new { label = t.AssignmentPropertyLabel, value = t.AssignmentPropertyID })
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
            message = "Objects found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

    [HttpPost, Route("getAllUseProperty"), Produces("application/json")]
    public async Task<IActionResult> getAllUseProperty([FromBody] JsonElement fromFront)
    {
        var entity = await _context.UseProperty
            .Select(t => new { label = t.UsePropertyLabel, value = t.UsePropertyID })
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
            message = "Objects found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }


    [HttpPost, Route("getAlConditionProperty"), Produces("application/json")]
    public async Task<IActionResult> getAlConditionProperty([FromBody] JsonElement fromFront)
    {
        var entity = await _context.ConditionProperty
            .Select(t => new { label = t.ConditionPropertyLabel, value = t.ConditionPropertyID })
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
            message = "Objects found.",
            data = entity
        });// ✅ encapsule dans IActionResult
    }

}