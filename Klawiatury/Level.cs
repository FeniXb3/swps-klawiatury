class Level
{
    private string[] levelVisuals =
    [
        "#.############################################",
        "..............................................",
        "#...%...................................######",
        "#...................#...................###",
        "#.........................................#",
        "#.........................................#",
        "#.......................................###",
        "##......................................#",
        "#.......................................#",
        "#########################################",
    ];

    private Cell[][] levelData;

    public Level()
    {
        levelData = new Cell[levelVisuals.Length][];
        for (int y = 0; y < levelVisuals.Length; y++)
        {
            string row = levelVisuals[y];
            Cell[] dataRow = new Cell[row.Length];
            for (int i = 0; i < row.Length; i++)
            {
                dataRow[i] = new Cell(row[i]);
            }
            levelData[y] = dataRow;
        }
    }

    public void Display()
    {
        foreach (Cell[] row in levelData)
        {
            foreach (Cell cell in row)
            {
                Console.Write(cell.Visual);
            }
            Console.WriteLine();
        }
    }

    public void RedrawCell(Point position)
    {
        Cell cell = GetCell(position);
        if (cell.IsOccupied())
        {
            cell.GetOccupant().Display();
        }
        else
        {
            Console.SetCursorPosition(position.x, position.y);
            char cellData = cell.Visual;
            Console.Write(cellData);
        }
    }

    public int GetHeight()
    {
        return levelData.Length;
    }

    public char GetCellVisuals(int x, int y)
    {
        Cell cell = GetCell(x, y);
        return cell.Visual;
    }

    public int GetRowWidth(int rowIndex)
    {
        return levelData[rowIndex].Length;
    }
    
    public bool IsWalkable(int x, int y)
    {
        return y >= 0 && y < GetHeight() && x >= 0 && x < GetRowWidth(y) && GetCellVisuals(x, y) != '#';
    }

    public Cell GetCell(int x, int y)
    {
        bool isYCorrect = y >= 0 && y < GetHeight();
        if (!isYCorrect)
        {
            throw new ArgumentOutOfRangeException(nameof(y), y, "Invalid coordinates");
        }

        bool isXCorrect = x >= 0 && x < GetRowWidth(y);
        if (!isXCorrect)
        {
            throw new ArgumentOutOfRangeException(nameof(x), x, "Invalid coordinates");
        }

        return levelData[y][x];
    }

    public Cell GetCell(Point coordinates)
    {
        return GetCell(coordinates.x, coordinates.y);
    }

    public void OccupyCell(Point position, Character character)
    {
        Cell cell = GetCell(position);
        cell.Occupy(character);
    }

    public bool IsCellOccupied(int x, int y)
    {
        return GetCell(x, y).IsOccupied();
    }

    public void LeaveCell(Point position)
    {
        GetCell(position).Leave();
    }
}