using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private const string _entityName = "Role";
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;

        public RoleRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        private IQueryable<Role> GetAllQuery()
        {
            try
            {
                return _dbContext.Role!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(r => new Role
                    {
                        Id = r.Id,
                        Title = r.Title,
                        AccessModules = r.RoleAccessModules!.Select(ram => new AccessModule
                        {
                            Id = ram.AccessModule!.Id,
                            Name = ram.AccessModule.Name
                        }).ToList()
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public async Task<IEnumerable<Role>?> GetAllAsync()
        {
            try
            {
                return await GetAllQuery().OrderBy(r => r.Title).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(r => r.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Role?> GetByTitleAsync(string title)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(r => r.Title == title);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<Role?> CreateAsync(Role role)
        {
            try
            {
                await _dbContext.Role!.AddAsync(role);
                await _dbContext.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<Role?> UpdateAsync(Role role)
        {
            try
            {
                var existing = await _dbContext.Role!.FindAsync(role.Id);
                existing!.Title = role.Title;
                await _dbContext.SaveChangesAsync();
                return role;
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
                var existing = await _dbContext.Role!.FindAsync(id);
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