using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x;
    public int y;

    public bool hasShip = false;
    public bool isHit = false;

    public Ship ship; // reference to ship

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Init(int xPos, int yPos)
    {
        x = xPos;
        y = yPos;
    }

    public void SetShip(Ship s)
    {
        ship = s;
        hasShip = true;

        // TEMP: visualize ship
        sr.color = new Color(0, 0, 1, 0.4f); // blue
    }

    void OnMouseDown()
    {
        if (isHit) return;

        isHit = true;

        if (hasShip)
        {
            Debug.Log("HIT!");

            ship.TakeHit();
            sr.color = Color.red;

            if (ship.IsDestroyed())
            {
                Debug.Log("SHIP DESTROYED!");
            }
        }
        else
        {
            Debug.Log("MISS!");
            sr.color = Color.white;
        }
    }
}