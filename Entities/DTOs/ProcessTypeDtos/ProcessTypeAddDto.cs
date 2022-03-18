using Core.Entities;

namespace Entities.DTOs.ProcessTypeDtos
{
    public class ProcessTypeAddDto: IDto
    { 
        public string ProcessTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
