using Cinema_Project.Models;
using Cinema_Project.Scripts.Actions;
using System;

namespace Cinema_Project.Gui
{
    internal class RoomView_Menu
    {
        private Room_Actions roomActions;
        private int roomID { get; set; }
        bool repeat = true;
        public RoomView_Menu(int roomID)
        {
            this.roomID = roomID;
            roomActions = new Room_Actions();
            Room room = roomActions.GetRoom(roomID);
            int rows = room.rows;
            int cols = room.cols;
            ConsoleKeyInfo key;
            bool isSelected = false;
            int selectedRow = 0;
            int selectedCol = 0;
            while (repeat)
            {


                while (!isSelected)
                {

                    Console.Clear();
                    Console.WriteLine("                        Wybierz miejsce które chcesz zarezerwować:            ");
                    Console.WriteLine("                 Klikając na zajęte miejsce możesz anulować rezerwacje:            ");

                    Console.WriteLine("-----------------------------------------------------------");

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            int seatNumber = i * cols + j;
                            Seat currentSeat = room.seats[seatNumber];

                            // Zaznaczenie wybranego miejsca
                            if (i == selectedRow && j == selectedCol)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                            }
                            else if (currentSeat.is_taken)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }

                            Console.Write($"{seatNumber + 1}".PadLeft(3));
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("-----------------------------------------------------------");

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            selectedCol = (selectedCol == 0) ? cols - 1 : selectedCol - 1;
                            break;

                        case ConsoleKey.RightArrow:
                            selectedCol = (selectedCol == cols - 1) ? 0 : selectedCol + 1;
                            break;

                        case ConsoleKey.UpArrow:
                            selectedRow = (selectedRow == 0) ? rows - 1 : selectedRow - 1;
                            break;

                        case ConsoleKey.DownArrow:
                            selectedRow = (selectedRow == rows - 1) ? 0 : selectedRow + 1;
                            break;

                        case ConsoleKey.Enter:
                            int selectedSeatNumber = selectedRow * cols + selectedCol;
                            Seat selectedSeat = room.seats[selectedSeatNumber];
                            if (!selectedSeat.is_taken)
                            {
                                // Rezerwacja miejsca
                                roomActions.Reservation(room.id, selectedSeatNumber, null);
                                Console.WriteLine($"Miejsce {selectedSeatNumber + 1} zostało zarezerwowane.");
                                repeat = false;

                                isSelected = true;
                            }
                            else
                            {
                                // Anulowanie rezerwacji miejsca
                                roomActions.Reservation_Cancel(room.id, selectedSeatNumber);
                                Console.WriteLine($"Rezerwacja miejsca {selectedSeatNumber + 1} została anulowana.");
                                ;
                                isSelected = true;
                                repeat = false;
                            }
                            Console.ReadKey(true);
                            break;
                    }
                }
            }
        }
    }
}