﻿namespace FinalExercise
{
    abstract class Person
    {
        private string Name { get; set; }

        public string Phone
        {
            get
            {
                return Phone;
            }
            set
            {

                if ((Phone.Length != 11) && (Phone.Contains("7")))
                {
                    Phone = value;
                }
            }
        }
        public string City { get; set; }
        public byte Age
        {
            get
            {
                return Age;
            }
            set
            {
                if (Age > 0)
                {
                    Age = value;
                }
            }
        }

        protected Person(string name, byte age, string phone, string city)
        {
            Name = name;
            Phone = phone;
            Age = age;
            City = city;
        }

        public void Greetings() => Console.WriteLine($"Hello {Name}");
        public abstract void ShowCity();
    }

    class Employee : Person
    {
        protected string employeeName;
        public string name
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private Employee() :
            base(name, age, phone, city)
        {
            
        }
    }
}