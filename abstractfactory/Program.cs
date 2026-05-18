using System;

namespace AbstractFactory
{
    public interface ILaptop
    {
        void GetInfo();
    }

    public interface INetbook
    {
        void GetInfo();
    }

    public interface IEBook
    {
        void GetInfo();
    }

    public interface ISmartphone
    {
        void GetInfo();
    }

    public class IProneLaptop : ILaptop
    {
        public void GetInfo() => Console.WriteLine("Ноутбук: IProne Book Pro");
    }

    public class IProneNetbook : INetbook
    {
        public void GetInfo() => Console.WriteLine("Нетбук: IProne Air Mini");
    }

    public class IProneEBook : IEBook
    {
        public void GetInfo() => Console.WriteLine("Електронна книга: IProne Read");
    }

    public class IProneSmartphone : ISmartphone
    {
        public void GetInfo() => Console.WriteLine("Смартфон: IProne 15 Pro");
    }

    public class KiaomiLaptop : ILaptop
    {
        public void GetInfo() => Console.WriteLine("Ноутбук: Kiaomi Mi Notebook");
    }

    public class KiaomiNetbook : INetbook
    {
        public void GetInfo() => Console.WriteLine("Нетбук: Kiaomi Redmi Book Mini");
    }

    public class KiaomiEBook : IEBook
    {
        public void GetInfo() => Console.WriteLine("Електронна книга: Kiaomi Paperwhite");
    }

    public class KiaomiSmartphone : ISmartphone
    {
        public void GetInfo() => Console.WriteLine("Смартфон: Kiaomi 14 Ultra");
    }

    public class BalaxyLaptop : ILaptop
    {
        public void GetInfo() => Console.WriteLine("Ноутбук: Balaxy Book Ultra");
    }

    public class BalaxyNetbook : INetbook
    {
        public void GetInfo() => Console.WriteLine("Нетбук: Balaxy Go Netbook");
    }

    public class BalaxyEBook : IEBook
    {
        public void GetInfo() => Console.WriteLine("Електронна книга: Balaxy Note Read");
    }

    public class BalaxySmartphone : ISmartphone
    {
        public void GetInfo() => Console.WriteLine("Смартфон: Balaxy S26 Ultra");
    }

    public interface ITechFactory
    {
        ILaptop CreateLaptop();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartphone CreateSmartphone();
    }

    public class IProneFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public INetbook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();
        public ISmartphone CreateSmartphone() => new IProneSmartphone();
    }

    public class KiaomiFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public INetbook CreateNetbook() => new KiaomiNetbook();
        public IEBook CreateEBook() => new KiaomiEBook();
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
    }

    public class BalaxyFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public INetbook CreateNetbook() => new BalaxyNetbook();
        public IEBook CreateEBook() => new BalaxyEBook();
        public ISmartphone CreateSmartphone() => new BalaxySmartphone();
    }

    class Program
    {
        static void Main2(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ITechFactory iproneFactory = new IProneFactory();
            Console.WriteLine("--- Виробництво техніки бренду IProne ---");
            ILaptop iproneLaptop = iproneFactory.CreateLaptop();
            ISmartphone ipronePhone = iproneFactory.CreateSmartphone();
            iproneLaptop.GetInfo();
            ipronePhone.GetInfo();
            Console.WriteLine(new string('-', 40));

            ITechFactory kiaomiFactory = new KiaomiFactory();
            Console.WriteLine("--- Виробництво техніки бренду Kiaomi ---");
            INetbook kiaomiNetbook = kiaomiFactory.CreateNetbook();
            IEBook kiaomiEBook = kiaomiFactory.CreateEBook();
            kiaomiNetbook.GetInfo();
            kiaomiEBook.GetInfo();
            Console.WriteLine(new string('-', 40));

            ITechFactory balaxyFactory = new BalaxyFactory();
            Console.WriteLine("--- Виробництво техніки бренду Balaxy ---");
            ILaptop balaxyLaptop = balaxyFactory.CreateLaptop();
            ISmartphone balaxyPhone = balaxyFactory.CreateSmartphone();
            balaxyLaptop.GetInfo();
            balaxyPhone.GetInfo();
            Console.WriteLine(new string('-', 40));

            Console.ReadKey();
        }
    }
}