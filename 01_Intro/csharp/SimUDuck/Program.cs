using System;

namespace SimUDuck
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();

            Console.WriteLine();

            var model = new ModelDuck();
            model.PerformFly();
            model.FlyBehavior = new FlyRocketPowered();
            model.PerformFly();
        }
    }
}
