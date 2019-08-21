using System;

namespace SimUDuck
{
    public abstract class Duck
    {
        protected IFlyBehavior _flyBehavior;
        protected IQuackBehavior _quackBehavior;

        protected Duck() { }

        public abstract void Display();

        public void PerformFly()
        {
            FlyBehavior.Fly();
        }

        public void PerformQuack()
        {
            QuackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }

        public IFlyBehavior FlyBehavior
        {
            get => _flyBehavior;
            set => _flyBehavior = value;
        }

        public IQuackBehavior QuackBehavior
        {
            get => _quackBehavior;
            set => _quackBehavior = value;
        }
    }
}
