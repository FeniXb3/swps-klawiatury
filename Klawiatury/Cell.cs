class Cell
{
    public char visual;
    private Character? occupant;

    public Cell(char visual)
    {
        this.visual = visual;
    }

    public bool IsOccupied()
    {
        return occupant != null;
    }

    public void Leave()
    {
        occupant = null;
    }

    internal void Occupy(Character character)
    {
        occupant = character;
    }
}