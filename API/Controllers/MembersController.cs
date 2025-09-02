using API.Controllers;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class MembersController(IMemberRepository memberRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Member>>> GetUsers()
    {
        return await memberRepository.GetMembersAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetUser(string id)
    {
        var member = await memberRepository.GetMemberByIdAsync(id);
        if (member == null)
        {
            return NotFound();
        }
        return member;
    }

    [HttpGet("{id}/photos")]
    public async Task<ActionResult<IReadOnlyList<Photo>>> GetMemberPhotos(string id)
    {
        return await memberRepository.GetPhotosForMemberAsync(id);
    }
}
