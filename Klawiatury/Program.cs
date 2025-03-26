Console.CursorVisible = false;
Player hero = new Player("Snake");
hero.x = 1;
hero.y = 2;
hero.speed = 3;
Console.WriteLine($"({hero.x}, {hero.y})");

while (true)
{
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");
    
    Point direction;

    switch (pressedKeyInfo.Key)
    {
        case ConsoleKey.A:
            direction = new Point
            {
                x = -hero.speed,
                y = -0
            };
            break;
        case ConsoleKey.D:
            direction = new Point
            {
                x = hero.speed,
                y = 0
            };
            break;
        case ConsoleKey.W:
            direction = new Point
            {
                x = -0,
                y = -hero.speed
            };
            break;
        case ConsoleKey.S:
            direction = new Point
            {
                x = 0,
                y = hero.speed
            };
            break;
        default:
            direction = new Point
            {
                x = 0,
                y = 0
            };
            break;
    }
    
    hero.x += direction.x;
    hero.y += direction.y;

    hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
    hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);

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
