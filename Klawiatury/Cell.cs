
class Cell
{
    public char Visual { get; }

    private Character? occupant;


    public Cell(char visual)
    {
        this.Visual = visual;
    }

    public bool IsOccupied()
    {
        return occupant != null;
    }

    public void Leave()
    {
        occupant = null;
    }

    public Character GetOccupant()
    {
        return occupant;
    }

    internal void Occupy(Character character)
    {
        occupant = character;
    }
}