
namespace FinalExercise                        
{
    
    //
    abstract class Person
    {
        public abstract string Name { get; set; }
        public string City;
        public abstract string Phone { get; set; }

        public Person(string name, string city, string phone)
        {
            Name = name;
            City = city;
            Phone = phone;
        }

        public virtual void GreetingPerson() => Console.WriteLine(Name);
        public abstract void ShowCity();
    }
    
    class Employee<T> : Person
    {
        private string employeeName;
        public override string Name
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        public bool isOnShift;
        public enum Role
        {
            Officemanager,
            Advisor,
            Deliveryman
        }
        protected T fieldID;
        protected string employeeSurname { get; set; }
        public string cityArea;
        protected string Email;

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
        public override void ShowCity() => Console.WriteLine(City, cityArea);
    }

    abstract class Customer : Person
    {
        protected string customerName;
        public override string Name
        {
            get { return customerName; }
            set { customerName = value; }
        }
        protected string customerSurname;
        protected string customerPhone;
        public override string Phone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }

        protected Customer(string name, string surname, string phone) :
            base(name, city, phone)
        {
            customerSurname = surname;
        }
        
        public abstract int this [int index] { get; set; }
    }

    class RegisteredCustomer<T1, T2> : Customer
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