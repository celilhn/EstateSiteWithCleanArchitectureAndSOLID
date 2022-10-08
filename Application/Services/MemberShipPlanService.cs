using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class MemberShipPlanService: IMemberShipPlanService
    {
        private readonly IMemberShipPlanRepository memberShipPlanRepository;

        public MemberShipPlanService(IMemberShipPlanRepository memberShipPlanRepository)
        {
            this.memberShipPlanRepository = memberShipPlanRepository;
        }

        public MemberShipPlan SaveMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            if (memberShipPlan.Id > 0)
            {
                memberShipPlan.UpdateDate = DateTime.Now;
                memberShipPlanRepository.UpdateMemberShipPlan(memberShipPlan);
            }
            else
            {
                memberShipPlanRepository.addMemberShipPlan(memberShipPlan);
            }
            return memberShipPlan;
        }

        public List<MemberShipPlan> GetMemberShipPlans()
        {
            return memberShipPlanRepository.GetMemberShipPlans();
        }
    }
}
