using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.AccountActivityType
{
    public class AccountActivityTypeGetDto : IDto
    {
        public int AccountActivityTypeId { get; set; }
        public string Name { get; set; }
    }
}
