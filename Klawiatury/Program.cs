﻿Console.CursorVisible = false;
Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPoint = new Point(1, 2);

Player hero = new Player("Snake", "@", startingPoint);
hero.speed = 1;
List<Player> clones = new List<Player>();
clones.Add(hero);

string[] level =
[
    "#########################################",
    "#.......................................#",
    "#.......................................#",
    "#...................#...................#",
    "#.......................................#",
    "#.......................................#",
    "#.......................................#",
    "#.......................................#",
    "#.......................................#",
    "#########################################",
];

foreach (string row in level)
{
    Console.WriteLine(row);
}

while (true)
{
    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        Console.Write(element.avatar);
    }
 
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        string row = level[element.position.y];
        char cellData = row[element.position.x];
        Console.Write(cellData);
    }

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        foreach (Player element in clones)
        {
            element.position.x += direction.x * element.speed;
            element.position.y += direction.y * element.speed;

            element.position.x = Math.Clamp(element.position .x, 0, Console.BufferWidth - 1);
            element.position.y = Math.Clamp(element.position.y, 0, Console.BufferHeight - 1);

            // element.speed += 1;
        }
    }
    else
    {
        switch (pressedKeyInfo.Key)
        {
            case ConsoleKey.C:
                Player clone = new Player(hero.name, "C", startingPoint);
                clones.Add(clone);
                break;
        }
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);
