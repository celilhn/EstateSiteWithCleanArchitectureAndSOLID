using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAddressRepository
    {
        Address AddAddress(Address address);
        Address UpdateAddress(Address address);
        List<Address> GetAddresses();
    }
}
