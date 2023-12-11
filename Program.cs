using AstroWars;
using AstroWars.Utilities;

using (var window = new Window(new(640, 480), "Test"))
{
    while (window.IsOpen())
    {
        if (window.KeyboardState.IsDown(KeyboardCode.Space))
        {
            Console.WriteLine("space!");
        }
    }
}