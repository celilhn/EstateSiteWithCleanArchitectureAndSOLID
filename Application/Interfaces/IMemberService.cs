using System.Collections.Generic;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IMemberService
    {
        Member AddMember(Member member);
        Member UpdateMember(Member member);
        Member GetMember(int Id);
        List<Member> GetAllMembers();
        List<Member> GetMembers();
    }
}
