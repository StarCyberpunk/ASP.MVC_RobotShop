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
        /// <summary>
        /// Не доделано
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
            var baseResponse = new BaseResponse<bool>();
            try
            {
                Profile resp = await _PrRepo.Get(id);
                if (resp == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                else
                {
                    await _PrRepo.Delete(resp);
                    baseResponse.Description = "Удалено";
                    baseResponse.Data = true;
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    return baseResponse;
                }

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[DeleteProfile]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Profile>> EditProfile(int id, ProfileViewModel pvm)
        {
            var baseResponse = new BaseResponse<Profile>();
            try
            {
                var robot = await _PrRepo.Get(id);
                if (robot == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;
                }
                else
                {
                   /* robot.Description = rvm.Description;
                    robot.DateCreate = rvm.DateCreate;
                    robot.Price = rvm.Price;
                    robot.Name = rvm.Name;
                    robot.Speed = rvm.Speed;
                    robot.Model = rvm.Model;

                    await _RoRepo.Update(robot);*/

                    baseResponse.Data = robot;
                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Profile>();
                z.Description = $"[EditProfile]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Profile>> GetProfileByUserId(int id)
        {
            var baseResponse = new BaseResponse<Profile>();
            try
            {
                var robot = await _PrRepo.Get(id);
                if (robot == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;

                }
                else
                {
                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    baseResponse.Data = robot;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Profile>();
                z.Description = $"[GetProfileById]:{ex.Message}";

                return z;
            }
        }
    }
}
