using second.Domain.Entity;
using second.Domain.Response;
using second.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace second.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register( RegisterViewModel rvm);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);


    }
}
