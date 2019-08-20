using System;

namespace SimUDuck
{
    public class Quacky : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack");
        }
    }
}