using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<Licence> Licences { get; set; }

    }
}
