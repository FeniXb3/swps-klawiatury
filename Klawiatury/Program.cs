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
    int directionX;
    int directionY;
    switch (pressedKeyInfo.Key)
    {
        case ConsoleKey.A:
            directionX = -hero.speed;
            directionY = -0;

            hero.x += directionX;
            hero.y += directionY;
            break;
        case ConsoleKey.D:
            directionX = hero.speed;
            directionY = 0;

            hero.x += directionX;
            hero.y += directionY;
            break;
        case ConsoleKey.W:
            directionX = -0;
            directionY = -hero.speed;

            hero.x += directionX;
            hero.y += directionY;
            break;
        case ConsoleKey.S:
            directionX = 0;
            directionY = hero.speed;

            hero.x += directionX;
            hero.y += directionY;
            break;
    }

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
