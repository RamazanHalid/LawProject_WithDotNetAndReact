using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.ContactUsDtos
{
    public class ContactInformationAddDto : IDto
    {
        public string Fullname { get; set; }
        public string CellPhone { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
