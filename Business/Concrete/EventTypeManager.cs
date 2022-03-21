using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.EventTypeDtos;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EventTypeManager : IEventTypeService
    {
        private IEventTypeDal _eventTypeDal;
        private readonly IMapper _mapper;
        public EventTypeManager(IEventTypeDal eventTypeDal, IMapper mapper)
        {
            _eventTypeDal = eventTypeDal;
            _mapper = mapper;
        }
        public IResult Add(EventTypeAddDto eventTypeAddDto)
        {
            EventType eventType = _mapper.Map<EventType>(eventTypeAddDto);
            _eventTypeDal.Add(eventType);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IDataResult<List<EventTypeGetDto>> GetAll()
        {
            List<EventType> eventTypes = _eventTypeDal.GetAll();
            List<EventTypeGetDto> eventTypeGetDtos = _mapper.Map<List<EventTypeGetDto>>(eventTypes);
            return new SuccessDataResult<List<EventTypeGetDto>>(eventTypeGetDtos, Messages.GetAllSuccessfuly);
        }
        public IDataResult<EventTypeGetDto> GetById(int id)
        {
            var eventType = _eventTypeDal.Get(c => c.EventTypeId == id);
            if (eventType == null)
                return new ErrorDataResult<EventTypeGetDto>(Messages.TheItemDoesNotExists);
            EventTypeGetDto eventTypeGetDto = _mapper.Map<EventTypeGetDto>(eventType);
            return new SuccessDataResult<EventTypeGetDto>(Messages.GetByIdSuccessfuly);
        }
        public IResult Delete(int id)
        {
            var eventType = _eventTypeDal.Get(c => c.EventTypeId == id);
            if (eventType == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            _eventTypeDal.Delete(eventType);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IResult Update(EventTypeUpdateDto eventTypeUpdateDto)
        {
            EventType eventType = _mapper.Map<EventType>(eventTypeUpdateDto);
            _eventTypeDal.Update(eventType);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult DoesItExist(int id)
        {
            var result = _eventTypeDal.Get(c => c.EventTypeId == id);
            if (result == null)
                return new ErrorResult(Messages.TheItemDoesNotExists);
            return new SuccessResult(Messages.TheItemExists);
        }
    }
}
