using Cinema_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Gui
{
    internal class Menu_Admin
    {
        bool repeat = true;

        public Menu_Admin(User user) {
            AdminVIew view = new(user);
            while (repeat)
            {
                // do przeanalizowania przez film i zmodyfikowania wedlug wlasnego pomyslu

                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Witaj oficjalnie w Aplikacji kina!");
                Console.ResetColor();
                Console.WriteLine("\nUżyj strzałki w góre lub dól aby wybrać opcje i zatwierdź \u001b[32mEnterem\u001b[0m:");
                (int left, int top) = Console.GetCursorPosition();
                var option = 1;
                var decorator = "> \u001b[32m";
                ConsoleKeyInfo key;
                bool isSelected = false;

                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);

                    Console.WriteLine($"{(option == 1 ? decorator : "   ")}Dodaj kino \u001b[0m");
                    Console.WriteLine($"{(option == 2 ? decorator : "   ")}Usuń kino \u001b[0m");
                    Console.WriteLine($"{(option == 3 ? decorator : "   ")}Stwórz sale \u001b[0m");
                    Console.WriteLine($"{(option == 4 ? decorator : "   ")}Usuń sale \u001b[0m");
                    Console.WriteLine($"{(option == 5 ? decorator : "   ")}Dodaj film \u001b[0m");
                    Console.WriteLine($"{(option == 6 ? decorator : "   ")}Usuń film \u001b[0m");
                    Console.WriteLine($"{(option == 7 ? decorator : "   ")}Wyloguj sie \u001b[0m");

                    key = Console.ReadKey(false);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            option = option == 1 ? 3 : option - 1;
                            break;

                        case ConsoleKey.DownArrow:
                            option = option == 7 ? 1 : option + 1;
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }
                }
                switch(option)
                {

                    case 1:
                        view.CreateCinema();
                        Console.ReadKey();
                        break;
                    case 2:
                        view.RemoveCinema();
                        Console.ReadKey();
                        break;
                    case 3:
                        view.CreateRoom();
                        Console.ReadKey();
                        break;
                    case 4:
                        view.RemoveRoom();
                        Console.ReadKey();
                        break;
                    case 5:
                        view.CreateMovie();
                        Console.ReadKey();
                        break;
                    case 6:
                        view.RemoveMovie();
                        Console.ReadKey();
                        break;
                    case 7:
                        repeat = false;
                        LoginPage p = new();
                        break;
                     
                }
                
            }

        }
    }
}
