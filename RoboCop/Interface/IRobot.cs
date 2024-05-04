using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCop.Interface
{
    public interface IRobot
    {
        public void Place(int x, int y, string direction);
        public void Move();
        public void Left();
        public void Right();
        public string Report();


    }
}
