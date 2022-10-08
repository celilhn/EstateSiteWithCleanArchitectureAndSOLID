using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Repositories
{
    public class AdressRepository: IAddressRepository
    {
        private readonly CacheManagerDbContext context;
        public AdressRepository(CacheManagerDbContext context)
        {
            this.context = context;
        }

        public Address AddAddress(Address address)
        {
            context.Adresses.Add(address);
            context.SaveChanges();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            context.Entry(address).State = EntityState.Modified;
            context.SaveChanges();
            return address;
        }

        public List<Address> GetAddresses()
        {
            return context.Adresses.Where(x => x.Status == StatusCodes.Active).ToList();
        }
    }
}
