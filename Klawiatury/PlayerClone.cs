
class PlayerClone : Player
{
    Player prototype;
    List<string> allowedActions;

    public PlayerClone(string name, string avatar, Point position, Level level, Dictionary<ConsoleKey, string> keyActionMap, Player prototype) : base(name, avatar, position, level, keyActionMap)
    {
        this.prototype = prototype;
        allowedActions = new List<string>
        {
            "moveUp",
            "moveDown",
            "moveLeft",
            "moveRight",
            "attack",
        };
    }

    public override string ChooseAction()
    {
        string chosenAction;
        if (allowedActions.Contains(prototype.chosenAction))
        {
            chosenAction = prototype.chosenAction;
        }
        else
        {
            chosenAction = "none";
        }
        
        return chosenAction;
    }
}