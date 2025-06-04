abstract class Character
{
    public string name;
    public Point position;
    public Point previousPosition;
    public int speed = 1;
    public string avatar;
    public bool isAlive = true;
    public Cell? cell;
    private Level level;

    public Character(string name, string avatar, Point position, Level level)
    {
        this.name = name;
        this.avatar = avatar;
        this.position = position;
        this.previousPosition = position;
        this.level = level;
        this.level.OccupyCell(position, this);
        this.cell = this.level.GetCell(position);
    }

    public abstract string ChooseAction();

    public virtual void Move(Point direction)
    {
        previousPosition = position;
        position = CalculateTargetPosition(direction);

        level.LeaveCell(previousPosition);
        level.OccupyCell(position, this);
        cell = level.GetCell(position);
    }

    private Point CalculateTargetPosition(Point direction)
    {
        Point target = position;

        int signY = Math.Sign(direction.y);
        int signX = Math.Sign(direction.x);

        for (int i = 1; i <= Math.Abs(direction.y * speed); i++)
        {
            int coordinateToTest = position.y + i * signY;

            if (!level.IsWalkable(target.x, coordinateToTest) || level.IsCellOccupied(target.x, coordinateToTest))
            {
                break;
            }
            else
            {
                target.y = coordinateToTest;
            }
        }

        for (int i = 1; i <= Math.Abs(direction.x * speed); i++)
        {
            int coordinateToTest = position.x + i * signX;

            if (!level.IsWalkable(coordinateToTest, target.y) || level.IsCellOccupied(coordinateToTest, target.y))
            {
                break;
            }
            else
            {
                target.x = coordinateToTest;
            }
        }

        return target;
    }

    /// <summary>
    /// Displays avatar on console.
    /// </summary>
    public void Display()
    {
        Console.SetCursorPosition(position.x, position.y);
        Console.Write(avatar);
    }

    internal void Kill()
    {
        isAlive = false;
        cell.Leave();
        cell = null;
    }

    internal void Attack()
    {
        // Choosing attack target:
        // 1. Scan surroundings to get all occupied cells
        //  a. left/right/top/bottom
        //  b. a + diagonals
        // 2. Let character choose target
        // 3. Attack chosen target 
        List<Point> attackDirections = new List<Point>
        {
            new Point(-1, 0),
            new Point(1, 0),
            new Point(0, -1),
            new Point(0, 1),
        };

        foreach (Point direction in attackDirections)
        {
            Point coordinatesToCheck = new Point(position.x + direction.x, position.y + direction.y);
            try
            {
                Cell cellToCheck = level.GetCell(coordinatesToCheck);
                if (cellToCheck.IsOccupied())
                {
                    Character other = cellToCheck.GetOccupant();
                    other.Kill();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.SetCursorPosition(0, level.GetHeight());
                Console.WriteLine($"{ex.ParamName} has incorrect value: {ex.ActualValue}");
            }
        }
    }
}