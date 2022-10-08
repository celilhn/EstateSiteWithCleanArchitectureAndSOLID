using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IMemberService
    {
        Member SaveMember(Member member);
        Member GetMember(int Id);
        List<Member> GetMembers();
    }
}
