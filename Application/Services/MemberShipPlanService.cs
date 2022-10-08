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
        
        public MemberShipPlan AddMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            return memberShipPlanRepository.addMemberShipPlan(memberShipPlan);
        }

        public MemberShipPlan UpdateMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            memberShipPlan.UpdateDate = DateTime.Now;
            return memberShipPlanRepository.UpdateMemberShipPlan(memberShipPlan);
        }

        public MemberShipPlan GetMemberShipPlan(int Id)
        {
            return memberShipPlanRepository.GetMemberShipPlan(Id);
        }

        public List<MemberShipPlan> GetAllMemberShipPlans()
        {
            return memberShipPlanRepository.GetAllMemberShipPlans();
        }

        public List<MemberShipPlan> GetMemberShipPlans()
        {
            return memberShipPlanRepository.GetMemberShipPlans();
        }
    }
}
