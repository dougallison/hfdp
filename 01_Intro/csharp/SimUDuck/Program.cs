namespace SimUDuck
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();
        }
    }
}
