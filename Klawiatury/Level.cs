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
                Console.Write(cell.visual);
            }
            Console.WriteLine();
        }
    }

    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        Cell[] row = levelData[position.y];
        char cellData = row[position.x].visual;
        Console.Write(cellData);
    }

    public int GetHeight()
    {
        return levelData.Length;
    }

    public char GetCellVisuals(int x, int y)
    {
        return GetCell(x, y).visual;
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
        return levelData[y][x];
    }

    public Cell GetCell(Point coordinates)
    {
        return GetCell(coordinates.x, coordinates.y);
    }

    public void OccupyCell(Point position, Character character)
    {
        Cell cell = GetCell(position);
        cell.occupant = character;
    }

    public bool IsCellOccupied(int x, int y)
    {
        return GetCell(x, y).occupant != null;
    }

    public void LeaveCell(Point position)
    {
        GetCell(position).occupant = null;
    }
}