
//

using System.ComponentModel.DataAnnotations;

namespace FinalExercise
{
    /*
     * 
    */
    // Основной абстрактный класс пользователя (Person)
    abstract class Person
    {
        // Поля класса
        protected internal string Name { get; set; }

        protected internal string Phone
        {
            get
            {
                return Phone;
            }
            set
            {
                if (value.Contains("+7"))
                {
                    Phone = value;
                }
            }
            
        }

        protected int Age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value > 0)
                {
                    Age = value;
                }
            }
        }

        // Конструктор класса
        public Person(string name, string phone, int age)
        {
            Name = name;
            Phone = phone;
            Age = age;
        }

        // Методы класса
        public abstract void Greeting();
        public abstract void ShowRole();
    }
    
    // Класс сотрудник, дочерний класс от PERSON
    class Employee : Person
    {
        // Поля класса
        protected int _age;
        protected int Age
        {
            get { return _age; }
            set
            {
                if (value > 18)
                {
                    _age = value;
                }
            }
        }
        private string Surname { get; set; }
        protected internal string ID { get; set; }   // Как сделать при помощи generic / новый класс generic поле ID а далее его принять в текущем классе? Или как?
        private string Email { get; set; }
        private string Position { get; set; }
        protected internal string City { get; set; }
        
        // Конструктор класса
        public Employee(string id, string name, string surname, int age, string position, string phone, string email, 
            string city) : base(name, phone, age)
        {
            ID = id;
            Surname = surname;
            Position = position;
            Email = email;
            City = city;
        }

        // Методы класса
        public override void Greeting() => Console.WriteLine($"Hello: {Surname} {Name}, ID: {ID}");
        public override void ShowRole() => Console.WriteLine($"Your postition is {Position}");
        private static string GenerateID(){}        // Генерирования случайного 9 значного числа в качестве ID
        private static bool CheckLocation(){}       // Проверка, офис находится в городе в котором оформлена доставка
    }
    
    // Создание базового класса для покупателей, на основе класса PERSON
    abstract class Customer : Person
    {
        // Поля класса
        protected int _age;
        protected int Age
        {
            get { return _age; }
            set
            {
                if (value > 16)
                {
                    _age = value;
                }
            }
        }
        protected string ID { get; set; }
        protected bool CustomerType { get; set; }

        // Конструктор класса
        public Customer(string id, string name, string phone, int age, bool customerType) : base(name, phone, age)
        {
            ID = id;
            CustomerType = customerType;
        }
        
        // Методы класса
        public override void Greeting() => Console.WriteLine($"{Name}");

        public override void ShowRole()
        {
            if (CustomerType)
            {
                Console.WriteLine($"User {ID} is registered");
            }
            else
            {
                Console.WriteLine($"{Name} you dont have a discount");
            }
        }
    }
    
    // Классы покупателей
    class UnregesteredCustomer : Customer
    {
        // Поля класса
        protected internal bool isDelivery { get; set; }  // true доставка только в магазин, false отсутствует доставка
        protected internal string Area { get; set; }
        public UnregesteredCustomer(string id, string name, string phone, int age, string area, bool customerType, 
            bool isdelivery) : base(id, name, phone, age, customerType)
        {
            Area = area;        // район получения заказа
            isDelivery = isdelivery;
        }

        // Методы класса
        public void Greeting() => Console.WriteLine($"{Name}");
        public new void ShowRole() => 
            Console.WriteLine($"{Name} you are nor registered customer. We cant apply discount for you");
        public string GenerateID() {}
        public int GenerateDiscountCoupon()
        {
            int Discount = 0;
            switch (Product.Price)      //  или такой вариант плохая идея?
            {
                case double price when price >= 10000 && price < 20000:
                    return 3;
                    break;
                case double price when price >= 20000 && price < 25000:
                    return 5;
                    break;
                default:
                    return 0;
            }
        }
        public string GenerateCodeCoupon()
        {
            int couponLength = 18;
            Random randomChar = new Random();
            string stringCoupon = "";

            for (int i = 0; i < couponLength; i++)
            {
                stringCoupon += randomChar.Next(0, 9);
            }

            return stringCoupon;
        } 
        public void ShowCoupon()
        {
            var discountValue = GenerateDiscountCoupon();
            var discountName = GenerateCodeCoupon();
            
            Console.WriteLine($"You discount is {discountValue}. {discountName}");
        }
    }  // !!! ДОБАВИТЬ ССЫЛКУ ЦЕНУ ТОВАРА

    class RegesteredCustomer : Customer
    {
        // Поля класса, часть полей используются в других классах
        protected internal string Surname { get; set; }
        protected internal string Email { get; set; }
        protected internal int Discount { get; set; }
        protected decimal SpendMoney { get; set; }
        protected internal string Address { get; set; }
        
        // Конструктор класса
        public RegesteredCustomer(string id, string name, string surname, int age, string phone, string email, 
            string address, int discount, decimal spendMoney, bool customerType) :
            base(id, name, phone, age, customerType)
        {
            Surname = surname;
            Email = email;
            SpendMoney = spendMoney;
            Address = address;
            Discount = discount;
        }
        
        // Методы класса
        public new void Greeting() => Console.WriteLine($"{Surname} {Name} {ID}");

        protected internal int DiscountCalculation()
        {
            if (SpendMoney > 0)
            {
                switch (SpendMoney)
                {
                    case decimal spendMoney when spendMoney >= 20000 && spendMoney < 35000:
                        return 5;
                        break;
                    case decimal spendMoney when spendMoney >= 35000 && spendMoney < 50000:
                        return 10;
                        break;
                    default:
                        return 1;
                }
            }

            return 0;
        }
    }
    
    /*
     * 
    */
    // Абстрактный класс продукта (Product)
    abstract class Product
    {
        // Поля класса 
        protected internal string ProductName { set; get; }
        protected string ProductDescription { set; get; }
        protected internal string ProductLabel { set; get; }
        protected internal double ProductPrice 
        {
            get { return ProductPrice; }
            set
            {
                if (value > 0)
                {
                    ProductPrice = value;
                }
            }
        }
        protected string[] StorageLocation { get; set; }
        
        //
        public Product(string name, string description, string label, double price, string[] storageLocation)
        {
            ProductName = name;
            ProductDescription = description;
            ProductLabel = label;
            ProductPrice = price;
            StorageLocation = storageLocation;
        }
        
        //
        public abstract void ShowProductData();
        public abstract void InitializeStorageLocationList();
    }
    
    // Абстратный клас от PRODUCT
    abstract class Goods : Product
    {
        //
        public float ProductWeight 
        {
            get { return ProductWeight; }
            set
            {
                if (value >= 0.1f)
                {
                    ProductWeight = value;
                }
            }
        }
        
        public float ProductHeight 
        {
            get { return ProductHeight; }
            set
            {
                if (value >= 0.1f)
                {
                    ProductHeight = value;
                }
            }
        }

        public float ProductWidth 
        {
            get { return ProductWidth; }
            set
            {
                if (value > 0.1f)
                {
                    ProductWidth = value;
                }
            }
        }

        public float ProductDepth 
        {
            get { return ProductDepth; }
            set
            {
                if (value > 0.1f)
                {
                    ProductDepth = value;
                }
            }
        }
        
        //
        public Goods(string name, string description, string label, double price, string[] storageLocation,
            float productWeight, float productHeight, float productWidth, float productDepth) :
            base(name, description, label, price, storageLocation)
        {
            ProductWeight = productWeight;
            ProductHeight = productHeight;
            ProductWidth = productWidth;
            ProductDepth = productDepth;
        }
    }
    
    // два класса не съесного оборудования
    abstract class FoodGoods : Product
    {
        
    }
    
    // Определение классов наследников по аналогии с блоком "ПОЛЬЗОВАТЕЛЬ"
    // От абстрактного класса GOODS > два класса наследника
    //      - HouseholdEquipment - должен содержать логику:
    //      расчёт стоимости товара в зависимости от пользователя, возможно использвать любые способы доставки.
    //      - OtherEquipment- должен содержать логику:
    //      расчёт стоимости товара в зависимости от пользователя, возможно использовать только самовывоз (два типа).
    // От абстрактного класса FOODGOODS > три класса наследника
    //      - ReadyMakeFood - ограничение на доставку, Иная логика скидки. проверка времени доставки.
    //      - PerishableProducts- ограничение на доставку, логика скидки уже описана, проверка времени доставки..
    //      - OtherFood- ограничений на доставку нет.

    //
    static class Order
    {
        public static int DiscountData;
        public static void GetDicountData(out int DiscountData)
        {
            RegesteredCustomer method = new DiscountCalculation();  // для передачи поля(метода) используется текущая конструкция
            DiscountData = method.DiscountCalculation();            // как реально она применяется?
        }
        public static string ProductName;
        
    }
    
    //
    abstract class Delivery
    {
        public string ProductNameToDelivery { get; set; }
        public string CustomerHomeAddress;
        public string CustomerName { get; set; }
        public Delivery(string productName, string customerName, string address)
        {
            ProductNameToDelivery = productName;
            CustomerHomeAddress = address;
            CustomerName = customerName;
        }
    }

    class HomeDelivery
    {
        private Delivery _delivery;

        public HomeDelivery()
        {
            _delivery = new Delivery();
        }
    }

    class ExpressDelicery : Delivery
    {
        
    }

    class PickPointDelivery: Delivery 
    {

    }

    class ShopDelivery: Delivery 
    {

    }

    class Order < TDelivery,
        TStruct > where TDelivery: Delivery 
    {
        public TDelivery Delivery { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public void DisplayAddress() 
        {
            Console.WriteLine(Delivery.CustomerHomeAddress);
        }
        
    }
}