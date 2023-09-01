
namespace FinalExercise                        
{
    /*
    Абстрактный класс "User". 
    На его основе описываются все пользователи системы.
    Сотрудник "Employee";
    Покупатель "Customer":
       - незарегистрированный покупатель ;
       - зарегистрированный покупатель.
       
    П.С. поле "пароль" опущено!  
    */
    abstract class User
    {
        protected bool isUserType;
        protected string ID;
        public string Name;
        public string Email;

        public void GenerateIdentificationNumber(out string ID)
        {
            
        }
    }
}