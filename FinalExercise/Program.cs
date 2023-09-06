
namespace FinalExercise
{

    // Customers and employees.
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
            personAge = age;            // используется this.
            personEmail = email;        // ->
            chosenCity = city;          // В текущей версии изменили или ...?
        }

        protected abstract void Greetings();
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
            string address, decimal expensis,bool isRegistered) : base(name, age, email, city)
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
            get
            {
                return base.personAge;
            }
            set
            {
                if (value > 14)
                {
                    base.personAge = value;
                }
            }
        }

        protected void GenerateIdentificationNumbers(out long id)
        {
            
        }

        protected decimal DiscountCalculate(in bool isCustomerRegistered, in decimal customerExpensise)
        {
            if (isCustomerRegistered)
            {
                decimal discount = 0;
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