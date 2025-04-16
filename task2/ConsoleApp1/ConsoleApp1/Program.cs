using System;

namespace Program
{
    interface IDevice
    {
        int GetStorage();
        string GetModelInfo();
    }

    interface IFactory
    {
        IDevice CreateSmartphone(string name, int storage, string info);
        IDevice CreateEBook(string name, int storage, string info);
        IDevice CreateNetBook(string name, int storage, string info);
    }

    abstract class Device : IDevice
    {
        public string Name { get; set; }
        public int Storage { get; set; }
        public string Info { get; set; }

        protected Device(string name, int storage, string info)
        {
            Name = name;
            Storage = storage;
            Info = info;
        }

        public abstract string GetModelInfo();
        public abstract int GetStorage();
    }

    class Smartphone : Device
    {
        public Smartphone(string name, int storage, string info)
            : base(name, storage, info) { }

        public override string GetModelInfo() => $"Smartphone: {Name} - {Info}";
        public override int GetStorage() => Storage;
    }

    class EBook : Device
    {
        public EBook(string name, int storage, string info)
            : base(name, storage, info) { }

        public override string GetModelInfo() => $"E-Book: {Name} - {Info}";
        public override int GetStorage() => Storage;
    }

    class NetBook : Device
    {
        public NetBook(string name, int storage, string info)
            : base(name, storage, info) { }

        public override string GetModelInfo() => $"NetBook: {Name} - {Info}";
        public override int GetStorage() => Storage;
    }

    class KiaomiFactory : IFactory
    {
        public IDevice CreateSmartphone(string name, int storage, string info)
            => new Smartphone("Kiaomi " + name, storage, info);

        public IDevice CreateEBook(string name, int storage, string info)
            => new EBook("Kiaomi " + name, storage, info);

        public IDevice CreateNetBook(string name, int storage, string info)
            => new NetBook("Kiaomi " + name, storage, info);
    }

    class IProneFactory : IFactory
    {
        public IDevice CreateSmartphone(string name, int storage, string info)
            => new Smartphone("iProne " + name, storage, info);

        public IDevice CreateEBook(string name, int storage, string info)
            => new EBook("iProne " + name, storage, info);

        public IDevice CreateNetBook(string name, int storage, string info)
            => new NetBook("iProne " + name, storage, info);
    }
    class BalaxyFabric : IFactory
    {
        public IDevice CreateSmartphone(string name, int storage, string info)
           => new Smartphone("Balaxy " + name, storage, info);

        public IDevice CreateEBook(string name, int storage, string info)
            => new EBook("Balaxy " + name, storage, info);

        public IDevice CreateNetBook(string name, int storage, string info)
            => new NetBook("Balaxy " + name, storage, info);
    }
    class Program
    {
        static void Main()
        {

            IFactory kiaomiFactory = new KiaomiFactory();
            IFactory iproneFactory = new IProneFactory();

            IDevice ebook = kiaomiFactory.CreateEBook("ReadMaster", 32, "Backlit display, e-ink");
            Console.WriteLine(ebook.GetModelInfo());
            Console.WriteLine("Storage: " + ebook.GetStorage() + " GB\n");

            IDevice phone = iproneFactory.CreateSmartphone("X12 Pro", 256, "Face ID, OLED screen");
            Console.WriteLine(phone.GetModelInfo());
            Console.WriteLine("Storage: " + phone.GetStorage() + " GB\n");

            IDevice netbook = kiaomiFactory.CreateNetBook("LiteBook", 128, "Lightweight, 10h battery");
            Console.WriteLine(netbook.GetModelInfo());
            Console.WriteLine("Storage: " + netbook.GetStorage() + " GB\n");
        }
    }
}
