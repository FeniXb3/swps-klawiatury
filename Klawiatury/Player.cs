
class Player : Character
{
    public Player(string name, string avatar) : base(name, avatar)
    {
    }

    public Player(string name, string avatar, Point position) : base(name, avatar, position)
    {
    }

    public override string ChooseAction(Dictionary<ConsoleKey, string> keyActionMap)
    {
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
        string chosenAction = keyActionMap.GetValueOrDefault(pressedKeyInfo.Key, "none");

        return chosenAction;
    }
}
