using UnityEngine;

public class Ship
{
    public int size;
    public int health;

    public Ship(int size)
    {
        this.size = size;
        this.health = size;
    }

    public void TakeHit()
    {
        health--;
    }

    public bool IsDestroyed()
    {
        return health <= 0;
    }
}