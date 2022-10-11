using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly CacheManagerDbContext context;
        public MemberRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public Member AddMember(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
            return member;
        }

        public Member UpdateMember(Member member)
        {
            context.Entry(member).State = EntityState.Modified;
            context.SaveChanges();
            return member;
        }

        public Member GetMember(int Id)
        {
            return context.Members.SingleOrDefault(x => x.Id == Id);
        }

        public List<Member> GetAllMembers()
        {
            return context.Members.ToList();
        }

        public List<Member> GetMembers()
        {
            return context.Members.Where(x => x.Status == StatusCodes.Active).ToList();
        }
    }
}
