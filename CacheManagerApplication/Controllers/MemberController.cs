using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.Interfaces;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers
{
    public class MemberController : Controller
    {
        private readonly ICacheManager cacheManager;
        private readonly IMemberService memberService;
        private readonly IPropertyService propertyService;
        private readonly IMemberShipPlanService memberShipPlanService;
        private readonly IImageService imageService;
        public MemberController(ICacheManager cacheManager, IMemberService memberService, IPropertyService propertyService, IMemberShipPlanService memberShipPlanService
        , IImageService imageService)
        {
            this.cacheManager = cacheManager;
            this.memberService = memberService;
            this.propertyService = propertyService;
            this.memberShipPlanService = memberShipPlanService;
            this.imageService = imageService;
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

        [HttpGet]
        public IActionResult CreateMemberImage(int memberId)
        {
            ViewBag.memberId = memberId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateMemberImage(int memberId, IFormFile file, ImageTypes type)
        {
            string url = "";
            Image image = null;
            try
            {
                if (ModelState.IsValid)
                {
                    image = imageService.GetImage(memberId, type);
                    url = imageService.UploadImage(file, image.Url);
                    if (url != "")
                    {
                        image.Url = url;
                        imageService.SaveImage(image);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
            if (url != "")
            {
                return RedirectToAction("ListMemberImages", "Member", new{ Id = memberId});
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberService.AddMember(member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (member.Id > 0)
            {
                return RedirectToAction("ListMembers", "Member");
            }
            else
            {
                return View(member);
            }
        }

        [HttpGet]
        public IActionResult UpdateMember(int Id)
        {
            Member member = null;
            try
            {
                member = memberService.GetMember(Id);
                IList<SelectListItem> status = Enum.GetValues(typeof(Constants.StatusCodes)).Cast<Constants.StatusCodes>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                SelectList tStatus = new SelectList(status, "Value", "Text");
                tStatus.First(x => x.Value == ((int)member.Status).ToString()).Selected = true;
                ViewBag.status = tStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (member == null)
            {
                return RedirectToAction("ListMembers", "Member");
            }
            else
            {
                return View(member);
            }
        }

        [HttpPost]
        public IActionResult UpdateMember(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberService.UpdateMember(member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("ListMembers", "Member");
            }
            else
            {
                return View(member);
            }
        }

        [HttpGet]
        public IActionResult ListMembers()
        {
            List<Member> members = null;
            try
            {
                members = memberService.GetAllMembers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(members);
        }

        [HttpGet]
        public IActionResult ListMemberImages(int Id)
        {
            List<Image> images = null;
            try
            {
                images = imageService.GetMemberImages(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(images);
        }

        public IActionResult DeleteMember(int Id)
        {
            Member member = null;
            try
            {
                member = memberService.GetMember(Id);
                if (member != null)
                {
                    member.Status = 0;
                    memberService.UpdateMember(member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListMembers", "Member");
        }

        public IActionResult DeleteMemberImage(int Id)
        {
            Image image = null;
            try
            {
                image = imageService.GetImage(Id);
                if (image != null)
                {
                    image.Status = 0;
                    imageService.SaveImage(image);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("ListMemberImages", "Member");
        }
    }
}
