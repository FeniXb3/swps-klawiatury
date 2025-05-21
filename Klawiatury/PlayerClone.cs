
class PlayerClone : Player
{
    Player prototype;
    List<string> allowedActions;

    public PlayerClone(string name, string avatar, Point position, Dictionary<ConsoleKey, string> keyActionMap, Player prototype) : base(name, avatar, position, keyActionMap)
    {
        this.prototype = prototype;
        allowedActions = new List<string>
        {
            "moveUp",
            "moveDown",
            "moveLeft",
            "moveRight",
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