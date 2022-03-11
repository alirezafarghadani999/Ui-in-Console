# Ui-in-Console
<h4>
  make Gui in terminal ( Console ) <br>
  you can use this class in your c# project and make Gui in Consoel base application too eazy <br>
  you can make menu , box && get input , print text <br>
  
</h4>
<h3>Simple Program i make with this class</h3>
<img src="https://user-images.githubusercontent.com/67876027/157758868-1023f5d9-1f2c-4776-950b-a6f8eeb31e2e.png">

  <h1>How import</h1>
<p>first import View_printer.cs in your project and next go to View_printer.cs and replace namespace name to your project name .</p>
<img src="https://user-images.githubusercontent.com/67876027/157757698-0b5dd544-dcbe-42db-9f25-76569eddee4a.png">

<h1>How can i use ..</h1>
first call View_print on Main Class 

```c#
class Program
{
  static View_Print views = new View_Print();
  ...
```
Next create main_loop functions for call Gui
```c#
static void main_loop()
{
    ...
}
```
Make While Loop in main function for refresh screen and resize Gui ..
```c#
static void Main(string[] args)
{

    while (true)
    {
    ...
    }
}
```
<h2>Methods ...</h2>
in this c# class we have 13 function for you and you can use for make Gui
<hr>
<h3>Function Group 1 -- Movement</h3>

```c#
public void move_up()
{
    ...
    }

    public void move_down()
    {
    ...
    }
    public void move_left()
    {
    ...
    }
    public void move_right()
    {
    ...
}
```

this group maek for Options menu . When you like controll menu and select menu you can use movement
for Example You liek controll menu selections with arrowup and arrowdown in keyboard 
you can write this to move select menu options to up and down
```c#
if (Console.ReadKey().Key == ConsoleKey.DownArrow && views.column_options >= 0 && views.select_options >= 0)
{
    views.move_down();

}
else if (Console.ReadKey().Key == ConsoleKey.UpArrow && views.column_options >= 0)
{

    views.move_up();

}
```
this part ``` views.column_options >= 0 && views.select_options >= 0 ``` for cant go uper than zero menu or downet than end menu ...
<hr>
<h3>Function 2 -- base window</h3>

```c#
//set setting view
public void set_window(object color_backGround)
{
...
}

//get console size

public void get_windowSize()
{
...
}

```
this two functions for base console setting first functions for set background color console 
and secend functions for get and save console size..
⚠️ default background color is white

for example :
```c#
static void main_loop()
        {
            views.get_windowSize();
            views.set_window(ConsoleColor.White);
            ...
```
in top example I get screen size for Gui and set background color to white in main_loop functions ..
EZ 😎
<hr>
<h3>Function 3 -- Bar line</h3>

```c#
public void bar_line(int width, int height, int margin_left, int margin_top, object color_bg, string titel, object color_text,bool visable)
{
  ...
}
```

would you like your program have bar on top or on bottom for show your name or program name or view name ...
<br>
you can use this functions 
for example :

