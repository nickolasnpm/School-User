using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassRankRepository : IClassRankRepository
    {
        private const string _entityName = "Class Type";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public ClassRankRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<ClassRank> GetAllQuery()
        {
            try
            {
                return _dbContext.ClassRank!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(ct => new ClassRank
                    {
                        Id = ct.Id,
                        Name = ct.Name,
                        Code = ct.Code,
                        IsActive = ct.IsActive,
                        ClassCategories = ct.ClassCategories!.Where(cc => cc.ClassRankId == ct.Id).Distinct().ToList(),
                        ClassStreams = ct.ClassCategories!.Select(cc => cc.ClassStream!.Name).Distinct().ToList(),
                        Batches = ct.ClassCategories!.Select(cc => cc.Batch!.Name).Distinct().ToList()
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<ClassRank>?> GetAllAsync(bool? isActive = null)
        {
            try
            {
                IQueryable<ClassRank> query = GetAllQuery();

                if (isActive.HasValue)
                {
                    query = query.Where(ct => ct.IsActive == isActive);
                }

                return await query.OrderBy(ct => ct.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassRank?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(ct => ct.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassRank?> GetByNameAsync(string Name)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(ct => ct.Name == Name);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<ClassRank?> CreateAsync(ClassRank classRank)
        {
            try
            {
                await _dbContext.ClassRank!.AddAsync(classRank);
                await _dbContext.SaveChangesAsync();
                return classRank;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<ClassRank?> UpdateAsync(ClassRank classRank)
        {
            try
            {
                var existing = await _dbContext.ClassRank!.FindAsync(classRank.Id);
                existing!.Name = classRank.Name;
                existing.Code = classRank.Code;
                existing.IsActive = classRank.IsActive;
                await _dbContext.SaveChangesAsync();
                return classRank;
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
                var existing = await _dbContext.ClassRank!.FindAsync(id);
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