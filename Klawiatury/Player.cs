class Player
{
    public string name;
    public Point position;
    public int speed = 1;

    public Player(string name)
    {
        this.name = name;
        position = new Point(0, 0);
    }

    public Player(string name, Point position)
    {
        this.name = name;
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