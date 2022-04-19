using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CasesDocumentDtos
{
    public class CasesDocumentUpdateDto : IDto
    {
        public int CaseDocumentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string DocumentPath { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
