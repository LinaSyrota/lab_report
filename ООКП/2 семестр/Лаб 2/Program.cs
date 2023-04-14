using System;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            LivingCreatureFactory livingCreatureFactory = new RandomLivingCreatureFactory();
            Game game = new Game(livingCreatureFactory);
            game.Initialize(3, 10);
            game.Play();
        }
    }
}
