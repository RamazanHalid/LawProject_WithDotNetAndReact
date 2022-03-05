using Core.Entities;
using Entities.Concrete; 

namespace Entities.DTOs.TransactionActivitySubType
{
    public class TransactionActivitySubTypeGetDto : IDto
    {
        public int TransactionAcitivitySubTypeId { get; set; }
        public TransactionActivityType TransactionActivityType { get; set; }
        public string TransactionAcitivitySubTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
