using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.SmsTemplateDtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISmsTemplateService
    {
        IDataResult<List<SmsTemplateGetDto>> GetAll();
        IDataResult<SmsTemplateGetDto> GetById(int id);
        IResult Add(SmsTemplateAddDto smsTemplateAddDto);
        IResult Update(SmsTemplateUpdateDto smsTemplateUpdateDto);
        IResult Delete(int id);
        IDataResult<SmsTemplate> GetByLicenceId(int licenceId);

    }
}
