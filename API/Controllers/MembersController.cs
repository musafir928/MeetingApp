using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class MembersController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<AppUser>>> GetUsers()
    {
        var members = await context.Users.ToListAsync();
        return members;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(string id)
    {
        var member = await context.Users.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }
        return member;
    }
}
