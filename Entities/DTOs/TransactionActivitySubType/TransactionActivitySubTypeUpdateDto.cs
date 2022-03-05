using Core.Entities;

namespace Entities.DTOs.TransactionActivitySubType
{
    public class TransactionActivitySubTypeUpdateDto : IDto
    {
        public int TransactionAcitivitySubTypeId { get; set; }
        public int TransactionAcitivityTypeId { get; set; }
        public string TransactionAcitivitySubTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
