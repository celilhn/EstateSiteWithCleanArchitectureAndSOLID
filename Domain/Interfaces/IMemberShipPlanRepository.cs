using System.Collections.Generic;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IMemberShipPlanRepository
    {
        MemberShipPlan addMemberShipPlan(MemberShipPlan memberShipPlan);
        MemberShipPlan UpdateMemberShipPlan(MemberShipPlan memberShipPlan);
        MemberShipPlan GetMemberShipPlan(int Id);
        List<MemberShipPlan> GetAllMemberShipPlans();
        List<MemberShipPlan> GetMemberShipPlans();
    }
}
