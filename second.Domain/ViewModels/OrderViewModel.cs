using second.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.Domain.ViewModels
{
    public class OrderViewModel
    {
        public long Id;
        public string RobotName;
        public double Speed;
        public TypeRobot TypeRobot;
        public string Model;
    }
}
