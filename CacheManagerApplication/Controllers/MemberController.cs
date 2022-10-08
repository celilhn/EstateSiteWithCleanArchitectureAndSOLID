using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers
{
    public class MemberController : Controller
    {
        private readonly ICacheManager cacheManager;
        private readonly IMemberService memberService;
        private readonly IPropertyService propertyService;
        private readonly IMemberShipPlanService memberShipPlanService;
        public MemberController(ICacheManager cacheManager, IMemberService memberService, IPropertyService propertyService, IMemberShipPlanService memberShipPlanService)
        {
            this.cacheManager = cacheManager;
            this.memberService = memberService;
            this.propertyService = propertyService;
            this.memberShipPlanService = memberShipPlanService;
        }

        public IActionResult MemberList()
        {
            List<Member> members = null;
            try
            {
                members = memberService.GetMembers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(members);
        }

        public IActionResult Detail(int Id)
        {
            Member member = null;
            Member cacheMember = null;
            try
            {
                cacheMember = cacheManager.Get<Member>(CacheArticleTypes.Member);
                if (cacheMember != null)
                {
                    member = cacheMember;
                    ViewBag.Properties = propertyService.GetProperties(cacheMember.Id);
                }
                else
                {
                    member = memberService.GetMember(Id);
                    ViewBag.Properties = member.Properties;
                    cacheManager.Set<Member>(CacheArticleTypes.Member, member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(member);
        }

        public IActionResult MemberShipPlans()
        {
            List<MemberShipPlan> memberShipPlans = null;
            List<MemberShipPlan> cacheMemberShipPlans = null;
            try
            {
                cacheMemberShipPlans = cacheManager.Get<List<MemberShipPlan>>(CacheArticleTypes.MemberShipPlans);
                if (cacheMemberShipPlans != null)
                {
                    memberShipPlans = cacheMemberShipPlans;
                }
                else
                {
                    memberShipPlans = memberShipPlanService.GetMemberShipPlans();
                    cacheManager.Set<List<MemberShipPlan>>(CacheArticleTypes.MemberShipPlans, memberShipPlans);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(memberShipPlans);
        }
    }
}
