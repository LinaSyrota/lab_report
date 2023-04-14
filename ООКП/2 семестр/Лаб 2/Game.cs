using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace lab_2
{
    class Game
    {
        private List<LivingCreature> _livingCreatures = new List<LivingCreature>();
        private LivingCreatureFactory _livingCreatureFactory;

        public Game(LivingCreatureFactory livingCreatureFactory)
        {
            _livingCreatureFactory = livingCreatureFactory;
        }
        public void Initialize(int predatorCount, int preyCount)
        {
            for (int i = 0; i < predatorCount; i++)
            {
                Predator predator = _livingCreatureFactory.CreatePredator(10 + i * 20, 10);
                _livingCreatures.Add(predator);
            }

            for (int i = 0; i < preyCount; i++)
            {
                Prey prey = _livingCreatureFactory.CreatePrey(50 + i * 20, 50);
                _livingCreatures.Add(prey);
            }
        }

        public void Play()
        {
            while (true)
            {
                // Move all creatures
                foreach (LivingCreature creature in _livingCreatures)
                {
                    creature.Move();
                }

                // Check for predator-prey interactions
                List<Predator> predators = _livingCreatures.OfType<Predator>().ToList();
                List<Prey> preys = _livingCreatures.OfType<Prey>().ToList();
                foreach (Predator predator in predators)
                {
                    foreach (Prey prey in preys)
                    {
                        if (predator.CanSwallowPrey(prey))
                        {
                            _livingCreatures.Remove(prey);
                            Console.WriteLine($"Predator at ({predator.X},{predator.Y}) swallowed prey at ({prey.X},{prey.Y})");
                        }
                    }
                }

                // Check for game over condition
                if (preys.Count == 0)
                {
                    Console.WriteLine("Game over: all preys are eaten");
                    break;
                }

                // Wait for a short time before the next iteration
                Thread.Sleep(100);
            }
        }
    }
}
