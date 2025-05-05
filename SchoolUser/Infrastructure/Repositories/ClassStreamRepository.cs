using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassStreamRepository : IClassStreamRepository
    {
        private const string _entityName = "Class Stream";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassStreamRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<ClassStream> GetAllQuery()
        {
            try
            {
                return _dbContext.ClassStream!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(cs => new ClassStream
                    {
                        Id = cs.Id,
                        Name = cs.Name,
                        Code = cs.Code,
                        IsActive = cs.IsActive,
                        ClassCategories = cs.ClassCategories!.Where(cc => cc.ClassStreamId == cs.Id).Distinct().ToList(),
                        Batches = cs.ClassCategories!.Select(cc => cc.Batch!.Name).Distinct().ToList(),
                        ClassRanks = cs.ClassCategories!.Select(cc => cc.ClassRank!.Name).Distinct().ToList()
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassStream>?> GetAllAsync(bool? isActive = null)
        {
            try
            {
                IQueryable<ClassStream> query = GetAllQuery();

                if (isActive.HasValue)
                {
                    query = query.Where(cs => cs.IsActive == isActive);
                }

                return await query.OrderBy(cs => cs.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassStream?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(cs => cs.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassStream?> GetByNameAsync(string Name)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(cs => cs.Name == Name);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }

        }

        public async Task<ClassStream?> CreateAsync(ClassStream ClassStream)
        {
            try
            {
                await _dbContext.ClassStream!.AddAsync(ClassStream);
                await _dbContext.SaveChangesAsync();
                return ClassStream;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<ClassStream?> UpdateAsync(ClassStream classStream)
        {
            try
            {
                var existing = await _dbContext.ClassStream!.FindAsync(classStream.Id);
                existing!.Name = classStream.Name;
                existing.Code = classStream.Code;
                existing.IsActive = classStream.IsActive;
                await _dbContext.SaveChangesAsync();
                return classStream;
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
                var existing = await _dbContext.ClassStream!.FindAsync(id);
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