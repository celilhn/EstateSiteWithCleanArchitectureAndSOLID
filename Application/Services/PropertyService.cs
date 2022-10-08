using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PropertyService: IPropertyService  
    {
        private readonly IPropertyRepository propertyRepository;
        public PropertyService(IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
        }

        public Property SaveProperty(Property property)
        {
            if (property.Id > 0)
            {
                property.UpdateDate = DateTime.Now;
                propertyRepository.UpdateProperty(property);
            }
            else
            {
                propertyRepository.AddProperty(property);
            }
            return property;
        }

        public Property GetProperty(int Id)
        {
            return propertyRepository.GetProperty(Id);
        }

        public List<Property> GetProperties()
        {
            return propertyRepository.GetProperties();
        }

        public List<Property> GetProperties(int memberId)
        {
            return propertyRepository.GetProperties(memberId);
        }
    }
}
