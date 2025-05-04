using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using EFCore.BulkExtensions;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassSubjectTeacherRepository : IClassSubjectTeacherRepository
    {
        private const string _entityName = "Class Subject Teacher";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassSubjectTeacherRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<ClassSubjectTeacher> GetAllQuery()
        {
            try
            {
                return _dbContext.ClassSubjectTeacher!.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassSubjectTeacher>?> GetListByClasssSubjectIdAsync(Guid classSubjectId)
        {
            try
            {
                return await GetAllQuery().Where(cst => cst.ClassSubjectId == classSubjectId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassSubjectTeacher>?> GetListByTeacherIdAsync(Guid teacherId)
        {
            try
            {
                return await GetAllQuery().Where(cst => cst.TeacherId == teacherId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<bool> CreateBulkAsync(List<ClassSubjectTeacher> classSubjectTeacher)
        {
            try
            {
                await _dbContext.BulkInsertAsync(classSubjectTeacher);
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
                var classSubjectTeacherList = await _dbContext.ClassSubjectTeacher!.Where(cst => classSubjectIds.Contains(cst.ClassSubjectId)).ToListAsync();
                await _dbContext.BulkDeleteAsync(classSubjectTeacherList!);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }
    }
}