
namespace FinalExercise                        
{
    
    //
    abstract class Person
    {
        public abstract string Name { get; set; }
        public string City;
        public string Phone;

        public Person(string name, string city, string phone)
        {
            Name = name;
            City = city;
            Phone = phone;
        }

        public virtual void GreetingPerson() => Console.WriteLine(Name);
        public abstract void ShowCity();
    }

    class Identification                            // !!!
    {
        public int Number;
        public string prefixNumber;
        public string networkNumber;
    }
    
    class Employee : Person
    {
        private string employeeName;
        public override string Name
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
            }
        }
        public bool isOnShift;
        public enum Role
        {
            Officemanager,
            Advisor,
            Deliveryman
        }
        protected object fieldID;
        protected string employeeSurname { get; set; }
        public string cityArea;
        public string Email;

        protected Employee(object fieldID, string name, string surname, bool isOnShift, string email, string city, string phone) :
            base(name, city, phone)
        {
            this.fieldID = fieldID;
            employeeName = name;
            employeeSurname = surname;
            this.isOnShift = isOnShift;
            Email = email;
        }
        
        private override void GreetingPerson() => Console.WriteLine(Name, employeeSurname);
    }

    abstract class Customer : Person
    {
        
    }

    class RegisteredCustomer : Customer
    {
        
    }

    class UnregisteredCustomer : Customer
    {
        
    }
        
    //
    abstract class Distributor
    {
        
    }

    class OnLineDistributor : Distributor
    {
        
    }

    class OffLineDistributor : Distributor
    {
        
    }
    
    // 
    abstract class Product
    {
        
    }

    abstract class Items : Product
    {
        
    }

    class BulkyGoods : Items
    {
        
    }

    class Goods : Items
    {
        
    }

    abstract class Food : Product
    {
        
    }

    class CookedFood : Food
    {
        
    }

    class FoodRequireSpecialStorageConditions : Food
    {
        
    }

    class FoodWithoutSpecialStorageConditions : Food
    {
        
    }
    
    //
    abstract class Delivery
    {
        
    }

    class HomeDelivery : Delivery
    {
        
    }

    class PickPointDelivery : Delivery
    {
        
    }

    class ShopDelivery : Delivery
    {
        
    }
    
    //
    class Order
    {
        
    }
    
    //
    //
    // ...
    // ...
    // ...
    
}