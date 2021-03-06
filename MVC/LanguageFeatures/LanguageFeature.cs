using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

    internal sealed class ConstraintClass // ключевое слово where constraint(ограничение) обобщенных типов
    {
        public static T Min<T>(T o1, T o2) where T : IComparable
        {
            if (o1.CompareTo(o2) < 0) return o1;
            return o2;
        }
    }


    internal sealed class Node<T> // обобщенные типы 
    {
        public T Data;
        public Node<T> Next;

        public Node(T Data, Node<T> Next)
        {
            this.Data = Data;
            this.Next = Next;
        }

        public Node(T data) : this(data, null)
        {

        }

        public override string ToString()
        {
            return Data.ToString() + ((Next!=null) ? Next.ToString() : null);
        }

    }


    class CounterClass // event 
    {
        public delegate void MethodContainer();

        public event MethodContainer onCount;

        public void Count()
        {
            for (int i = 0; i < 100; i++)
                if (i == 71) onCount();

        }

    }

    class Handler1 // event class
    {
        public void Message()
        {
            Console.WriteLine("Уже 71!");
        }
    }

    class Handler2 // event class 
    {
        public void Message()
        {
            Console.WriteLine("И впрямь пора действовать!");
        }
    }



    delegate int Compute(int a, int b); // делегат


    sealed class Pull
    {
        public int Counter { get; set; }

        public static implicit operator Pull(int value) // неявное преобразование
        {
            return new Pull { Counter = value };
        }

        public static explicit operator int(Pull value) // явное преобразование 
        {
            return value.Counter;
        }

    }

    partial class Action // частичные методы
    {
        partial void Method(int a, int b);

        public void AddMethod(int a, int b)
        {
            Method(a, b);
        }

    }

    partial class Action
    {
        partial void Method(int a, int b)
        {
            Console.WriteLine("Hoi!");
        }

        public void MinusMethod(int a, int b)
        {
            Method(a, b);
            Console.WriteLine("Ji!");
        }

    }

    class RefAndOut
    {
        public static void Change(ref int a, out int b) // обычная передача - копирует значение не меняя оригинал ref - дает прямую ссылку на переменную и при этом передает её значение out - Дает прямую ссылку на переменную, но !Не передает её значение
        {
            a++;
            b = a + 5;
            Console.WriteLine($"A = {a}, B= {b}");
        }
    }

    class MathOperation // перечислимые тип, enum
    {
        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public static void DoMath(double x, double y, Operation o)
        {
            double result = 0;

            switch(o)
            {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subtract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
            }

            Console.WriteLine("Result : " + result);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
             int a = 5;   
             int b;
            // RefAndOut.Change(ref a, out b); вызов ref and out

            //Compute comp = Add; // вызов делегата
            //Console.WriteLine(comp(a, b));



            /* вызов event(событий)
            CounterClass counter = new CounterClass();
            Handler1 hand1 = new Handler1();
            Handler2 hand2 = new Handler2();

            counter.onCount += hand1.Message;
            counter.onCount += hand2.Message;

            counter.Count();
            */



            //Action act = new Action(); частичные классы 
            //act.MinusMethod(5, 6); 

            /*
            Node<Char> node = new Node<Char>('C');
            node = new Node<char>('B', node);
            node = new Node<char>('A', node);
            Console.WriteLine(node.ToString());
            */

           // MathOperation.DoMath(25, 5, MathOperation.Operation.Divide); перечислимые типы


            Console.ReadLine();
        }

        private static void Counter_onCount()
        {
            throw new NotImplementedException();
        }

        public static int Add(int a, int b) // методы делегата
        {
            return a + b;
        }

        public static int Multiply(int a, int b) // методы делегата 
        {
            return a * b;
        }

    }


    public static class StringBuilderExtensions 
    {
        public static int IndexOf(this StringBuilder sb, char value) // метод расширения 
        {
            for (int index = 0; index < sb.Length; index++)
            {
                if (sb[index] == value) return index;
            }
            return -1;
        }
    }




}