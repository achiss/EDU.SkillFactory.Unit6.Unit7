
namespace FinalExercise
{

    // Customers and employees.
    // Base class to other from this part.
    abstract class Person
    {
        private string personName { get; set; }
        private byte personAge
        {
            get
            {
                return personAge;
            }
            set
            {
                if (personAge > 0)
                {
                    personAge = value;
                }
            }
        }
        private string personEmail { get; set; }
        private string chosenCity { get; set; }

        private Person(string name, byte age, string email, string city)
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
        private decimal customerID { get; set; }
        private string customerSurname { get; set; }
        private string customerPhone { get; set; }
        private string customerAdress { get; set; }
        private bool isCustomerRegistered { get; set; }
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