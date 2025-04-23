Console.CursorVisible = false;
Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPoint = new Point(1, 0);

Player hero = new Player("Snake", "@", startingPoint);
hero.speed = 1;
List<Player> clones = new List<Player>();
clones.Add(hero);

string[] level =
[
    "#.############################################",
    "#............................................#",
    "#.......................................######",
    "#...................#...................###",
    "#.........................................#",
    "#.........................................#",
    "#.......................................###",
    "##......................................#",
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
        element.Display();
    }

    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    foreach (Player element in clones)
    {
        RedrawCell(element.position, level);
    }

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        foreach (Player element in clones)
        {
            element.Move(direction, level);
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

void RedrawCell(Point position, string[] level)
{
    Console.SetCursorPosition(position.x, position.y);
    string row = level[position.y];
    char cellData = row[position.x];
    Console.Write(cellData);
}