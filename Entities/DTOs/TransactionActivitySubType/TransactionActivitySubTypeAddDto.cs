using Core.Entities;

namespace Entities.DTOs.TransactionActivitySubType
{
    public class TransactionActivitySubTypeAddDto : IDto
    {
        public int TransactionAcitivityTypeId { get; set; }
        public string TransactionAcitivitySubTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
