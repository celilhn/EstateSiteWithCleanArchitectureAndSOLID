using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTag(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tagService.AddTag(tag);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return RedirectToAction("UpdateTag","Tag", new {Id = tag.Id});
        }

        [HttpGet]
        public IActionResult UpdateTag(int Id)
        {
            Tag tag = null;
            try
            {
                tag = tagService.GetTag(Id);
                IList<SelectListItem> status = Enum.GetValues(typeof(StatusCodes)).Cast<StatusCodes>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                SelectList tStatus = new SelectList(status, "Value", "Text");
                tStatus.First(x => x.Value == ((int)tag.Status).ToString()).Selected = true;
                ViewBag.status = tStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            if (tag == null)
            {
                return RedirectToAction("ListTags", "Tag");
            }
            else
            {
                return View(tag);
            }
        }

        [HttpPost]
        public IActionResult UpdateTag(Tag tag)
        {
            try
            {
                tagService.UpdateTag(tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return RedirectToAction("ListTags", "Tag");
        }

        public IActionResult ListTags()
        {
            List<Tag> tags = null;
            try
            {
                tags = tagService.GetTags();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(tags);
        }
    }
}
