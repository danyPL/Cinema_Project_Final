using Cinema_Project.Models;
using Cinema_Project.Scripts.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Gui
{
    internal class LoginPage
    {
        bool repeat = true;
        public User user;
        public LoginPage() {
            User_Actions actions = new();
            Console.Clear();
            string login, password;
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            while (repeat)
            {
        Console.WriteLine("Witaj w aplikacji kina!\n Aby rozpocząć pracę zaloguj się na swoje konto.");
            Console.WriteLine("Podaj login:");
            login = Console.ReadLine();
            Console.WriteLine("Podaj hasło");
            password = Console.ReadLine();
            user = actions.Login(login, password);
            if(user == null)
                {
                    Console.WriteLine("Podane dane są błedne!");
                    Console.ReadKey();
                }
            else if(!user.isAdmin)
                {
                    Console.Clear();
                    Menu menu_player = new();
                }
                Menu_Admin menu_admin = new(user);
            }
    

        }
    }
}
