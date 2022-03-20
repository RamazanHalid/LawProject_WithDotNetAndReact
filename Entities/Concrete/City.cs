using Core.Entities;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string CityName { get; set; }
    }
}
