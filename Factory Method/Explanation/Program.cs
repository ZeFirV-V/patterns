namespace Explanation
{
    class Client
    {
        /// <summary>
        /// Переключение на следующее сообщение.
        /// </summary>
        private void Next()
        {
            Console.WriteLine(" \n Нажмите `Enter` для продолжения.");
            Console.ReadLine();
        }
        /// <summary>
        /// Сообщение с теорией.
        /// </summary>
        private void PrintMessage()
        {
            Console.WriteLine("Разбор паттерна `Фабричный метод`.");
            Next();
            Console.WriteLine("Пример из refactoring guru");
            Next();
            Console.WriteLine("Представьте, что вы создаёте программу управления грузовыми перевозками. " +
                " Сперва вы рассчитываете перевозить товары только на автомобилях. " +
                " Поэтому весь ваш код работает с объектами класса Грузовик." +
                " Большая часть существующего кода жёстко привязана к классам Грузовиков. " +
                " Чтобы добавить в программу классы морских Судов, понадобится перелопатить всю программу. " +
                " Более того, если вы потом решите добавить в программу ещё один вид транспорта, то всю эту работу придётся повторить.");
            Next();
            Console.WriteLine("Фабричный метод — это порождающий паттерн проектирования, " +
                "который определяет общий интерфейс для создания объектов в суперклассе, " +
                "позволяя подклассам изменять тип создаваемых объектов.");
            Next();
            Console.WriteLine("Своими словами. Мы создаем общий интерфейс." +
                " Создание объектов мы передаем подклассам, а основной код работает с абстракциями." +
                " Из-за этого есть возможность гибко менять поведение системы. " +
                " Мы можем добавлять новые подклассы и не вносить изменения в основной код. " +
                " Так мы изолируем основной код от создания конкретных объектов. " +
                " Этим повышаем поддерживаемость и гибкость программы ");
            Next();
            Console.WriteLine("Дальше пойдет пример с катерами и грузовиками.");
            Next();
        }
        /// <summary>
        /// Основной метод.
        /// </summary>
        public void Main()
        {
            PrintMessage();
            //какая-та логика для определенныз случаев с логистикой.
            Console.WriteLine("класс фабрики по логистике по суше");
            ClientCode(new RoadLogistics());
            Console.WriteLine("");
            Console.WriteLine("класс фабрики по логистике по воде");
            ClientCode(new SeaLogistics());
        }

        // Клиентский код работает с экземпляром конкретного создателя, хотя и
        // через его базовый интерфейс. Пока клиент продолжает работать с
        // создателем через базовый интерфейс, вы можете передать ему любой
        // подкласс создателя.
        public void ClientCode(Logistics logistic)
        {
            // ...
            Console.WriteLine(logistic.PlanDelivery());
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
    /// <summary>
    /// Абстрактный класс логистического отдела. Наши подклассы будут наследоваться от него. Здесь прописана логика, с которой мы работаем в основном коде.
    /// 
    /// Подклассы смогут производить объекты различных классов, следующих одному и тому же интерфейсу.
    /// Подклассы могут изменять класс создаваемых объектов.
    /// </summary>
    abstract class Logistics
    {
        public abstract Transport CreatTransport(int id);

        public string PlanDelivery()
        {
            int id = GetIdFromTransport();
            var transport = CreatTransport(id);
            var result = transport.ToString();
            return result;
        }

        private int GetIdFromTransport()
        {
            //Какая-та логика для получения свободного id транспорта.
            var rnd = new Random();
            int id = rnd.Next();
            return id;
        }
    }
    /// <summary>
    /// Класс сухопутного логистического отдела. Наш подкласс (класс-создатель), который создает и возвращает объект.
    /// 
    /// Пока все продукты реализуют общий интерфейс, их объекты можно взаимозаменять в клиентском коде.
    /// </summary>
    class RoadLogistics : Logistics
    {
        public override Transport CreatTransport(int id)
        {
            return new Track(id);
        }
    }

    /// <summary>
    /// Класс морского логистического отдела. Наш подкласс (класс-создатель), который создает и возвращает объект.
    /// 
    /// Пока все продукты реализуют общий интерфейс, их объекты можно взаимозаменять в клиентском коде.
    /// </summary>
    class SeaLogistics : Logistics
    {
        public override Transport CreatTransport(int id)
        {
            return new Ship(id);
        }
    }

    /// <summary>
    /// Абстракный класс транспорта. Логика, с которой работет основной код прописана тут.
    /// 
    /// Для клиента фабричного метода нет разницы между объектами, которые наследуются от этого класса, 
    /// так как он будет трактовать их как некий абстрактный Транспорт. 
    /// Для него будет важно, чтобы объект имел метод доставить, а как конкретно он работает — не важно.
    /// </summary>
    abstract class Transport
    { 
        public int Id { get; }
        public string TransportType { get; }

        public Transport(int id, string type)
        {
            Id = id;
            TransportType = type;
        }
        abstract public void Deliver();

        public override string ToString()
        {
            return $"Транспорта типа: {TransportType} с Id: {Id}";
        }
    }

    /// <summary>
    /// Класс грузовика. Наследуется от абстрактного класс транспорта.
    /// 
    /// Все объекты-продукты должны иметь общий интерфейс.
    /// </summary>
    class Track : Transport
    {
        public Track(int id) : base(id, "Track") { }

        public override void Deliver()
        {
            Console.WriteLine($"Грузовик {Id} доставляет продукты");
        }
    }

    /// <summary>
    /// Класс лодки. Наследуется от абстрактного класс транспорта.
    /// 
    /// Все объекты-продукты должны иметь общий интерфейс.
    /// </summary>
    class Ship : Transport
    {
        public Ship(int id) : base(id, "Ship") { }

        public override void Deliver()
        {
            Console.WriteLine($"Судно {Id} доставляет продукты");
        }
    }
}