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

    public void Move(Point direction, string[] level)
    {
        int targetX = position.x;
        int targetY = position.y;

        int signY = Math.Sign(direction.y);
        int signX = Math.Sign(direction.x);

        for (int i = 1; i <= Math.Abs(direction.y * speed); i++)
        {
            int coordinateToTest = position.y + i * signY;
            if (coordinateToTest >= level.Length || coordinateToTest < 0 || level[coordinateToTest][targetX] == '#')
            {
                break;
            }
            else
            {
                targetY = coordinateToTest;
            }
        }

        for (int i = 1; i <= Math.Abs(direction.x * speed); i++)
        {
            int coordinateToTest = position.x + i * signX;
            if (coordinateToTest >= level[targetY].Length || coordinateToTest < 0 || level[targetY][coordinateToTest] == '#')
            {
                break;
            }
            else
            {
                targetX = coordinateToTest;
            }
        }

        position.x = targetX;
        position.y = targetY;

        speed += 1;
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