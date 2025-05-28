
class NonPlayerCharacter : Character
{
    private string[] availableActions;
    
    public NonPlayerCharacter(string name, string avatar, Point position) : base(name, avatar, position)
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