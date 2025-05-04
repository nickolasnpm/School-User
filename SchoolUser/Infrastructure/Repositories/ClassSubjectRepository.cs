using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using EFCore.BulkExtensions;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        private const string _entityName = "Class Subject";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassSubjectRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<ClassSubject> GetAllQuery()
        {
            try
            {
                return _dbContext.ClassSubject!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(cs => new ClassSubject
                    {
                        Id = cs.Id,
                        Code = cs.Code,
                        AcademicYear = cs.AcademicYear,
                        ClassCategoryId = cs.ClassCategoryId,
                        SubjectId = cs.SubjectId,
                        Teachers = cs.ClassSubjectTeachers!.Select(cst => cst.Teacher!).ToList(),
                        Students = cs.ClassSubjectStudents!.Select(cst => cst.Student!).ToList(),
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassSubject>?> GetAllAsync()
        {
            try
            {
                return await GetAllQuery().OrderBy(cs => cs.Code).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassSubject>?> GetByClassCategoryIdAsync(Guid classCategoryId)
        {
            try
            {
                return await GetAllQuery().Where(cs => cs.ClassCategoryId == classCategoryId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassSubject?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().Where(cs => cs.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassSubject?> GetByCodeAndYearAsync(string code, int year)
        {
            try
            {
                return await GetAllQuery().Where(cs => cs.Code == code && cs.AcademicYear == year).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassSubject?> CreateAsync(ClassSubject classSubject)
        {
            try
            {
                await _dbContext.ClassSubject!.AddAsync(classSubject);
                await _dbContext.SaveChangesAsync();
                return classSubject;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<bool> CreateBulkAsync(List<ClassSubject> classSubjects)
        {
            try
            {
                await _dbContext.BulkInsertAsync(classSubjects);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<ClassSubject?> UpdateAsync(ClassSubject classSubject)
        {
            try
            {
                var existing = await _dbContext.ClassSubject!.FindAsync(classSubject.Id);
                existing!.Code = classSubject.Code;
                await _dbContext.SaveChangesAsync();
                return classSubject;
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
                var existing = await _dbContext.ClassSubject!.FindAsync(id);
                _dbContext.Remove(existing!);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }

        public async Task<bool> DeleteBulkAsync(List<Guid> subjectIds)
        {
            try
            {
                var classSubjectList = await _dbContext.ClassSubject!.Where(cs => subjectIds.Contains(cs.SubjectId)).ToListAsync();
                await _dbContext.BulkDeleteAsync(classSubjectList);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }
    }
}