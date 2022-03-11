using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NIDE
{
    public class View_Print
    {
        public int He, Wd;
        public int select_options = 0;
        public int options_get = 0;
        static int[] options_list_number = new int[500];
        public int all_options = 0;
        private int select_list_options_row = 0;
        private int select_list_options = 0;


        public int Select_list_options   // property
        {
            get { return select_list_options; }   // get method
            set { select_list_options = value; }  // set method
        }
        public int Select_list_options_row   // property
        {
            get { return select_list_options_row; }   // get method
            set { select_list_options_row = value; }  // set method
        }


        // erorr screen function
        public void error_screen(string error)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < He; i++)
            {
                for (int j = 0; j < Wd; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                    if (i == He / 2 && j == 0)
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
            options_get -= 1;
            select_options = 0;
            refresh();
        }
        public void move_right()
        {
            options_get += 1;
            select_options = 0;
            refresh();
        }

        //set setting view
        public void set_window(object color_backGround)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = (ConsoleColor)color_backGround;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < He; i++)
            {
                for (int j = 0; j < Wd; j++)
                {
                    Console.Write(" ");
                }
            }

            Console.CursorVisible = false;
        }

        //get consoel size

        public void get_windowSize()
        {
            He = Console.WindowHeight;
            Wd = Console.WindowWidth;
        }

        //add bar line
        public void bar_line(int width, int height, int margin_left, int margin_top, object color_bg, string titel, object color_text,bool visable)
        {
            if (visable)
            {

                if (margin_top == 1)
                {
                    try
                    {
                        Console.SetCursorPosition(margin_left, He - height);
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
        public void Options(string[] options, int width_optins, int margin_left_inside, object bg_color, object text_color, bool person_maring, int maring_left, int maring_top
            , object select_color, int option_menu_number, bool visable)
        {
            try
            {
                if (visable)
                {
                    if (options_get < 0 || select_options < 0)
                    {
                        options_get = 0;
                        select_options = 0;
                    }

                    options_list_number[option_menu_number] = options.Length;
                    all_options += 1;
                    if (person_maring)
                    {
                        maring_left = maring_left * Wd / 100;
                        maring_top = maring_top * He / 100;
                    }
                    Console.BackgroundColor = (ConsoleColor)bg_color;
                    Console.ForegroundColor = (ConsoleColor)text_color;


                    for (int i = 0; i < options.Length; i++)
                    {

                        if (i == select_options && options_get == option_menu_number)
                        {
                            Console.BackgroundColor = (ConsoleColor)select_color;
                            select_list_options = i;
                            select_list_options_row = options_get;

                        }
                        else if (select_options > options_list_number[options_get] - 1)
                        {
                            options_get += 1;
                            select_options = 0;

                        } 
                        else if (select_options < 0)
                        {
                            options_get -= 1;
                            select_options = options.Length - 1;

                        }
                        else if (options_get < 0)
                        {
                            options_get = 0;
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
                                if (width_optins + options[i].Length > Wd)
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
        public void null_window(bool person_value_size, int width, int height, bool person_value_margin, int margin_left, int margin_Top, object color_bg,bool visable)
        {
            if (visable)
            {
                if (person_value_size)
                {
                    width = width * Wd / 100;
                    height = height * He / 100;
                }
                if (person_value_margin)
                {
                    margin_left = margin_left * Wd / 100;
                    margin_Top = margin_Top * He / 100;
                }

                try
                {
                    if (margin_left == 0 && margin_Top == 0)
                    {
                        Console.SetCursorPosition(Wd / 2 - width / 2, He / 2 - height / 2);

                    }
                    else if (margin_left == 0)
                    {
                        Console.SetCursorPosition(Wd / 2 - width / 2, margin_Top - height / 2);

                    }
                    else if (margin_Top == 0)
                    {
                        Console.SetCursorPosition(margin_left - width / 2, He / 2 - height / 2);
                    }
                    else
                    {
                        Console.SetCursorPosition(margin_left , margin_Top );
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
                            Console.SetCursorPosition(Wd / 2 - width / 2, He / 2 - height / 2 + i);

                        }
                        else if (margin_left == 0)
                        {
                            Console.SetCursorPosition(Wd / 2 - width / 2, margin_Top - height / 2 + i);

                        }
                        else if (margin_Top == 0)
                        {
                            Console.SetCursorPosition(margin_left - width / 2, He / 2 - height / 2 + i);
                        }
                        else
                        {
                            Console.SetCursorPosition(margin_left , margin_Top + i);
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
        public void text(bool person_value,int left,int top,string txt,object bg_color,object text_color,bool visable)
        {
            if (visable)
            {
                if (person_value)
                {
                    left = left * Wd / 100;
                    top = top * He / 100;
                }
                Console.BackgroundColor = (ConsoleColor)bg_color;
                Console.ForegroundColor = (ConsoleColor)text_color;

                Console.SetCursorPosition(left, top);
                Console.Write(txt);
            }
        }

        public string input(bool person_value, int left, int top, string input_text, object bg_color, object text_color, bool visable)
        {
            string value_get;
            if (visable)
            {
                if (person_value)
                {
                    left = left * Wd / 100;
                    top = top * He / 100;
                }
                Console.BackgroundColor = (ConsoleColor)bg_color;
                Console.ForegroundColor = (ConsoleColor)text_color;
                Console.CursorVisible = true;

                Console.SetCursorPosition(left, top);
                Console.Write(input_text);
                value_get = Console.ReadLine();
                return value_get;
                Console.CursorVisible = false;

            }
            return "";
           
        }



    }
}
