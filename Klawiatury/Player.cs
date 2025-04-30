
class Player : Character
{
    private Dictionary<ConsoleKey, string> keyBindings;
    public Player(string name, string avatar) : base(name, avatar)
    {
    }

    public Player(string name, string avatar, Point position, Dictionary<ConsoleKey, string> keyActionMap) : base(name, avatar, position)
    {
        keyBindings = keyActionMap;
    }

    public override string ChooseAction()
    {
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
        string chosenAction = keyBindings.GetValueOrDefault(pressedKeyInfo.Key, "none");

        return chosenAction;
    }
}
