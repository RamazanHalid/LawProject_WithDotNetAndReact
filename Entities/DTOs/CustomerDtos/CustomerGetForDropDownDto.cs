using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs.CustomerDtos
{
    public class CustomerGetForDropDownDto : IDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
