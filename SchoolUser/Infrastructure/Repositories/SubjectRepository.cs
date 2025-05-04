using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private const string _entityName = "Subject";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public SubjectRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<Subject> GetAllQuery()
        {
            try
            {
                return _dbContext.Subject!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(s => new Subject
                    {
                        Id = s.Id,
                        Code = s.Code,
                        Name = s.Name,
                        TeacherId = s.TeacherId,
                        ClassSubjects = s.ClassSubjects!.Where(cs => cs.SubjectId == s.Id).ToList(),
                        ClassCategories = s.ClassSubjects!.Select(cs => cs.ClassCategory!.Code).ToList(),
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<Subject>?> GetAllAsync()
        {
            try
            {
                return await GetAllQuery().OrderBy(s => s.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Subject?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Subject?> GetByNameAsync(string name)
        {
            try
            {
                return await GetAllQuery().Where(s => s.Name == name).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Subject?> CreateAsync(Subject subject)
        {
            try
            {
                await _dbContext.Subject!.AddAsync(subject);
                await _dbContext.SaveChangesAsync();
                return subject;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<Subject?> UpdateAsync(Subject subject)
        {
            try
            {
                var existing = await _dbContext.Subject!.FindAsync(subject.Id);
                existing!.Name = subject.Name;
                existing.Code = subject.Code;
                existing.TeacherId = subject.TeacherId;
                await _dbContext.SaveChangesAsync();
                return subject;
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
                var existing = await _dbContext.Subject!.FindAsync(id);
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