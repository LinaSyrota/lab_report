using System;
using System.Threading;

namespace _2
{
    class Program
    {
        static (bool, Animal, string) Sense(Animal predator, Animal[] animals)
        {  
            foreach (Animal prey in animals)
            {
                if (prey is Prey)
                {
                    bool flag;
                    string message;
                    (bool, string) mes;

                    mes = ((Predator)predator).SensePrey(prey, predator, 5, 1);

                    flag = mes.Item1;
                    message = mes.Item2;
                    
                    return (flag, prey, message);
                }
            }

            return (false, animals[0], null);
        }

        static void Main(string[] args)
        {
            string[,] field = new string[10,10];
            
            Field f = new Field(field);
            field = f.CreateField(field);
           
            AnimalFactory[] factories = new AnimalFactory[2];
            factories[0] = new PredatorFactory();
            factories[1] = new PreyFactory();

            Animal[] animals = new Animal[3];
            string[] names = new string[3] { "Predator_1", "Prey", "Predator_2" };
            for (int i = 0; i < 3; i++)
            {
                int x = 2 + i * 3;
                int y = 2 + i * 3;
                animals[i] = factories[i % 2].CreateAnimal(x, y, names[i]);
            }

            int n = 0;
            var sensed = (false, animals[0], "");

            while (n <= 10)
            {
                foreach (Animal animal in animals)
                {
                    if (animal is Predator)
                        sensed = Sense(animal, animals);

                    animal.Move(animal, sensed, field);
                }

                n++;
            }

            Console.ReadLine();
        }
    }
}




