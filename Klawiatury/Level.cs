class Level
{
    private string[] levelData =
    [
        "#.############################################",
        "#............................................#",
        "#.......................................######",
        "#...................#...................###",
        "#.........................................#",
        "#.........................................#",
        "#.......................................###",
        "##......................................#",
        "#.......................................#",
        "#########################################",
    ];

    public void Display()
    {
        foreach (string row in levelData)
        {
            Console.WriteLine(row);
        }
    }

    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        string row = levelData[position.y];
        char cellData = row[position.x];
        Console.Write(cellData);
    }

    public int GetHeight()
    {
        return levelData.Length;
    }

    public char GetCell(int x, int y)
    {
        return levelData[y][x];
    }

    public int GetRowWidth(int rowIndex)
    {
        return levelData[rowIndex].Length;
    }
}