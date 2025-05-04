using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories
{
    public class RoleAccessModuleRepository : IRoleAccessModuleRepository
    {
        private const string _entityName = "Role Access Module";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public RoleAccessModuleRepository(DBContext dBContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dBContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<RoleAccessModule> GetAllQuery()
        {
            try
            {
                return _dbContext.RoleAccessModule!.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<RoleAccessModule>?> GetByRoleIdAsync(Guid roleId)
        {
            try
            {
                return await GetAllQuery().Where(ram => ram.RoleId == roleId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<IEnumerable<RoleAccessModule>?> GetByAccessModuleIdAsync(Guid accessModuleId)
        {
            try
            {
                return await GetAllQuery().Where(ram => ram.AccessModuleId == accessModuleId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<RoleAccessModule?> CreateAsync(RoleAccessModule roleAccessModule)
        {
            try
            {
                await _dbContext.RoleAccessModule!.AddAsync(roleAccessModule);
                await _dbContext.SaveChangesAsync();
                return roleAccessModule;
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
                var existing = await _dbContext.RoleAccessModule!.FindAsync(id);
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