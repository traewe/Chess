using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Net.Security;
using System.Runtime;
using System.Text;

namespace program
{
    public class Chess
    {
        static void Main(string[] args)
        {
            string cell1;
            string cell2;
            string temp;
            int dig1 = -1;
            int dig2 = -1;
            int dig3 = -1;
            int dig4 = -1;
            string enemyП = "";
            string enemyC = "";
            string enemyH = "";
            string enemyT = "";
            string enemyT1 = "";
            string enemyQ = "";
            string enemyK = "";
            string allyП = "";
            string allyC = "";
            string allyH = "";
            string allyT = "";
            string allyT1 = "";
            string allyQ = "";
            string allyK = "";
            int counter_no_free_place = 0;
            int counter_tura1_green_moves = 0;
            int counter_tura2_green_moves = 0;
            int counter_tura1_red_moves = 0;
            int counter_tura2_red_moves = 0;
            int counter_king_green_moves = 0;
            int counter_king_red_moves = 0;
            string figura = "";
            int counter_side = 0;
            int counter_moves = 1;
            int king_green_coor1 = 9;
            int king_green_coor2 = 6;
            int king_red_coor1 = 2;
            int king_red_coor2 = 6;
            bool chaxmat = false;
            bool chax_right_top_slon = true;
            bool chax_left_top_slon = true;
            bool chax_right_down_slon = true;
            bool chax_left_down_slon = true;
            bool chax_left_tura = true;
            bool chax_right_tura = true;
            bool chax_top_tura = true;
            bool chax_down_tura = true;
            bool error_cell = false;
            int answer;
            int advantage;
            string green_losses = "";
            string red_losses = "";
            int king_coor1 = -1;
            int king_coor2 = -1;
            int tura_green_possible_quantity = 2;
            int slon_green_possible_quantity = 2;
            int queen_green_possible_quantity = 1;
            int horse_green_possible_quantity = 2;
            int tura_red_possible_quantity = 2;
            int slon_red_possible_quantity = 2;
            int queen_red_possible_quantity = 1;
            int horse_red_possible_quantity = 2;
            List<int> first_coor_death = new();
            List<int> second_coor_death = new();
            List<int> first_coor_block = new();
            List<int> second_coor_block = new();
            List<int> opposite_first_coor_death = new();
            List<int> opposite_second_coor_death = new();
            List<int> ally_first_coor_death = new();
            List<int> ally_second_coor_death = new();
            Console.WriteLine("Обозначения: Т - тура, Н - horse, С - слон, Q - queen, К - король, П - пешка");
            Console.WriteLine("Структура хода: сначала пишешь букву и цифру клетки, где стоит фигура, потом куда хочешь ею походить(пример c2 c4)");
            Console.WriteLine("Для рокировки - рокировка вправо/рокировка влево");
            string[,] matrix = new string[12, 12] { { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", "A", "B", "C", "D", "E", "F", "G", "H", " ", " " }, { " ", "8", "Tr", "Hr", "Cr", "Qr", "Kr", "Cr", "Hr", "Tr1", "8", " " }, { " ", "7", "Пr", "Пr", "Пr", "Пr", "Пr", "Пr", "Пr", "Пr", "7", " " }, { " ", "6", "*", "*", "*", "*", "*", "*", "*", "*", "6", " " }, { " ", "5", "*", "*", "*", "*", "*", "*", "*", "*", "5", " " }, { " ", "4", "*", "*", "*", "*", "*", "*", "*", "*", "4", " " }, { " ", "3", "*", "*", "*", "*", "*", "*", "*", "*", "3", " " }, { " ", "2", "Пg", "Пg", "Пg", "Пg", "Пg", "Пg", "Пg", "Пg", "2", " " }, { " ", "1", "Tg", "Hg", "Cg", "Qg", "Kg", "Cg", "Hg", "Tg1", "1", " " }, { " ", " ", "A", "B", "C", "D", "E", "F", "G", "H", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " } };
            matrix_build();
            while (true)
            {
                try
                {
                    if (counter_side == 0)
                    {
                        int a = 1;
                        int b = 2;
                        int c = 3;
                        a = b;
                        b = c;
                        error_cell = false;
                        first_coor_death.Clear();
                        second_coor_death.Clear();
                        if (stalemate("green"))
                        {
                            Console.WriteLine("Шах и ПАТ! Зеленый рад");
                            break;
                        }
                        else if (chax(king_green_coor1, king_green_coor2, "green"))
                        {
                            if (end("green"))
                            {
                                Console.WriteLine("VIKA! VIKA! VIKA! RED WON");
                                break;
                            }
                            Console.WriteLine("ATTENTION! ШАХ!(зеленый! Алло)");
                        }
                        Console.WriteLine($"Ход зеленых {counter_moves} ");
                        cell1 = Console.ReadLine().ToUpper();
                        place1(cell1);
                        if (error_cell)
                        {
                            matrix_build();
                            Console.WriteLine("Внеси данные правильно");
                            continue;
                        }
                        switch (matrix[dig1, dig2])
                        {
                            case "Пg":
                                Console.WriteLine("(пешка)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                peshak("Пg");
                                break;

                            case "Hg":
                                Console.WriteLine("(конь)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                horse("Hg");
                                break;

                            case "Tg":
                                figura = "Tg";
                                goto case "Tg + Tg1";

                            case "Tg1":
                                figura = "Tg1";
                                goto case "Tg + Tg1";

                            case "Tg + Tg1":
                                Console.WriteLine("(тура)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                tura();
                                break;

                            case "Cg":
                                Console.WriteLine("(слон)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Cg";
                                slon();
                                break;

                            case "Qg":
                                Console.WriteLine("(королева)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Qg";
                                tura();
                                if (matrix[dig1, dig2] == "Qg")
                                {
                                    slon();
                                }
                                break;
                                break;

                            case "Kg":
                                Console.WriteLine("(король)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                king("Kg");
                                break;
                        }
                        if (cell1 == "РОКИРОВКА ВПРАВО")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (chax(9, 6 + i, "green"))
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (chaxmat == false)
                            {
                                if (counter_king_green_moves == 0 && counter_tura2_green_moves == 0)
                                {
                                    if (matrix[9, 7] == "*" && matrix[9, 8] == "*")
                                    {
                                        matrix[9, 6] = "*";
                                        matrix[9, 7] = "Tg1";
                                        matrix[9, 8] = "Kg";
                                        matrix[9, 9] = "*";
                                        counter_side++;
                                        counter_moves++;
                                        king_green_coor2 = 8;
                                        counter_king_green_moves++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Где то битое поле");
                            }
                        }
                        else if (cell1 == "РОКИРОВКА ВЛЕВО")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (chax(9, 6 - i, "green"))
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (chaxmat == false)
                            {
                                if (counter_king_green_moves == 0 && counter_tura1_green_moves == 0)
                                {
                                    if (matrix[9, 3] == "*" && matrix[9, 4] == "*" && matrix[9, 5] == "*")
                                    {
                                        matrix[9, 2] = "*";
                                        matrix[9, 3] = "*";
                                        matrix[9, 4] = "Kg";
                                        matrix[9, 5] = "Tg";
                                        matrix[9, 6] = "*";
                                        counter_side++;
                                        counter_moves++;
                                        king_green_coor2 = 4;
                                        counter_king_green_moves++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Где то битое поле");
                            }
                        }
                        if (counter_side != 1)
                        {
                            Console.WriteLine("Берешь свою фигуру и бьешь вражескую. Понял?");
                        }
                        matrix_build();
                    }
                    if (counter_side == 1)
                    {
                        error_cell = false;
                        if (stalemate("red"))
                        {
                            Console.WriteLine("Шах и ПАТ! Красный рад");
                            break;
                        }
                        if (chax(king_red_coor1, king_red_coor2, "red"))
                        {
                            if (end("red"))
                            {
                                Console.WriteLine("GG WP! GREEN WON");
                                break;
                            }
                            Console.WriteLine("ATTENTION! ШАХ!(красный! Алло)");
                        }
                        Console.WriteLine($"Ход красных {counter_moves} ");
                        cell1 = Console.ReadLine().ToUpper();
                        place1(cell1);
                        if (error_cell)
                        {
                            matrix_build();
                            Console.WriteLine("Внеси данные правильно");
                            continue;
                        }
                        Console.WriteLine(matrix[4, 5]);
                        switch (matrix[dig1, dig2])
                        {
                            case "Пr":
                                Console.WriteLine("(пешка)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                peshak("Пr");
                                break;
                            case "Hr":
                                Console.WriteLine("(конь)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                horse("Hr");
                                break;

                            case "Tr":
                                figura = "Tr";
                                goto case "Tr + Tr1";

                            case "Tr1":
                                figura = "Tr1";
                                goto case "Tr + Tr1";

                            case "Tr + Tr1":
                                Console.WriteLine("(тура)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                tura();
                                break;

                            case "Cr":
                                Console.WriteLine("(слон)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Cr";
                                slon();
                                break;

                            case "Qr":
                                Console.WriteLine("(королева)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Qr";
                                tura();
                                if (matrix[dig1, dig2] == "Qr")
                                {
                                    slon();
                                }
                                break;

                            case "Kr":
                                Console.WriteLine("(король)");
                                cell2 = Console.ReadLine().ToUpper();
                                place2(cell2);
                                if (error_cell)
                                {
                                    matrix_build();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                king("Kr");
                                break;
                        }
                        if (cell1 == "РОКИРОВКА ВЛЕВО")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (chax(2, 6 + i, "red"))
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (chaxmat == false)
                            {
                                if (counter_king_red_moves == 0 && counter_tura2_red_moves == 0)
                                {
                                    if (matrix[2, 7] == "*" && matrix[2, 8] == "*")
                                    {
                                        matrix[2, 6] = "*";
                                        matrix[2, 7] = "Tr1";
                                        matrix[2, 8] = "Kr";
                                        matrix[2, 9] = "*";
                                        counter_side--;
                                        counter_moves++;
                                        counter_king_red_moves++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Где то битое поле");
                            }
                        }
                        else if (cell1 == "РОКИРОВКА ВПРАВО")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (chax(2, 6 - i, "red"))
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (chaxmat == false)
                            {
                                if (counter_king_red_moves == 0 && counter_tura1_red_moves == 0)
                                {
                                    if (matrix[2, 3] == "*" && matrix[2, 4] == "*" && matrix[2, 5] == "*")
                                    {
                                        matrix[2, 2] = "*";
                                        matrix[2, 3] = "*";
                                        matrix[2, 4] = "Kr";
                                        matrix[2, 5] = "Tr";
                                        matrix[2, 6] = "*";
                                        counter_side--;
                                        counter_moves++;
                                        counter_king_red_moves++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Где то битое поле");
                            }
                        }
                        if (counter_side != 0)
                        {
                            Console.WriteLine("Фигуру выбери! Желательно свою");
                        }
                        matrix_build();
                    }
                }
                catch
                {
                     Console.WriteLine("Ай, код поплавило");
                     matrix_build();
                }
            }
            Console.WriteLine("Ось i казочцi кiнець, а хто слухав - молодець");
            void matrix_build()
            {
                counter_figures();
                if (counter_side == 0)
                {
                    for (int i = 1; i < 11; i++)
                    {
                        for (int j = 1; j < 11; j++)
                        {
                            if (matrix[i, j] == "Kg")
                            {
                                king_green_coor1 = i;
                                king_green_coor2 = j;
                            }
                            if (matrix[i, j] == "Kr")
                            {
                                king_red_coor1 = i;
                                king_red_coor2 = j;
                            }
                            if ((i + j) % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            if (matrix[i, j] == "Пr" || matrix[i, j] == "Tr" || matrix[i, j] == "Hr" || matrix[i, j] == "Cr" || matrix[i, j] == "Qr" || matrix[i, j] == "Kr" || matrix[i, j] == "Tr1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(" " + matrix[i, j][0] + " ");
                            }
                            else if (matrix[i, j] == "Пg" || matrix[i, j] == "Tg" || matrix[i, j] == "Hg" || matrix[i, j] == "Cg" || matrix[i, j] == "Qg" || matrix[i, j] == "Kg" || matrix[i, j] == "Tg1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(" " + matrix[i, j][0] + " ");
                            }
                            else if (matrix[i, j] == "*")
                            {
                                Console.Write("   ");
                            }
                            else
                            {
                                if (Console.BackgroundColor == ConsoleColor.White)
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                Console.Write(" " + matrix[i, j] + " ");
                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            if (i == 1 && j == 10 && green_losses != "")
                            {
                                Console.Write(" " + green_losses);
                            }
                            else if (i == 10 && j == 10 && green_losses != "")
                            {
                                Console.Write(" " + red_losses);
                            }
                        }
                        Console.WriteLine();
                    }
                }
                else if (counter_side == 1)
                {
                    for (int i = 10; i > 0; i--)
                    {
                        for (int j = 10; j > 0; j--)
                        {
                            if ((i + j) % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            if (matrix[i, j] == "Пr" || matrix[i, j] == "Tr" || matrix[i, j] == "Hr" || matrix[i, j] == "Cr" || matrix[i, j] == "Qr" || matrix[i, j] == "Kr" || matrix[i, j] == "Tr1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(" " + matrix[i, j][0] + " ");
                            }
                            else if (matrix[i, j] == "Пg" || matrix[i, j] == "Tg" || matrix[i, j] == "Hg" || matrix[i, j] == "Cg" || matrix[i, j] == "Qg" || matrix[i, j] == "Kg" || matrix[i, j] == "Tg1")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(" " + matrix[i, j][0] + " ");
                            }
                            else if (matrix[i, j] == "*")
                            {
                                Console.Write("   ");
                            }
                            else
                            {
                                if (Console.BackgroundColor == ConsoleColor.White)
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                Console.Write(" " + matrix[i, j] + " ");
                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            if (i == 1 && j == 1 && green_losses != "")
                            {
                                Console.Write(" " + green_losses);
                            }
                            if (i == 10 && j == 1 && red_losses != "")
                            {
                                Console.Write(" " + red_losses);
                            }
                        }
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            void counter_figures()
            {
                int lose_counter_green_tura = 0;
                int lose_counter_red_tura = 0;
                int lose_counter_green_slon = 0;
                int lose_counter_red_slon = 0;
                int lose_counter_green_horse = 0;
                int lose_counter_red_horse = 0;
                int lose_counter_green_queen = 0;
                int lose_counter_red_queen = 0;
                int lose_counter_green_peshak = 0;
                int lose_counter_red_peshak = 0;
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 10; j++)
                    {
                        switch (matrix[i, j])
                        {
                            case "Tg":
                                goto case "Tg1";
                            case "Tg1":
                                lose_counter_green_tura++;
                                break;
                            case "Tr":
                                goto case "Tr1";
                            case "Tr1":
                                lose_counter_red_tura++;
                                break;
                            case "Cg":
                                lose_counter_green_slon++;
                                break;
                            case "Cr":
                                lose_counter_red_slon++;
                                break;
                            case "Hg":
                                lose_counter_green_horse++;
                                break;
                            case "Hr":
                                lose_counter_red_horse++;
                                break;
                            case "Qg":
                                lose_counter_green_queen++;
                                break;
                            case "Qr":
                                lose_counter_red_queen++;
                                break;
                            case "Пg":
                                lose_counter_green_peshak++;
                                break;
                            case "Пr":
                                lose_counter_red_peshak++;
                                break;
                        }
                    }
                }
                advantage = 8 - lose_counter_red_peshak + 3 * (horse_red_possible_quantity - lose_counter_red_horse) + 3 * (slon_red_possible_quantity - lose_counter_red_slon) + 5 * (tura_red_possible_quantity - lose_counter_red_tura) + 9 * (queen_red_possible_quantity - lose_counter_red_queen) - (8 - lose_counter_green_peshak + 3 * (horse_green_possible_quantity - lose_counter_green_horse) + 3 * (slon_green_possible_quantity - lose_counter_green_slon) + 5 * (tura_green_possible_quantity - lose_counter_green_tura) + 9 * (queen_green_possible_quantity - lose_counter_green_queen));
                green_losses = string.Concat(Enumerable.Repeat("П", 8 - lose_counter_green_peshak)) + string.Concat(Enumerable.Repeat("H", horse_green_possible_quantity - lose_counter_green_horse)) + string.Concat(Enumerable.Repeat("C", slon_green_possible_quantity - lose_counter_green_slon)) + string.Concat(Enumerable.Repeat("T", tura_green_possible_quantity - lose_counter_green_tura)) + string.Concat(Enumerable.Repeat("Q", queen_green_possible_quantity - lose_counter_green_queen));
                red_losses = string.Concat(Enumerable.Repeat("П", 8 - lose_counter_red_peshak)) + string.Concat(Enumerable.Repeat("H", horse_red_possible_quantity - lose_counter_red_horse)) + string.Concat(Enumerable.Repeat("C", slon_red_possible_quantity - lose_counter_red_slon)) + string.Concat(Enumerable.Repeat("T", tura_red_possible_quantity - lose_counter_red_tura)) + string.Concat(Enumerable.Repeat("Q", queen_red_possible_quantity - lose_counter_red_queen));
                if (advantage > 0)
                {
                    red_losses += " +" + Convert.ToString(8 - lose_counter_red_peshak + 3 * (horse_red_possible_quantity - lose_counter_red_horse) + 3 * (slon_red_possible_quantity - lose_counter_red_slon) + 5 * (tura_red_possible_quantity - lose_counter_red_tura) + 9 * (queen_red_possible_quantity - lose_counter_red_queen));
                }
                else if (advantage < 0)
                {
                    green_losses += " +" + Convert.ToString(8 - lose_counter_green_peshak + 3 * (horse_green_possible_quantity - lose_counter_green_horse) + 3 * (slon_green_possible_quantity - lose_counter_green_slon) + 5 * (tura_green_possible_quantity - lose_counter_green_tura) + 9 * (queen_green_possible_quantity - lose_counter_green_queen));
                }
            }
            void place1(string green)
            {
                if (cell1.Length == 2)
                {
                    letter_converter(cell1, ref dig2);
                    if (1 < 58 - Convert.ToInt32(cell1[1]) && 58 - Convert.ToInt32(cell1[1]) < 10)
                    {
                        dig1 = 58 - Convert.ToInt32(cell1[1]);
                    }
                }
                if (cell1 == "РОКИРОВКА ВПРАВО" || cell1 == "РОКИРОВКА ВЛЕВО")
                {
                    error_cell = false;
                }
                else if (cell1.Length != 2 || (Convert.ToString(cell1[1]) != "1" && Convert.ToString(cell1[1]) != "2" && Convert.ToString(cell1[1]) != "3" && Convert.ToString(cell1[1]) != "4" && Convert.ToString(cell1[1]) != "5" && Convert.ToString(cell1[1]) != "6" && Convert.ToString(cell1[1]) != "7" && Convert.ToString(cell1[1]) != "8"))
                {
                    error_cell = true;
                }
            }
            void place2(string green)
            {
                if (cell2.Length == 2)
                {
                    letter_converter(cell2, ref dig4);
                    if (1 < 58 - Convert.ToInt32(cell2[1]) && 58 - Convert.ToInt32(cell2[1]) < 10)
                    {
                        dig3 = 58 - Convert.ToInt32(cell2[1]);
                    }
                }
                if (cell2.Length != 2 || (Convert.ToString(cell2[1]) != "1" && Convert.ToString(cell2[1]) != "2" && Convert.ToString(cell2[1]) != "3" && Convert.ToString(cell2[1]) != "4" && Convert.ToString(cell2[1]) != "5" && Convert.ToString(cell2[1]) != "6" && Convert.ToString(cell2[1]) != "7" && Convert.ToString(cell2[1]) != "8"))
                {
                    error_cell = true;
                }
                else if (cell1[0] == cell2[0] && cell1[1] == cell2[1])
                {
                    error_cell = true;
                }
            }
            void letter_converter(string cell, ref int dig)
            {
                switch (Convert.ToString(cell[0]))
                {
                    case "A":
                        dig = 2;
                        break;
                    case "B":
                        dig = 3;
                        break;
                    case "C":
                        dig = 4;
                        break;
                    case "D":
                        dig = 5;
                        break;
                    case "E":
                        dig = 6;
                        break;
                    case "F":
                        dig = 7;
                        break;
                    case "G":
                        dig = 8;
                        break;
                    case "H":
                        dig = 9;
                        break;
                }
            }
            bool attempt(string attacker)
            {
                matrix[dig1, dig2] = "*";
                temp = matrix[dig3, dig4];
                matrix[dig3, dig4] = attacker;
                if (attacker == "Пg" || attacker == "Tg" || attacker == "Tg1" || attacker == "Cg" || attacker == "Hg" || attacker == "Qg")
                {
                    chax(king_green_coor1, king_green_coor2, "green");
                    matrix[dig1, dig2] = attacker;
                    matrix[dig3, dig4] = temp;
                }
                else
                {
                    chax(king_red_coor1, king_red_coor2, "red");
                    matrix[dig1, dig2] = attacker;
                    matrix[dig3, dig4] = temp;
                }
                return chaxmat;
            }
            void enemy_ally(string hero)
            {
                if (hero == "Tg1" || hero == "Tg" || hero == "Cg" || hero == "Hg" || hero == "Qg" || hero == "Kg" || hero == "Пg")
                {
                    enemyП = "Пr";
                    enemyC = "Cr";
                    enemyH = "Hr";
                    enemyT = "Tr";
                    enemyT1 = "Tr1";
                    enemyQ = "Qr";
                    enemyK = "Kr";
                    allyП = "Пg";
                    allyC = "Cg";
                    allyH = "Hg";
                    allyT = "Tg";
                    allyT1 = "Tg1";
                    allyQ = "Qg";
                    allyK = "Kg";
                }
                else
                {
                    enemyП = "Пg";
                    enemyC = "Cg";
                    enemyH = "Hg";
                    enemyT = "Tg";
                    enemyT1 = "Tg1";
                    enemyQ = "Qg";
                    enemyK = "Kg";
                    allyП = "Пr";
                    allyC = "Cr";
                    allyH = "Hr";
                    allyT = "Tr";
                    allyT1 = "Tr1";
                    allyQ = "Qr";
                    allyK = "Kr";
                }
            }
            void peshak(string hero)
            {
                int edge_start = 0;
                int edge_end = 0;
                int distance = 0;
                if (hero == "Пg")
                {
                    edge_start = 8;
                    edge_end = 2;
                    distance = -1;
                }
                else
                {
                    edge_start = 3;
                    edge_end = 9;
                    distance = 1;
                }
                enemy_ally(hero);
                if (attempt(hero))
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (matrix[dig3, dig4] == "*" && dig2 == dig4 && ((dig3 - dig1 == distance) || (dig1 == edge_start && dig3 - dig1 == 2 * distance && matrix[dig3 - distance, dig4] == "*")))
                {
                    if (dig3 == edge_end)
                    {
                        Console.WriteLine("тура(1)/слон(2)/ферзь(3)/конь(4)?");
                        answer = Convert.ToInt32(Console.ReadLine());
                        while (answer != 1 && answer != 2 && answer != 3 && answer != 4)
                        {
                            Console.WriteLine("Выбери что то из вышеперечисленного и напиши цифру");
                            answer = Convert.ToInt32(Console.ReadLine());
                        }
                        switch (answer)
                        {
                            case 1:
                                matrix[dig3, dig4] = allyT;
                                if (hero == "Пg")
                                {
                                    tura_green_possible_quantity++;
                                }
                                else
                                {

                                    tura_red_possible_quantity++;
                                }
                                break;
                            case 2:
                                matrix[dig3, dig4] = allyC;
                                if (hero == "Пg")
                                {
                                    slon_green_possible_quantity++;
                                }
                                else
                                {

                                    slon_red_possible_quantity++;
                                }
                                break;
                            case 3:
                                matrix[dig3, dig4] = allyQ;
                                if (hero == "Пg")
                                {
                                    queen_green_possible_quantity++;
                                }
                                else
                                {

                                    queen_red_possible_quantity++;
                                }
                                break;
                            case 4:
                                matrix[dig3, dig4] = allyH;
                                if (hero == "Пg")
                                {
                                    horse_green_possible_quantity++;
                                }
                                else
                                {

                                    horse_red_possible_quantity++;
                                }
                                break;
                        }
                    }
                    else
                    {
                        matrix[dig3, dig4] = hero;
                    }
                    if (hero == "Пg")
                    {
                        counter_side++;
                    }
                    else
                    {
                        counter_side--;
                    }
                    counter_moves++;
                    matrix[dig1, dig2] = "*";
                }
                else if ((matrix[dig3, dig4] == enemyП || matrix[dig3, dig4] == enemyC || matrix[dig3, dig4] == enemyH || matrix[dig3, dig4] == enemyT || matrix[dig3, dig4] == enemyT1 || matrix[dig3, dig4] == enemyQ || matrix[dig3, dig4] == enemyK) && Math.Abs(dig4 - dig2) == 1 && dig3 - dig1 == distance)
                {
                    if (dig3 == edge_end)
                    {
                        Console.WriteLine("тура(1)/слон(2)/ферзь(3)/конь(4)?");
                        answer = Convert.ToInt32(Console.ReadLine());
                        while (answer != 1 && answer != 2 && answer != 3 && answer != 4)
                        {
                            Console.WriteLine("Выбери что то из вышеперечисленного и цифру");
                            answer = Convert.ToInt32(Console.ReadLine());
                        }
                        switch (answer)
                        {
                            case 1:
                                matrix[dig3, dig4] = allyT;
                                break;
                            case 2:
                                matrix[dig3, dig4] = allyC;
                                break;
                            case 3:
                                matrix[dig3, dig4] = allyQ;
                                break;
                            case 4:
                                matrix[dig3, dig4] = allyH;
                                break;
                        }
                    }
                    else
                    {
                        matrix[dig3, dig4] = hero;
                    }
                    if (hero == "Пg")
                    {
                        counter_side++;
                    }
                    else
                    {
                        counter_side--;
                    }
                    counter_moves++;
                    matrix[dig1, dig2] = "*";
                }
                else
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
            }
            void horse(string hero)
            {
                enemy_ally(hero);
                if (attempt(hero))
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (matrix[dig3, dig4] != " " && (Math.Pow((dig3 - dig1), 2) + Math.Pow((dig4 - dig2), 2)) == 5 && matrix[dig3, dig4] != allyП && matrix[dig3, dig4] != allyC && matrix[dig3, dig4] != allyH && matrix[dig3, dig4] != allyT && matrix[dig3, dig4] != allyT1 && matrix[dig3, dig4] != allyQ && matrix[dig3, dig4] != allyK)
                {
                    matrix[dig3, dig4] = hero;
                    matrix[dig1, dig2] = "*";
                    if (hero == "Hg")
                    {
                        counter_side++;
                    }
                    else
                    {
                        counter_side--;
                    }
                    counter_moves++;
                }
                else
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
            }
            void tura()
            {
                enemy_ally(figura);
                if (attempt(figura))
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (dig1 == dig3)
                {
                    if (dig4 > dig2 || matrix[dig3, dig4] == enemyП || matrix[dig3, dig4] == enemyC || matrix[dig3, dig4] == enemyH || matrix[dig3, dig4] == enemyT || matrix[dig3, dig4] == enemyT1 || matrix[dig3, dig4] == enemyQ || matrix[dig3, dig4] == enemyK)
                    {
                        counter_no_free_place--;
                    }
                    for (int i = Math.Min(dig2, dig4); i < Math.Max(dig2, dig4); i++)
                    {
                        if (matrix[dig1, i] != "*")
                        {
                            counter_no_free_place++;
                        }
                        if (counter_no_free_place > 0)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                            break;
                        }
                    }
                    if (counter_no_free_place == 0 && matrix[dig3, dig4] != allyП && matrix[dig3, dig4] != allyC && matrix[dig3, dig4] != allyH && matrix[dig3, dig4] != allyT && matrix[dig3, dig4] != allyT1 && matrix[dig3, dig4] != allyQ && matrix[dig3, dig4] != allyK)
                    {
                        matrix[dig3, dig4] = figura;
                        matrix[dig1, dig2] = "*";
                        counter_moves++;
                        if (figura == "Tg" || figura == "Tg1" || figura == "Qg")
                        {
                            counter_side++;
                        }
                        else if (figura == "Tr" || figura == "Tr1" || figura == "Qr")
                        {
                            counter_side--;
                        }
                        if (figura == "Tg")
                        {
                            counter_tura1_green_moves++;
                        }
                        else if (figura == "Tg1")
                        {
                            counter_tura2_green_moves++;
                        }
                        else if (figura == "Tr")
                        {
                            counter_tura1_red_moves++;
                        }
                        else if (figura == "Tr1")
                        {
                            counter_tura2_red_moves++;
                        }
                    }
                }
                else if (dig2 == dig4)
                {
                    if (dig1 < dig3 || matrix[dig3, dig4] == enemyП || matrix[dig3, dig4] == enemyC || matrix[dig3, dig4] == enemyH || matrix[dig3, dig4] == enemyT || matrix[dig3, dig4] == enemyT1 || matrix[dig3, dig4] == enemyQ || matrix[dig3, dig4] == enemyK)
                    {
                        counter_no_free_place--;
                    }
                    for (int i = Math.Min(dig1, dig3); i < Math.Max(dig1, dig3); i++)
                    {
                        if (matrix[i, dig2] != "*")
                        {
                            counter_no_free_place++;
                        }
                        if (counter_no_free_place > 0)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                            break;
                        }
                    }
                    if (counter_no_free_place == 0 && matrix[dig3, dig4] != allyП && matrix[dig3, dig4] != allyC && matrix[dig3, dig4] != allyH && matrix[dig3, dig4] != allyT && matrix[dig3, dig4] != allyT1 && matrix[dig3, dig4] != allyQ && matrix[dig3, dig4] != allyK)
                    {
                        matrix[dig3, dig4] = figura;
                        matrix[dig1, dig2] = "*";
                        counter_moves++;
                        if (figura == "Tg" || figura == "Tg1" || figura == "Qg")
                        {
                            counter_side++;
                        }
                        else if (figura == "Tr" || figura == "Tr1" || figura == "Qr")
                        {
                            counter_side--;
                        }
                        if (figura == "Tg")
                        {
                            counter_tura1_green_moves++;
                        }
                        else if (figura == "Tg1")
                        {
                            counter_tura2_green_moves++;
                        }
                        else if (figura == "Tr")
                        {
                            counter_tura1_red_moves++;
                        }
                        else if (figura == "Tr1")
                        {
                            counter_tura2_red_moves++;
                        }
                    }
                }
                if (dig1 != dig3 && dig2 != dig4 && figura != "Qr" && figura != "Qg")
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
                counter_no_free_place = 0;
            }
            void slon()
            {
                enemy_ally(figura);
                if (attempt(figura))
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (Math.Abs(dig3 - dig1) == Math.Abs(dig4 - dig2) && matrix[dig3, dig4] != allyП && matrix[dig3, dig4] != allyC && matrix[dig3, dig4] != allyH && matrix[dig3, dig4] != allyT && matrix[dig3, dig4] != allyT1 && matrix[dig3, dig4] != allyQ && matrix[dig3, dig4] != allyK)
                {
                    if (dig1 > dig3 && dig2 > dig4)
                    {
                        for (int i = 0; i < Math.Abs(dig3 - dig1); i++)
                        {
                            if (matrix[dig1 - i, dig2 - i] != "*")
                            {
                                counter_no_free_place++;
                            }
                        }
                        if (counter_no_free_place > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counter_side++;
                            }
                            else
                            {
                                counter_side--;
                            }
                            matrix[dig1, dig2] = "*";
                            matrix[dig3, dig4] = figura;
                        }
                    }
                    else if (dig1 > dig3 && dig2 < dig4)
                    {
                        for (int i = 0; i < Math.Abs(dig3 - dig1); i++)
                        {
                            if (matrix[dig1 - i, dig2 + i] != "*")
                            {
                                counter_no_free_place++;
                            }
                        }
                        if (counter_no_free_place > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counter_side++;
                            }
                            else
                            {
                                counter_side--;
                            }
                            counter_moves++;
                            matrix[dig1, dig2] = "*";
                            matrix[dig3, dig4] = figura;
                        }
                    }
                    else if (dig1 < dig3 && dig2 > dig4)
                    {
                        for (int i = 0; i < Math.Abs(dig3 - dig1); i++)
                        {
                            if (matrix[dig1 + i, dig2 - i] != "*")
                            {
                                counter_no_free_place++;
                            }
                        }
                        if (counter_no_free_place > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counter_side++;
                            }
                            else
                            {
                                counter_side--;
                            }
                            counter_moves++;
                            matrix[dig1, dig2] = "*";
                            matrix[dig3, dig4] = figura;
                        }
                    }
                    else if (dig1 < dig3 && dig2 < dig4)
                    {
                        for (int i = 0; i < Math.Abs(dig3 - dig1); i++)
                        {
                            if (matrix[dig1 + i, dig2 + i] != "*")
                            {
                                counter_no_free_place++;
                            }
                        }
                        if (counter_no_free_place > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counter_side++;
                            }
                            else
                            {
                                counter_side--;
                            }
                            counter_moves++;
                            matrix[dig1, dig2] = "*";
                            matrix[dig3, dig4] = figura;
                        }
                    }
                }
                else  if (Math.Abs(dig3 - dig1) != Math.Abs(dig4 - dig2) && figura != "Qg" && figura != "Qr")
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
                counter_no_free_place = 0;
            }
            void king(string hero)
            {
                enemy_ally(hero);
                matrix[dig1, dig2] = "*";
                if (hero == "Kg")
                {
                    if (chax(dig3, dig4, "green"))
                    {
                        Console.WriteLine("Не надо, дядя. Убьют тебя");
                    }
                    matrix[dig1, dig2] = hero;
                }
                else if (hero == "Kr")
                {
                    if (chax(dig3, dig4, "red"))
                    {
                        Console.WriteLine("Не надо, дядя. Убьют тебя");
                    }
                    matrix[dig1, dig2] = hero;
                }
                if (chaxmat == false)
                {
                    if (((Math.Abs(dig3 - dig1) == 1 && Math.Abs(dig4 - dig2) == 1) || (dig3 - dig1 == 0 && Math.Abs(dig4 - dig2) == 1) || (dig4 - dig2 == 0 && Math.Abs(dig3 - dig1) == 1)) && (matrix[dig3, dig4] != " " && matrix[dig3, dig4] != allyП && matrix[dig3, dig4] != allyC && matrix[dig3, dig4] != allyH && matrix[dig3, dig4] != allyT && matrix[dig3, dig4] != allyT1 && matrix[dig3, dig4] != allyQ))
                    {
                        matrix[dig3, dig4] = hero;
                        matrix[dig1, dig2] = "*";
                        if (hero == "Kg")
                        {
                            counter_king_green_moves++;
                            counter_side++;
                        }
                        else
                        {
                            counter_king_red_moves++;
                            counter_side--;
                        }
                        counter_moves++;
                    }
                    else
                    {
                        Console.WriteLine("Не-а, так нельзя ходить");
                    }
                }
            }
            void killer_detector(int x, int y, string hero, List<int> firstcoor, List<int> secondcoor)
            {
                if (matrix[x, y] == hero)
                {
                    firstcoor.Add(x);
                    secondcoor.Add(y);
                }
            }
            void slon_detector(int x, int y, ref bool noobstacle, List<int> firstcoor, List<int> secondcoor)
            {
                if (matrix[x, y] != "*" && matrix[x, y] != enemyC && matrix[x, y] != enemyQ)
                {
                    noobstacle = false;
                }
                if (noobstacle == true && (matrix[x, y] == enemyC || matrix[x, y] == enemyQ))
                {
                    firstcoor.Add(x);
                    secondcoor.Add(y);
                }
            }
            void tura_detector(int x, int y, ref bool noobstacle, List<int> firstcoor, List<int> secondcoor)
            {
                if (matrix[x, y] != "*" && matrix[x, y] != enemyQ && matrix[x, y] != enemyT && matrix[x, y] != enemyT1)
                {
                    noobstacle = false;
                }
                if (noobstacle == true && (matrix[x, y] == enemyQ || matrix[x, y] == enemyT || matrix[x, y] == enemyT1))
                {
                    firstcoor.Add(x);
                    secondcoor.Add(y);
                }
            }
            bool chax(int n, int m, string color)
            {
                first_coor_death.Clear();
                second_coor_death.Clear();
                chaxmat = false;
                chax_right_top_slon = true;
                chax_left_top_slon = true;
                chax_right_down_slon = true;
                chax_left_down_slon = true;
                chax_left_tura = true;
                chax_right_tura = true;
                chax_top_tura = true;
                chax_down_tura = true;
                if (color == "green")
                {
                    enemy_ally("Kg");
                    killer_detector(n - 1, m + 1, enemyП, first_coor_death, second_coor_death);
                    killer_detector(n - 1, m - 1, enemyП, first_coor_death, second_coor_death);
                }
                else if (color == "red")
                {
                    enemy_ally("Kr");
                    killer_detector(n + 1, m + 1, enemyП, first_coor_death, second_coor_death);
                    killer_detector(n + 1, m - 1, enemyП, first_coor_death, second_coor_death);
                }
                //Console.WriteLine("До коней");
                //matrix_build();
                killer_detector(n - 1, m - 2, enemyH, first_coor_death, second_coor_death);
                killer_detector(n - 1, m + 2, enemyH, first_coor_death, second_coor_death);
                killer_detector(n + 1, m - 2, enemyH, first_coor_death, second_coor_death);
                killer_detector(n + 1, m + 2, enemyH, first_coor_death, second_coor_death);
                killer_detector(n - 2, m - 1, enemyH, first_coor_death, second_coor_death);
                killer_detector(n - 2, m + 1, enemyH, first_coor_death, second_coor_death);
                killer_detector(n + 2, m - 1, enemyH, first_coor_death, second_coor_death);
                killer_detector(n + 2, m + 1, enemyH, first_coor_death, second_coor_death);
                //Console.WriteLine("После коней");
                //matrix_build();
                for (int i = 1; i < 12; i++)
                {
                    if (0 < n - i && 0 < m - i)
                    {
                        slon_detector(n - i, m - i, ref chax_right_top_slon, first_coor_death, second_coor_death);
                    }
                    if (0 < n - i && m + i < 11)
                    {
                        slon_detector(n - i, m + i, ref chax_left_top_slon, first_coor_death, second_coor_death);
                    }
                    if (n + i < 11 && 0 < m - i)
                    {
                        slon_detector(n + i, m - i, ref chax_right_down_slon, first_coor_death, second_coor_death);
                    }
                    if (n + i < 11 && m + i < 11)
                    {
                        slon_detector(n + i, m + i, ref chax_left_down_slon, first_coor_death, second_coor_death);
                    }
                    if (0 < n - i)
                    {
                        tura_detector(n - i, m, ref chax_top_tura, first_coor_death, second_coor_death);
                    }
                    if (n + i < 11)
                    {
                        tura_detector(n + i, m, ref chax_down_tura, first_coor_death, second_coor_death);
                    }
                    if (0 < m - i)
                    {
                        tura_detector(n, m - i, ref chax_left_tura, first_coor_death, second_coor_death);
                    }
                    if (m + i < 11)
                    {
                        tura_detector(n, m + i, ref chax_right_tura, first_coor_death, second_coor_death);
                    }

                    killer_detector(n - 1, m, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n + 1, m, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n - 1, m - 1, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n - 1, m + 1, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n, m - 1, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n, m + 1, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n + 1, m - 1, enemyK, first_coor_death, second_coor_death);
                    killer_detector(n + 1, m + 1, enemyK, first_coor_death, second_coor_death);
                }
                if (first_coor_death.Count > 0)
                {
                    chaxmat = true;
                }
                return chaxmat;
            }
            
            void block(int n, int m, string color) // указывать цвет который блокирует атаку оппонента
            {
                first_coor_block.Clear();
                second_coor_block.Clear();
                chax_right_top_slon = true;
                chax_left_top_slon = true;
                chax_right_down_slon = true;
                chax_left_down_slon = true;
                chax_left_tura = true;
                chax_right_tura = true;
                chax_top_tura = true;
                chax_down_tura = true;
                if (color == "green")
                {
                    enemy_ally("Kr");
                    killer_detector(n + 1, m, enemyП, first_coor_block, second_coor_block);
                    if (matrix[n + 2, m] == enemyП && n == 6 && matrix[n + 1, m] == "*")
                    {
                        killer_detector(n + 2, m, enemyП, first_coor_block, second_coor_block);
                    }
                }
                else if (color == "red")
                {
                    enemy_ally("Kg");
                    killer_detector(n - 1, m, enemyП, first_coor_block, second_coor_block);
                    if (matrix[n - 2, m] == enemyП && n == 5 && matrix[n - 1, m] == "*")
                    {
                        killer_detector(n - 2, m, enemyП, first_coor_block, second_coor_block);
                    }
                }
                
                killer_detector(n - 1, m - 2, enemyH, first_coor_block, second_coor_block);
                killer_detector(n - 1, m + 2, enemyH, first_coor_block, second_coor_block);
                killer_detector(n + 1, m - 2, enemyH, first_coor_block, second_coor_block);
                killer_detector(n + 1, m + 2, enemyH, first_coor_block, second_coor_block);
                killer_detector(n - 2, m - 1, enemyH, first_coor_block, second_coor_block);
                killer_detector(n - 2, m + 1, enemyH, first_coor_block, second_coor_block);
                killer_detector(n + 2, m - 1, enemyH, first_coor_block, second_coor_block);
                killer_detector(n + 2, m + 1, enemyH, first_coor_block, second_coor_block);
                
                for (int i = 1; i < 12; i++)
                {
                    if (0 < n - i && 0 < m - i)
                    {
                        slon_detector(n - i, m - i, ref chax_right_top_slon, first_coor_block, second_coor_block);
                    }
                    if (0 < n - i && m + i < 11)
                    {
                        slon_detector(n - i, m + i, ref chax_left_top_slon, first_coor_block, second_coor_block);
                    }
                    if (n + i < 11 && 0 < m - i)
                    {
                        slon_detector(n + i, m - i, ref chax_right_down_slon, first_coor_block, second_coor_block);
                    }
                    if (n + i < 11 && m + i < 11)
                    {
                        slon_detector(n + i, m + i, ref chax_left_down_slon, first_coor_block, second_coor_block);
                    }
                    if (0 < n - i)
                    {
                        tura_detector(n - i, m, ref chax_top_tura, first_coor_block, second_coor_block);
                    }
                    if (n + i < 11)
                    {
                        tura_detector(n + i, m, ref chax_down_tura, first_coor_block, second_coor_block);
                    }
                    if (0 < m - i)
                    {
                        tura_detector(n, m - i, ref chax_left_tura, first_coor_block, second_coor_block);
                    }
                    if (m + i < 11)
                    {
                        tura_detector(n, m + i, ref chax_right_tura, first_coor_block, second_coor_block);
                    }
                }
                for (int i = 0; i < first_coor_block.Count - 1; i++)
                {
                    if (first_coor_block[i] == first_coor_block[i + 1] && second_coor_block[i] == second_coor_block[i + 1])
                    {
                        first_coor_block.Remove(first_coor_block[i]);
                        second_coor_block.Remove(second_coor_block[i]);
                    }
                }
            }
            bool free_area_around_king(int limitcoor1, int limitcoor2, int x, int y, string col)
            {
                if (king_coor1 != limitcoor1 && king_coor2 != limitcoor2 && matrix[x, y] != allyП && matrix[x, y] != allyC && matrix[x, y] != allyH && matrix[x, y] != allyT && matrix[x, y] != allyT1 && matrix[x, y] != allyQ)
                {
                    temp = matrix[king_coor1, king_coor2];
                    matrix[king_coor1, king_coor2] = "*";
                    chax(x, y, col);
                    matrix[king_coor1, king_coor2] = temp;
                    if (chaxmat == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            bool end(string color)
            {
                string oppositecolor = "";
                bool killed = false;
                bool blocked = false;
                string temp;
                int range1;
                int range2;
                string copy_list_ally_coor1 = "";
                string copy_list_ally_coor2 = "";
                string copy_list_opposite_coor1 = "";
                string copy_list_opposite_coor2 = "";
                int ally_coor1 = 0;
                int ally_coor2 = 0;
                int opposite_coor1 = 0;
                int opposite_coor2 = 0;
                if (color == "green")
                {
                    oppositecolor = "red";
                    king_coor1 = king_green_coor1;
                    king_coor2 = king_green_coor2;
                }
                else if (color == "red")
                {
                    oppositecolor = "green";
                    king_coor1 = king_red_coor1;
                    king_coor2 = king_red_coor2;
                }
                
                if (chax(king_coor1, king_coor2, color))
                {
                    range1 = first_coor_death.Count;
                    ally_first_coor_death = first_coor_death;
                    ally_second_coor_death = second_coor_death;
                    for (int k = 0; k < range1; k++)
                    {
                        copy_list_ally_coor1 += ally_first_coor_death[k];
                        copy_list_ally_coor2 += ally_second_coor_death[k];
                    }
                    for (int i = 0; i < range1; i++)
                    {
                        ally_coor1 = Convert.ToInt32(copy_list_ally_coor1[i]) - 48;
                        ally_coor2 = Convert.ToInt32(copy_list_ally_coor2[i]) - 48;
                        if (chax(ally_coor1, ally_coor2, oppositecolor))
                        {
                            opposite_first_coor_death = first_coor_death;
                            opposite_second_coor_death = second_coor_death;
                            for (int k = 0; k < opposite_first_coor_death.Count; k++)
                            {
                                copy_list_opposite_coor1 += opposite_first_coor_death[k];
                                copy_list_opposite_coor2 += opposite_second_coor_death[k];
                            }
                            range2 = copy_list_opposite_coor1.Length;
                            for (int j = 0; j < range2; j++)
                            {
                                opposite_coor1 = Convert.ToInt32(copy_list_opposite_coor1[i]) - 48;
                                opposite_coor2 = Convert.ToInt32(copy_list_opposite_coor2[i]) - 48;
                                enemy_ally(matrix[king_coor1, king_coor2]);
                                if (matrix[opposite_coor1, opposite_coor2] == allyK)
                                {
                                    if (chax(ally_coor1, ally_coor2, color))
                                    {
                                        continue;
                                    }
                                }
                                if (chaxmat == false)
                                {
                                    killed = true;
                                    break;
                                }
                            }
                            chaxmat = false;
                        }
                    }
                    for (int i = 2; i < 10; i++)
                    {
                        for (int j = 2; j < 10; j++)
                        {
                            if (matrix[i, j] == "*")
                            {
                                block(i, j, color);
                                for (int k = 0; k < first_coor_block.Count; k++)
                                {
                                    matrix[i, j] = matrix[first_coor_block[k], second_coor_block[k]];
                                    matrix[first_coor_block[k], second_coor_block[k]] = "*";
                                    chax(king_coor1, king_coor2, color);
                                    matrix[first_coor_block[k], second_coor_block[k]] = matrix[i, j];
                                    matrix[i, j] = "*";
                                    if (chaxmat == false)
                                    {
                                        blocked = true;
                                    }
                                }

                            }
                        }
                    }
                }
                if (free_area_around_king(2, 0, king_coor1 - 1, king_coor2, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(2, 9, king_coor1 - 1, king_coor2 + 1, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(2, 2, king_coor1 - 1, king_coor2 - 1, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(9, 0, king_coor1 + 1, king_coor2, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(9, 9, king_coor1 + 1, king_coor2 + 1, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(9, 2, king_coor1 + 1, king_coor2 - 1, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(0, 9, king_coor1, king_coor2 + 1, color) == false)
                {
                    return false;
                }
                if (free_area_around_king(0, 2, king_coor1, king_coor2 - 1, color) == false)
                {
                    return false;
                }
                if (killed || blocked)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            void possible_move(int x_start, int y_start, int x_finish, int y_finish, string hero, ref int counter_moves, string color)
            {
                if (matrix[x_finish, y_finish] == "*" || matrix[x_finish, y_finish] == enemyП || matrix[x_finish, y_finish] == enemyC && matrix[x_finish, y_finish] == enemyH && matrix[x_finish, y_finish] == enemyT && matrix[x_finish, y_finish] == enemyT1 && matrix[x_finish, y_finish] == enemyQ)
                {
                    temp = matrix[x_finish, y_finish];
                    matrix[x_finish, y_finish] = hero;
                    matrix[x_start, y_start] = "*";
                    chax(king_coor1, king_coor2, color);
                    if (chaxmat)
                    { 
                        counter_moves++;
                    }
                    matrix[x_start, y_start] = hero;
                    matrix[x_finish, y_finish] = temp;
                }
                else
                {
                    counter_moves++;
                }
            }
            bool stalemate(string color)
            {
                int counterimposmoves;
                if (color == "green")
                {
                    enemy_ally("Kg");
                    king_coor1 = king_green_coor1;
                    king_coor2 = king_green_coor2;
                }
                else if (color == "red")
                {
                    enemy_ally("Kr");
                    king_coor1 = king_red_coor1;
                    king_coor2 = king_red_coor2;
                }
                if (chax(king_coor1, king_coor2, color))
                {
                    return false;
                }
                else
                {
                    if (free_area_around_king(2, 0, king_coor1 - 1, king_coor2, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(2, 9, king_coor1 - 1, king_coor2 + 1, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(0, 2, king_coor1, king_coor2 - 1, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(2, 0, king_coor1 - 1, king_coor2, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(0, 9, king_coor1, king_coor2 + 1, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(9, 0, king_coor1 + 1, king_coor2, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(9, 9, king_coor1 + 1, king_coor2 + 1, color) == false)
                    {
                        return false;
                    }
                    if (free_area_around_king(9, 2, king_coor1 + 1, king_coor2 - 1, color) == false)
                    {
                        return false;
                    }
                }
                
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 10; j++)
                    {
                        counterimposmoves = 0;
                        if (matrix[i, j] == allyП)
                        {
                            if (matrix[i - 1, j] != "*")
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j - 1] == enemyП || matrix[i - 1, j - 1] == enemyC || matrix[i - 1, j - 1] == enemyH || matrix[i - 1, j - 1] == enemyT || matrix[i - 1, j - 1] == enemyT1 || matrix[i - 1, j - 1] == enemyQ)
                            {
                                temp = matrix[i - 1, j - 1];
                                matrix[i - 1, j - 1] = allyП;
                                matrix[i, j] = "*";
                                chax(king_coor1, king_coor2, color);
                                if (chaxmat)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = allyП;
                                matrix[i - 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 1] == enemyП || matrix[i - 1, j + 1] == enemyC || matrix[i - 1, j + 1] == enemyH || matrix[i - 1, j + 1] == enemyT || matrix[i - 1, j + 1] == enemyT1 || matrix[i - 1, j + 1] == enemyQ)
                            {
                                temp = matrix[i - 1, j + 1];
                                matrix[i - 1, j + 1] = allyП;
                                matrix[i, j] = "*";
                                chax(king_coor1, king_coor2, color);
                                if (chaxmat)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = allyП;
                                matrix[i - 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 3)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == allyH)
                        {
                            possible_move(i, j, i - 2, j - 1, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i - 2, j + 1, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i + 2, j - 1, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i + 2, j + 1, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i - 1, j - 2, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i - 1, j + 2, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j - 2, allyH, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j + 2, allyH, ref counterimposmoves, color);
                            if (counterimposmoves != 8)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == allyT)
                        {
                            possible_move(i, j, i - 1, j, allyT, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j, allyT, ref counterimposmoves, color);
                            possible_move(i, j, i, j - 1, allyT, ref counterimposmoves, color);
                            possible_move(i, j, i, j + 1, allyT, ref counterimposmoves, color);
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == allyT1)
                        {
                            possible_move(i, j, i - 1, j, allyT1, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j, allyT1, ref counterimposmoves, color);
                            possible_move(i, j, i, j - 1, allyT1, ref counterimposmoves, color);
                            possible_move(i, j, i, j + 1, allyT1, ref counterimposmoves, color);
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == allyC)
                        {
                            possible_move(i, j, i - 1, j - 1, allyC, ref counterimposmoves, color);
                            possible_move(i, j, i - 1, j + 1, allyC, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j - 1, allyC, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j + 1, allyC, ref counterimposmoves, color);
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == allyQ)
                        {
                            possible_move(i, j, i - 1, j, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i, j - 1, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i, j + 1, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i - 1, j - 1, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i - 1, j + 1, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j - 1, allyQ, ref counterimposmoves, color);
                            possible_move(i, j, i + 1, j + 1, allyQ, ref counterimposmoves, color);
                            if (counterimposmoves != 8)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
        }
    }
}
