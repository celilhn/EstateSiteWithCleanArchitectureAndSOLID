using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Property SaveProperty(Property property);
        Property GetProperty(int Id);
        List<Property> GetProperties();
        List<Property> GetProperties(int memberId);
    }
}
