using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;


namespace CacheManagerApplication.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ICommentService commentService;
        private readonly ICacheManager cacheManager;
        private readonly IPropertyService propertyService;
        public PropertiesController(ICommentService commentService, ICacheManager cacheManager, IPropertyService propertyService)
        {
            this.commentService = commentService;
            this.cacheManager = cacheManager;
            this.propertyService = propertyService;
        }

        public IActionResult List()
        {
            List<Property> properties = null;
            try
            {
                properties = propertyService.GetProperties();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return View(properties);
        }

        public IActionResult Detail(int Id)
        {
            DateTime startDateTime = DateTime.Now;
            DateTime endDateTime = DateTime.Now;
            Property property = null;
            Property cacheProperty = null;
            try
            {
                cacheProperty = cacheManager.Get<Property>(CacheArticleTypes.Property + Id);
                if (cacheProperty != null)
                {
                    property = cacheProperty;   
                    ViewBag.Comments = commentService.GetCommentsByPropertyID(cacheProperty.Id);
                }
                else
                {
                    property = propertyService.GetProperty(Id);
                    ViewBag.Comments = property.Comments;  
                    cacheManager.Set<Property>(CacheArticleTypes.Property + Id, property);
                }
                endDateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            String difference = (endDateTime - startDateTime).TotalMilliseconds.ToString();
            return View(property);
        }
    }
}
