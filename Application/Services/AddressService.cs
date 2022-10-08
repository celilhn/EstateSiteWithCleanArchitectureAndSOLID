using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public Address SaveAddress(Address address)
        {
            if (address.Id > 0)
            {
                address.UpdateDate = DateTime.Now;
                addressRepository.UpdateAddress(address);
            }
            else
            {
                addressRepository.AddAddress(address);
            }
            return address;
        }

        public List<Address> GetAddresses()
        {
            return addressRepository.GetAddresses();
        }
    }
}
