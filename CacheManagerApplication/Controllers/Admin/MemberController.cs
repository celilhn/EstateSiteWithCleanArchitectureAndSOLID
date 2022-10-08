using System;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers.Admin
{
    public class MemberController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IPropertyService propertyService;
        private readonly IMemberShipPlanService memberShipPlanService;
        public MemberController(IMemberService memberService, IPropertyService propertyService, IMemberShipPlanService memberShipPlanService)
        {
            this.memberService = memberService;
            this.propertyService = propertyService;
            this.memberShipPlanService = memberShipPlanService;
        }

        [HttpPost]
        public IActionResult SaveMember(Member member)
        {
            try
            {
                ViewBag.Model = member;
                if (member.Id > 0)
                {
                    ViewBag.Action = ActionTypes.Update;
                }
                else
                {
                    ViewBag.Action = ActionTypes.Create;
                }
                if (ModelState.IsValid)
                {
                    memberService.SaveMember(member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(member);
        }
    }
}
