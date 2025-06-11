
class Cell
{
    public char Visual { get; }

    public Character? Occupant { get; private set; }

    private Point position;


    public Cell(char visual, int x, int y)
    {
        this.Visual = visual;
        position = new Point(x, y);
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

    internal void Display()
    {
        if (IsOccupied())
        {
            Occupant?.Display();
        }
        else
        {
            Console.SetCursorPosition(position.x, position.y);
            char cellData = Visual;
            Console.Write(cellData);
        }
    }
}