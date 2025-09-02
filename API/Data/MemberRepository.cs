using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class MemberRepository(AppDbContext context) : IMemberRepository
{
    public async Task<ActionResult<Member?>> GetMemberByIdAsync(string id)
    {
        return await context.Members.FindAsync(id);
    }

    public async Task<ActionResult<Member?>> GetMemberForUpdate(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<IReadOnlyList<Member>>> GetMembersAsync()
    {
        return await context.Members.ToListAsync();
    }

    public async Task<ActionResult<IReadOnlyList<Photo>>> GetPhotosForMemberAsync(
        string memberId
    // bool isCurrentUser
    )
    {
        return await context
            .Members.Where(x => x.Id == memberId)
            .SelectMany(x => x.Photos)
            .ToListAsync();
    }

    public async Task<ActionResult<bool>> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(Member member)
    {
        context.Entry(member).State = EntityState.Modified;
    }
}
