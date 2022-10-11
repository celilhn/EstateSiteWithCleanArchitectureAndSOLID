using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMemberRepository
    {
        Member AddMember(Member member);
        Member UpdateMember(Member member);
        Member GetMember(int Id);
        List<Member> GetAllMembers();
        List<Member> GetMembers();
    }
}
