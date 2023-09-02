
namespace FinalExercise
{

    /*
    Абстрактный класс "Person".
    На его основе описываются все пользователи системы.
    Сотрудник "Employee" (только сотрудники отдела доставки);
    Покупатель "Customer" (второй абстрактный класс блока):
       - незарегистрированный покупатель (UnregisteredCustomer);
       - зарегистрированный покупатель (RegisteredCustomer).
     */
    abstract class Person
    {
        public bool isPersonType; // true -> customer
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public Person(bool isPersonType, string name, string surname, string phone)
        {
            this.isPersonType = isPersonType;
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }

    class Employee : Person
    {
        public bool isOnShift; // true -> on a work
        public string Role { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

        public Employee(bool isPersonType, string name, string surname, string phone, bool isOnShift, string role,
            string location, string email) :
            base(isPersonType, name, surname, phone)
        {
            this.isOnShift = isOnShift;
            Role = role;
            Location = location;
            Email = email;
        }
    }

    abstract class Customer : Person
    {
        public bool isFormalizedCustomer; // true -> Registrered Customer
        public string ID { get; }
        public string Adress { get; set; }

        public Customer(bool isPersonType, string name, string surname, string phone, bool isFormalizedCustomer,
            string id, string adress) : base(isPersonType, name, surname, phone)
        {
            this.isFormalizedCustomer = isFormalizedCustomer;
            ID = id;
            Adress = adress;
        }

        public abstract void GenerateID(in bool isFormalizedCustomer, out string ID);
    }

    class UnregisteredCustomer : Customer
    {
        public UnregisteredCustomer(bool isPersonType, string name, string surname, string phone,
            bool isFormalizedCustomer,
            string id, string adress) : base(isPersonType, name, surname, phone, isFormalizedCustomer, id, adress)
        {

        }

        public override void GenerateID(in bool isFormalizedCustomer, out string ID)
        {
            Random value = new Random();
            int number = value.Next(000001, 999999);
            {
                string userType = "UnregCustomer_";
                ID = string.Format("{0}{1}", userType, number.ToString());
            }
        }
    }

    class RegisteredCustomer : Customer
    {
        public string Email;
        public bool isStandartDelivery; // Так как пользователь зарегистрирован, есть возможность купить в 1 клик.
        public decimal MoneySpend; // Расчёт скидки на товары
        public DateTime RegistrationDate; // Расчёт скидки на товары

        public (string cardHolderName, string cardHolderSurname, string cardNumber, DateTime expirationDateCard)
            CardData;

        public RegisteredCustomer(bool isPersonType, string name, string surname, string phone,
            bool isFormalizedCustomer,
            string id, string adress, string email, bool isStandartDelivery, decimal moneyspend,
            DateTime registrationdate) :
            base(isPersonType, name, surname, phone, isFormalizedCustomer, id, adress)
        {
            Email = email;
            this.isStandartDelivery = isStandartDelivery;
            MoneySpend = moneyspend;
            RegistrationDate = registrationdate;

        }

        public override void GenerateID(in bool isFormalizedCustomer, out string ID)
        {
            // написать метод
        }

        protected int DiscountCalculation(in DateTime registrationdate, in decimal moneyspend)
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.AddYears(1) > registrationdate || moneyspend > 10000)
            {
                return 5;
            }
            else if (currentDate.AddYears(1) > registrationdate && moneyspend > 20000)
            {
                return 10;
            }
            else if (currentDate.AddYears(7) > registrationdate || moneyspend > 100000)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }
    }

    /*
     Абстратктный класс Items. Является оснвоным для классов Food и Equipment.
     Food. Имеются ограничения на доставку. Может быть или в магазин или курьерская доставка.
     Equipment.
     */
    abstract class Items
    {
        public string Product;
        public string productLabel;
        public string productDecription;
        public string productNotes;
        public decimal productPrice;
        public int productCount;
    }

    class Food : Items
    {

    }

    class Equipment : Items
    {

    }

    /*
     Абстратктный класс Distribution.
     */
    abstract class Distribution
    {

    }

    /*
     Абстратктный класс Delivery.
     */
    abstract class Delivery
    {
        public string Address;
    }

    class HomeDelivery : Delivery
    {
        /* ... */
    }

    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    class ShopDelivery : Delivery
    {
        /* ... */
    }

    class Order<TDelivery,
        TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
}