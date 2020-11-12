using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbstractInterface
{
    public abstract class Animal
    {
        public int Age { get; set; }

        public string Rasa { get; set; }

        //public void Eat()
        //{
        //    Console.WriteLine("The animal is eating");
        //    Thread.Sleep(5000);
        //}

        //public virtual void Running()
        //{

        //    Console.WriteLine("The animal is running.");
        //    Thread.Sleep(4000);
        //}
    }

    public class Dog : Animal, IAnimal
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public /*override*/ void Running()
        {
            Console.WriteLine("This animal is a dog.");
        }
    }

    public interface IAnimal
    {
        void Eat();

        void Running();
    }

    public class Cat : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("The cat is eating");
            Thread.Sleep(3000);
        }

        public void Running()
        {
            Console.WriteLine("The cat is running");
            Thread.Sleep(6000);
        }
    }
}
