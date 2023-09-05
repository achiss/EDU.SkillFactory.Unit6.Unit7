namespace FinalExercise
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birhday { get; set; }
        public string City { get; set; }
        public int Age
        {
            get {  ; }
            set {  ; }
        }

        protected Person(string name, DateTime birhday, string phone, string city)
        {
            Name = name;
            Phone = phone;
            Birhday = birhday;
            City = city;
        }

        public void Greetings() => Console.WriteLine($"Hello {Name}");

        public void AgeDetermination(in DateTime Birhday, out int Age)
        {
            
        } 
    }
}