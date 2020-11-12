using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Age = 20;
            dog.Rasa = "Pitbul";

            dog.Running();

            Animal animal = new Dog();

            IAnimal cat = new Cat();
        }
    }
}
