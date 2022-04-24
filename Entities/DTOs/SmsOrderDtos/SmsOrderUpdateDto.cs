using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.SmsOrderDtos
{
    public class SmsOrderUpdateDto : IDto
    {
        public int Id { get; set; }
        public int SmsCount { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
    }
}
