using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    // Интерфейс для подвески
    interface ISuspension
    {
        void Install();
    }

    // Интерфейс для фабрики компонентов автомобиля
    interface ICarFactory
    {
        IEngine CreateEngine();
        ITransmission CreateTransmission();
        ISuspension CreateSuspension();
    }
    // Реализация двигателя для спорткара
    class SportEngine : IEngine
    {
        public void Install()
        {
            Console.WriteLine("Installing sport engine");
        }
    }

    // Реализация коробки передач для спорткара
    class SportTransmission : ITransmission
    {
        public void Install()
        {
            Console.WriteLine("Installing sport transmission");
        }
    }

    // Реализация подвески для спорткара
    class SportSuspension : ISuspension
    {
        public void Install()
        {
            Console.WriteLine("Installing sport suspension");
        }
    }

    // Реализация фабрики компонентов для спорткара
    class SportCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new SportEngine();
        }

        public ITransmission CreateTransmission()
        {
            return new SportTransmission();
        }

        public ISuspension CreateSuspension()
        {
            return new SportSuspension();
        }
    }
    // Посредник, который связывает компоненты автомобиля и обрабатывает заказы
    class CarMediator
    {
        private IEngine engine;
        private ITransmission transmission;
        private ISuspension suspension;

        public CarMediator(IEngine engine, ITransmission transmission, ISuspension suspension)
        {
            this.engine = engine;
            this.transmission = transmission;
            this.suspension = suspension;
        }

        public void BuildCar()
        {
            engine.Install();
            transmission.Install();
            suspension.Install();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр фабрики для спорткара
            ICarFactory factory = new SportCarFactory();

            // Создаем компоненты автомобиля, используя фабрику
            IEngine engine = factory.CreateEngine();
            ITransmission transmission = factory.CreateTransmission();
            ISuspension suspension = factory.CreateSuspension();

            // Создаем посредника и передаем ему компоненты автомобиля
            CarMediator mediator = new CarMediator(engine, transmission, suspension);

            // Строим автомобиль
            mediator.BuildCar();

            Console.ReadKey();
        }
    }
}
