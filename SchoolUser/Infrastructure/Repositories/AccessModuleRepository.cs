using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories
{
    public class AccessModuleRepository : IAccessModuleRepository
    {
        private const string _entityName = "Access Module";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public AccessModuleRepository(DBContext dBContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dBContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<AccessModule> GetAllQuery()
        {
            try
            {
                return _dbContext.AccessModule!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(am => new AccessModule
                    {
                        Id = am.Id,
                        Name = am.Name,
                        Roles = am.RoleAccessModules!.Select(ram => new Role
                        {
                            Id = ram.Role!.Id,
                            Title = ram.Role.Title
                        }).ToList()
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<AccessModule>?> GetAllAsync()
        {
            try
            {
                return await GetAllQuery().OrderBy(am => am.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<AccessModule?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(am => am.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<AccessModule?> GetByNameAsync(string name)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(am => am.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<AccessModule?> CreateAsync(AccessModule accessModule)
        {
            try
            {
                await _dbContext.AccessModule!.AddAsync(accessModule);
                await _dbContext.SaveChangesAsync();
                return accessModule;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<AccessModule?> UpdateAsync(AccessModule accessModule)
        {
            try
            {
                var existing = await _dbContext.AccessModule!.FindAsync(accessModule.Id);
                existing!.Name = accessModule.Name;
                await _dbContext.SaveChangesAsync();
                return accessModule;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName), ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var existing = await _dbContext.AccessModule!.FindAsync(id);
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