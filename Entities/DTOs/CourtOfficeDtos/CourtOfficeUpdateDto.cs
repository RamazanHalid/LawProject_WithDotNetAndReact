namespace Entities.DTOs.CourtOfficeDtos
{
    public class CourtOfficeUpdateDto
    {
        public int CourtOfficeId { get; set; }
        public int CourtOfficeTypeId { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
