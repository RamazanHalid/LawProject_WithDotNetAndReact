using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Country : IEntity
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Abbreviation { get; set; }
        public string Code { get; set; }

    }
}