```c#
static void main_loop()
{
    views.get_windowSize();
    views.set_window(ConsoleColor.White);
    views.bar_line(views.WIDTH, 3, 0, 0, ConsoleColor.DarkBlue, "Alireza Farghadani Test GUI", ConsoleColor.White,true);
    //(int width, int height, int margin_left, int margin_top, object color_bg, string titel, object color_text,bool visable)
    ...
```
![image](https://user-images.githubusercontent.com/67876027/157830742-13d50217-e327-4efe-8eb8-cb17a07eb447.png)
<br>
if in margin_top set 0 your bar show in top if set 1 show in bottom

<hr>
<h3>Function 4 -- options menu</h3>

```c#
 // add menu options 
public void Options(string[] options, int width_optins, int margin_left_inside, object bg_color, object text_color, bool Percentage_maring, int maring_left, int maring_top , object select_color, int option_menu_number, bool visable)
{
  ...
}
```
this function help you to create menu and button for user to user can Communicate with Gui 👌
<br>
for example :

```c#
static void main_loop()
{
    views.get_windowSize();
    views.set_window(ConsoleColor.White);
    views.bar_line(views.Wd, 3, 0, 0, ConsoleColor.DarkBlue, "Alireza Farghadani Test GUI", ConsoleColor.White,true);
    string[] tesr = { "terminal 1", "terminal 2" };
    views.Options(tesr,20,4,ConsoleColor.DarkBlue,ConsoleColor.White,false,10,3,ConsoleColor.Red,0,true);
```
![image](https://user-images.githubusercontent.com/67876027/157834127-be99df9b-925e-464b-8e3d-d5e652642a51.png)

<center><h4>if you need select options value for make onclick or ... event or set select menu value you can use get and set value</h4></center>
  
  ```c#
      public int Select_list_options   
      {
        ...
        //set/get
      }
      public int Select_list_options_row   
      {
        ...
        //set/get
      }
  ```
  <hr>
<h3>Function 5 -- Null window(box)</h3>
if you like draw box in your gui you can use this functions

```c#
public void null_window(bool Percentage_value_size, int width, int height, bool Percentage_value_margin, int margin_left, int margin_Top, object color_bg,bool visable)
{
  ...
}
```
for example i draw red and blue box for my program :

```c#
static void main_loop()
{
    views.get_windowSize();
    views.set_window(ConsoleColor.White);
    views.bar_line(views.Wd, 3, 0, 0, ConsoleColor.DarkBlue, "Alireza Farghadani Test GUI", ConsoleColor.White,true);
    string[] tesr = { "terminal 1", "terminal 2" };
    views.Options(tesr,20,4,ConsoleColor.DarkBlue,ConsoleColor.White,false,10,3,ConsoleColor.Red,0,true);
    views.null_window(true, 50, 85, false, 1 * views.WIDTH / 100, 6, ConsoleColor.Red, true);
    views.null_window(true, 50, 85, false, 50 * views.WIDTH / 100, 6, ConsoleColor.DarkBlue, true);
    ...
```

![image](https://user-images.githubusercontent.com/67876027/157836488-99d92345-2368-4ea8-abf6-eaf6a50cb8f2.png)

<hr>
  <h3>Function Group 6 -- Print and Input</h3>
  if you need get input or show text you can use this two functiosn
  
  ```c#
  public void text(bool Percentage_value,int left,int top,string txt,object bg_color,object text_color,bool visable)
  {
    ...
  }
  public string input(bool Percentage_value, int left, int top, string input_text, object bg_color, object text_color, bool visable)
  {
    ...
  }
        
  ```
  for example i use to get input and show on othe side off screen
  
  ```c#
  for (int i = 0; i <= 10; i++)
  {

      string inputtest = views.input(true, 2, 20 + i * 3, "$: ", ConsoleColor.Red, ConsoleColor.White, true);
      views.text(true, 52, 20 + i * 3, inputtest, ConsoleColor.DarkBlue, ConsoleColor.White, true);
  }
  ```
  ![image](https://user-images.githubusercontent.com/67876027/157838278-6e76cff6-b52f-4bd0-84bf-b0ec322c6dd3.png)
  
<h3>Mini Functions ..</h3>
```c#
public void error_screen(string error){ ..}
public void refresh(){ ..}
```
you can show error msg with ``` error_screen(error text) ``` and refresh(update screen) with ``` refresh() ``` function

<hr>
<h1>I recommend you ..</h1>
write main program like this :

```c#
        static View_Print views = new View_Print();
        static void main_loop()
        {
            //GUI COD
        }
        static void Main(string[] args)
        {
            
            while (true)
            {
            if (views.HEIGHT != Console.WindowHeight || views.WIDTH != Console.WindowWidth)
                {
                    views.refresh();
                    main_loop();
                }    
            }
        }
```

and after refresh screen All time call main_loop(); again ...
and Example cod file in example folder ...

Have Good day 😊🤞🙌
