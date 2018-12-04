using System;

namespace task11
{
    public interface IComputer
    {
        void Do();
    }

    public interface IPlace
    {
        IComputer createComp();
        IPrinter createPrint();
    }

    public interface IPrinter
    {
        void Do();
    }

    public class OfficeComp : IComputer
    {
        public void Do()
        { Console.WriteLine("Офисный компьютер"); }
    }

    public class GameComp : IComputer
    {
        public void Do()
        { Console.WriteLine("Игровой компьютер"); }
    }

    public class LaserPrinter : IPrinter
    {
        public void Do() { Console.WriteLine("Лазерный принтер"); }
    }

    public class InjektPrinter : IPrinter
    {
        public void Do()
        { Console.WriteLine("Струйный принтер"); }
    }

    public class House : IPlace
    {
        public IComputer createComp()
        {
            return new GameComp();
        }
        public IPrinter createPrint()
        {
            return new InjektPrinter();
        }
    }

    public class Office : IPlace
    {
        public IComputer createComp()
        {
            return new OfficeComp();
        }
        public IPrinter createPrint()
        {
            return new LaserPrinter();
        }
    }

    public class Client
    {
        private IComputer abstractComp;
        private IPrinter abstractPrinter;

        public Client(IPlace place)
        {
            abstractComp = place.createComp();
            abstractPrinter = place.createPrint();
        }

        public void Run()
        {
            abstractPrinter.Do();
            abstractComp.Do();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("0 : Бинарное дерево \n" +
                "1 : Абстрактная фабрика \n" +
                "? : ");
            int switcher = int.Parse(Console.ReadLine());
            switch (switcher)
            {
                case 0:
                    var binaryTree1 =
                new BinarySearchTree<Test>(new Test[]
                {
                    new Test("Tyler", "History", 10, "01/10/18"),
                    new Test("Mark", "History", 5, "01/10/18"),
                    new Test("John", "History", 3, "01/10/18"),
                    new Test("Joseph", "History", 1, "01/10/18"),
                    new Test("Boris", "History", 6, "01/10/18"),
                    new Test("Alex", "History", 9, "01/10/18")
                });

                    foreach (Test b in binaryTree1.InOrder())
                        Console.Write(b + "\n");

                    Console.Write("\n\n");

                    var binaryTree2 =
                        new BinarySearchTree<Test>(new Test[]
                        {
                    new Test("Alex", "Biology", 3, "02/10/18"),
                    new Test("Boris", "Biology", 4, "02/10/18"),
                    new Test("Joseph", "Biology", 7, "02/10/18"),
                    new Test("John", "Biology", 2, "02/10/18"),
                    new Test("Mark", "Biology", 1, "02/10/18"),
                    new Test("Tyler", "Biology", 10, "02/10/18")
                        }, new CompareByStudent());

                    foreach (Test b in binaryTree2.InOrder())
                        Console.Write(b + "\n");      
                    break;

                case 1:
                    IPlace house = new House();
                    Client cl1 = new Client(house);
                    cl1.Run();

                    IPlace office = new Office();
                    Client cl2 = new Client(office);
                    cl2.Run();

                    break;
            }
            Console.ReadKey();
        }
    }
}
