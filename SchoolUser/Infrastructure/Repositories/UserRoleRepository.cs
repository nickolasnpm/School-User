using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private const string _entityName = "UserRole";
    private readonly DBContext _dbContext;
    private readonly IReturnValueConstants _returnValueConstants;
    public UserRoleRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
    {
        _dbContext = dbContext;
        _returnValueConstants = returnValueConstants;
    }

    public async Task<UserRole?> CreateAsync(UserRole userRole)
    {
        try
        {
            await _dbContext.UserRole!.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();
            return userRole;
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
            var existing = await _dbContext.UserRole!.FindAsync(id);
            _dbContext.Remove(existing!);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
        }
    }
}
