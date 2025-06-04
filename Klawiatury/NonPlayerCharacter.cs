
class NonPlayerCharacter : Character
{
    private string[] availableActions;
    
    public NonPlayerCharacter(string name, string avatar, Point position, Level level) : base(name, avatar, position, level)
    {
        availableActions = 
        [
            "moveLeft",
            "moveRight",
            "moveUp",
            "moveDown",
            "attack",
        ];
    }

    public override string ChooseAction()
    {
        int actionIndex = Random.Shared.Next(availableActions.Length);
        return availableActions[actionIndex];
    }
}