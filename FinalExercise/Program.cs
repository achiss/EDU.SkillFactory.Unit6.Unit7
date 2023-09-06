
namespace FinalExercise
{

    // Customers and employees (2 abstract classes Person, Customer)
    // Base class to other from this part.
    abstract class Person
    {
        private string personName { get; set; }
        private byte _personAge;                        // 
        protected byte personAge                        //
        {
            get
            {
                return _personAge;
            }
            set
            {
                if (value > 0)
                {
                    _personAge = value;
                }
            }
        }
        private string personEmail { get; set; }
        private string chosenCity { get; set; }

        protected Person(string name, byte age, string email, string city)
        {
            personName = name;          // 7.1 Ключевые слова this и base
            personAge = age;            // в левой части используется this.
            personEmail = email;        // ->
            chosenCity = city;          // В текущей версии изменили или ...?
        }

        protected abstract void Greetings(string name);
        protected abstract void CheckCity();
    }

    // Based on class PERSON, and it's based for RegistredCustomer and Unregistread custmer.
    abstract class Customer : Person
    {
        private long customerID { get; set; }
        private string customerSurname { get; set; }
        private string customerPhone { get; set; }
        private string customerAddress { get; set; }
        private bool isCustomerRegistered { get; set; }

        private decimal customerExpensise
        {
            get { return customerExpensise; }
            set
            {
                if (value > 0)
                {
                    customerExpensise = value;
                }
            }
        }

        protected Customer(long id, string name, string surname, byte age, string phone, string email, string city,
            string address, decimal expensis, bool isRegistered) : base(name, age, email, city)
        {
            customerSurname = surname;
            customerPhone = phone;
            customerAddress = address;
            customerID = id;
            isCustomerRegistered = isRegistered;
            customerExpensise = expensis;
        }

        protected new byte personAge
        {
            get { return base.personAge; }
            set
            {
                if (value > 14)
                {
                    base.personAge = value;
                }
            }
        }


        protected override void Greetings(string name) => Console.WriteLine($"Hello {name}");
        protected void GenerateIdentificationNumbers(out long id)
        {
            int idLength = 18;
            Random randomID = new Random();
            string stringID = "";

            for (int i = 0; i < idLength; i++)
            {
                stringID += randomID.Next(0, 9);
            }

            id = long.Parse(stringID);
        }
        protected decimal DiscountCalculate(in bool isCustomerRegistered, in decimal customerExpensise)
        {
            decimal discount = 0;
            if (isCustomerRegistered)
            {
                switch (customerExpensise)
                {
                    case decimal expensise when expensise >= 5000 && expensise < 20000:
                        discount = 0.03m;
                        break;
                    case decimal expensise when expensise >= 20000 && expensise < 50000:
                        discount = 0.05m;
                        break;
                    default:
                        break;
                }

                return discount;
            }
            else
            {
                Console.WriteLine("Customer is not registered!");
                return discount;
            }
        }
    }
    
    // Class EMPLOYEE based on person
    class Employee : Person
    {
        private long employeeID { get; set; }
        private string employeeSurname { get; set; }
        public bool isOnShift { get; set; }
        public string Role { get; set; }
        private string localArea { get; set; }
        private string emloyeePhone { get; set; }

        protected Employee(long id, bool isShift, string name, string role, string surname, byte age, string phone, 
            string email, string city, string area) : base(name, age, email, city)
        {
            employeeID = id;
            isOnShift = isShift;
            Role = role;
            employeeSurname = surname;
            emloyeePhone = phone;
            localArea = area;
        }
        
        protected new byte age
        {
            get { return base.personAge; }
            set
            {
                if (value > 18)
                {
                    base.personAge = value;
                }
            }
        }

        protected override void Greetings(string name)
        {
            throw new NotImplementedException();
        }

        protected override void CheckCity()
        {
            throw new NotImplementedException();
        }
    }

    // Types of goods.
    // Base class to other from this part.
    abstract class Goods
    {
        
    }
    
    // 
    abstract class ShoppingCar
    {
        
    }
    
    // 
    abstract class Logistics
    {
        
    }
}