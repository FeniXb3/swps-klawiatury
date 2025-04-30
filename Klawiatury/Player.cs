class Player
{
    public string name;
    public Point position;
    public int speed = 1;
    public string avatar;

    public Player(string name, string avatar)
    {
        this.name = name;
        this.avatar = avatar;
        position = new Point(0, 0);
    }

    public Player(string name, string avatar, Point position)
    {
        this.name = name;
        this.avatar = avatar;
        this.position = position;
    }

    public string ChooseAction(Dictionary<ConsoleKey, string> keyActionMap)
    {
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
        string chosenAction = keyActionMap.GetValueOrDefault(pressedKeyInfo.Key, "none");

        return chosenAction;
    }

    public void Move(Point direction, string[] level)
    {
        position = CalculateTargetPosition(direction, level);
        speed += 1;
    }

    private Point CalculateTargetPosition(Point direction, string[] level)
    {
        Point target = position;

        int signY = Math.Sign(direction.y);
        int signX = Math.Sign(direction.x);

        for (int i = 1; i <= Math.Abs(direction.y * speed); i++)
        {
            int coordinateToTest = position.y + i * signY;
            if (coordinateToTest >= level.Length || coordinateToTest < 0 || level[coordinateToTest][target.x] == '#')
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
            if (coordinateToTest >= level[target.y].Length || coordinateToTest < 0 || level[target.y][coordinateToTest] == '#')
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

/*
Player:
- dane:
    - name
    - hp
    - maxhp
    - stamina
    - maxstamina
    - attackStrength
    - currentWeapon
    - inventory
    - position
    - speed
- akcje:
    - takeDamage
    - heal
    - levelUp
    - attack
    - die
    - move
*/