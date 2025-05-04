using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassCategoryRepository : IClassCategoryRepository
    {
        private const string _entityName = "Class Category";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassCategoryRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<ClassCategory> GetAllQuery()
        {
            try
            {
                return _dbContext.ClassCategory!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(cc => new ClassCategory
                    {
                        Id = cc.Id,
                        Code = cc.Code,
                        AcademicYear = cc.AcademicYear,
                        BatchId = cc.BatchId,
                        ClassStreamId = cc.ClassStreamId,
                        ClassRankId = cc.ClassRankId,
                        ClassSubjects = cc.ClassSubjects!.Where(cs => cs.ClassCategoryId == cc.Id).ToList(),
                        Subjects = cc.ClassSubjects!.Select(cs => cs.Subject!.Name).ToList(),
                        Students = cc.Students,
                        Teachers = cc.Teachers
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassCategory>?> GetAllAsync()
        {
            try
            {
                return await GetAllQuery().OrderBy(cc => cc.Code).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassCategory?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(cc => cc.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassCategory?> GetByCodeAndYearAsync(string code, int year)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(cc => cc.Code == code && cc.AcademicYear == year);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<IEnumerable<Guid>?> GetUniqueClassCategoryIdsAsync()
        {
            try
            {
                return await GetAllQuery().Select(cc => cc.Id).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassCategory?> CreateAsync(ClassCategory classCategory)
        {
            try
            {
                await _dbContext.ClassCategory!.AddAsync(classCategory);
                await _dbContext.SaveChangesAsync();
                return classCategory;
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
                var existing = await _dbContext.ClassCategory!.FindAsync(id);
                _dbContext.Remove(existing!);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }
    }
}