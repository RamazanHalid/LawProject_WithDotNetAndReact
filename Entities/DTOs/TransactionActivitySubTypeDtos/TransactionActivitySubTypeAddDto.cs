using Core.Entities;

namespace Entities.DTOs.TransactionActivitySubTypeDtos
{
    public class TransactionActivitySubTypeAddDto : IDto
    {
        public int TransactionActivityTypeId { get; set; }
        public string TransactionActivitySubTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
