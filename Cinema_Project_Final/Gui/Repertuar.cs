using Cinema_Project.Models;
using Cinema_Project.Scripts.Actions;
using System;
using System.Text;

namespace Cinema_Project.Gui
{
    internal class Repertuar
    {
        private bool repeat = true;
        private Room_Actions actions_room = new Room_Actions();

        public Repertuar()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Wyświetlenie stałego komunikatu powitalnego i instrukcji
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Witaj w Repertuarze naszego kina!");
            Console.ResetColor();
            Console.WriteLine("\nUżyj strzałek w górę lub w dół, aby wybrać opcję i zarezerwować miejsce!, a następnie zatwierdź Enterem:");

            while (repeat)
            {
                int option = 1;
                bool isSelected = false;
                var decorator = "> \u001b[32m";
                (int left, int top) = Console.GetCursorPosition();

                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine($"{(option == 1 ? decorator : "   ")}|{actions_room.GetRoomMovie(0).name}| |{actions_room.GetRoomMovie(0).director}| \u001b[0m");
                    Console.WriteLine($"{(option == 2 ? decorator : "   ")}|{actions_room.GetRoomMovie(1).name}| |{actions_room.GetRoomMovie(0).director}|\u001b[0m");
                    Console.WriteLine($"{(option == 3 ? decorator : "   ")}Wróć do menu\u001b[0m");
                    Console.WriteLine("-----------------------------------------------------");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            option = (option == 1) ? 5 : option - 1; // Poprawienie wyboru opcji górnej granicy
                            break;

                        case ConsoleKey.DownArrow:
                            option = (option == 5) ? 1 : option + 1; // Poprawienie wyboru opcji dolnej granicy
                            break;

                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }

                    Console.Clear(); 
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Witaj w Repertuarze naszego kina!");
                    Console.ResetColor();
                    Console.WriteLine("\nUżyj strzałek w górę lub w dół, aby wybrać opcję, a następnie zatwierdź Enterem:");
                }

                switch (option)
                {
                    case 1:
                        RoomView_Menu menu = new(0);
                    break;
                    case 2:
                        RoomView_Menu menu2 = new(1);
                        break;
                    case 3:
                        repeat = false;
                        Menu menuG = new();
                        break;
                }
                Console.ReadKey();
            }
        }

     
    }
}
