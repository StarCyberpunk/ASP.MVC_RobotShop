﻿using second.Domain.Entity;
using second.Domain.Response;
using second.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.Service.Interfaces
{
    public interface IProfileService
    {
       
        Task<BaseResponse<bool>> CreateProfile(ProfileViewModel p);
        Task<BaseResponse<Profile>> GetProfileByUserId(int id);
        Task<BaseResponse<bool>> DeleteProfile(int id);

        Task<BaseResponse<Profile>> EditProfile( ProfileViewModel pvm);
        ProfileViewModel ProfileToPWM(Profile data);
    }
}
