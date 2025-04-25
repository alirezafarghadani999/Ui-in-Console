# Ui-in-Console

A lightweight C# class for building **GUI-like experiences inside the terminal (console)**.  
You can easily create menus, boxes, get user input, and print styled text directly in your console apps.

![Example](https://user-images.githubusercontent.com/67876027/157758868-1023f5d9-1f2c-4776-950b-a6f8eeb31e2e.png)

---

## 🧩 Installation

1. Add `View_printer.cs` to your project.
2. Change the namespace inside `View_printer.cs` to match your project’s namespace.

![Import](https://user-images.githubusercontent.com/67876027/157757698-0b5dd544-dcbe-42db-9f25-76569eddee4a.png)

---

## 🚀 Getting Started

In your `Main` class:

```csharp
static View_Print views = new View_Print();
```

Create a main loop for rendering the UI:

```csharp
static void main_loop()
{
    // UI logic here
}
```

And call it like this in your `Main` method:

```csharp
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

---

## 🧰 Available Functions

### 🕹️ Movement (for menu control)

```csharp
move_up();
move_down();
move_left();
move_right();
```

Example usage with arrow keys:

```csharp
if (Console.ReadKey().Key == ConsoleKey.DownArrow)
    views.move_down();
else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
    views.move_up();
```

---

### 🪟 Window Settings

```csharp
set_window(ConsoleColor.White);
get_windowSize();
```

---

### 📊 Bar Line

Draw a bar at the top or bottom of the screen:

```csharp
bar_line(width, height, marginLeft, marginTop, bgColor, title, textColor, visible);
```

Example:

```csharp
views.bar_line(views.WIDTH, 3, 0, 0, ConsoleColor.DarkBlue, "My Console GUI", ConsoleColor.White, true);
```

---

### 📋 Options Menu

```csharp
Options(string[] options, int width, int paddingLeft, object bgColor, object textColor, 
        bool usePercentMargin, int marginLeft, int marginTop, object selectedColor, 
        int menuNumber, bool visible);
```

Get or set selected item:

```csharp
views.Select_list_options
views.Select_list_options_row
```

---

### 🔲 Boxes (Null Window)

```csharp
null_window(usePercentSize, width, height, usePercentMargin, marginLeft, marginTop, bgColor, visible);
```

Draws empty boxes on screen for layout.

---

### ✏️ Text & Input

```csharp
text(usePercent, left, top, "Text", bgColor, textColor, visible);
input(usePercent, left, top, "Label: ", bgColor, textColor, visible);
```

Example:

```csharp
string inputValue = views.input(true, 2, 20, "$: ", ConsoleColor.Red, ConsoleColor.White, true);
views.text(true, 52, 20, inputValue, ConsoleColor.DarkBlue, ConsoleColor.White, true);
```

---

### ⚠️ Utility

```csharp
error_screen("Something went wrong!");
refresh();
```

---

## 💡 Recommended Structure

```csharp
static View_Print views = new View_Print();

static void main_loop()
{
    // All UI rendering here
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

---

## 📂 Example

Check out the `example/` folder for a ready-to-run sample project.

---

## 💬 Final Word

This class is still growing. Pull requests and ideas are always welcome!  
Thanks for checking it out — and happy coding! 😊
