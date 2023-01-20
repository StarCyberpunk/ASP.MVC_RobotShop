using second.DAL.Interfaces;
using second.DAL.Repositories;
using second.Domain.Entity;
using second.Domain.Enum;
using second.Domain.Response;
using second.Domain.ViewModels;
using second.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace second.Service.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IBaseRepository<Profile> _PrRepo;
        public ProfileService(IBaseRepository<Profile> repo)
        {
            _PrRepo = repo;
        }

        public async Task<BaseResponse<bool>> CreateProfile(ProfileViewModel p)
        {
            var baseRepository = new BaseResponse<bool>();
            try
            {
                Profile r = new Profile()
                {
                    

                };
                await _PrRepo.Create(r);
                baseRepository.Description = "Saved";
                baseRepository.StatusCode = StatusCode.OK;
                baseRepository.Data = true;
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[CreateProfile]:{ex.Message}";
                z.Data = false;
                return z;
            }
            return baseRepository;
        }

        public async Task<BaseResponse<bool>> DeleteProfile(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<Profile>> EditProfile(int id, ProfileViewModel pvm)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<Profile>> GetProfileById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
