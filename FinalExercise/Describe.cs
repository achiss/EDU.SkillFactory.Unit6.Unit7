﻿
namespace FinalExercise                        
{
    /*
    Абстрактный класс "User". 
    На его основе описываются все пользователи системы.
    Сотрудник "Employee" (только сотрудники отдела доставки);
    Покупатель "Customer":
       - незарегистрированный покупатель ;
       - зарегистрированный покупатель.
       
    П.С. поле "пароль" опущено!  
    */
    abstract class User
    {
        protected bool isUserType;      // Если правда то покупатель, в противном случае сотрудник
        public string ID;
        public string Name;             // Заполнятся вручную
        public string Surname;          // Заполнятся вручную
        public string Email;            // Заполнятся вручную

        public User(string id, string name, string surname, string email)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public void GenerateIdentificationNumber(in bool isUserType, out string ID)
        {
            Random value = new Random();
            int number = value.Next(000001, 999999);
            if (isUserType)
            {
                string userType = "Customer_";
                ID = string.Format("{0}{1}", userType, number.ToString());
            }
            else
            {
                string userType = "Employee_";
                ID = string.Format("{0}{1}", userType, number.ToString());
            }
        }
    }

    class Customer : User
    {
        public string Phone;             // Заполнятся вручную
        public string City;              // Заполнятся вручную
        public string Adress;            // Заполнятся вручную
        public int deliveryCost;
        
        public Customer(string id, string name, string surname, string email, string phone, string city, string adress,
            int deliveryCost) : base(id, name, surname, email)
        {
            Phone = phone;
            City = city;
            Adress = adress;
            this.deliveryCost = deliveryCost;

        }
    }

    class UnregisteredCustomer : Customer
    {
        
    }

    class RegisteredCustomer : Customer
    {
        public bool preferDeliveryType;                 // Курьерская доставка (true), самовывоз (false)
        public DateTime RegistrationDateTime;
        private int moneySpend;                         // Зависит от суммы потраченной клиентом в магазине
        protected int discountType;

        private void CalculationOfDiscount(in DateTime RegistrationDateTime, in int moneySpend,out int discoutType)
        {
            
            
            
        }
    }

    class Employee: User
    {
        public bool isOnShift;          // Рабочая смена сотрудника

        /*
        enum Area
        {
            None,
            North,
            South,
            East,
            West
        }

        enum Role
        {
            Logistician,
            Courier,
            OfficeManager,
            OfficeWorker
        }
        */

        public Employee(string id, string name, string surname, string email, bool isOnShift) : base(id, name, surname,
            email)
        {
            this.isOnShift = isOnShift;
        }
    }
}