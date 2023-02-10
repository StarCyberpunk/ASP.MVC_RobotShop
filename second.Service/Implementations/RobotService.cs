using second.DAL.Interfaces;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace second.Service.Implementations
{
    public class RobotService : IRobotService
    {
        private readonly IBaseRepository<Robot> _RoRepo;
        public RobotService(IBaseRepository<Robot> repo)
        {
            _RoRepo = repo;
        }

        public async Task<BaseResponse<bool>> CreateRobot(RobotViewModel rvm)
        {
           var baseRepository= new BaseResponse<bool>();
            try
            {
                Robot r = new Robot()
                {
                    Name = rvm.Name,
                    Model=rvm.Model,
                    DateCreate=DateTime.Now,
                    Speed=rvm.Speed,
                    Description=rvm.Description,
                    Price=rvm.Price,
                    TypeRobot=(TypeRobot)Enum.Parse(typeof(TypeRobot),rvm.TypeRobot)
                    
                };
                await _RoRepo.Create(r);
                baseRepository.Description = "Saved";
                baseRepository.StatusCode = StatusCode.OK;
                baseRepository.Data = true;
            }
            catch(Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[CreateRobot]:{ex.Message}";
                z.Data = false;
                return z;
            }
            return baseRepository;
        }
        public async Task<BaseResponse<bool>> DeleteRobot(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
               Robot resp = await _RoRepo.Get(id);
                if (resp == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                else
                {
                   await _RoRepo.Delete(resp);
                    baseResponse.Description = "Удалено";
                    baseResponse.Data = true;
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    return baseResponse;
                }
                
            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool> ();
                z.Description = $"[DeleteRobot]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Robot>> GetByName(string name)
        {
            var baseResponse = new BaseResponse<Robot>();
            try
            {
                /* var robot = await _RoRepo.GetByName(name);*/
                var robot =  _RoRepo.Select().FirstOrDefault(x => x.Name == name);
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
                var z = new BaseResponse<Robot>();
                z.Description = $"[GetByName]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Robot>> GetRobotById(int id)
        {
            var baseResponse = new BaseResponse<Robot>();
            try
            {
                var robot = await _RoRepo.Get(id);
                if (robot==null)
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
                var z = new BaseResponse<Robot>();
                z.Description = $"[GetRobotById]:{ex.Message}";

                return z;
            }
        }
        public async Task<BaseResponse<IEnumerable<Robot>>> GetAllRobots()
        {
            var baseResponse = new BaseResponse<IEnumerable<Robot>>();
            try
            {
                var robots = _RoRepo.Select().ToList();
                if (robots.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 эл-в";
                }
                else
                {
                    baseResponse.Description = String.Format("Найдено {0} эл-в", robots.Count);
                    baseResponse.Data = robots;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<IEnumerable<Robot>>();
                z.Description = $"[GetRobots]:{ex.Message}";

                return z;
            }
        }

        public async Task<BaseResponse<Robot>> EditRobot(int id, RobotViewModel rvm)
        {
            var baseResponse = new BaseResponse<Robot>();
            try
            {
                var robot = await _RoRepo.Get(id);
                if (robot == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;
                }
                else
                {
                    robot.Description = rvm.Description;
                    robot.DateCreate = rvm.DateCreate;
                    robot.Price = rvm.Price;
                    robot.Name = rvm.Name;
                    robot.Speed = rvm.Speed;
                    robot.Model = rvm.Model;

                    await _RoRepo.Update(robot);

                    baseResponse.Data = robot;
                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Robot>();
                z.Description = $"[EditRobot]:{ex.Message}";

                return z;
            }
        }

        public RobotViewModel RobotToRWM(Robot r)
        {
            RobotViewModel rw = new RobotViewModel();
            rw.Id = r.Id;
            rw.Description = r.Description;
            rw.DateCreate = r.DateCreate;
            rw.Price = r.Price;
            rw.Name = r.Name;
            rw.Speed = r.Speed;
            rw.Model = r.Model;
            return rw;
        }

        public async Task<BaseResponse<IEnumerable<Robot>>> Search(string input)
        {
            var baseResponse = new BaseResponse<IEnumerable<Robot>>();
            string pattern = String.Format("@(\\w*){0}(\\w*)", input);
            Regex inp = new Regex(pattern);
            try
            {
                var robots = _RoRepo.Select().Where(x=>x.Name.ToLower()==input.ToLower()).ToList();
                if (robots.Count == 0)
                {
                    /* robots = _RoRepo.Select().Where(x => inp.IsMatch(x.Name)).ToList();*/
                    baseResponse.Description = String.Format("Найдено 0 эл-в");
                }
                else
                {
                    baseResponse.Description = String.Format("Найдено {0} эл-в", robots.Count);
                    baseResponse.Data = robots;
                }
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<IEnumerable<Robot>>();
                z.Description = $"[GetRobots]:{ex.Message}";

                return z;
            }
        }
    }
}
