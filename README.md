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
