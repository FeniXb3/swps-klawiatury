Console.CursorVisible = false;

Dictionary<ConsoleKey, string> keyActionMap = new Dictionary<ConsoleKey, string>();
keyActionMap.Add(ConsoleKey.A, "moveLeft");
keyActionMap.Add(ConsoleKey.D, "moveRight");
keyActionMap.Add(ConsoleKey.W, "moveUp");
keyActionMap.Add(ConsoleKey.S, "moveDown");
keyActionMap.Add(ConsoleKey.C, "clone");
keyActionMap.Add(ConsoleKey.Escape, "quitGame");
keyActionMap.Add(ConsoleKey.Q, "attack");


Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

Point startingPoint = new Point(1, 0);

List<Character> characters = new List<Character>();
Level firstLevel = new Level();

Player hero = new Player("Snake", "@", startingPoint, firstLevel, keyActionMap);
hero.speed = 1;
characters.Add(hero);

for (int i = 0; i < 10; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L", new Point(25 - i, 8), firstLevel);
    characters.Add(npc);
}

firstLevel.Display();

bool isPlaying = true;

foreach (Character element in characters)
{
    element.Display();
}

while (isPlaying)
{
    // We're saving last characters count before the loop
    // so that the new clone will not perform it's action
    // untill next turn.
    int charactersCount = characters.Count;
    for (int i = 0; i < charactersCount; i++)
    {
        Character element = characters[i];

        if (!element.isAlive)
        {
            firstLevel.RedrawCell(element.position);
            continue;
        }

        string chosenAction = element.ChooseAction();
        if (directionsMap.ContainsKey(chosenAction))
        {
            Point direction = directionsMap[chosenAction];
            element.Move(direction, firstLevel, characters);

            firstLevel.RedrawCell(element.previousPosition);
            element.Display();
        }
        else
        {
            switch (chosenAction)
            {
                case "clone":
                    PlayerClone clone = new PlayerClone(hero.name, "C", startingPoint, firstLevel, keyActionMap, hero);
                    characters.Add(clone);
                    clone.Display();
                    break;
                case "quitGame":
                    isPlaying = false;
                    break;
                case "attack":
                    // Choosing attack target:
                    // 1. Scan surroundings to get all occupied cells
                    //  a. left/right/top/bottom
                    //  b. a + diagonals
                    // 2. Let character choose target
                    // 3. Attack chosen target 
                    List<Point> attackDirections = new List<Point>
                    {
                        new Point(-1, 0),
                        new Point(1, 0),
                        new Point(0, -1),
                        new Point(0, 1),
                    };

                    foreach (Point direction in attackDirections)
                    {
                        Point coordinatesToCheck = new Point(element.position.x + direction.x, element.position.y + direction.y);
                        try
                        {
                            Cell cellToCheck = firstLevel.GetCell(coordinatesToCheck);
                            if (cellToCheck.IsOccupied())
                            {
                                Character other = cellToCheck.GetOccupant();
                                other.Kill();
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.SetCursorPosition(0, firstLevel.GetHeight());
                            Console.WriteLine($"{ex.ParamName} has incorrect value: {ex.ActualValue}");
                        }
                    }
                    
                    break;
            }
        }
    }
}

Console.SetCursorPosition(0, firstLevel.GetHeight());
Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);

