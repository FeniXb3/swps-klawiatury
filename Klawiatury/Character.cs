abstract class Character
{
    public string name;
    public Point position;
    public int speed = 1;
    public string avatar;

    public Character(string name, string avatar)
    {
        this.name = name;
        this.avatar = avatar;
        position = new Point(0, 0);
    }

    public Character(string name, string avatar, Point position)
    {
        this.name = name;
        this.avatar = avatar;
        this.position = position;
    }

    public abstract string ChooseAction();

    public virtual void Move(Point direction, string[] level, List<Character> characters)
    {
        position = CalculateTargetPosition(direction, level, characters);
    }

    private Point CalculateTargetPosition(Point direction, string[] level, List<Character> characters)
    {
        Point target = position;

        int signY = Math.Sign(direction.y);
        int signX = Math.Sign(direction.x);

        for (int i = 1; i <= Math.Abs(direction.y * speed); i++)
        {
            int coordinateToTest = position.y + i * signY;
            bool isThereAnyone = false;
            foreach(Character character in characters)
            {
                if (character.position.x == target.x && character.position.y == coordinateToTest)
                {
                    isThereAnyone = true;
                    break;
                }
            }

            if (coordinateToTest >= level.Length || coordinateToTest < 0 || level[coordinateToTest][target.x] == '#' || isThereAnyone)
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

            bool isThereAnyone = false;
            foreach(Character character in characters)
            {
                if (character.position.x == coordinateToTest && character.position.y == target.y)
                {
                    isThereAnyone = true;
                    break;
                }
            }

            if (coordinateToTest >= level[target.y].Length || coordinateToTest < 0 || level[target.y][coordinateToTest] == '#' || isThereAnyone)
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
}