Console.CursorVisible = false;
Player hero = new Player("Snake");
hero.x = 1;
hero.y = 2;
hero.speed = 3;
Console.WriteLine($"({hero.x}, {hero.y})");


Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-hero.speed, -0));
directionsMap.Add(ConsoleKey.D, new Point(hero.speed, 0));
directionsMap.Add(ConsoleKey.W, new Point(-0, -hero.speed));
directionsMap.Add(ConsoleKey.S, new Point(0, hero.speed));

while (true)
{
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        hero.x += direction.x;
        hero.y += direction.y;

        hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
        hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);
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
