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