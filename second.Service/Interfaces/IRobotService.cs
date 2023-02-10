using second.Domain.Entity;
using second.Domain.Response;
using second.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.Service.Interfaces
{
    public interface IRobotService
    {
        Task<BaseResponse<IEnumerable<Robot>>> GetAllRobots();
        Task<BaseResponse<bool>> CreateRobot(RobotViewModel r);
        Task<BaseResponse<Robot>> GetRobotById(int id);
        Task<BaseResponse<bool>> DeleteRobot(int id);
        Task<BaseResponse<Robot>> GetByName(string name);
        Task<BaseResponse<Robot>> EditRobot(int id, RobotViewModel rvm);
        Task<BaseResponse<IEnumerable<Robot>>> Search(string input);
        RobotViewModel RobotToRWM(Robot data);
    }
}
