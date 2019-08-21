using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with a rocket!");
        }
    }
}
