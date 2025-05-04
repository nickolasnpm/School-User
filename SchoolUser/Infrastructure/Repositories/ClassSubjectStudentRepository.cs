using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassSubjectStudentRepository : IClassSubjectStudentRepository
    {
        private const string _entityName = "Class Subject Student";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassSubjectStudentRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<ClassSubjectStudent> GetAllQuery()
        {
            try
            {
                return _dbContext.ClassSubjectStudent!.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassSubjectStudent>?> GetListByClassSubjectIdAsync(Guid classSubjectId)
        {
            try
            {
                return await GetAllQuery().Where(css => css.ClassSubjectId == classSubjectId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassSubjectStudent>?> GetListByStudentIdAsync(Guid studentId)
        {
            try
            {
                return await GetAllQuery().Where(css => css.StudentId == studentId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<bool> CreateBulkAsync(List<ClassSubjectStudent> classSubjectStudents)
        {
            try
            {
                await _dbContext.BulkInsertAsync(classSubjectStudents);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<bool> DeleteBulkAsync(List<Guid> classSubjectIds)
        {
            try
            {
                var classSubjectStudentList = await _dbContext.ClassSubjectStudent!.Where(css => classSubjectIds.Contains(css.ClassSubjectId)).ToListAsync();
                await _dbContext.BulkDeleteAsync(classSubjectStudentList);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }
    }
}