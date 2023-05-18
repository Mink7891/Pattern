using System;

namespace ConsoleApp1
{
    // Интерфейс для двигателя
    interface IEngine
    {
        void Install();
    }

    // Интерфейс для коробки передач
    interface ITransmission
    {
        void Install();
    }

    // Интерфейс для фабрики компонентов автомобиля
    interface ICarFactory
    {
        IEngine CreateEngine();
        ITransmission CreateTransmission();
    }

    // Реализация двигателя для спортивного автомобиля
    class SportEngine : IEngine
    {
        public void Install()
        {
            Console.WriteLine("Installing sport engine");
        }
    }

    // Реализация коробки передач для спортивного автомобиля
    class SportTransmission : ITransmission
    {
        private readonly IMediator mediator;

        public SportTransmission(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Install()
        {
            Console.WriteLine("Installing sport transmission");
            mediator.Notify(this, "Sport transmission installed");
        }
    }

    // Реализация двигателя для обычного автомобиля
    class RegularEngine : IEngine
    {
        public void Install()
        {
            Console.WriteLine("Installing regular engine");
        }
    }

    // Реализация коробки передач для обычного автомобиля
    class RegularTransmission : ITransmission
    {
        private readonly IMediator mediator;

        public RegularTransmission(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Install()
        {
            Console.WriteLine("Installing regular transmission");
            mediator.Notify(this, "Regular transmission installed");
        }
    }

    // Реализация фабрики компонентов для спортивного автомобиля
    class SportCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new SportEngine();
        }

        public ITransmission CreateTransmission()
        {
            return new SportTransmission(new CarMediator());
        }
    }

    // Реализация фабрики компонентов для обычного автомобиля
    class RegularCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new RegularEngine();
        }

        public ITransmission CreateTransmission()
        {
            return new RegularTransmission(new CarMediator());
        }
    }

    // Абстрактная фабрика для создания компонентов автомобиля
    abstract class AbstractCarFactory
    {
        public abstract IEngine CreateEngine();
        public abstract ITransmission CreateTransmission();
    }

    // Конкретная реализация абстрактной фабрики для спортивного автомобиля
    class SportCarAbstractFactory : AbstractCarFactory
    {
        public override IEngine CreateEngine()
        {
            return new SportEngine();
        }

        public override ITransmission CreateTransmission()
        {
            return new SportTransmission(new CarMediator());
        }
    }

    // Конкретная реализация абстрактной фабрики для обычного автомобиля
    class RegularCarAbstractFactory : AbstractCarFactory
    {
        public override IEngine CreateEngine()
        {
            return new RegularEngine();
        }

        public override ITransmission CreateTransmission()
        {
            return new RegularTransmission(new CarMediator());
        }
    }

    // Интерфейс посредника
    interface IMediator
    {
        void Notify(object sender, string message);
    }

    // Реализация посредника
    class CarMediator : IMediator
    {
        public void Notify(object sender, string message)
        {
            Console.WriteLine("Mediator received message: " + message);
            // Perform coordination actions here
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр абстрактной фабрики для спортивного автомобиля
            AbstractCarFactory sportCarFactory = new SportCarAbstractFactory();

            // Создаем компоненты спортивного автомобиля
            IEngine sportEngine = sportCarFactory.CreateEngine();
            ITransmission sportTransmission = sportCarFactory.CreateTransmission();

            // Устанавливаем компоненты спортивного автомобиля
            sportEngine.Install();
            sportTransmission.Install();

            Console.WriteLine();

            // Создаем экземпляр абстрактной фабрики для обычного автомобиля
            AbstractCarFactory regularCarFactory = new RegularCarAbstractFactory();

            // Создаем компоненты обычного автомобиля
            IEngine regularEngine = regularCarFactory.CreateEngine();
            ITransmission regularTransmission = regularCarFactory.CreateTransmission();

            // Устанавливаем компоненты обычного автомобиля
            regularEngine.Install();
            regularTransmission.Install();

            Console.ReadKey();
        }
    }
}
