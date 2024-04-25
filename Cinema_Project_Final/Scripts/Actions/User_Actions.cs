using Cinema_Project.Models;

namespace Cinema_Project.Scripts.Actions
{
    internal class User_Actions : DataManagment
    {
        public User_Actions()
        {
            LoadData();
        }
        // testowa funkcja(sprawdza czy wszstko działa :) EDIT[TAK TO DZIALA!])
        public void test()
        {
            foreach (User user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
        public User Login(string name,string password)
        {
            User user = users.Find(e=>e.Name == name);

            if(user != null && user.Password == password) {
                return user;
            }
            return null;
        }
        public void AddUser(string name, string password)
        {
            User user = new User()
            {
                Id = users.Count + 1,
                Name = name,
                Password = password,
                isAdmin = false
            };
            users.Add(user);
            Console.Write(user.Name);
            PushData(users, ActionTypes.User);
        }
       // Do naprawienia RemoveUser(string  name)
        public void RemoveUser(string name)
        {
            //User Removeuser = users.FirstOrDefault(n => n.Name == name);
            //Console.WriteLine(Removeuser.Name);
            
            //PushData(users,Types.User);
        }
    }
}
