using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private const string _entityName = "Teacher";
        private readonly DBContext _dbContext;
        private readonly ICacheServices<User> _cacheServices;
        private const string cacheKey_GetUserById = "GetUserById";
        private readonly IReturnValueConstants _returnValueConstants;
        public TeacherRepository(DBContext dbContext, ICacheServices<User> cacheServices, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _cacheServices = cacheServices;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<Teacher> GetAllQuery()
        {
            try
            {
                return _dbContext.Teacher!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(t => new Teacher
                    {
                        Id = t.Id,
                        ServiceStatus = t.ServiceStatus,
                        IsAvailable = t.IsAvailable,
                        ResponsibilityType = t.ResponsibilityType,
                        ResponsibilityFocus = t.ResponsibilityFocus,
                        UserId = t.UserId,
                        ClassCategoryId = t.ClassCategoryId,
                        ClassSubjects = t.ClassSubjectTeachers == null ? new List<ClassSubject>() :
                            t.ClassSubjectTeachers.Select(cst => cst.ClassSubject!).ToList(),
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<Teacher>?> GetAllAsync()
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

        public async Task<IEnumerable<Teacher>?> GetListBySubjectIdAsync(Guid subjectId)
        {
            try
            {
                return await GetAllQuery()
                    .Where(t => t.ClassSubjectTeachers!.Any(cst => cst.ClassSubject!.SubjectId == subjectId))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Teacher?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Teacher?> GetByUserIdAsync(Guid userId)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(t => t.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Teacher?> CreateAsync(Teacher teacher)
        {
            try
            {
                await _dbContext.Teacher!.AddAsync(teacher);
                await _dbContext.SaveChangesAsync();
                return teacher;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<Teacher?> UpdateAsync(Teacher teacher)
        {
            try
            {
                var existing = await _dbContext.Teacher!.FindAsync(teacher.Id);

                if (existing == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
                }

                if (existing.ServiceStatus == teacher.ServiceStatus &&
                    existing.IsAvailable == teacher.IsAvailable &&
                    existing.ResponsibilityType == teacher.ResponsibilityType &&
                    existing.ResponsibilityFocus == teacher.ResponsibilityFocus &&
                    existing.UserId == teacher.UserId &&
                    existing.ClassCategoryId == teacher.ClassCategoryId)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                }

                existing.ServiceStatus = teacher.ServiceStatus;
                existing.IsAvailable = teacher.IsAvailable;
                existing.ResponsibilityType = teacher.ResponsibilityType;
                existing.ResponsibilityFocus = teacher.ResponsibilityFocus;
                existing.UserId = teacher.UserId;
                existing.ClassCategoryId = teacher.ClassCategoryId;
                await _dbContext.SaveChangesAsync();

                var cacheKey = $"{cacheKey_GetUserById}_{existing!.UserId}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return teacher;
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
                var existing = await _dbContext.Teacher!.FindAsync(id);
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