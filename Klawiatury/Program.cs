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
Level firstLevel = new Level(@"C:\projekty\SWPS\Semestr 2\Dzienne 1\Klawiatury\Klawiatury\firstLevel.txt");
Level secondLevel = new Level(@"C:\projekty\SWPS\Semestr 2\Dzienne 1\Klawiatury\Klawiatury\secondLevel.txt");

Level currentLevel = firstLevel;
Player hero = new Player("Snake", "@", startingPoint, currentLevel, keyActionMap);
hero.speed = 1;
characters.Add(hero);

for (int i = 0; i < 10; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L", new Point(25 - i, 2), currentLevel);
    characters.Add(npc);
}

currentLevel.Display();

bool isPlaying = true;

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
            currentLevel.RedrawCell(element.position);
            continue;
        }

        string chosenAction = element.ChooseAction();
        if (directionsMap.ContainsKey(chosenAction))
        {
            Point direction = directionsMap[chosenAction];
            element.Move(direction);

            if (currentLevel.GetCellVisuals(element.position.x, element.position.y) == '%')
            {
                currentLevel = secondLevel;
                Console.Clear();
                currentLevel.Display();
            }

            currentLevel.RedrawCell(element.previousPosition);
            element.Display();
        }
        else
        {
            switch (chosenAction)
            {
                case "clone":
                    PlayerClone clone = new PlayerClone(hero.name, "C", startingPoint, currentLevel, keyActionMap, hero);
                    characters.Add(clone);
                    clone.Display();
                    break;
                case "quitGame":
                    isPlaying = false;
                    break;
                case "attack":
                    element.Attack();
                    break;
            }
        }
    }
}

Console.SetCursorPosition(0, currentLevel.GetHeight());
Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);

