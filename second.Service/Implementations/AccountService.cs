using Microsoft.Extensions.Logging;
using second.DAL.Interfaces;
using second.Domain.Entity;
using second.Domain.Enum;
using second.Domain.Helpers;
using second.Domain.Response;
using second.Domain.ViewModels;
using second.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace second.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUserRepository userRepository, ILogger<AccountService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {

            try
            {
                var user = await _userRepository.GetByLogin(model.Login);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                    };
                }

                user = new User()
                {
                    Login = model.Login,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password),
                };

                await _userRepository.Create(user);

                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.GetByLogin(model.Login);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль или логин"
                    };
                }
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

       

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<BaseResponse<IEnumerable<User>>> GetAllUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var users = await _userRepository.Select();
                if (users.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 эл-в";
                }
                else
                {
                    baseResponse.Description = String.Format("Найдено {0} эл-в", users.Count);
                    baseResponse.Data = users;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<IEnumerable<User>>();
                z.Description = $"[GetUsers]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<User>> GetUser(string name)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = await _userRepository.GetByLogin(name);
                if (user==null)
                {
                    baseResponse.Description = "Не найдено";
                }
                else
                {
                    baseResponse.Data = user;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<User>();
                z.Description = $"[GetUser]:{ex.Message}";

                return z;
            }
        }
    }
}
