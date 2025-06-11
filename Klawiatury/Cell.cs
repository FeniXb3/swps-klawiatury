
class Cell
{
    public char Visual { get; }

    public Character? Occupant { get; private set; }


    public Cell(char visual)
    {
        this.Visual = visual;
    }

    public bool IsOccupied()
    {
        return Occupant != null;
    }

    public void Leave()
    {
        Occupant = null;
    }

    internal void Occupy(Character character)
    {
        ArgumentNullException.ThrowIfNull(character);

        Occupant = character;
    }
}