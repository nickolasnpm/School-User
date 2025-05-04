using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Commands;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using System.Globalization;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;

namespace SchoolUser.Domain.Services
{
    public class BatchServices : IBatchServices
    {
        private readonly string _entityName = "Batch";
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;

        public BatchServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Batch>?> GetAllService(bool? isActive)
        {
            if (isActive.HasValue && isActive.Value)
            {
                return await _sender.Send(new GetAllBatchesQuery(isActive));
            }

            return Enumerable.Empty<Batch>();
        }

        public async Task<Batch?> GetByIdService(Guid id)
        {
            return await _sender.Send(new GetBatchByIdQuery(id));
        }

        public async Task<Batch?> GetByNameService(string name)
        {
            return await _sender.Send(new GetBatchByNameQuery(name));
        }

        public async Task<bool> CreateService(BatchDto batchDto)
        {
            if (batchDto == null)
            {
                throw new ArgumentNullException(nameof(batchDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "BatchDto"));
            }

            Batch? batch = await _sender.Send(new GetBatchByNameQuery(batchDto.Name));

            if (batch != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, _entityName));
            }

            // check teacher validity 
            var teacher = await _sender.Send(new GetTeacherByIdQuery(batchDto.TeacherId));

            if (teacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "Teacher"));
            }

            if (teacher.ResponsibilityType != null)
            {
                await UpdateExistingTeacherResponsibility(teacher);
            }

            batch = new Batch
            {
                Id = Guid.NewGuid(),
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(batchDto.Name),
                Code = batchDto.Code,
                IsActive = batchDto.IsActive,
                TeacherId = batchDto.TeacherId
            };

            teacher.ResponsibilityType = "Batch";
            teacher.ResponsibilityFocus = batch.Name;

            var createdBatch = await _sender.Send(new AddBatchCommand(batch)) != null;
            var updatedTeacher = await _sender.Send(new UpdateTeacherCommand(teacher)) != null;
            return createdBatch && updatedTeacher;
        }

        public async Task<bool> UpdateService(Guid id, BatchDto batchDto)
        {
            if (batchDto == null)
            {
                throw new ArgumentNullException(nameof(batchDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "BatchDto"));
            }

            var batch = await _sender.Send(new GetBatchByIdQuery(id));

            if (batch == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            // check teacher validity 
            var teacher = await _sender.Send(new GetTeacherByIdQuery(batchDto.TeacherId));

            if (teacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "Teacher"));
            }

            if (teacher.ResponsibilityType != null)
            {
                await UpdateExistingTeacherResponsibility(teacher);
            }

            if (batch.Name.ToLower() == batchDto.Name.ToLower() &&
                batch.Code == batchDto.Code &&
                batch.IsActive == batchDto.IsActive &&
                batch.TeacherId == batchDto.TeacherId)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
            }

            batch.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(batchDto.Name);
            batch.Code = batchDto.Code;
            batch.IsActive = batchDto.IsActive;
            batch.TeacherId = batchDto.TeacherId;

            if (teacher.ResponsibilityType?.ToLower() != "batch" || teacher.ResponsibilityFocus?.ToLower() != batch.Name.ToLower())
            {
                teacher.ResponsibilityType = "Batch";
                teacher.ResponsibilityFocus = batch.Name;
            }

            var updatedBatch = await _sender.Send(new UpdateBatchCommand(batch)) != null;
            var updatedTeacher = await _sender.Send(new UpdateTeacherCommand(teacher)) != null;
            return updatedBatch && updatedTeacher;
        }

        public async Task<bool> DeleteService(Guid id)
        {
            var existing = await _sender.Send(new GetBatchByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteBatchCommand(id));
        }

        private async Task UpdateExistingTeacherResponsibility(Teacher teacher)
        {
            if (teacher.ResponsibilityType!.ToLower() == "batch" && teacher.ResponsibilityFocus != null)
            {
                var existingResponsibility = await _sender.Send(new GetBatchByNameQuery(teacher.ResponsibilityFocus));

                if (existingResponsibility != null)
                {
                    var toUpdateBatch = new Batch
                    {
                        Id = existingResponsibility.Id,
                        Name = existingResponsibility.Name,
                        Code = existingResponsibility.Code,
                        IsActive = existingResponsibility.IsActive,
                        TeacherId = null
                    };

                    var updatedExistingResponsibility = await _sender.Send(new UpdateBatchCommand(toUpdateBatch));

                    if (updatedExistingResponsibility == null)
                    {
                        throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, "existing batch responsibility"));
                    }
                }

            }
        }

    }
}