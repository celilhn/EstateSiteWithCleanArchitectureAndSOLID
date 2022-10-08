using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IMemberShipPlanService
    {
        MemberShipPlan AddMemberShipPlan(MemberShipPlan memberShipPlan);
        MemberShipPlan UpdateMemberShipPlan(MemberShipPlan memberShipPlan);
        MemberShipPlan GetMemberShipPlan(int Id);
        List<MemberShipPlan> GetAllMemberShipPlans();
        List<MemberShipPlan> GetMemberShipPlans();
    }
}
