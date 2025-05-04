using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Infrastructure.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private const string _entityName = "Batch";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public BatchRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<Batch> GetAllQuery()
        {
            try
            {
                return _dbContext.Batch!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(b => new Batch
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Code = b.Code,
                        IsActive = b.IsActive,
                        TeacherId = b.TeacherId,
                        ClassCategories = b.ClassCategories!.Where(cc => cc.BatchId == b.Id).ToList(),
                        ClassStreams = b.ClassCategories!.Select(cc => cc.ClassStream!.Name).ToList(),
                        ClassRanks = b.ClassCategories!.Select(cc => cc.ClassRank!.Name).ToList()
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<Batch>?> GetAllAsync(bool? isActive)
        {
            try
            {
                IQueryable<Batch> query = GetAllQuery();

                if (isActive.HasValue)
                {
                    query = query.Where(b => b.IsActive == isActive);
                }

                return await query.OrderBy(b => b.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Batch?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Batch?> GetByNameAsync(string name)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Batch?> CreateAsync(Batch batch)
        {
            try
            {
                await _dbContext.Batch!.AddAsync(batch);
                await _dbContext.SaveChangesAsync();
                return batch;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<Batch?> UpdateAsync(Batch batch)
        {
            try
            {
                var existing = await _dbContext.Batch!.FindAsync(batch.Id);
                existing!.Name = batch.Name;
                existing.Code = batch.Code;
                existing.IsActive = batch.IsActive;
                existing.TeacherId = batch.TeacherId;
                await _dbContext.SaveChangesAsync();
                return batch;
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
                var existing = await _dbContext.Batch!.FindAsync(id);
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