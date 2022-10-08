using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IMemberShipPlanRepository
    {
        MemberShipPlan addMemberShipPlan(MemberShipPlan memberShipPlan);
        MemberShipPlan UpdateMemberShipPlan(MemberShipPlan memberShipPlan);
        List<MemberShipPlan> GetMemberShipPlans();
    }
}
