class Player
{
    public string name;
    public int x;
    public int y;
    public int speed = 1;

    public Player(string name)
    {
        this.name = name;
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