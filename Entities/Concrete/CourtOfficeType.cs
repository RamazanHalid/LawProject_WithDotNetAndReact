using Core.Entities;
namespace Entities.Concrete
{
    public class CourtOfficeType : IEntity
    {
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeTypeNameTr { get; set; }
        public string CourtOfficeTypeNameEn { get; set; }
    }
}
