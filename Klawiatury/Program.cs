Console.CursorVisible = false;
Player hero = new Player("Snake");
Console.WriteLine($"({hero.x}, {hero.y})");

while (true)
{
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");
    if (pressedKeyInfo.Key == ConsoleKey.A)
    {
        if (hero.x > 0)
        {
            hero.x -= 1;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.D)
    {
        if (hero.x < Console.BufferWidth - 1)
        {
            hero.x += 1;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.W)
    {
        if (hero.y > 0)
        {
            hero.y -= 1;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.S)
    {
        if (hero.y < Console.BufferHeight - 1)
        {
            hero.y += 1;
        }
    }

    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})       ");
    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);
