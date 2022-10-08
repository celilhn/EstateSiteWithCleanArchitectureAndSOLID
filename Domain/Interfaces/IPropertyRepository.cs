using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Property AddProperty(Property property);
        Property UpdateProperty(Property property);
        Property GetProperty(int Id);
        List<Property> GetProperties();
        List<Property> GetProperties(int memberId);
    }
}
