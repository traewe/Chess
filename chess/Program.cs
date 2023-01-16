using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Net.Security;
using System.Runtime;
using System.Text;

namespace program
{
    class World
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
            string enemy1 = "";
            string enemy2 = "";
            string enemy3 = "";
            string enemy4 = "";
            string enemy5 = "";
            string enemy6 = "";
            string enemy7 = "";
            string ally1 = "";
            string ally2 = "";
            string ally3 = "";
            string ally4 = "";
            string ally5 = "";
            string ally6 = "";
            string ally7 = "";
            int counterproh = 0;
            int counterturagreenleft = 0;
            int counterturagreenright = 0;
            int counterturaredleft = 0;
            int counterturaredright = 0;
            int counterkinggreen = 0;
            int counterkingred = 0;
            string figura = "";
            int counterside = 0;
            int counterhod = 1;
            int kinggreenplace1 = 9;
            int kinggreenplace2 = 6;
            int kingredplace1 = 2;
            int kingredplace2 = 6;
            bool greenchaxmat = false;
            bool greenchaxrighttopslon = true;
            bool greenchaxlefttopslon = true;
            bool greenchaxrightdownslon = true;
            bool greenchaxleftdownslon = true;
            bool greenchaxlefttura = true;
            bool greenchaxrighttura = true;
            bool greenchaxtoptura = true;
            bool greenchaxdowntura = true;
            bool redchaxmat = false;
            bool redchaxrighttopslon;
            bool redchaxlefttopslon;
            bool redchaxrightdownslon;
            bool redchaxleftdownslon;
            bool redchaxlefttura;
            bool redchaxrighttura;
            bool redchaxtoptura;
            bool redchaxdowntura;
            bool greenkilled = false;
            bool greenblocked = false;
            bool redkilled = false;
            bool redblocked = false;
            bool errorcell1 = false;
            bool errorcell2 = false;
            int answer;
            int advantage;
            string greenlosses = "";
            string redlosses = "";
            List<int> greenfirstcoordeath = new();
            List<int> greensecondcoordeath = new();
            List<int> redfirstcoordeath = new();
            List<int> redsecondcoordeath = new();
            List<int> redfirstcoorblock = new();
            List<int> redsecondcoorblock = new();
            List<int> greenfirstcoorblock = new();
            List<int> greensecondcoorblock = new();
            Console.WriteLine("Обозначения: Т - тура, Н - horse, С - слон, Q - queen, К - король, П - пешка");
            Console.WriteLine("Структура хода: сначала пишешь букву и цифру клетки, где стоит фигура, потом куда хочешь ею походить(пример G3 E3)");
            Console.WriteLine("Для рокировки - рокировка вправо/рокировка влево");
            string[,] matrix = new string[12, 12] { { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }, { " ", " ", "1", "2", "3", "4", "5", "6", "7", "8", " ", " " }, { " ", "A", "Tr", "Hr", "Cr", "*", "Kr", "Cr", "Hr", "Tr1", "A", " " }, { " ", "B", "Пr", "Пr", "Пr", "Пr", "Пr", "Пr", "Пr", "Пr", "B", " " }, { " ", "C", "*", "*", "*", "*", "*", "*", "*", "*", "C", " " }, { " ", "D", "*", "*", "*", "*", "Tg", "*", "Qr", "*", "D", " " }, { " ", "E", "*", "*", "*", "*", "*", "*", "*", "*", "E", " " }, { " ", "F", "*", "*", "*", "*", "*", "*", "*", "*", "F", " " }, { " ", "G", "Пg", "Пg", "Пg", "Пg", "Пg", "Пg", "Пg", "Пg", "G", " " }, { " ", "Н", "*", "Hg", "Cg", "Qg", "Kg", "Cg", "Hg", "Tg1", "Н", " " }, { " ", " ", "1", "2", "3", "4", "5", "6", "7", "8", " ", " " }, { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " } };
            matrixbuild();
            while (true)
            {
                 try
                 {
                    if (counterside == 0)
                    {
                        errorcell1 = false;
                        errorcell2 = false;
                        greenfirstcoordeath.Clear();
                        greensecondcoordeath.Clear();
                        redfirstcoorblock.Clear();
                        redsecondcoorblock.Clear();
                        if (greenstalemate())
                        {
                            Console.WriteLine("Шах и ПАТ! Зеленый рад");
                            break;
                        }
                        else if (greenchax(kinggreenplace1, kinggreenplace2))
                        {
                            Console.WriteLine("YES");
                            if (greenend())
                            {
                                Console.WriteLine("VIKA! VIKA! VIKA! RED WON");
                                break;
                            }
                            Console.WriteLine("ATTENTION! ШАХ!(зеленый! Алло)");
                        }
                        Console.WriteLine($"Ход зеленых  {counterhod} ");
                        cell1 = Console.ReadLine();
                        if (cell1 == "s")
                        {
                            counterside = 1;
                        }
                        place1(cell1);
                        if (errorcell1)
                        {
                            matrixbuild();
                            Console.WriteLine("Внеси данные правильно");
                            continue;
                        }
                        switch (matrix[dig1, dig2])
                        {
                            case "Пg":
                                Console.WriteLine("(пешка)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                peshak("Пg");
                                break;

                            case "Hg":
                                Console.WriteLine("(конь)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
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
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                tura();
                                break;

                            case "Cg":
                                Console.WriteLine("(слон)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Cg";
                                slon();
                                break;

                            case "Qg":
                                Console.WriteLine("(королева)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Qg";
                                tura();
                                slon();
                                break;

                            case "Kg":
                                Console.WriteLine("(король)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                king("Kg");
                                break;
                        }
                        if (cell1 == "рокировка вправо")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                greenchax(9, 6 + i);
                                if (greenchaxmat)
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (greenchaxmat == false)
                            {
                                if (counterkinggreen == 0 && counterturagreenright == 0)
                                {
                                    if (matrix[9, 7] == "*" && matrix[9, 8] == "*")
                                    {
                                        matrix[9, 6] = "*";
                                        matrix[9, 7] = "Tg1";
                                        matrix[9, 8] = "Kg";
                                        matrix[9, 9] = "*";
                                        counterside++;
                                        counterhod++;
                                        kinggreenplace2 = 8;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                        }
                        else if (cell1 == "рокировка влево")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                greenchax(9, 6 - i);
                                if (greenchaxmat)
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (greenchaxmat == false)
                            {
                                if (counterkinggreen == 0 && counterturagreenleft == 0)
                                {
                                    if (matrix[9, 3] == "*" && matrix[9, 4] == "*" && matrix[9, 5] == "*")
                                    {
                                        matrix[9, 2] = "*";
                                        matrix[9, 3] = "*";
                                        matrix[9, 4] = "Kg";
                                        matrix[9, 5] = "Tg";
                                        matrix[9, 6] = "*";
                                        counterside++;
                                        counterhod++;
                                        kinggreenplace2 = 4;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                        }
                        if (counterside != 1)
                        {
                            Console.WriteLine("Берешь свою фигуру и бьешь вражескую. Понял?");
                        }
                        matrixbuild();
                    }
                    if (counterside == 1)
                    {
                        errorcell1 = false;
                        errorcell2 = false;
                        redfirstcoordeath.Clear();
                        redsecondcoordeath.Clear();
                        redfirstcoorblock.Clear();
                        redsecondcoorblock.Clear();
                        if (redstalemate())
                        {
                            Console.WriteLine("Шах и ПАТ! Красный рад");
                            break;
                        }
                        if (redchax(kingredplace1, kingredplace2))
                        {
                            if (redend())
                            {
                                Console.WriteLine("GG WP! GREEN WON");
                                break;
                            }
                            Console.WriteLine("ATTENTION! ШАХ!(красный! Алло)");
                        }
                        Console.WriteLine($"Ход красных {counterhod} ");
                        cell1 = Console.ReadLine();
                        if (cell1 == "s")
                        {
                            counterside = 0;
                        }
                        place1(cell1);
                        if (errorcell1)
                        {
                            matrixbuild();
                            Console.WriteLine("Внеси данные правильно");
                            continue;
                        }
                        switch (matrix[dig1, dig2])
                        {
                            case "Пr":
                                Console.WriteLine("(пешка)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                peshak("Пr");
                                break;
                            case "Hr":
                                Console.WriteLine("(конь)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
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
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                tura();
                                break;

                            case "Cr":
                                Console.WriteLine("(слон)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Cr";
                                attempt("Cr");
                                if (redchaxmat)
                                {
                                    Console.WriteLine("Король: Та за шо");
                                }
                                else
                                {
                                    slon();
                                }
                                break;

                            case "Qr":
                                Console.WriteLine("(королева)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                figura = "Qr";
                                tura();
                                slon();
                                break;

                        case "Kr":
                                Console.WriteLine("(король)");
                                cell2 = Console.ReadLine();
                                place2(cell2);
                                if (errorcell2)
                                {
                                    matrixbuild();
                                    Console.WriteLine("Внеси данные правильно");
                                    continue;
                                }
                                king("Kr");
                                break;
                        }
                        if (cell1 == "рокировка влево")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                redchax(2, 6 + i);
                                if (redchaxmat)
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (redchaxmat == false)
                            {
                                if (counterkingred == 0 && counterturaredright == 0)
                                {
                                    if (matrix[2, 7] == "*" && matrix[2, 8] == "*")
                                    {
                                        matrix[2, 6] = "*";
                                        matrix[2, 7] = "Tr1";
                                        matrix[2, 8] = "Kr";
                                        matrix[2, 9] = "*";
                                        counterside--;
                                        counterhod++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                        }
                        else if (cell1 == "рокировка вправо")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                redchax(2, 6 - i);
                                if (redchaxmat)
                                {
                                    Console.WriteLine("Mission(рокировка) impossible");
                                    break;
                                }
                            }
                            if (redchaxmat == false)
                            {
                                if (counterkingred == 0 && counterturaredleft == 0)
                                {
                                    if (matrix[2, 3] == "*" && matrix[2, 4] == "*" && matrix[2, 5] == "*")
                                    {
                                        matrix[2, 2] = "*";
                                        matrix[2, 3] = "*";
                                        matrix[2, 4] = "Kr";
                                        matrix[2, 5] = "Tr";
                                        matrix[2, 6] = "*";
                                        counterside--;
                                        counterhod++;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Не, ходил ты уже турой или королем");
                                }
                            }
                        }
                        if (counterside != 0)
                        {
                            Console.WriteLine("Фигуру выбери! Желательно свою");
                        }
                        matrixbuild();
                    }
                 }
                 catch
                 {
                     Console.WriteLine("Ай, код поплавило");
                     matrixbuild();
                 }
            }
            Console.WriteLine("Ось i казочцi кiнець, а хто слухав - молодець");
            void matrixbuild()
            {
                counter();
                if (counterside == 0)
                {
                    for (int i = 1; i < 11; i++)
                    {
                        for (int j = 1; j < 11; j++)
                        {
                            if (matrix[i, j] == "Kg")
                            {
                                kinggreenplace1 = i;
                                kinggreenplace2 = j;
                            }
                            if (matrix[i, j] == "Kr")
                            {
                                kingredplace1 = i;
                                kingredplace2 = j;
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
                            if (i == 1 && j == 10 && greenlosses != "")
                            {
                                Console.Write(" " + greenlosses);
                            }
                            else if (i == 10 && j == 10 && greenlosses != "")
                            {
                                Console.Write(" " + redlosses);
                            }
                        }
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (counterside == 1)
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
                            if (i == 1 && j == 1 && greenlosses != "")
                            {
                                Console.Write(" " + greenlosses);
                            }
                            if (i == 10 && j == 1 && redlosses != "")
                            {
                                Console.Write(" " + redlosses);
                            }
                        }
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            void counter()
            {
                int losecountergreentura = 0;
                int losecounterredtura = 0;
                int losecountergreenslon = 0;
                int losecounterredslon = 0;
                int losecountergreenhorse = 0;
                int losecounterredhorse = 0;
                int losecountergreenqueen = 0;
                int losecounterredqueen = 0;
                int losecountergreenpeshak = 0;
                int losecounterredpeshak = 0;
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 10; j++)
                    {
                        switch (matrix[i, j])
                        {
                            case "Tg":
                                goto case "Tg1";
                            case "Tg1":
                                losecountergreentura++;
                                break;
                            case "Tr":
                                goto case "Tr1";
                            case "Tr1":
                                losecounterredtura++;
                                break;
                            case "Cg":
                                losecountergreenslon++;
                                break;
                            case "Cr":
                                losecounterredslon++;
                                break;
                            case "Hg":
                                 losecountergreenhorse++;
                                break;
                            case "Hr":
                                losecounterredhorse++;
                                break;
                            case "Qg":
                                losecountergreenqueen++;
                                break;
                            case "Qr":
                                losecounterredqueen++;
                                break;
                            case "Пg":
                                losecountergreenpeshak++;
                                break;
                            case "Пr":
                                losecounterredpeshak++;
                                break;
                        }
                    }
                }
                advantage = 8 - losecounterredpeshak + 3 * (2 - losecounterredhorse) + 3 * (2 - losecounterredslon) + 5 * (2 - losecounterredtura) + 9 * (1 - losecounterredqueen) - (8 - losecountergreenpeshak + 3 * (2 - losecountergreenhorse) + 3 * (2 - losecountergreenslon) + 5 * (2 - losecountergreentura) + 9 * (1 - losecountergreenqueen));
                greenlosses = string.Concat(Enumerable.Repeat("П", 8 - losecountergreenpeshak)) + string.Concat(Enumerable.Repeat("H", 2 - losecountergreenhorse)) + string.Concat(Enumerable.Repeat("C", 2 - losecountergreenslon)) + string.Concat(Enumerable.Repeat("T", 2 - losecountergreentura)) + string.Concat(Enumerable.Repeat("Q", 1 - losecountergreenqueen));
                redlosses = string.Concat(Enumerable.Repeat("П", 8 - losecounterredpeshak)) + string.Concat(Enumerable.Repeat("H", 2 - losecounterredhorse)) + string.Concat(Enumerable.Repeat("C", 2 - losecounterredslon)) + string.Concat(Enumerable.Repeat("T", 2 - losecounterredtura)) + string.Concat(Enumerable.Repeat("Q", 1 - losecounterredqueen));
                if (advantage > 0)
                {
                    redlosses += " +" + Convert.ToString(8 - losecounterredpeshak + 3 * (2 - losecounterredhorse) + 3 * (2 - losecounterredslon) + 5 * (2 - losecounterredtura) + 9 * (1 - losecounterredqueen) - (8 - losecountergreenpeshak + 3 * (2 - losecountergreenhorse) + 3 * (2 - losecountergreenslon) + 5 * (2 - losecountergreentura) + 9 * (1 - losecountergreenqueen)));
                }
                else if (advantage < 0)
                {
                    greenlosses += " +" + Convert.ToString((8 - losecountergreenpeshak + 3 * (2 - losecountergreenhorse) + 3 * (2 - losecountergreenslon) + 5 * (2 - losecountergreentura) + 9 * (1 - losecountergreenqueen)) - (8 - losecounterredpeshak + 3 * (2 - losecounterredhorse) + 3 * (2 - losecounterredslon) + 5 * (2 - losecounterredtura) + 9 * (1 - losecounterredqueen)));
                }
            }
            void place1(string green)
            {
                if (cell1.Length == 2)
                {
                    letterconverter(cell1, ref dig1);
                    if (1 < Convert.ToInt32(cell1[1]) - 47 && Convert.ToInt32(cell1[1]) - 47 < 10)
                    {
                        dig2 = Convert.ToInt32(cell1[1]) - 47;
                    }
                }
                if (cell1 == "рокировка вправо" || cell1 == "рокировка влево")
                {
                    errorcell1 = false;
                }
                else if (cell1.Length != 2 || (Convert.ToString(cell1[1]) != "1" && Convert.ToString(cell1[1]) != "2" && Convert.ToString(cell1[1]) != "3" && Convert.ToString(cell1[1]) != "4" && Convert.ToString(cell1[1]) != "5" && Convert.ToString(cell1[1]) != "6" && Convert.ToString(cell1[1]) != "7" && Convert.ToString(cell1[1]) != "8"))
                {
                    errorcell1 = true;
                }
            }
            void place2(string green)
            {
                if (cell2.Length == 2)
                {
                    letterconverter(cell2, ref dig3);
                    if (1 < Convert.ToInt32(cell2[1]) - 47 && Convert.ToInt32(cell2[1]) - 47 < 10)
                    {
                        dig4 = Convert.ToInt32(cell2[1]) - 47;
                    }
                }
                if (cell2.Length != 2 || (Convert.ToString(cell2[1]) != "1" && Convert.ToString(cell2[1]) != "2" && Convert.ToString(cell2[1]) != "3" && Convert.ToString(cell2[1]) != "4" && Convert.ToString(cell2[1]) != "5" && Convert.ToString(cell2[1]) != "6" && Convert.ToString(cell2[1]) != "7" && Convert.ToString(cell2[1]) != "8"))
                {
                    errorcell2 = true;
                }
                else if (cell1[0] == cell2[0] && cell1[1] == cell2[1])
                {
                    errorcell2 = true;
                }
            }
            void letterconverter(string cell, ref int dig)
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
            void attempt(string attacker)
            {
                matrix[dig1, dig2] = "*";
                temp = matrix[dig3, dig4];
                matrix[dig3, dig4] = attacker;
                if (attacker == "Пg" || attacker == "Tg" || attacker == "Tg1" || attacker == "Cg" || attacker == "Hg" || attacker == "Qg")
                {
                    greenchax(kinggreenplace1, kinggreenplace2);
                }
                else
                {
                    redchax(kingredplace1, kingredplace2);
                }
                matrix[dig1, dig2] = attacker;
                matrix[dig3, dig4] = temp;
            }
            void enemyally(string hero)
            {
                if (hero == "Tg1" || hero == "Tg" || hero == "Cg" || hero == "Hg" || hero == "Qg" || hero == "Kg" || hero == "Пg")
                {
                    enemy1 = "Пr";
                    enemy2 = "Cr";
                    enemy3 = "Hr";
                    enemy4 = "Tr";
                    enemy5 = "Tr1";
                    enemy6 = "Qr";
                    enemy7 = "Kr";
                    ally1 = "Пg";
                    ally2 = "Cg";
                    ally3 = "Hg";
                    ally4 = "Tg";
                    ally5 = "Tg1";
                    ally6 = "Qg";
                    ally7 = "Kg";
                }
                else
                {
                    enemy1 = "Пg";
                    enemy2 = "Cg";
                    enemy3 = "Hg";
                    enemy4 = "Tg";
                    enemy5 = "Tg1";
                    enemy6 = "Qg";
                    enemy7 = "Kg";
                    ally1 = "Пr";
                    ally2 = "Cr";
                    ally3 = "Hr";
                    ally4 = "Tr";
                    ally5 = "Tr1";
                    ally6 = "Qr";
                    ally7 = "Kr";
                }
            }
            void peshak(string hero)
            {
                int edgestart = 0;
                int edgeend = 0;
                int distance = 0;
                if (hero == "Пg")
                {
                    edgestart = 8;
                    edgeend = 2;
                    distance = -1;
                }
                else
                {
                    edgestart = 3;
                    edgeend = 9;
                    distance = 1;
                }
                enemyally(hero);
                attempt(hero);
                if (hero == "Пg" && greenchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (hero == "Пr" && redchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (matrix[dig3, dig4] == "*" && dig2 == dig4 && ((dig2 == dig4 && dig3 - dig1 == distance) || (dig1 == edgestart && dig3 - dig1 == 2 * distance)))
                {
                    if (dig3 == edgeend)
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
                                matrix[dig3, dig4] = ally4;
                                break;
                            case 2:
                                matrix[dig3, dig4] = ally2;
                                break;
                            case 3:
                                matrix[dig3, dig4] = ally6;
                                break;
                            case 4:
                                matrix[dig3, dig4] = ally3;
                                break;
                        }
                    }
                    else
                    {
                        matrix[dig3, dig4] = hero;
                    }
                    if (hero == "Пg")
                    {
                        counterside++;
                    }
                    else
                    {
                        counterside--;
                    }
                    counterhod++;
                    matrix[dig1, dig2] = "*";
                }
                else if ((matrix[dig3, dig4] == enemy1 || matrix[dig3, dig4] == enemy2 || matrix[dig3, dig4] == enemy3 || matrix[dig3, dig4] == enemy4 || matrix[dig3, dig4] == enemy5 || matrix[dig3, dig4] == enemy6 || matrix[dig3, dig4] == enemy7) && Math.Abs(dig4 - dig2) == 1 && dig3 - dig1 == distance)
                {
                    if (dig3 == edgeend)
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
                                matrix[dig3, dig4] = ally4;
                                break;
                            case 2:
                                matrix[dig3, dig4] = ally2;
                                break;
                            case 3:
                                matrix[dig3, dig4] = ally6;
                                break;
                            case 4:
                                matrix[dig3, dig4] = ally3;
                                break;
                        }
                    }
                    else
                    {
                        matrix[dig3, dig4] = hero;
                    }
                    if (hero == "Пg")
                    {
                        counterside++;
                    }
                    else
                    {
                        counterside--;
                    }
                    counterhod++;
                    matrix[dig1, dig2] = "*";
                }
                else
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
            }
            void horse(string hero)
            {
                attempt(hero);
                enemyally(hero);
                if (hero == "Hg" && greenchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (hero == "Hr" && redchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (matrix[dig3, dig4] != " " && (Math.Pow((dig3 - dig1), 2) + Math.Pow((dig4 - dig2), 2)) == 5 && matrix[dig3, dig4] != ally1 && matrix[dig3, dig4] != ally2 && matrix[dig3, dig4] != ally3 && matrix[dig3, dig4] != ally4 && matrix[dig3, dig4] != ally5 && matrix[dig3, dig4] != ally6 && matrix[dig3, dig4] != ally7)
                {
                    matrix[dig3, dig4] = hero;
                    matrix[dig1, dig2] = "*";
                    if (hero == "Hg")
                    {
                        counterside++;
                    }
                    else
                    {
                        counterside--;
                    }
                    counterhod++;
                }
                else
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
            }
            void tura()
            {
                attempt(figura);
                if ((figura == "Tg" || figura == "Tg1" || figura == "Qg") && greenchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if ((figura == "Tr" || figura == "Tr1" || figura == "Qr") && redchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (dig1 == dig3)
                {
                    if (dig4 > dig2)
                    {
                        counterproh--;
                    }
                    else if (matrix[dig3, dig4] == enemy1 || matrix[dig3, dig4] == enemy2 || matrix[dig3, dig4] == enemy3 || matrix[dig3, dig4] == enemy4 || matrix[dig3, dig4] == enemy5 || matrix[dig3, dig4] == enemy6 || matrix[dig3, dig4] == enemy7)
                    {
                        counterproh--;
                    }
                    for (int i = Math.Min(dig2, dig4); i < Math.Max(dig2, dig4); i++)
                    {
                        if (matrix[dig1, i] != "*")
                        {
                            counterproh++;
                        }
                        if (counterproh > 0)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                            break;
                        }
                    }
                    if (counterproh == 0 && matrix[dig3, dig4] != ally1 && matrix[dig3, dig4] != ally2 && matrix[dig3, dig4] != ally3 && matrix[dig3, dig4] != ally4 && matrix[dig3, dig4] != ally5 && matrix[dig3, dig4] != ally6 && matrix[dig3, dig4] != ally7)
                    {
                        matrix[dig3, dig4] = figura;
                        matrix[dig1, dig2] = "*";
                        counterhod++;
                        if (figura == "Tg" || figura == "Tg1" || figura == "Qg")
                        {
                            counterside++;
                        }
                        else if (figura == "Tr" || figura == "Tr1" || figura == "Qr")
                        {
                            counterside--;
                        }
                        if (figura == "Tg")
                        {
                            counterturagreenleft++;
                        }
                        else if (figura == "Tg1")
                        {
                            counterturagreenright++;
                        }
                        else if (figura == "Tr")
                        {
                            counterturaredleft++;
                        }
                        else if (figura == "Tr1")
                        {
                            counterturaredright++;
                        }
                    }
                }
                else if (dig2 == dig4)
                {
                    if (dig1 < dig3)
                    {
                        counterproh--;

                    }
                    else if (matrix[dig3, dig4] == enemy1 || matrix[dig3, dig4] == enemy2 || matrix[dig3, dig4] == enemy3 || matrix[dig3, dig4] == enemy4 || matrix[dig3, dig4] == enemy5 || matrix[dig3, dig4] == enemy6 || matrix[dig3, dig4] == enemy7)
                    {
                        counterproh--;
                    }
                    for (int i = Math.Min(dig1, dig3); i < Math.Max(dig1, dig3); i++)
                    {
                        if (matrix[i, dig2] != "*")
                        {
                            counterproh++;
                        }
                        if (counterproh > 0)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                            break;
                        }
                    }
                    if (counterproh == 0 && matrix[dig3, dig4] != ally1 && matrix[dig3, dig4] != ally2 && matrix[dig3, dig4] != ally3 && matrix[dig3, dig4] != ally4 && matrix[dig3, dig4] != ally5 && matrix[dig3, dig4] != ally6 && matrix[dig3, dig4] != ally7)
                    {
                        matrix[dig3, dig4] = figura;
                        matrix[dig1, dig2] = "*";
                        counterhod++;
                        if (figura == "Tg" || figura == "Tg1" || figura == "Qg")
                        {
                            counterside++;
                        }
                        else if (figura == "Tr" || figura == "Tr1" || figura == "Qr")
                        {
                            counterside--;
                        }
                        if (figura == "Tg")
                        {
                            counterturagreenleft++;
                        }
                        else if (figura == "Tg1")
                        {
                            counterturagreenright++;
                        }
                        else if (figura == "Tr")
                        {
                            counterturaredleft++;
                        }
                        else if (figura == "Tr1")
                        {
                            counterturaredright++;
                        }
                    }
                }
                if (dig1 != dig3 && dig2 != dig4 && figura != "Qr" && figura != "Qg")
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
                counterproh = 0;
            }
            void slon()
            {
                attempt(figura);
                enemyally(figura);
                if ((figura == "Cg" || figura == "Qg") && greenchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if ((figura == "Cr" || figura == "Qr") && redchaxmat)
                {
                    Console.WriteLine("Король: Та за шо");
                }
                else if (Math.Abs(dig3 - dig1) == Math.Abs(dig4 - dig2) && matrix[dig3, dig4] != ally1 && matrix[dig3, dig4] != ally2 && matrix[dig3, dig4] != ally3 && matrix[dig3, dig4] != ally4 && matrix[dig3, dig4] != ally5 && matrix[dig3, dig4] != ally6 && matrix[dig3, dig4] != ally7)
                {
                    if (dig1 > dig3 && dig2 > dig4)
                    {
                        for (int i = 0; i < Math.Abs(dig3 - dig1); i++)
                        {
                            if (matrix[dig1 - i, dig2 - i] != "*")
                            {
                                counterproh++;
                            }
                        }
                        if (counterproh > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counterside++;
                            }
                            else
                            {
                                counterside--;
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
                                counterproh++;
                            }
                        }
                        if (counterproh > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counterside++;
                            }
                            else
                            {
                                counterside--;
                            }
                            counterhod++;
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
                                counterproh++;
                            }
                        }
                        if (counterproh > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counterside++;
                            }
                            else
                            {
                                counterside--;
                            }
                            counterhod++;
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
                                counterproh++;
                            }
                        }
                        if (counterproh > 1)
                        {
                            Console.WriteLine("ТЫ НЕ ПРОЙДЕШЬ");
                        }
                        else
                        {
                            if (figura == "Cg" || figura == "Qg")
                            {
                                counterside++;
                            }
                            else
                            {
                                counterside--;
                            }
                            counterhod++;
                            matrix[dig1, dig2] = "*";
                            matrix[dig3, dig4] = figura;
                        }
                    }
                }
                else  if (Math.Abs(dig3 - dig1) != Math.Abs(dig4 - dig2))
                {
                    Console.WriteLine("Не-а, так нельзя ходить");
                }
                counterproh = 0;
            }
            void king(string hero)
            {
                Console.WriteLine("flag0");
                enemyally(hero);
                matrix[dig1, dig2] = "*";
                if (hero == "Kg")
                {
                    Console.WriteLine("flag1");
                    if (greenchax(dig3, dig4))
                    {
                        Console.WriteLine("flag2");
                        Console.WriteLine("Не надо, дядя. Убьют тебя");
                    }
                    matrix[dig1, dig2] = hero;
                }
                else if (hero == "Kr")
                {
                    Console.WriteLine("flag3");
                    if (redchax(dig3, dig4))
                    {
                        Console.WriteLine("flag4");
                        Console.WriteLine("Не надо, дядя. Убьют тебя");
                    }
                    matrix[dig1, dig2] = hero;
                }
                else
                {
                    Console.WriteLine("flag5");
                    if (((Math.Abs(dig3 - dig1) == 1 && Math.Abs(dig4 - dig2) == 1) || (dig3 - dig1 == 0 && Math.Abs(dig4 - dig2) == 1) || (dig4 - dig2 == 0 && Math.Abs(dig3 - dig1) == 1)) && (matrix[dig3, dig4] != " " && matrix[dig3, dig4] != ally1 && matrix[dig3, dig4] != ally2 && matrix[dig3, dig4] != ally3 && matrix[dig3, dig4] != ally4 && matrix[dig3, dig4] != ally5 && matrix[dig3, dig4] != ally6))
                    {
                        matrix[dig3, dig4] = hero;
                        matrix[dig1, dig2] = "*";
                        if (hero == "Kg")
                        {
                            counterkinggreen++;
                            counterside++;
                        }
                        else
                        {
                            counterkingred++;
                            counterside--;
                        }
                        counterhod++;
                    }
                    else
                    {
                        Console.WriteLine("Не-а, так нельзя ходить");
                    }
                }
            }
            //DEATH
            bool greenchax(int n, int m)
            {
                if (matrix[n - 1, m - 1] == "Пr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n - 1);
                    greensecondcoordeath.Add(m - 1);
                }
                if (matrix[n - 1, m + 1] == "Пr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n - 1);
                    greensecondcoordeath.Add(m + 1);
                }
                if (matrix[n - 1, m - 2] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n - 1);
                    greensecondcoordeath.Add(m - 2);
                }
                if (matrix[n - 1, m + 2] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n - 1);
                    greensecondcoordeath.Add(m + 2);
                }
                if (matrix[n - 2, m - 1] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n - 2);
                    greensecondcoordeath.Add(m - 1);
                }
                if (matrix[n - 2, m + 1] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n - 2);
                    greensecondcoordeath.Add(m + 1);
                }
                if (matrix[n + 1, m - 2] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n + 1);
                    greensecondcoordeath.Add(m - 2);
                }
                if (matrix[n + 1, m + 2] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n + 1);
                    greensecondcoordeath.Add(m + 2);
                }
                if (matrix[n + 2, m - 1] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n + 2);
                    greensecondcoordeath.Add(m - 1);
                }
                if (matrix[n + 2, m + 1] == "Hr")
                {
                    greenchaxmat = true;
                    greenfirstcoordeath.Add(n + 2);
                    greensecondcoordeath.Add(m + 1);
                }
                for (int i = 1; i < 12; i++)
                {
                    if (0 < n - i && 0 < m - i)
                    {
                        if (matrix[n - i, m - i] != "*" && matrix[n - i, m - i] != "Qr" && matrix[n - i, m - i] != "Cr")
                        {
                            greenchaxlefttopslon = false;
                        }
                        if (greenchaxlefttopslon == true && (matrix[n - i, m - i] == "Cr" || matrix[n - i, m - i] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n - i);
                            greensecondcoordeath.Add(m - i);
                        }
                    }
                    if (0 < n - i && m + i < 11)
                    {
                        if (matrix[n - i, m + i] != "*" && matrix[n - i, m + i] != "Qr" && matrix[n - i, m + i] != "Cr")
                        {
                            greenchaxrighttopslon = false;
                        }
                        if (greenchaxrighttopslon == true && (matrix[n - i, m + i] == "Cr" || matrix[n - i, m + i] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n - i);
                            greensecondcoordeath.Add(m + i);
                        }
                    }
                    if (n + i < 11 && 0 < m - i)
                    {
                        if (matrix[n + i, m - i] != "*" && matrix[n + i, m - i] != "Qr" && matrix[n + i, m - i] != "Cr")
                        {
                            greenchaxleftdownslon = false;
                        }
                        if (greenchaxleftdownslon == true && (matrix[n + i, m - i] == "Cr" || matrix[n + i, m - i] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n + i);
                            greensecondcoordeath.Add(m - i);
                        }
                    }
                    if (n + i < 11 && m + i < 11)
                    {
                        if (matrix[n + i, m + i] != "*" && matrix[n + i, m + i] != "Qr" && matrix[n + i, m + i] != "Cr")
                        {
                            greenchaxrightdownslon = false;
                        }
                        if (greenchaxrightdownslon == true && (matrix[n + i, m + i] == "Cr" || matrix[n + i, m + i] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n + i);
                            greensecondcoordeath.Add(m + i);
                        }
                    }
                    if (0 < n - i)
                    {
                        if (matrix[n - i, m] != "*" && matrix[n - i, m] != "Qr" && matrix[n - i, m] != "Tr" && matrix[n - i, m] != "Tr1")
                        {
                            greenchaxtoptura = false;
                        }
                        if (greenchaxtoptura == true && (matrix[n - i, m] == "Tr" || matrix[n - i, m] == "Tr1" || matrix[n - i, m] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n - i);
                            greensecondcoordeath.Add(m);
                        }
                    }
                    if (n + i < 11)
                    {
                        if (matrix[n + i, m] != "*" && matrix[n + i, m] != "Qr" && matrix[n + i, m] != "Tr" && matrix[n + i, m] != "Tr1")
                        {
                            greenchaxdowntura = false;
                        }
                        if (greenchaxdowntura == true && (matrix[n + i, m] == "Tr" || matrix[n + i, m] == "Tr1" || matrix[n + i, m] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n + i);
                            greensecondcoordeath.Add(m);
                        }

                    }
                    if (0 < m - i)
                    {
                        if (matrix[n, m - i] != "*" && matrix[n, m - i] != "Qr" && matrix[n, m - i] != "Tr" && matrix[n, m - i] != "Tr1")
                        {
                            greenchaxlefttura = false;
                        }
                        if (greenchaxlefttura == true && (matrix[n, m - i] == "Tr" || matrix[n, m - i] == "Tr1" || matrix[n, m - i] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n);
                            greensecondcoordeath.Add(m - i);
                        }
                    }
                    if (m + i < 11)
                    {
                        if (matrix[n, m + i] != "*" && matrix[n, m + i] != "Qr" && matrix[n, m + i] != "Tr" && matrix[n, m + i] != "Tr1")
                        {
                            greenchaxrighttura = false;
                        }
                        if (greenchaxrighttura == true && (matrix[n, m + i] == "Tr" || matrix[n, m + i] == "Tr1" || matrix[n, m + i] == "Qr"))
                        {
                            greenchaxmat = true;
                            greenfirstcoordeath.Add(n);
                            greensecondcoordeath.Add(m + i);
                        }
                    }
                    if (matrix[n - 1, m] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n - 1);
                        greensecondcoordeath.Add(m);
                    }
                    if (matrix[n - 1, m + 1] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n - 1);
                        greensecondcoordeath.Add(m + 1);
                    }
                    if (matrix[n - 1, m - 1] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n - 1);
                        greensecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n, m - 1] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n);
                        greensecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n, m - 1] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n);
                        greensecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n + 1, m] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n + 1);
                        greensecondcoordeath.Add(m);
                    }
                    if (matrix[n + 1, m - 1] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n + 1);
                        greensecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n + 1, m + 1] == "Kr")
                    {
                        greenchaxmat = true;
                        greenfirstcoordeath.Add(n + 1);
                        greensecondcoordeath.Add(m + 1);
                    }
                }
                return greenchaxmat;
            }
            bool redchax(int n, int m)
            {
                redchaxmat = false;
                redchaxrighttopslon = true;
                redchaxlefttopslon = true;
                redchaxrightdownslon = true;
                redchaxleftdownslon = true;
                redchaxlefttura = true;
                redchaxrighttura = true;
                redchaxtoptura = true;
                redchaxdowntura = true;
                if (matrix[n + 1, m + 1] == "Пg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n + 1);
                    redsecondcoordeath.Add(m + 1);
                }
                if (matrix[n + 1, m - 1] == "Пg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n + 1);
                    redsecondcoordeath.Add(m - 1);
                }
                if (matrix[n - 1, m - 2] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n - 1);
                    redsecondcoordeath.Add(m - 2);
                }
                if (matrix[n - 1, m + 2] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n - 1);
                    redsecondcoordeath.Add(m + 2);
                }
                if (matrix[n - 2, m - 1] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n - 2);
                    redsecondcoordeath.Add(m - 1);
                }
                if (matrix[n - 2, m + 1] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n - 2);
                    redsecondcoordeath.Add(m + 1);
                }
                if (matrix[n + 1, m - 2] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n + 1);
                    redsecondcoordeath.Add(m - 2);
                }
                if (matrix[n + 1, m + 2] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n + 1);
                    redsecondcoordeath.Add(m + 2);
                }
                if (matrix[n + 2, m - 1] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n + 2);
                    redsecondcoordeath.Add(m - 1);
                }
                if (matrix[n + 2, m + 1] == "Hg")
                {
                    redchaxmat = true;
                    redfirstcoordeath.Add(n + 2);
                    redsecondcoordeath.Add(m + 1);
                }
                for (int i = 1; i < 12; i++)
                {
                    if (0 < n - i && 0 < m - i)
                    {
                        if (matrix[n - i, m - i] != "*" && matrix[n - i, m - i] != "Qg" && matrix[n - i, m - i] != "Cg")
                        {
                            redchaxlefttopslon = false;
                        }
                        if (redchaxlefttopslon == true && (matrix[n - i, m - i] == "Cg" || matrix[n - i, m - i] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n - i);
                            redsecondcoordeath.Add(m - i);
                        }
                    }
                    if (0 < n - i && m + i < 11)
                    {
                        if (matrix[n - i, m + i] != "*" && matrix[n - i, m + i] != "Qg" && matrix[n - i, m + i] != "Cg")
                        {
                            redchaxrighttopslon = false;
                        }
                        if (redchaxrighttopslon == true && (matrix[n - i, m + i] == "Cg" || matrix[n - i, m + i] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n - i);
                            redsecondcoordeath.Add(m + i);
                        }
                    }
                    if (n + i < 11 && 0 < m - i)
                    {
                        if (matrix[n + i, m - i] != "*" && matrix[n + i, m - i] != "Qg" && matrix[n + i, m - i] != "Cg")
                        {
                            redchaxleftdownslon = false;
                        }
                        if (redchaxleftdownslon == true && (matrix[n + i, m - i] == "Cg" || matrix[n + i, m - i] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n + i);
                            redsecondcoordeath.Add(m - i);
                        }
                    }
                    if (n + i < 11 && m + i < 11)
                    {
                        if (matrix[n + i, m + i] != "*" && matrix[n + i, m + i] != "Qg" && matrix[n + i, m + i] != "Cg")
                        {
                            redchaxrightdownslon = false;
                        }
                        if (redchaxrightdownslon == true && (matrix[n + i, m + i] == "Cg" || matrix[n + i, m + i] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n + i);
                            redsecondcoordeath.Add(m + i);
                        }
                    }
                    if (0 < n - i)
                    {
                        if (matrix[n - i, m] != "*" && matrix[n - i, m] != "Qg" && matrix[n - i, m] != "Tg" && matrix[n - i, m] != "Tg1")
                        {
                            redchaxtoptura = false;
                        }
                        if (redchaxtoptura == true && (matrix[n - i, m] == "Tg" || matrix[n - i, m] == "Tg1" || matrix[n - i, m] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n - i);
                            redsecondcoordeath.Add(m);
                        }
                    }
                    if (n + i < 11)
                    {
                        if (matrix[n + i, m] != "*" && matrix[n + i, m] != "Qg" && matrix[n + i, m] != "Tg" && matrix[n + i, m] != "Tg1")
                        {
                            redchaxdowntura = false;
                        }
                        if (redchaxdowntura == true && (matrix[n + i, m] == "Tg" || matrix[n + i, m] == "Tg1" || matrix[n + i, m] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n + i);
                            redsecondcoordeath.Add(m);
                        }
                    }
                    if (0 < m - i)
                    {
                        if (matrix[n, m - i] != "*" && matrix[n, m - i] != "Qg" && matrix[n, m - i] != "Tg" && matrix[n, m - i] != "Tg1")
                        {
                            redchaxlefttura = false;
                        }
                        if (redchaxlefttura == true && (matrix[n, m - i] == "Tg" || matrix[n, m - i] == "Tg1" || matrix[n, m - i] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n);
                            redsecondcoordeath.Add(m - i);
                        }
                    }
                    if (m + i < 11)
                    {
                        if (matrix[n, m + i] != "*" && matrix[n, m + i] != "Qg" && matrix[n, m + i] != "Tg" && matrix[n, m + i] != "Tg1")
                        {
                            redchaxrighttura = false;
                        }
                        if (redchaxrighttura == true && (matrix[n, m + i] == "Tg" || matrix[n, m + i] == "Tg1" || matrix[n, m + i] == "Qg"))
                        {
                            redchaxmat = true;
                            redfirstcoordeath.Add(n);
                            redsecondcoordeath.Add(m + i);
                        }
                    }
                    if (matrix[n - 1, m] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n - 1);
                        redsecondcoordeath.Add(m);
                    }
                    if (matrix[n - 1, m + 1] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n - 1);
                        redsecondcoordeath.Add(m + 1);
                    }
                    if (matrix[n - 1, m - 1] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n - 1);
                        redsecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n, m - 1] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n);
                        redsecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n, m - 1] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n);
                        redsecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n + 1, m] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n + 1);
                        redsecondcoordeath.Add(m);
                    }
                    if (matrix[n + 1, m - 1] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n + 1);
                        redsecondcoordeath.Add(m - 1);
                    }
                    if (matrix[n + 1, m + 1] == "Kg")
                    {
                        redchaxmat = true;
                        redfirstcoordeath.Add(n + 1);
                        redsecondcoordeath.Add(m + 1);
                    }
                }
                return redchaxmat;
            }
            void redblock(int n, int m)
            {
                redchaxrighttopslon = true;
                redchaxlefttopslon = true;
                redchaxrightdownslon = true;
                redchaxleftdownslon = true;
                redchaxlefttura = true;
                redchaxrighttura = true;
                redchaxtoptura = true;
                redchaxdowntura = true;
                if (matrix[n + 1, m] == "Пg")
                {
                    redfirstcoorblock.Add(n + 1);
                    redsecondcoorblock.Add(m);
                }
                if (matrix[n + 2, m] == "Пg" && n == 6 && matrix[n + 1, m] == "*")
                {
                    redfirstcoorblock.Add(n + 2);
                    redsecondcoorblock.Add(m);
                }
                if (matrix[n - 1, m - 2] == "Hg")
                {
                    redfirstcoorblock.Add(n - 1);
                    redsecondcoorblock.Add(m - 2);
                }
                if (matrix[n - 1, m + 2] == "Hg")
                {
                    redfirstcoorblock.Add(n - 1);
                    redsecondcoorblock.Add(m + 2);
                }
                if (matrix[n - 2, m - 1] == "Hg")
                {
                    redfirstcoorblock.Add(n - 2);
                    redsecondcoorblock.Add(m - 1);
                }
                if (matrix[n - 2, m + 1] == "Hg")
                {
                    redfirstcoorblock.Add(n - 2);
                    redsecondcoorblock.Add(m + 1);
                }
                if (matrix[n + 1, m - 2] == "Hg")
                {
                    redfirstcoorblock.Add(n + 1);
                    redsecondcoorblock.Add(m - 2);
                }
                if (matrix[n + 1, m + 2] == "Hg")
                {
                    redfirstcoorblock.Add(n + 1);
                    redsecondcoorblock.Add(m + 2);
                }
                if (matrix[n + 2, m - 1] == "Hg")
                {
                    redfirstcoorblock.Add(n + 2);
                    redsecondcoorblock.Add(m - 1);
                }
                if (matrix[n + 2, m + 1] == "Hg")
                {
                    redfirstcoorblock.Add(n + 2);
                    redsecondcoorblock.Add(m + 1);
                }
                for (int i = 1; i < 12; i++)
                {
                    if (0 < n - i && 0 < m - i)
                    {
                        if (matrix[n - i, m - i] != "*" && matrix[n - i, m - i] != "Qg" && matrix[n - i, m - i] != "Cg")
                        {
                            redchaxlefttopslon = false;
                        }
                        if (redchaxlefttopslon == true && (matrix[n - i, m - i] == "Cg" || matrix[n - i, m - i] == "Qg"))
                        {
                            redfirstcoorblock.Add(n - i);
                            redsecondcoorblock.Add(m - i);
                        }
                    }
                    if (0 < n - i && m + i < 11)
                    {
                        if (matrix[n - i, m + i] != "*" && matrix[n - i, m + i] != "Qg" && matrix[n - i, m + i] != "Cg")
                        {
                            redchaxrighttopslon = false;
                        }
                        if (redchaxrighttopslon == true && (matrix[n - i, m + i] == "Cg" || matrix[n - i, m + i] == "Qg"))
                        {
                            redfirstcoorblock.Add(n - i);
                            redsecondcoorblock.Add(m + i);
                        }
                    }
                    if (n + i < 11 && 0 < m - i)
                    {
                        if (matrix[n + i, m - i] != "*" && matrix[n + i, m - i] != "Qg" && matrix[n + i, m - i] != "Cg")
                        {
                            redchaxleftdownslon = false;
                        }
                        if (redchaxleftdownslon == true && (matrix[n + i, m - i] == "Cg" || matrix[n + i, m - i] == "Qg"))
                        {
                            redfirstcoorblock.Add(n + i);
                            redsecondcoorblock.Add(m - i);
                        }
                    }
                    if (n + i < 11 && m + i < 11)
                    {
                        if (matrix[n + i, m + i] != "*" && matrix[n + i, m + i] != "Qg" && matrix[n + i, m + i] != "Cg")
                        {
                            redchaxrightdownslon = false;
                        }
                        if (redchaxrightdownslon == true && (matrix[n + i, m + i] == "Cg" || matrix[n + i, m + i] == "Qg"))
                        {
                            redfirstcoorblock.Add(n + i);
                            redsecondcoorblock.Add(m + i);
                        }
                    }
                    if (0 < n - i)
                    {
                        if (matrix[n - i, m] != "*" && matrix[n - i, m] != "Qg" && matrix[n - i, m] != "Tg" && matrix[n - i, m] != "Tg1")
                        {
                            redchaxtoptura = false;
                        }
                        if (redchaxtoptura == true && (matrix[n - i, m] == "Tg" || matrix[n - i, m] == "Tg1" || matrix[n - i, m] == "Qg"))
                        {
                            redfirstcoorblock.Add(n - i);
                            redsecondcoorblock.Add(m);
                        }
                    }
                    if (n + i < 11)
                    {
                        if (matrix[n + i, m] != "*" && matrix[n + i, m] != "Qg" && matrix[n + i, m] != "Tg" && matrix[n + i, m] != "Tg1")
                        {
                            redchaxdowntura = false;
                        }
                        if (redchaxdowntura == true && (matrix[n + i, m] == "Tg" || matrix[n + i, m] == "Tg1" || matrix[n + i, m] == "Qg"))
                        {
                            redfirstcoorblock.Add(n + i);
                            redsecondcoorblock.Add(m);
                        }
                    }
                    if (0 < m - i)
                    {
                        if (matrix[n, m - i] != "*" && matrix[n, m - i] != "Qg" && matrix[n, m - i] != "Tg" && matrix[n, m - i] != "Tg1")
                        {
                            redchaxlefttura = false;
                        }
                        if (redchaxlefttura == true && (matrix[n, m - i] == "Tg" || matrix[n, m - i] == "Tg1" || matrix[n, m - i] == "Qg"))
                        {
                            redfirstcoorblock.Add(n);
                            redsecondcoorblock.Add(m - i);
                        }
                    }
                    if (m + i < 11)
                    {
                        if (matrix[n, m + i] != "*" && matrix[n, m + i] != "Qg" && matrix[n, m + i] != "Tg" && matrix[n, m + i] != "Tg1")
                        {
                            redchaxrighttura = false;
                        }
                        if (redchaxrighttura == true && (matrix[n, m + i] == "Tg" || matrix[n, m + i] == "Tg1" || matrix[n, m + i] == "Qg"))
                        {
                            redfirstcoorblock.Add(n);
                            redsecondcoorblock.Add(m + i);
                        }
                    }
                }
            }
            void greenblock(int n, int m)
            {
                greenchaxrighttopslon = true;
                greenchaxlefttopslon = true;
                greenchaxrightdownslon = true;
                greenchaxleftdownslon = true;
                greenchaxlefttura = true;
                greenchaxrighttura = true;
                greenchaxtoptura = true;
                greenchaxdowntura = true;
                if (matrix[n - 1, m] == "Пr")
                {
                    greenfirstcoorblock.Add(n - 1);
                    greensecondcoorblock.Add(m);
                }
                if (matrix[n - 2, m] == "Пr" && n == 6 && matrix[n - 1, m] == "*")
                {
                    greenfirstcoorblock.Add(n - 2);
                    greensecondcoorblock.Add(m);
                }
                if (matrix[n - 1, m - 2] == "Hr")
                {
                    greenfirstcoorblock.Add(n - 1);
                    greensecondcoorblock.Add(m - 2);
                }
                if (matrix[n - 1, m + 2] == "Hr")
                {
                    greenfirstcoorblock.Add(n - 1);
                    greensecondcoorblock.Add(m + 2);
                }
                if (matrix[n - 2, m - 1] == "Hr")
                {
                    greenfirstcoorblock.Add(n - 2);
                    greensecondcoorblock.Add(m - 1);
                }
                if (matrix[n - 2, m + 1] == "Hr")
                {
                    greenfirstcoorblock.Add(n - 2);
                    greensecondcoorblock.Add(m + 1);
                }
                if (matrix[n + 1, m - 2] == "Hr")
                {
                    greenfirstcoorblock.Add(n + 1);
                    greensecondcoorblock.Add(m - 2);
                }
                if (matrix[n + 1, m + 2] == "Hr")
                {
                    greenfirstcoorblock.Add(n + 1);
                    greensecondcoorblock.Add(m + 2);
                }
                if (matrix[n + 2, m - 1] == "Hr")
                {
                    greenfirstcoorblock.Add(n + 2);
                    greensecondcoorblock.Add(m - 1);
                }
                if (matrix[n + 2, m + 1] == "Hr")
                {
                    greenfirstcoorblock.Add(n + 2);
                    greensecondcoorblock.Add(m + 1);
                }
                for (int i = 1; i < 12; i++)
                {
                    if (0 < n - i && 0 < m - i)
                    {
                        if (matrix[n - i, m - i] != "*" && matrix[n - i, m - i] != "Qr" && matrix[n - i, m - i] != "Cr")
                        {
                            greenchaxlefttopslon = false;
                        }
                        if (greenchaxlefttopslon == true && (matrix[n - i, m - i] == "Cr" || matrix[n - i, m - i] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n - i);
                            greensecondcoorblock.Add(m - i);
                        }
                    }
                    if (0 < n - i && m + i < 11)
                    {
                        if (matrix[n - i, m + i] != "*" && matrix[n - i, m + i] != "Qr" && matrix[n - i, m + i] != "Cr")
                        {
                            greenchaxrighttopslon = false;
                        }
                        if (greenchaxrighttopslon == true && (matrix[n - i, m + i] == "Cr" || matrix[n - i, m + i] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n - i);
                            greensecondcoorblock.Add(m + i);
                        }
                    }
                    if (n + i < 11 && 0 < m - i)
                    {
                        if (matrix[n + i, m - i] != "*" && matrix[n + i, m - i] != "Qr" && matrix[n + i, m - i] != "Cr")
                        {
                            greenchaxleftdownslon = false;
                        }
                        if (greenchaxleftdownslon == true && (matrix[n + i, m - i] == "Cr" || matrix[n + i, m - i] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n + i);
                            greensecondcoorblock.Add(m - i);
                        }
                    }
                    if (n + i < 11 && m + i < 11)
                    {
                        if (matrix[n + i, m + i] != "*" && matrix[n + i, m + i] != "Qr" && matrix[n + i, m + i] != "Cr")
                        {
                            greenchaxrightdownslon = false;
                        }
                        if (greenchaxrightdownslon == true && (matrix[n + i, m + i] == "Cr" || matrix[n + i, m + i] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n + i);
                            greensecondcoorblock.Add(m + i);
                        }
                    }
                    if (0 < n - i)
                    {
                        if (matrix[n - i, m] != "*" && matrix[n - i, m] != "Qr" && matrix[n - i, m] != "Tr" && matrix[n - i, m] != "Tr1")
                        {
                            greenchaxtoptura = false;
                        }
                        if (greenchaxtoptura == true && (matrix[n - i, m] == "Tr" || matrix[n - i, m] == "Tr1" || matrix[n - i, m] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n - i);
                            greensecondcoorblock.Add(m);
                        }
                    }
                    if (n + i < 11)
                    {
                        if (matrix[n + i, m] != "*" && matrix[n + i, m] != "Qr" && matrix[n + i, m] != "Tr" && matrix[n + i, m] != "Tr1")
                        {
                            greenchaxdowntura = false;
                        }
                        if (greenchaxdowntura == true && (matrix[n + i, m] == "Tr" || matrix[n + i, m] == "Tr1" || matrix[n + i, m] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n + i);
                            greensecondcoorblock.Add(m);
                        }
                    }
                    if (0 < m - i)
                    {
                        if (matrix[n, m - i] != "*" && matrix[n, m - i] != "Qr" && matrix[n, m - i] != "Tr" && matrix[n, m - i] != "Tr1")
                        {
                            greenchaxlefttura = false;
                        }
                        if (greenchaxlefttura == true && (matrix[n, m - i] == "Tr" || matrix[n, m - i] == "Tr1" || matrix[n, m - i] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n);
                            greensecondcoorblock.Add(m - i);
                        }
                    }
                    if (m + i < 11)
                    {
                        if (matrix[n, m + i] != "*" && matrix[n, m + i] != "Qr" && matrix[n, m + i] != "Tr" && matrix[n, m + i] != "Tr1")
                        {
                            greenchaxrighttura = false;
                        }
                        if (greenchaxrighttura == true && (matrix[n, m + i] == "Tr" || matrix[n, m + i] == "Tr1" || matrix[n, m + i] == "Qr"))
                        {
                            greenfirstcoorblock.Add(n);
                            greensecondcoorblock.Add(m + i);
                        }
                    }
                }
            }
            bool greenend()
            {
                greenkilled = false;
                greenblocked = false;
                string temp;
                int range;
                greenchax(kinggreenplace1, kinggreenplace2);
                if (greenchaxmat)
                {
                    range = greenfirstcoordeath.Count;
                    for (int i = 0; i < range; i++)
                    {
                        redchax(greenfirstcoordeath[i], greensecondcoordeath[i]);
                        if (redchaxmat)
                        {
                            for (int j = 0; j < redfirstcoordeath.Count; j++)
                            {
                                if (matrix[redfirstcoordeath[j], redsecondcoordeath[j]] == "Kg")
                                {
                                    greenchax(greenfirstcoordeath[i], greensecondcoordeath[i]);
                                    if (greenchaxmat)
                                    {
                                        continue;
                                    }
                                }
                                temp = matrix[greenfirstcoordeath[i], greensecondcoordeath[i]];
                                matrix[greenfirstcoordeath[i], greensecondcoordeath[i]] = matrix[redfirstcoordeath[j], redsecondcoordeath[j]];
                                matrix[redfirstcoordeath[j], redsecondcoordeath[j]] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                matrix[redfirstcoordeath[j], redsecondcoordeath[j]] = matrix[greenfirstcoordeath[i], greensecondcoordeath[i]];
                                matrix[greenfirstcoordeath[i], greensecondcoordeath[i]] = temp;
                                if (greenchaxmat == false)
                                {
                                    greenkilled = true;
                                    break;
                                }
                            }
                            redchaxmat = false;
                        }
                        redfirstcoorblock.Clear();
                        redsecondcoorblock.Clear();
                    }
                    for (int i = 2; i < 10; i++)
                    {
                        for (int j = 2; j < 10; j++)
                        {
                            if (matrix[i, j] == "*")
                            {
                                redblock(i, j);
                                for (int k = 0; k < redfirstcoorblock.Count; k++)
                                {
                                    matrix[i, j] = matrix[redfirstcoorblock[k], redsecondcoorblock[k]];
                                    matrix[redfirstcoorblock[k], redsecondcoorblock[k]] = "*";
                                    greenchax(kinggreenplace1, kinggreenplace2);
                                    matrix[redfirstcoorblock[k], redsecondcoorblock[k]] = matrix[i, j];
                                    matrix[i, j] = "*";
                                    if (greenchaxmat == false)
                                    {
                                        greenblocked = true;
                                    }
                                }
                                redfirstcoorblock.Clear();
                                redsecondcoorblock.Clear();
                            }
                        }
                    }
                }
                if (kinggreenplace1 != 2 && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Tg" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Tg1" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Cg" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Hg" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1 - 1, kinggreenplace2);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace1 != 2 && kinggreenplace2 != 2 && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Tg" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Tg1" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Cg" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Hg" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1 - 1, kinggreenplace2 - 1);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace2 != 9 && kinggreenplace1 != 2 && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Tg" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Tg1" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Cg" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Hg" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1 - 1, kinggreenplace2 + 1);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace2 != 2 && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Tg" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Tg1" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Cg" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Hg" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1, kinggreenplace2 - 1);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace2 != 9 && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Tg" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Tg1" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Cg" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Hg" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1, kinggreenplace2 + 1);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace1 != 9 && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Tg" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Tg1" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Cg" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Hg" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1 + 1, kinggreenplace2);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace1 != 9 && kinggreenplace2 != 9 && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Tg" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Tg1" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Cg" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Hg" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1 + 1, kinggreenplace2 + 1);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kinggreenplace1 != 9 && kinggreenplace2 != 2 && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Tg" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Tg1" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Cg" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Hg" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Qg")
                {
                    matrix[kinggreenplace1, kinggreenplace2] = "*";
                    greenchax(kinggreenplace1 + 1, kinggreenplace2 - 1);
                    matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                    if (greenchaxmat == false)
                    {
                        return false;
                    }
                }
                if (greenkilled || greenblocked)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            bool redend()
            {
                redkilled = false;
                redblocked = false;
                string temp;
                int range;
                redchax(kingredplace1, kingredplace2);
                if (redchaxmat)
                {
                    range = redfirstcoordeath.Count;
                    for (int i = 0; i < range; i++)
                    {
                        greenchax(redfirstcoordeath[i], redsecondcoordeath[i]);
                        if (greenchaxmat)
                        {
                            for (int j = 0; j < greenfirstcoordeath.Count; j++)
                            {
                                if (matrix[greenfirstcoordeath[j], greensecondcoordeath[j]] == "Kr")
                                {
                                    redchax(redfirstcoordeath[i], redsecondcoordeath[i]);
                                    if (redchaxmat)
                                    {
                                        continue;
                                    }
                                }
                                temp = matrix[redfirstcoordeath[i], redsecondcoordeath[i]];
                                matrix[redfirstcoordeath[i], redsecondcoordeath[i]] = matrix[greenfirstcoordeath[j], greensecondcoordeath[j]];
                                matrix[greenfirstcoordeath[j], greensecondcoordeath[j]] = "*";
                                redchax(kingredplace1, kingredplace2);
                                matrix[greenfirstcoordeath[j], greensecondcoordeath[j]] = matrix[redfirstcoordeath[i], redsecondcoordeath[i]];
                                matrix[redfirstcoordeath[i], redsecondcoordeath[i]] = temp;
                                if (redchaxmat == false)
                                {
                                    redkilled = true;
                                    break;
                                }
                            }
                            greenchaxmat = false;
                        }
                        greenfirstcoorblock.Clear();
                        greensecondcoorblock.Clear();
                    }
                    for (int i = 2; i < 10; i++)
                    {
                        for (int j = 2; j < 10; j++)
                        {
                            if (matrix[i, j] == "*")
                            {
                                greenblock(i, j);
                                for (int k = 0; k < greenfirstcoorblock.Count; k++)
                                {
                                    matrix[i, j] = matrix[greenfirstcoorblock[k], greensecondcoorblock[k]];
                                    matrix[greenfirstcoorblock[k], greensecondcoorblock[k]] = "*";
                                    redchax(kingredplace1, kingredplace2);
                                    matrix[greenfirstcoorblock[k], greensecondcoorblock[k]] = matrix[i, j];
                                    matrix[i, j] = "*";
                                    if (redchaxmat == false)
                                    {
                                        redblocked = true;
                                    }
                                }
                                greenfirstcoorblock.Clear();
                                greensecondcoorblock.Clear();
                            }
                        }
                    }
                }
                if (kingredplace1 != 2 && matrix[kingredplace1 - 1, kingredplace2] != "Tr" && matrix[kingredplace1 - 1, kingredplace2] != "Tr1" && matrix[kingredplace1 - 1, kingredplace2] != "Cr" && matrix[kingredplace1 - 1, kingredplace2] != "Hr" && matrix[kingredplace1 - 1, kingredplace2] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1 - 1, kingredplace2);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace1 != 2 && kingredplace2 != 2 && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Tr" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Tr1" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Cr" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Hr" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1 - 1, kingredplace2 - 1);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace2 != 9 && kingredplace1 != 2 && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Tr" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Tr1" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Cr" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Hr" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1 - 1, kingredplace2 + 1);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace2 != 2 && matrix[kingredplace1, kingredplace2 - 1] != "Tr" && matrix[kingredplace1, kingredplace2 - 1] != "Tr1" && matrix[kingredplace1, kingredplace2 - 1] != "Cr" && matrix[kingredplace1, kingredplace2 - 1] != "Hr" && matrix[kingredplace1, kingredplace2 - 1] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1, kingredplace2 - 1);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace2 != 9 && matrix[kingredplace1, kingredplace2 + 1] != "Tr" && matrix[kingredplace1, kingredplace2 + 1] != "Tr1" && matrix[kingredplace1, kingredplace2 + 1] != "Cr" && matrix[kingredplace1, kingredplace2 + 1] != "Hr" && matrix[kingredplace1, kingredplace2 + 1] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1, kingredplace2 + 1);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace1 != 9 && matrix[kingredplace1 + 1, kingredplace2] != "Tr" && matrix[kingredplace1 + 1, kingredplace2] != "Tr1" && matrix[kingredplace1 + 1, kingredplace2] != "Cr" && matrix[kingredplace1 + 1, kingredplace2] != "Hr" && matrix[kingredplace1 + 1, kingredplace2] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1 + 1, kingredplace2);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace1 != 9 && kingredplace2 != 9 && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Tr" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Tr1" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Cr" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Hr" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1 + 1, kingredplace2 + 1);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (kingredplace1 != 9 && kingredplace2 != 2 && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Tr" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Tr1" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Cr" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Hr" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Qr")
                {
                    matrix[kingredplace1, kingredplace2] = "*";
                    redchax(kingredplace1 + 1, kingredplace2 - 1);
                    matrix[kingredplace1, kingredplace2] = "Kr";
                    if (redchaxmat == false)
                    {
                        return false;
                    }
                }
                if (redkilled || redblocked)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            bool greenstalemate()
            {
                if (greenchax(kinggreenplace1, kinggreenplace2))
                {
                    return false;
                }
                else
                {
                    if (kinggreenplace1 != 2 && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Tg" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Tg1" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Cg" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Hg" && matrix[kinggreenplace1 - 1, kinggreenplace2] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1 - 1, kinggreenplace2);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace1 != 2 && kinggreenplace2 != 2 && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Tg" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Tg1" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Cg" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Hg" && matrix[kinggreenplace1 - 1, kinggreenplace2 - 1] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1 - 1, kinggreenplace2 - 1);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace2 != 9 && kinggreenplace1 != 2 && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Tg" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Tg1" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Cg" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Hg" && matrix[kinggreenplace1 - 1, kinggreenplace2 + 1] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1 - 1, kinggreenplace2 + 1);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace2 != 2 && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Tg" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Tg1" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Cg" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Hg" && matrix[kinggreenplace1, kinggreenplace2 - 1] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1, kinggreenplace2 - 1);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace2 != 9 && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Tg" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Tg1" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Cg" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Hg" && matrix[kinggreenplace1, kinggreenplace2 + 1] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1, kinggreenplace2 + 1);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace1 != 9 && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Tg" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Tg1" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Cg" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Hg" && matrix[kinggreenplace1 + 1, kinggreenplace2] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1 + 1, kinggreenplace2);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace1 != 9 && kinggreenplace2 != 9 && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Tg" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Tg1" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Cg" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Hg" && matrix[kinggreenplace1 + 1, kinggreenplace2 + 1] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1 + 1, kinggreenplace2 + 1);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kinggreenplace1 != 9 && kinggreenplace2 != 2 && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Tg" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Tg1" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Cg" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Hg" && matrix[kinggreenplace1 + 1, kinggreenplace2 - 1] != "Qg")
                    {
                        matrix[kinggreenplace1, kinggreenplace2] = "*";
                        greenchax(kinggreenplace1 + 1, kinggreenplace2 - 1);
                        matrix[kinggreenplace1, kinggreenplace2] = "Kg";
                        if (greenchaxmat == false)
                        {
                            return false;
                        }
                    }
                }
                int counterimposmoves;
                string temp;
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 10; j++)
                    {
                        counterimposmoves = 0;
                        if (matrix[i, j] == "Пg")
                        {
                            if (matrix[i - 1, j] != "*")
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j - 1] == "Tr" || matrix[i - 1, j - 1] == "Tr1" && matrix[i - 1, j - 1] == "Qr" && matrix[i - 1, j - 1] == "Cr" && matrix[i - 1, j - 1] == "Hr" && matrix[i - 1, j - 1] == "Пr")
                            {
                                temp = matrix[i - 1, j - 1];
                                matrix[i - 1, j - 1] = "Пg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Пg";
                                matrix[i - 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 1] == "Tr" || matrix[i - 1, j + 1] == "Tr1" && matrix[i - 1, j + 1] == "Qr" && matrix[i - 1, j - 1] == "Cr" && matrix[i - 1, j + 1] == "Hr" && matrix[i - 1, j + 1] == "Пr")
                            {
                                temp = matrix[i - 1, j + 1];
                                matrix[i - 1, j + 1] = "Пg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Пg";
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
                        else if (matrix[i, j] == "Hg")
                        {
                            if (matrix[i - 2, j - 1] == "*" || matrix[i - 2, j - 1] == "Tr" || matrix[i - 2, j - 1] == "Tr1" || matrix[i - 2, j - 1] == "Cr" || matrix[i - 2, j - 1] == "Hr" || matrix[i - 2, j - 1] == "Qr" || matrix[i - 2, j - 1] == "Пr")
                            {
                                temp = matrix[i - 2, j - 1];
                                matrix[i - 2, j - 1] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i - 2, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 2, j + 1] == "*" || matrix[i - 2, j + 1] == "Tr" || matrix[i - 2, j + 1] == "Tr1" || matrix[i - 2, j + 1] == "Cr" || matrix[i - 2, j + 1] == "Hr" || matrix[i - 2, j + 1] == "Qr" || matrix[i - 2, j + 1] == "Пr")
                            {
                                temp = matrix[i - 2, j + 1];
                                matrix[i - 2, j + 1] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i - 2, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j - 2] == "*" || matrix[i - 1, j - 2] == "Tr" || matrix[i - 1, j - 2] == "Tr1" || matrix[i - 1, j - 2] == "Cr" || matrix[i - 1, j - 2] == "Hr" || matrix[i - 1, j - 2] == "Qr" || matrix[i - 1, j - 2] == "Пr")
                            {
                                temp = matrix[i - 1, j - 2];
                                matrix[i - 1, j - 2] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i - 1, j - 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 2] == "*" || matrix[i - 1, j + 2] == "Tr" || matrix[i - 1, j + 2] == "Tr1" || matrix[i - 1, j + 2] == "Cr" || matrix[i - 1, j + 2] == "Hr" || matrix[i - 1, j + 2] == "Qr" || matrix[i - 1, j + 2] == "Пr")
                            {
                                temp = matrix[i - 1, j + 2];
                                matrix[i - 1, j + 2] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i - 1, j + 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 2, j + 1] == "*" || matrix[i + 2, j + 1] == "Tr" || matrix[i + 2, j + 1] == "Tr1" || matrix[i + 2, j + 1] == "Cr" || matrix[i + 2, j + 1] == "Hr" || matrix[i + 2, j + 1] == "Qr" || matrix[i + 2, j + 1] == "Пr")
                            {
                                temp = matrix[i + 2, j + 1];
                                matrix[i + 2, j + 1] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i + 2, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 2, j - 1] == "*" || matrix[i + 2, j - 1] == "Tr" || matrix[i + 2, j - 1] == "Tr1" || matrix[i + 2, j - 1] == "Cr" || matrix[i + 2, j - 1] == "Hr" || matrix[i + 2, j - 1] == "Qr" || matrix[i + 2, j - 1] == "Пr")
                            {
                                temp = matrix[i + 2, j - 1];
                                matrix[i + 2, j - 1] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i + 2, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 2] == "*" || matrix[i + 1, j + 2] == "Tr" || matrix[i + 1, j + 2] == "Tr1" || matrix[i + 1, j + 2] == "Cr" || matrix[i + 1, j + 2] == "Hr" || matrix[i + 1, j + 2] == "Qr" || matrix[i + 1, j + 2] == "Пr")
                            {
                                temp = matrix[i + 1, j + 2];
                                matrix[i + 1, j + 2] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i + 1, j + 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 2] == "*" || matrix[i + 1, j - 2] == "Tr" || matrix[i + 1, j - 2] == "Tr1" || matrix[i + 1, j - 2] == "Cr" || matrix[i + 1, j - 2] == "Hr" || matrix[i + 1, j - 2] == "Qr" || matrix[i + 1, j - 2] == "Пr")
                            {
                                temp = matrix[i + 1, j - 2];
                                matrix[i + 1, j - 2] = "Hg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i + 1, j - 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 8)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == "Tg" || matrix[i, j] == "Tg1")
                        {
                            if (matrix[i, j - 1] == "*" || matrix[i, j - 1] == "Tr" || matrix[i, j - 1] == "Tr1" || matrix[i, j - 1] == "Cr" || matrix[i, j - 1] == "Hr" || matrix[i, j - 1] == "Qr" || matrix[i, j - 1] == "Пr")
                            {
                                temp = matrix[i, j - 1];
                                matrix[i, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i, j + 1] == "*" || matrix[i, j + 1] == "Tr" || matrix[i, j + 1] == "Tr1" || matrix[i, j + 1] == "Cr" || matrix[i, j + 1] == "Hr" || matrix[i, j + 1] == "Qr" || matrix[i, j + 1] == "Пr")
                            {
                                temp = matrix[i, j + 1];
                                matrix[i, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j + 1];
                                matrix[i, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j] == "*" || matrix[i - 1, j] == "Tr" || matrix[i - 1, j] == "Tr1" || matrix[i - 1, j] == "Cr" || matrix[i - 1, j] == "Hr" || matrix[i - 1, j] == "Qr" || matrix[i - 1, j] == "Пr")
                            {
                                temp = matrix[i - 1, j];
                                matrix[i - 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i - 1, j];
                                matrix[i - 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j] == "*" || matrix[i + 1, j] == "Tr" || matrix[i + 1, j] == "Tr1" || matrix[i + 1, j] == "Cr" || matrix[i + 1, j] == "Hr" || matrix[i + 1, j] == "Qr" || matrix[i + 1, j] == "Пr")
                            {
                                temp = matrix[i + 1, j];
                                matrix[i + 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i + 1, j];
                                matrix[i + 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == "Cg")
                        {
                            if (matrix[i - 1, j - 1] == "*" || matrix[i - 1, j - 1] == "Tr" || matrix[i - 1, j - 1] == "Tr1" || matrix[i - 1, j - 1] == "Cr" || matrix[i - 1, j - 1] == "Hr" || matrix[i - 1, j - 1] == "Qr" || matrix[i - 1, j - 1] == "Пr")
                            {
                                temp = matrix[i - 1, j - 1];
                                matrix[i - 1, j - 1] = "Cg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cg";
                                matrix[i - 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 1] == "*" || matrix[i + 1, j - 1] == "Tr" || matrix[i + 1, j - 1] == "Tr1" || matrix[i + 1, j - 1] == "Cr" || matrix[i + 1, j - 1] == "Hr" || matrix[i + 1, j - 1] == "Qr" || matrix[i + 1, j - 1] == "Пr")
                            {
                                temp = matrix[i + 1, j - 1];
                                matrix[i + 1, j - 1] = "Cg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cg";
                                matrix[i + 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 1] == "*" || matrix[i - 1, j + 1] == "Tr" || matrix[i - 1, j + 1] == "Tr1" || matrix[i - 1, j + 1] == "Cr" || matrix[i - 1, j + 1] == "Hr" || matrix[i - 1, j + 1] == "Qr" || matrix[i - 1, j + 1] == "Пr")
                            {
                                temp = matrix[i - 1, j + 1];
                                matrix[i - 1, j + 1] = "Cg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cg";
                                matrix[i - 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 1] == "*" || matrix[i + 1, j + 1] == "Tr" || matrix[i + 1, j + 1] == "Tr1" || matrix[i + 1, j + 1] == "Cr" || matrix[i + 1, j + 1] == "Hr" || matrix[i + 1, j + 1] == "Qr" || matrix[i + 1, j + 1] == "Пr")
                            {
                                temp = matrix[i + 1, j + 1];
                                matrix[i + 1, j + 1] = "Cg";
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cg";
                                matrix[i + 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == "Qg")
                        {
                            if (matrix[i, j - 1] == "*" || matrix[i, j - 1] == "Tr" || matrix[i, j - 1] == "Tr1" || matrix[i, j - 1] == "Cr" || matrix[i, j - 1] == "Hr" || matrix[i, j - 1] == "Qr" || matrix[i, j - 1] == "Пr")
                            {
                                temp = matrix[i, j - 1];
                                matrix[i, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i, j + 1] == "*" || matrix[i, j + 1] == "Tr" || matrix[i, j + 1] == "Tr1" || matrix[i, j + 1] == "Cr" || matrix[i, j + 1] == "Hr" || matrix[i, j + 1] == "Qr" || matrix[i, j + 1] == "Пr")
                            {
                                temp = matrix[i, j + 1];
                                matrix[i, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j + 1];
                                matrix[i, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j] == "*" || matrix[i - 1, j] == "Tr" || matrix[i - 1, j] == "Tr1" || matrix[i - 1, j] == "Cr" || matrix[i - 1, j] == "Hr" || matrix[i - 1, j] == "Qr" || matrix[i - 1, j] == "Пr")
                            {
                                temp = matrix[i - 1, j];
                                matrix[i - 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i - 1, j];
                                matrix[i - 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j] == "*" || matrix[i + 1, j] == "Tr" || matrix[i + 1, j] == "Tr1" || matrix[i + 1, j] == "Cr" || matrix[i + 1, j] == "Hr" || matrix[i + 1, j] == "Qr" || matrix[i + 1, j] == "Пr")
                            {
                                temp = matrix[i + 1, j];
                                matrix[i + 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i + 1, j];
                                matrix[i + 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j - 1] == "*" || matrix[i - 1, j - 1] == "Tr" || matrix[i - 1, j - 1] == "Tr1" || matrix[i - 1, j - 1] == "Cr" || matrix[i - 1, j - 1] == "Hr" || matrix[i - 1, j - 1] == "Qr" || matrix[i - 1, j - 1] == "Пr")
                            {
                                temp = matrix[i - 1, j - 1];
                                matrix[i - 1, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i - 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 1] == "*" || matrix[i + 1, j - 1] == "Tr" || matrix[i + 1, j - 1] == "Tr1" || matrix[i + 1, j - 1] == "Cr" || matrix[i + 1, j - 1] == "Hr" || matrix[i + 1, j - 1] == "Qr" || matrix[i + 1, j - 1] == "Пr")
                            {
                                temp = matrix[i + 1, j - 1];
                                matrix[i + 1, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i + 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 1] == "*" || matrix[i - 1, j + 1] == "Tr" || matrix[i - 1, j + 1] == "Tr1" || matrix[i - 1, j + 1] == "Cr" || matrix[i - 1, j + 1] == "Hr" || matrix[i - 1, j + 1] == "Qr" || matrix[i - 1, j + 1] == "Пr")
                            {
                                temp = matrix[i - 1, j + 1];
                                matrix[i - 1, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i - 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 1] == "*" || matrix[i + 1, j + 1] == "Tr" || matrix[i + 1, j + 1] == "Tr1" || matrix[i + 1, j + 1] == "Cr" || matrix[i + 1, j + 1] == "Hr" || matrix[i + 1, j + 1] == "Qr" || matrix[i + 1, j + 1] == "Пr")
                            {
                                temp = matrix[i + 1, j + 1];
                                matrix[i + 1, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                greenchax(kinggreenplace1, kinggreenplace2);
                                if (greenchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i + 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 8)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            bool redstalemate()
            {
                if (redchax(kingredplace1, kingredplace2))
                {
                    return false;
                }
                else
                {
                    if (kingredplace1 != 2 && matrix[kingredplace1 - 1, kingredplace2] != "Tr" && matrix[kingredplace1 - 1, kingredplace2] != "Tr1" && matrix[kingredplace1 - 1, kingredplace2] != "Cr" && matrix[kingredplace1 - 1, kingredplace2] != "Hr" && matrix[kingredplace1 - 1, kingredplace2] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1 - 1, kingredplace2);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace1 != 2 && kingredplace2 != 2 && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Tr" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Tr1" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Cr" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Hr" && matrix[kingredplace1 - 1, kingredplace2 - 1] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1 - 1, kingredplace2 - 1);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace2 != 9 && kingredplace1 != 2 && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Tr" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Tr1" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Cr" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Hr" && matrix[kingredplace1 - 1, kingredplace2 + 1] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1 - 1, kingredplace2 + 1);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace2 != 2 && matrix[kingredplace1, kingredplace2 - 1] != "Tr" && matrix[kingredplace1, kingredplace2 - 1] != "Tr1" && matrix[kingredplace1, kingredplace2 - 1] != "Cr" && matrix[kingredplace1, kingredplace2 - 1] != "Hr" && matrix[kingredplace1, kingredplace2 - 1] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1, kingredplace2 - 1);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace2 != 9 && matrix[kingredplace1, kingredplace2 + 1] != "Tr" && matrix[kingredplace1, kingredplace2 + 1] != "Tr1" && matrix[kingredplace1, kingredplace2 + 1] != "Cr" && matrix[kingredplace1, kingredplace2 + 1] != "Hr" && matrix[kingredplace1, kingredplace2 + 1] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1, kingredplace2 + 1);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace1 != 9 && matrix[kingredplace1 + 1, kingredplace2] != "Tr" && matrix[kingredplace1 + 1, kingredplace2] != "Tr1" && matrix[kingredplace1 + 1, kingredplace2] != "Cr" && matrix[kingredplace1 + 1, kingredplace2] != "Hr" && matrix[kingredplace1 + 1, kingredplace2] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1 + 1, kingredplace2);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace1 != 9 && kingredplace2 != 9 && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Tr" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Tr1" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Cr" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Hr" && matrix[kingredplace1 + 1, kingredplace2 + 1] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1 + 1, kingredplace2 + 1);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                    if (kingredplace1 != 9 && kingredplace2 != 2 && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Tr" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Tr1" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Cr" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Hr" && matrix[kingredplace1 + 1, kingredplace2 - 1] != "Qr")
                    {
                        matrix[kingredplace1, kingredplace2] = "*";
                        redchax(kingredplace1 + 1, kingredplace2 - 1);
                        matrix[kingredplace1, kingredplace2] = "Kr";
                        if (redchaxmat == false)
                        {
                            return false;
                        }
                    }
                }
                int counterimposmoves;
                string temp;
                for (int i = 2; i < 10; i++)
                {
                    for (int j = 2; j < 10; j++)
                    {
                        counterimposmoves = 0;
                        if (matrix[i, j] == "Пr")
                        {
                            if (matrix[i + 1, j] != "*")
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 1] == "Tg" || matrix[i + 1, j + 1] == "Tg1" && matrix[i + 1, j + 1] == "Qg" && matrix[i + 1, j + 1] == "Cg" && matrix[i + 1, j + 1] == "Hg" && matrix[i + 1, j + 1] == "Пg")
                            {
                                temp = matrix[i + 1, j + 1];
                                matrix[i + 1, j + 1] = "Пr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Пr";
                                matrix[i + 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 1] == "Tg" || matrix[i + 1, j - 1] == "Tg1" && matrix[i + 1, j - 1] == "Qg" && matrix[i + 1, j - 1] == "Cg" && matrix[i + 1, j - 1] == "Hg" && matrix[i + 1, j - 1] == "Пg")
                            {
                                temp = matrix[i + 1, j - 1];
                                matrix[i + 1, j - 1] = "Пr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Пr";
                                matrix[i + 1, j - 1] = temp;
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
                        else if (matrix[i, j] == "Hr")
                        {
                            if (matrix[i - 2, j - 1] == "*" || matrix[i - 2, j - 1] == "Tg" || matrix[i - 2, j - 1] == "Tg1" || matrix[i - 2, j - 1] == "Cg" || matrix[i - 2, j - 1] == "Hg" || matrix[i - 2, j - 1] == "Qg" || matrix[i - 2, j - 1] == "Пg")
                            {
                                temp = matrix[i - 2, j - 1];
                                matrix[i - 2, j - 1] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i - 2, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 2, j + 1] == "*" || matrix[i - 2, j + 1] == "Tg" || matrix[i - 2, j + 1] == "Tg1" || matrix[i - 2, j + 1] == "Cg" || matrix[i - 2, j + 1] == "Hg" || matrix[i - 2, j + 1] == "Qg" || matrix[i - 2, j + 1] == "Пg")
                            {
                                temp = matrix[i - 2, j + 1];
                                matrix[i - 2, j + 1] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i - 2, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j - 2] == "*" || matrix[i - 1, j - 2] == "Tg" || matrix[i - 1, j - 2] == "Tg1" || matrix[i - 1, j - 2] == "Cg" || matrix[i - 1, j - 2] == "Hg" || matrix[i - 1, j - 2] == "Qg" || matrix[i - 1, j - 2] == "Пg")
                            {
                                temp = matrix[i - 1, j - 2];
                                matrix[i - 1, j - 2] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i - 1, j - 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 2] == "*" || matrix[i - 1, j + 2] == "Tg" || matrix[i - 1, j + 2] == "Tg1" || matrix[i - 1, j + 2] == "Cg" || matrix[i - 1, j + 2] == "Hg" || matrix[i - 1, j + 2] == "Qg" || matrix[i - 1, j + 2] == "Пg")
                            {
                                temp = matrix[i - 1, j + 2];
                                matrix[i - 1, j + 2] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hg";
                                matrix[i - 1, j + 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 2, j + 1] == "*" || matrix[i + 2, j + 1] == "Tg" || matrix[i + 2, j + 1] == "Tg1" || matrix[i + 2, j + 1] == "Cg" || matrix[i + 2, j + 1] == "Hg" || matrix[i + 2, j + 1] == "Qg" || matrix[i + 2, j + 1] == "Пg")
                            {
                                temp = matrix[i + 2, j + 1];
                                matrix[i + 2, j + 1] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i + 2, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 2, j - 1] == "*" || matrix[i + 2, j - 1] == "Tg" || matrix[i + 2, j - 1] == "Tg1" || matrix[i + 2, j - 1] == "Cg" || matrix[i + 2, j - 1] == "Hg" || matrix[i + 2, j - 1] == "Qg" || matrix[i + 2, j - 1] == "Пg")
                            {
                                temp = matrix[i + 2, j - 1];
                                matrix[i + 2, j - 1] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i + 2, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 2] == "*" || matrix[i + 1, j + 2] == "Tg" || matrix[i + 1, j + 2] == "Tg1" || matrix[i + 1, j + 2] == "Cg" || matrix[i + 1, j + 2] == "Hg" || matrix[i + 1, j + 2] == "Qg" || matrix[i + 1, j + 2] == "Пg")
                            {
                                temp = matrix[i + 1, j + 2];
                                matrix[i + 1, j + 2] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i + 1, j + 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 2] == "*" || matrix[i + 1, j - 2] == "Tg" || matrix[i + 1, j - 2] == "Tg1" || matrix[i + 1, j - 2] == "Cg" || matrix[i + 1, j - 2] == "Hg" || matrix[i + 1, j - 2] == "Qg" || matrix[i + 1, j - 2] == "Пg")
                            {
                                temp = matrix[i + 1, j - 2];
                                matrix[i + 1, j - 2] = "Hr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Hr";
                                matrix[i + 1, j - 2] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 8)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == "Tr" || matrix[i, j] == "Tr1")
                        {
                            if (matrix[i, j - 1] == "*" || matrix[i, j - 1] == "Tg" || matrix[i, j - 1] == "Tg1" || matrix[i, j - 1] == "Cg" || matrix[i, j - 1] == "Hg" || matrix[i, j - 1] == "Qg" || matrix[i, j - 1] == "Пg")
                            {
                                temp = matrix[i, j - 1];
                                matrix[i, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i, j + 1] == "*" || matrix[i, j + 1] == "Tg" || matrix[i, j + 1] == "Tg1" || matrix[i, j + 1] == "Cg" || matrix[i, j + 1] == "Hg" || matrix[i, j + 1] == "Qg" || matrix[i, j + 1] == "Пg")
                            {
                                temp = matrix[i, j + 1];
                                matrix[i, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j + 1];
                                matrix[i, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j] == "*" || matrix[i - 1, j] == "Tg" || matrix[i - 1, j] == "Tg1" || matrix[i - 1, j] == "Cg" || matrix[i - 1, j] == "Hg" || matrix[i - 1, j] == "Qg" || matrix[i - 1, j] == "Пg")
                            {
                                temp = matrix[i - 1, j];
                                matrix[i - 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i - 1, j];
                                matrix[i - 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j] == "*" || matrix[i + 1, j] == "Tg" || matrix[i + 1, j] == "Tg1" || matrix[i + 1, j] == "Cg" || matrix[i + 1, j] == "Hg" || matrix[i + 1, j] == "Qg" || matrix[i + 1, j] == "Пg")
                            {
                                temp = matrix[i + 1, j];
                                matrix[i + 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i + 1, j];
                                matrix[i + 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == "Cr")
                        {
                            if (matrix[i - 1, j - 1] == "*" || matrix[i - 1, j - 1] == "Tg" || matrix[i - 1, j - 1] == "Tg1" || matrix[i - 1, j - 1] == "Cg" || matrix[i - 1, j - 1] == "Hg" || matrix[i - 1, j - 1] == "Qg" || matrix[i - 1, j - 1] == "Пg")
                            {
                                temp = matrix[i - 1, j - 1];
                                matrix[i - 1, j - 1] = "Cr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cr";
                                matrix[i - 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 1] == "*" || matrix[i + 1, j - 1] == "Tg" || matrix[i + 1, j - 1] == "Tg1" || matrix[i + 1, j - 1] == "Cg" || matrix[i + 1, j - 1] == "Hg" || matrix[i + 1, j - 1] == "Qg" || matrix[i + 1, j - 1] == "Пg")
                            {
                                temp = matrix[i + 1, j - 1];
                                matrix[i + 1, j - 1] = "Cr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cr";
                                matrix[i + 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 1] == "*" || matrix[i - 1, j + 1] == "Tg" || matrix[i - 1, j + 1] == "Tg1" || matrix[i - 1, j + 1] == "Cg" || matrix[i - 1, j + 1] == "Hg" || matrix[i - 1, j + 1] == "Qg" || matrix[i - 1, j + 1] == "Пg")
                            {
                                temp = matrix[i - 1, j + 1];
                                matrix[i - 1, j + 1] = "Cr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cr";
                                matrix[i - 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 1] == "*" || matrix[i + 1, j + 1] == "Tg" || matrix[i + 1, j + 1] == "Tg1" || matrix[i + 1, j + 1] == "Cg" || matrix[i + 1, j + 1] == "Hg" || matrix[i + 1, j + 1] == "Qg" || matrix[i + 1, j + 1] == "Пg")
                            {
                                temp = matrix[i + 1, j + 1];
                                matrix[i + 1, j + 1] = "Cr";
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = "Cr";
                                matrix[i + 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (counterimposmoves != 4)
                            {
                                return false;
                            }
                        }
                        else if (matrix[i, j] == "Qr")
                        {
                            if (matrix[i, j - 1] == "*" || matrix[i, j - 1] == "Tg" || matrix[i, j - 1] == "Tg1" || matrix[i, j - 1] == "Cg" || matrix[i, j - 1] == "Hg" || matrix[i, j - 1] == "Qg" || matrix[i, j - 1] == "Пg")
                            {
                                temp = matrix[i, j - 1];
                                matrix[i, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i, j + 1] == "*" || matrix[i, j + 1] == "Tg" || matrix[i, j + 1] == "Tg1" || matrix[i, j + 1] == "Cg" || matrix[i, j + 1] == "Hg" || matrix[i, j + 1] == "Qg" || matrix[i, j + 1] == "Пg")
                            {
                                temp = matrix[i, j + 1];
                                matrix[i, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j + 1];
                                matrix[i, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j] == "*" || matrix[i - 1, j] == "Tg" || matrix[i - 1, j] == "Tg1" || matrix[i - 1, j] == "Cg" || matrix[i - 1, j] == "Hg" || matrix[i - 1, j] == "Qg" || matrix[i - 1, j] == "Пg")
                            {
                                temp = matrix[i - 1, j];
                                matrix[i - 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i - 1, j];
                                matrix[i - 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j] == "*" || matrix[i + 1, j] == "Tg" || matrix[i + 1, j] == "Tg1" || matrix[i + 1, j] == "Cg" || matrix[i + 1, j] == "Hg" || matrix[i + 1, j] == "Qg" || matrix[i + 1, j] == "Пg")
                            {
                                temp = matrix[i + 1, j];
                                matrix[i + 1, j] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i + 1, j];
                                matrix[i + 1, j] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j - 1] == "*" || matrix[i - 1, j - 1] == "Tg" || matrix[i - 1, j - 1] == "Tg1" || matrix[i - 1, j - 1] == "Cg" || matrix[i - 1, j - 1] == "Hg" || matrix[i - 1, j - 1] == "Qg" || matrix[i - 1, j - 1] == "Пg")
                            {
                                temp = matrix[i - 1, j - 1];
                                matrix[i - 1, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i - 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j - 1] == "*" || matrix[i + 1, j - 1] == "Tg" || matrix[i + 1, j - 1] == "Tg1" || matrix[i + 1, j - 1] == "Cg" || matrix[i + 1, j - 1] == "Hg" || matrix[i + 1, j - 1] == "Qg" || matrix[i + 1, j - 1] == "Пg")
                            {
                                temp = matrix[i + 1, j - 1];
                                matrix[i + 1, j - 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i + 1, j - 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i - 1, j + 1] == "*" || matrix[i - 1, j + 1] == "Tg" || matrix[i - 1, j + 1] == "Tg1" || matrix[i - 1, j + 1] == "Cg" || matrix[i - 1, j + 1] == "Hg" || matrix[i - 1, j + 1] == "Qg" || matrix[i - 1, j + 1] == "Пg")
                            {
                                temp = matrix[i - 1, j + 1];
                                matrix[i - 1, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i - 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
                            if (matrix[i + 1, j + 1] == "*" || matrix[i + 1, j + 1] == "Tg" || matrix[i + 1, j + 1] == "Tg1" || matrix[i + 1, j + 1] == "Cg" || matrix[i + 1, j + 1] == "Hg" || matrix[i + 1, j + 1] == "Qg" || matrix[i + 1, j + 1] == "Пg")
                            {
                                temp = matrix[i + 1, j + 1];
                                matrix[i + 1, j + 1] = matrix[i, j];
                                matrix[i, j] = "*";
                                redchax(kingredplace1, kingredplace2);
                                if (redchaxmat == true)
                                {
                                    counterimposmoves++;
                                }
                                matrix[i, j] = matrix[i, j];
                                matrix[i + 1, j + 1] = temp;
                            }
                            else
                            {
                                counterimposmoves++;
                            }
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
