using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface IMemberRepository
{
    void Update(Member member);

    // Task<PaginatedResult<Member>> GetMembersAsync(MemberParams memberParams);
    Task<ActionResult<IReadOnlyList<Member>>> GetMembersAsync();
    Task<ActionResult<Member?>> GetMemberByIdAsync(string id);
    Task<ActionResult<IReadOnlyList<Photo>>> GetPhotosForMemberAsync(string memberId);
    Task<ActionResult<Member?>> GetMemberForUpdate(string id);

    Task<ActionResult<bool>> SaveAllAsync();
}
