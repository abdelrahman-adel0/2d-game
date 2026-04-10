using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;

    public int gridSize = 10;

    public float cellSize = 1f; // adjust based on your board

    public Vector2 startPosition; // bottom-left of grid

    private Cell[,] grid;

    void GenerateGrid()
    {
        grid = new Cell[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector2 position = new Vector2(
                    startPosition.x + x * cellSize,
                    startPosition.y + y * cellSize
                );

                GameObject obj = Instantiate(cellPrefab, position, Quaternion.identity, transform);

                Cell cell = obj.GetComponent<Cell>();
                cell.Init(x, y);

                grid[x, y] = cell;
            }
        }
    }
    
    void Start()
    {
        GenerateGrid();
        PlaceShips();
    }
    
    void PlaceShips()
    {
        // Example: place 1 ship of size 3 horizontally

        Ship ship = new Ship(3);

        int startX = 2;
        int startY = 5;

        for (int i = 0; i < ship.size; i++)
        {
            grid[startX + i, startY].SetShip(ship);
        }
    }
}