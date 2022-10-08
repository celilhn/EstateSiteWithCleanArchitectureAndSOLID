using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAddressService
    {
        Address SaveAddress(Address address);
        List<Address> GetAddresses();
    }
}
