
class NonPlayerCharacter : Character
{
    public NonPlayerCharacter(string name, string avatar) : base(name, avatar)
    {
    }

    public NonPlayerCharacter(string name, string avatar, Point position) : base(name, avatar, position)
    {
    }

    public override string ChooseAction(Dictionary<ConsoleKey, string> keyActionMap)
    {
        return "moveLeft";
    }
}