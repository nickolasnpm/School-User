using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private const string _entityName = "Student";
        private readonly DBContext _dbContext;
        private readonly ICacheServices<User> _cacheServices;
        private const string cacheKey_GetUserById = "GetUserById";
        private readonly IReturnValueConstants _returnValueConstants;

        public StudentRepository(DBContext dbContext, ICacheServices<User> cacheServices, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _cacheServices = cacheServices;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<Student> GetAllQuery()
        {
            try
            {
                return _dbContext.Student!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(s => new Student
                    {
                        Id = s.Id,
                        EntranceYear = s.EntranceYear,
                        EstimatedExitYear = s.EstimatedExitYear,
                        RealExitYear = s.RealExitYear,
                        ExitReason = s.ExitReason,
                        UserId = s.UserId,
                        ClassCategoryId = s.ClassCategoryId,
                        ClassSubjects = s.ClassSubjectStudents == null ? new List<ClassSubject>() :
                            s.ClassSubjectStudents.Select(css => css.ClassSubject!).ToList(),
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<Student>?> GetAllAsync()
        {
            try
            {
                return await GetAllQuery().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Student?> GetByUserIdAsync(Guid userId)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(s => s.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Student?> CreateAsync(Student student)
        {
            try
            {
                await _dbContext.Student!.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            try
            {
                var existing = await _dbContext.Student!.FindAsync(student.Id);

                if (existing == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
                }

                if (existing.EntranceYear == student.EntranceYear &&
                    existing.EstimatedExitYear == student.EstimatedExitYear &&
                    existing.RealExitYear == student.RealExitYear &&
                    existing.ExitReason == student.ExitReason &&
                    existing.ClassCategoryId == student.ClassCategoryId)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                }

                existing.EntranceYear = student.EntranceYear;
                existing.EstimatedExitYear = student.EstimatedExitYear;
                existing.RealExitYear = student.RealExitYear;
                existing.ExitReason = student.ExitReason;
                existing.ClassCategoryId = student.ClassCategoryId;
                await _dbContext.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<bool> UpdateBulkAsync(StudentsBulkUpdateDto updateDto)
        {
            try
            {
                var studentsToUpdate = await GetAllQuery()
                   .Where(student => updateDto.StudentIds.Contains(student.Id))
                   .ToListAsync();

                if (!studentsToUpdate.Any())
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
                }

                var uniqueClassCategoryIds = studentsToUpdate.Select(student => student.ClassCategoryId).Distinct().Count();

                if (uniqueClassCategoryIds == 1)
                {
                    if (studentsToUpdate.All(s => s.EntranceYear == updateDto.EntranceYear &&
                    s.EstimatedExitYear == updateDto.EstimatedExitYear &&
                    s.RealExitYear == updateDto.RealExitYear &&
                    s.ExitReason == updateDto.ExitReason &&
                    s.ClassCategoryId == updateDto.ClassCategoryId))
                    {
                        throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                    }
                }
                else
                {
                    if (studentsToUpdate.All(s => s.EntranceYear == updateDto.EntranceYear &&
                    s.EstimatedExitYear == updateDto.EstimatedExitYear &&
                    s.RealExitYear == updateDto.RealExitYear &&
                    s.ExitReason == updateDto.ExitReason))
                    {
                        throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                    }
                }

                foreach (var student in studentsToUpdate)
                {
                    student.EntranceYear = updateDto.EntranceYear;
                    student.EstimatedExitYear = updateDto.EstimatedExitYear;
                    student.RealExitYear = updateDto.RealExitYear;
                    student.ExitReason = updateDto.ExitReason;

                    if (updateDto.ClassCategoryId != null && uniqueClassCategoryIds == 1)
                    {
                        student.ClassCategoryId = (Guid)updateDto.ClassCategoryId;
                    }
                }

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var existing = await _dbContext.Student!.FindAsync(id);
                _dbContext.Remove(existing!);
                await _dbContext.SaveChangesAsync();

                var cacheKey = $"{cacheKey_GetUserById}_{existing!.Id}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }
    }
}