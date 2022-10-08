using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Application.Interfaces;
using Application.Models;
using CacheManagerApplication.Models;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using static Domain.Constants.Constants;

namespace CacheManagerApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheManager cacheManager;
        private readonly IAddressService adressService;

        public HomeController(ICacheManager cacheManager, IAddressService adressService)
        {
            this.cacheManager = cacheManager;
            this.adressService = adressService;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            List<Address> addresses = null;
            List<Address> cacheAddresses = null;
            try
            {
                cacheAddresses = cacheManager.Get<List<Address>>(CacheArticleTypes.Adresses);
                if (cacheAddresses != null)
                {
                    addresses = cacheAddresses;
                }
                else
                {
                    addresses = adressService.GetAddresses();
                    cacheManager.Set<List<Address>>(CacheArticleTypes.Adresses, addresses);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(addresses);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
