using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IMemberShipPlanService
    {
        MemberShipPlan SaveMemberShipPlan(MemberShipPlan memberShipPlan);
        List<MemberShipPlan> GetMemberShipPlans();
    }
}
