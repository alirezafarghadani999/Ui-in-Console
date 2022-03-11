using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NIDE
{
    public class View_Print
    {
        public int HEIGHT, WIDTH;
        public int select_options = 0;
        public int column_options = 0;
        static int[] options_list_number = new int[500];
        public int all_options = 0;
        private int select_list_options_row = 0;
        private int select_list_options = 0;


        public int Select_list_options
        {
            get { return select_list_options; }
            set
            {
                select_list_options = value;
                select_options = select_list_options;
                refresh();
            }
        }
        public int Select_list_options_row
        {
            get { return select_list_options_row; }
            set
            {
                select_list_options_row = value;
                column_options = select_list_options_row;
                refresh();
            }
        }


        // erorr screen function
        public void error_screen(string error)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                    if (i == HEIGHT / 2 && j == 0)
                    {
                        Console.Write(error);
                        j = j + error.Length;
                    }

                }
            }
        }

        //refresh view
        public void refresh()
        {

            set_window(ConsoleColor.White);
            Console.Clear();
            get_windowSize();
            all_options = 0;
            select_list_options = select_options;
            select_list_options_row = column_options;

        }


        //move ...

        public void move_up()
        {
            select_options -= 1;
            refresh();
        }

        public void move_down()
        {
            select_options += 1;
            refresh();
        }
        public void move_left()
        {
            column_options -= 1;
            select_options = 0;
            refresh();
        }
        public void move_right()
        {
            column_options += 1;
            select_options = 0;
            refresh();
        }

        //set setting view
        public void set_window(object color_backGround)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = (ConsoleColor)color_backGround;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Console.Write(" ");
                }
            }

            Console.CursorVisible = false;
        }

        //get consoel size

        public void get_windowSize()
        {
            HEIGHT = Console.WindowHeight;
            WIDTH = Console.WindowWidth;
        }

        //add bar line
        public void bar_line(int width, int height, int margin_left, int margin_top, object color_bg, string titel, object color_text, bool visable)
        {
            if (visable)
            {

                if (margin_top == 1)
                {
                    try
                    {
                        Console.SetCursorPosition(margin_left, HEIGHT - height);
                    }
                    catch
                    {
                        Console.Write("Problem in View size");
                    }
                }
                else
                {
                    Console.SetCursorPosition(margin_left, margin_top);

                }

                int titel_size = titel.Length;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.BackgroundColor = (ConsoleColor)color_bg;
                        Console.ForegroundColor = (ConsoleColor)color_text;
                        if (i == height / 2 && j == width / 2 - titel_size / 2)
                        {
                            Console.Write(titel);
                            Console.Write(" ");
                            j += titel_size;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write("");
                }
            }

        }

        // add menu options 
        public void Options(string[] options, int width_optins, int margin_left_inside, object bg_color, object text_color, bool Percentage_maring, int maring_left, int maring_top
            , object select_color, int option_menu_number, bool visable)
        {
            try
            {
                if (visable)
                {
                    if (column_options < 0 || select_options < 0)
                    {
                        column_options = 0;
                        select_options = 0;
                    }

                    options_list_number[option_menu_number] = options.Length;
                    all_options += 1;
                    if (Percentage_maring)
                    {
                        maring_left = maring_left * WIDTH / 100;
                        maring_top = maring_top * HEIGHT / 100;
                    }
                    Console.BackgroundColor = (ConsoleColor)bg_color;
                    Console.ForegroundColor = (ConsoleColor)text_color;


                    for (int i = 0; i < options.Length; i++)
                    {

                        if (i == select_options && column_options == option_menu_number)
                        {
                            Console.BackgroundColor = (ConsoleColor)select_color;
                            select_list_options = i;
                            select_list_options_row = column_options;

                        }
                        else if (select_options > options_list_number[column_options] - 1)
                        {
                            column_options += 1;
                            select_options = 0;

                        }
                        else if (select_options < 0)
                        {
                            column_options -= 1;
                            select_options = options.Length - 1;

                        }
                        else if (column_options < 0)
                        {
                            column_options = 0;
                        }
                        else
                        {
                            Console.BackgroundColor = (ConsoleColor)bg_color;

                        }


                        Console.SetCursorPosition(maring_left - width_optins / 2, maring_top + i);
                        for (int j = 0; j < width_optins; j++)
                        {
                            Console.Write(" ");
                            if (j == margin_left_inside)
                            {

                                Console.Write(options[i]);
                                j += options[i].Length;
                                if (width_optins + options[i].Length > WIDTH)
                                {
                                    error_screen("Screen Too Small for this view");
                                }
                            }
                        }

                    }
                }

            }
            catch
            {
                error_screen("Screen Too Small for this view");

            }

        }

        // add rectangel window 
        public void null_window(bool Percentage_value_size, int width, int height, bool Percentage_value_margin, int margin_left, int margin_Top, object color_bg, bool visable)
        {
            if (visable)
            {
                if (Percentage_value_size)
                {
                    width = width * WIDTH / 100;
                    height = height * HEIGHT / 100;
                }
                if (Percentage_value_margin)
                {
                    margin_left = margin_left * WIDTH / 100;
                    margin_Top = margin_Top * HEIGHT / 100;
                }

                try
                {
                    if (margin_left == 0 && margin_Top == 0)
                    {
                        Console.SetCursorPosition(WIDTH / 2 - width / 2, HEIGHT / 2 - height / 2);

                    }
                    else if (margin_left == 0)
                    {
                        Console.SetCursorPosition(WIDTH / 2 - width / 2, margin_Top - height / 2);

                    }
                    else if (margin_Top == 0)
                    {
                        Console.SetCursorPosition(margin_left - width / 2, HEIGHT / 2 - height / 2);
                    }
                    else
                    {
                        Console.SetCursorPosition(margin_left, margin_Top);
                    }
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            Console.BackgroundColor = (ConsoleColor)color_bg;
                            Console.Write(" ");

                        }
                        if (margin_left == 0 && margin_Top == 0)
                        {
                            Console.SetCursorPosition(WIDTH / 2 - width / 2, HEIGHT / 2 - height / 2 + i);

                        }
                        else if (margin_left == 0)
                        {
                            Console.SetCursorPosition(WIDTH / 2 - width / 2, margin_Top - height / 2 + i);

                        }
                        else if (margin_Top == 0)
                        {
                            Console.SetCursorPosition(margin_left - width / 2, HEIGHT / 2 - height / 2 + i);
                        }
                        else
                        {
                            Console.SetCursorPosition(margin_left, margin_Top + i);
                        }


                    }
                }
                catch (Exception)
                {
                    error_screen("Screen Too Small for this view");

                }
            }

        }


        // text 
        public void text(bool Percentage_value, int left, int top, string txt, object bg_color, object text_color, bool visable)
        {
            if (visable)
            {
                if (Percentage_value)
                {
                    left = left * WIDTH / 100;
                    top = top * HEIGHT / 100;
                }
                Console.BackgroundColor = (ConsoleColor)bg_color;
                Console.ForegroundColor = (ConsoleColor)text_color;

                Console.SetCursorPosition(left, top);
                Console.Write(txt);
            }
        }

        public string input(bool Percentage_value, int left, int top, string input_text, object bg_color, object text_color, bool visable)
        {
            string value_get;
            if (visable)
            {
                if (Percentage_value)
                {
                    left = left * WIDTH / 100;
                    top = top * HEIGHT / 100;
                }
                Console.BackgroundColor = (ConsoleColor)bg_color;
                Console.ForegroundColor = (ConsoleColor)text_color;
                Console.CursorVisible = true;

                Console.SetCursorPosition(left, top);
                Console.Write(input_text);
                value_get = Console.ReadLine();
                Console.CursorVisible = false;
                Console.SetCursorPosition(WIDTH-1, HEIGHT-1);
                return value_get;

            }
            return "";

        }


    }
}
