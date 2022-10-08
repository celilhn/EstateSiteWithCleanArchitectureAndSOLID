using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers
{
    public class MemberShipPlanController : Controller
    {
        private readonly IMemberShipPlanService memberShipPlanService;
        public MemberShipPlanController(IMemberShipPlanService memberShipPlanService)
        {
            this.memberShipPlanService = memberShipPlanService;
        }

        [HttpGet]
        public IActionResult CreateMemberShipPlan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberShipPlanService.AddMemberShipPlan(memberShipPlan);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (memberShipPlan.Id > 0)
            {
                return RedirectToAction("ListMemberShipPlans", "MemberShipPlan");
            }
            else
            {
                return View(memberShipPlan);
            }
        }

        [HttpGet]
        public IActionResult UpdateMemberShipPlan(int Id)
        {
            MemberShipPlan memberShipPlan = null;
            try
            {
                memberShipPlan = memberShipPlanService.GetMemberShipPlan(Id);
                IList<SelectListItem> status = Enum.GetValues(typeof(StatusCodes)).Cast<StatusCodes>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                SelectList tStatus = new SelectList(status, "Value", "Text");
                tStatus.First(x => x.Value == ((int)memberShipPlan.Status).ToString()).Selected = true;
                ViewBag.status = tStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (memberShipPlan == null)
            {
                return RedirectToAction("ListMemberShipPlans", "MemberShipPlan");
            }
            else
            {
                return View(memberShipPlan);
            }
        }

        [HttpPost]
        public IActionResult UpdateMemberShipPlan(MemberShipPlan memberShipPlan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberShipPlanService.UpdateMemberShipPlan(memberShipPlan);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("ListMemberShipPlans", "MemberShipPlan");
            }
            else
            {
                return View(memberShipPlan);
            }
        }

        public IActionResult ListMemberShipPlans()
        {
            List<MemberShipPlan> memberShipPlans = null;
            try
            {
                memberShipPlans = memberShipPlanService.GetAllMemberShipPlans();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(memberShipPlans);
        }
    }
}
