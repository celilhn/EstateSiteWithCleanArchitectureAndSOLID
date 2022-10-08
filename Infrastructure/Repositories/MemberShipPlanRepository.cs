using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class MemberShipPlanRepository : IMemberShipPlanRepository
    {
        private readonly CacheManagerDbContext context;
        public MemberShipPlanRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public MemberShipPlan addMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            context.MemberShipPlans.Add(memberShipPlan);
            context.SaveChanges();
            return memberShipPlan;
        }

        public MemberShipPlan UpdateMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            context.Entry(memberShipPlan).State = EntityState.Modified;
            context.SaveChanges();
            return memberShipPlan;
        }

        public MemberShipPlan GetMemberShipPlan(int Id)
        {
            return context.MemberShipPlans.SingleOrDefault(x => x.Id == Id);
        }

        public List<MemberShipPlan> GetAllMemberShipPlans()
        {
            return context.MemberShipPlans.ToList();
        }

        public List<MemberShipPlan> GetMemberShipPlans()
        {
            return context.MemberShipPlans.Where(x => x.Status == StatusCodes.Active).ToList();
        }
    }
}
