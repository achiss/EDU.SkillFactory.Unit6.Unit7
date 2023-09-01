
namespace FinalExercise                         //
{
    abstract class Customer
    {
        public string Name;
        public string Surname;
        public int Age;
        public string Email;
        
        enum DiscontType            // Выбираем шаг скидки
        {
            None = 0,
            TenPercent,
            FifteenPercent
        }

        enum DeliveryType           // Задаем тип доставки
        {
            None,
            Pickup,
            shopDelivery,
            homeDelivery
        }
    }

    class RegisteredCustomer: Customer
    {
        public string phoneNumber;
        protected string homeAddress;
        protected decimal moneySpend;
        protected string registrationDate;
    }
    
    abstract class Delivery 
    {
        public string Address;
    }

    class HomeDelivery: Delivery 
    {
        /* ... */
    }

    class PickPointDelivery: Delivery 
    {
        /* ... */
    }

    class ShopDelivery: Delivery 
    {
        /* ... */
    }

    class Order < TDelivery,
        TStruct > where TDelivery: Delivery 
    {
        public TDelivery Delivery;

        public int orderNumber;

        public string Description;

        public void DisplayAddress() 
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
    
}