using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;
using System.Globalization;
using SchoolUser.Application.DTOs;

namespace SchoolUser.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string _entityName = "User";
        private readonly DBContext _dbContext;
        private readonly ICacheServices<User> _cacheServices;
        private readonly IHelperServices _helperServices;
        private const string cacheKey_GetUserById = "GetUserById";
        private const string cacheKey_GetAllUsers = "GetAllUsers";
        private const string cacheKey_GetPaginatedUsers = "GetPaginatedUsers";
        private const string student_constant = "student";
        private const string teacher_constant = "teacher";
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IGeneralUseConstants _generalUseConstants;

        public UserRepository(DBContext dbContext, ICacheServices<User> cacheServices, IReturnValueConstants returnValueConstants, IHelperServices helperServices, IGeneralUseConstants generalUseConstants)
        {
            _dbContext = dbContext;
            _cacheServices = cacheServices;
            _returnValueConstants = returnValueConstants;
            _helperServices = helperServices;
            _generalUseConstants = generalUseConstants;
        }

        private IQueryable<User> GetAllQuery()
        {
            try
            {
                return _dbContext.User!
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(u => new User
                    {
                        Id = u.Id,
                        SerialTag = u.SerialTag,
                        FullName = u.FullName,
                        EmailAddress = u.EmailAddress,
                        MobileNumber = u.MobileNumber,
                        BirthDate = u.BirthDate,
                        Gender = u.Gender,
                        Age = u.Age,
                        ProfilePictureUri = u.ProfilePictureUri != null ? u.ProfilePictureUri : null,
                        IsChangedPassword = u.IsChangedPassword,
                        PasswordSalt = u.PasswordSalt,
                        PasswordHash = u.PasswordHash,
                        IsConfirmedEmail = u.IsConfirmedEmail,
                        VerificationNumber = u.VerificationNumber,
                        VerificationExpiration = u.VerificationExpiration,
                        AccessToken = u.AccessToken != null ? u.AccessToken : null,
                        RefreshToken = u.RefreshToken != null ? u.RefreshToken : null,
                        TokenExpiration = u.TokenExpiration,
                        IsActive = u.IsActive,
                        CreatedBy = u.CreatedBy,
                        CreatedAt = u.CreatedAt,
                        UpdatedBy = u.UpdatedBy,
                        UpdatedAt = u.UpdatedAt,
                        Roles = u.UserRoles!.Select(ur => ur.Role!.Title).ToList(),
                        Student = u.UserRoles!.Any(ur => ur.Role!.Title == student_constant) ? new Student
                        {
                            Id = u.Student!.Id,
                            EntranceYear = u.Student.EntranceYear,
                            EstimatedExitYear = u.Student.EstimatedExitYear,
                            RealExitYear = u.Student.RealExitYear,
                            ExitReason = u.Student.ExitReason,
                            UserId = u.Student.UserId,
                            ClassCategoryId = u.Student.ClassCategoryId,
                            ClassSubjects = u.Student.ClassSubjectStudents == null ? new List<ClassSubject>() :
                                u.Student.ClassSubjectStudents.Select(css => css.ClassSubject!).ToList(),
                        } : null,
                        Teacher = u.UserRoles!.Any(ur => ur.Role!.Title == teacher_constant) ? new Teacher
                        {
                            Id = u.Teacher!.Id,
                            ServiceStatus = u.Teacher.ServiceStatus,
                            IsAvailable = u.Teacher.IsAvailable,
                            ResponsibilityType = u.Teacher.ResponsibilityType,
                            ResponsibilityFocus = u.Teacher.ResponsibilityFocus,
                            UserId = u.Teacher.UserId,
                            ClassCategoryId = u.Teacher.ClassCategoryId,
                            ClassSubjects = u.Teacher.ClassSubjectTeachers == null ? new List<ClassSubject>() :
                                u.Teacher.ClassSubjectTeachers.Select(cst => cst.ClassSubject!).ToList(),
                        } : null,
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_QUERY, _entityName), ex);
            }
        }

        public Task<IQueryable<User>?> GetAllUsersAsync()
        {
            try
            {
                return (Task<IQueryable<User>?>)GetAllQuery().OrderBy(u => u.FullName).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<(IEnumerable<User>?, int)> GetPaginatedUsersAsync(UsersListRequestDto listRequestDto)
        {
            try
            {
                List<User>? users = await GetAllQuery().Where(u => u.Roles!.Contains(listRequestDto.RoleTitle!)).ToListAsync();

                if (listRequestDto.IsActive == true)
                {
                    users = users.Where(u => u.IsActive == true).ToList();
                }

                int totalUsers = 0;
                int totalPages = 0;

                string current_cacheKey = "";
                string next_cacheKey = "";

                if (listRequestDto.PageNumber > 0 && listRequestDto.PageSize > 0)
                {
                    totalUsers = users.Count;
                    totalPages = (int)Math.Ceiling(totalUsers / (double)listRequestDto.PageSize);

                    current_cacheKey = $"{cacheKey_GetPaginatedUsers}_{listRequestDto.RoleTitle}_{listRequestDto.PageNumber}_{listRequestDto.PageSize}";
                    next_cacheKey = $"{cacheKey_GetPaginatedUsers}_{listRequestDto.RoleTitle}_{listRequestDto.PageNumber + 1}_{listRequestDto.PageSize}";

                    if (totalUsers < 1 || listRequestDto.PageNumber < 1 || listRequestDto.PageNumber > totalPages)
                    {
                        return (Enumerable.Empty<User>(), 0);
                    }

                    if (totalPages < 2)
                    {
                        return (users, totalUsers);
                    }

                    if (listRequestDto.PageNumber < totalPages)
                    {
                        await SetNextCacheObject(next_cacheKey, listRequestDto.PageNumber + 1, listRequestDto.PageSize);
                    }

                    return (await GetCachedObject(current_cacheKey, listRequestDto.PageNumber, listRequestDto.PageSize), totalUsers);
                }

                return (users, users.Count);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        private async Task<IEnumerable<User>?> GetCachedObject(string cacheKey, int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber == 1)
                {
                    var users = await GetAllQuery().ToListAsync();

                    if (pageNumber > 0 && pageSize > 0)
                    {
                        users = (List<User>)users.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                    }

                    // set current cache
                    _cacheServices.SetCacheObject(cacheKey, users);

                    // return cached users
                    return users;
                }

                var cachedObject = _cacheServices.TryGetObjectFromCache(cacheKey, typeof(IEnumerable<User?>));
                return (IEnumerable<User>)cachedObject!;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CACHING_OBJECT, _entityName), ex);
            }
        }

        private async Task SetNextCacheObject(string cacheKey, int pageNumber, int pageSize)
        {
            try
            {
                var users = await GetAllQuery()
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

                // set next cache
                _cacheServices.SetCacheObject(cacheKey, users);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CACHING_OBJECT, _entityName), ex);
            }
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<User?> GetByJwtTokenAsync(string jwtToken)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(u => u.AccessToken == jwtToken);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            try
            {
                return await GetAllQuery().FirstOrDefaultAsync(u => u.EmailAddress == email);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_GET, _entityName), ex);
            }
        }

        public async Task<User?> CreateAsync(User user)
        {
            try
            {
                await _dbContext.User!.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_CREATE, _entityName), ex);
            }
        }

        public async Task<User?> UpdateAsync(User user)
        {

            try
            {
                var existing = await _dbContext.User!.FindAsync(user.Id);
                existing!.FullName = user.FullName;
                existing.EmailAddress = user.EmailAddress;
                existing.MobileNumber = user.MobileNumber;
                existing.BirthDate = user.BirthDate;
                existing.Age = user.Age;
                existing.Gender = user.Gender;
                existing.IsActive = user.IsActive;
                int result = await _dbContext.SaveChangesAsync();

                if (result < 1)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName));
                }

                var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName), ex);
            }
        }

        public async Task<User?> VerifyUserAsync(User user)
        {
            try
            {
                var existing = await _dbContext.User!.FindAsync(user.Id);

                existing!.EmailAddress = user.EmailAddress;
                existing.MobileNumber = user.MobileNumber;

                existing.IsChangedPassword = user.IsChangedPassword;
                existing.PasswordHash = user.PasswordHash;
                existing.PasswordSalt = user.PasswordSalt;

                existing.IsConfirmedEmail = user.IsConfirmedEmail;
                existing.VerificationNumber = user.VerificationNumber;
                existing.VerificationExpiration = user.VerificationExpiration;

                existing.UpdatedBy = user.UpdatedBy;
                existing.UpdatedAt = user.UpdatedAt;

                int result = await _dbContext.SaveChangesAsync();

                if (result < 1)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName));
                }

                var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName), ex);
            }
        }

        public async Task<User?> ChangePasswordAsync(User user)
        {
            try
            {
                var existing = await _dbContext.User!.FindAsync(user.Id);

                existing!.IsChangedPassword = user.IsChangedPassword;
                existing.PasswordHash = user.PasswordHash;
                existing.PasswordSalt = user.PasswordSalt;

                existing.UpdatedBy = user.UpdatedBy;
                existing.UpdatedAt = user.UpdatedAt;

                int result = await _dbContext.SaveChangesAsync();

                if (result < 1)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName));
                }

                var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName), ex);
            }
        }

        public async Task<User?> UpdateTokenAsync(User user)
        {
            try
            {
                var existing = await _dbContext.User!.FindAsync(user.Id);

                if (existing == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
                }

                if (existing.AccessToken == user.AccessToken &&
                existing.RefreshToken == user.RefreshToken &&
                existing.TokenExpiration == user.TokenExpiration)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                }

                existing.AccessToken = user.AccessToken;
                existing.RefreshToken = user.RefreshToken;
                existing.TokenExpiration = user.TokenExpiration;

                existing.UpdatedBy = user.UpdatedBy;
                existing.UpdatedAt = user.UpdatedAt;

                int result = await _dbContext.SaveChangesAsync();

                if (result < 1)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName));
                }

                var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName), ex);
            }
        }

        public async Task<User?> UpdateProfilePictureUriAsync(Guid id, string uri)
        {
            try
            {
                var existing = await _dbContext.User!.FindAsync(id);

                if (existing == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
                }

                if (existing.ProfilePictureUri == uri)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                }

                existing.ProfilePictureUri = uri;

                existing.UpdatedBy = existing.FullName;
                existing.UpdatedAt = DateTime.Now;

                int result = await _dbContext.SaveChangesAsync();

                if (result < 1)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName));
                }

                var cacheKey = $"{cacheKey_GetUserById}_{existing.Id}";
                _cacheServices.RemoveCacheObject(cacheKey);

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, _entityName), ex);
            }
        }

        public async Task<bool> AutoUpdateUsersAgeAsync()
        {
            try
            {
                string today = DateTime.Now.ToString("dd-MM");

                var userList = await GetAllQuery().Where(user => EF.Functions.Like(user.BirthDate, $"{today}%")).ToListAsync();

                if (userList.Any())
                {
                    foreach (var user in userList)
                    {
                        DateTime birthdate = DateTime.ParseExact(user.BirthDate, _generalUseConstants.DateFormat, CultureInfo.InvariantCulture);
                        user.Age = _helperServices.CalculateAge(birthdate);

                        user.UpdatedBy = "System";
                        user.UpdatedAt = DateTime.Now;
                    }

                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return true;
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
                var existing = await _dbContext.User!.FindAsync(id);
                _dbContext.User.Remove(existing!);
                int result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    var cacheKey = $"{cacheKey_GetUserById}_{existing!.Id}";
                    _cacheServices.RemoveCacheObject(cacheKey);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }

        public async Task<bool> DeleteInactiveUsersAsync()
        {
            try
            {
                DateTime thresholdYears = DateTime.Now.AddYears(-5);

                var inactiveUsers = await _dbContext.User!.Where(u => u.TokenExpiration < thresholdYears && u.IsActive == false).ToListAsync();

                if (inactiveUsers.Any())
                {
                    _dbContext.User!.RemoveRange(inactiveUsers);
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }

        public async Task<bool> DeleteUnregisteredUsersAsync()
        {
            try
            {
                DateTime thresholdDays = DateTime.Now;

                var unregisteredUsers = await _dbContext.User!.Where(u => u.IsConfirmedEmail == false && u.TokenExpiration < thresholdDays).ToListAsync();

                if (unregisteredUsers.Any())
                {
                    _dbContext.User!.RemoveRange(unregisteredUsers);
                    return await _dbContext.SaveChangesAsync() > 0;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(_returnValueConstants.FAILED_DELETE, _entityName), ex);
            }
        }
    }
}