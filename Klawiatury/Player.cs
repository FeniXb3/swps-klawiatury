
class Player : Character
{
    public string chosenAction;
    private Dictionary<ConsoleKey, string> keyBindings;

    public Player(string name, string avatar, Point position, Level level, Dictionary<ConsoleKey, string> keyActionMap) : base(name, avatar, position, level)
    {
        keyBindings = keyActionMap;
    }

    public override string ChooseAction()
    {
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
        chosenAction = keyBindings.GetValueOrDefault(pressedKeyInfo.Key, "none");

        return chosenAction;
    }

    public override void Move(Point direction, Level level, List<Character> characters)
    {
        base.Move(direction, level, characters);
        // speed += 1;
    }
}
