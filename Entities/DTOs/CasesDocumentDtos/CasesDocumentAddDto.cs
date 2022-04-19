using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CasesDocumentDtos
{
    public class CasesDocumentAddDto : IDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string DocumentPath { get; set; }
        public int CaseeId { get; set; }
     }
}
