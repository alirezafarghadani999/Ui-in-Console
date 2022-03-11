using System;

namespace NIDE
{

    class Program
    {
        static View_Print views = new View_Print();
        static bool visable = false;
        static bool visable2 = false;


        static void main_loop()
        {
            views.get_windowSize();
            views.bar_line(views.Wd, 3, 0, 0, ConsoleColor.DarkBlue, "Alireza Farghadani Test GUI", ConsoleColor.White,true);
            string[] tesr = { "terminal 1", "terminal 2" };
            views.Options(tesr,20,4,ConsoleColor.DarkBlue,ConsoleColor.White,false,10,3,ConsoleColor.Red,0,true);

            if(views.Select_list_options == 0 && views.Select_list_options_row == 0)
            {
                visable = true;
                visable2 = false;

            }
            if (views.Select_list_options == 1 && views.Select_list_options_row == 0)
            {
                visable = false;
                visable2 = true;

            }

            views.null_window(true, 50, 85, false, 1 * views.Wd / 100, 6, ConsoleColor.Red, visable2);
            views.null_window(true, 50, 85, false, 50 * views.Wd / 100, 6, ConsoleColor.DarkBlue, visable2);
            for (int i = 0; i <= 10; i++)
            {

                string inputtest = views.input(true, 2, 20 + i * 3, "$: ", ConsoleColor.Red, ConsoleColor.White, visable2);
                views.text(true, 52, 20 + i * 3, inputtest, ConsoleColor.DarkBlue, ConsoleColor.White, visable2);
            }
        }



        static void Main(string[] args)
        {


            while (true)
            {

                if (Console.KeyAvailable)
                {

                    if (Console.ReadKey().Key == ConsoleKey.DownArrow && views.options_get >= 0 && views.select_options >= 0)
                    {
                        views.move_down();
                        main_loop();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.UpArrow && views.options_get >= 0)
                    {

                        views.move_up();
                        main_loop();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.LeftArrow && views.options_get > 0)
                    {
                        views.move_left();
                        main_loop();
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.RightArrow && views.options_get < views.all_options-1)
                    {
                        views.move_right();
                        main_loop();

                    }

                    else if (Console.ReadKey().Key == ConsoleKey.R)
                    {
                        views.refresh();
                        main_loop();
                    }
                }
                else
                {
                    if (views.He != Console.WindowHeight || views.Wd != Console.WindowWidth)
                    {
                        views.refresh();
                        main_loop();
                    }
                }

            }
        }
    }
}
