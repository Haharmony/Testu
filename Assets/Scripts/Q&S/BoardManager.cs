using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    const int rows = 10;
    const int cols = 10;
    public int mines = 20;
    public Button cellButtonPrefab;
    MapGenerator mGenerator = new MapGenerator();
    public Tile[,] UIboard = new Tile[rows, cols];
    private int uncoveredCells = 0;
    private int flagsLeft = 20;
    Queue<Tile> m_queue = new Queue<Tile>();

    public void MapGenerator()
    {
        mGenerator.Generator();
        mGenerator.BombsCounterTile();
        mGenerator.PrintBoard();

        UIboard = mGenerator.board;

        GenerateBoardUI();
    }

    public void CheckQueueCountButton()
    {
        Debug.Log(m_queue.Count);
    }

    private void GenerateBoardUI()
    {
        GridLayoutGroup gridLayout = GetComponent<GridLayoutGroup>();
        gridLayout.constraintCount = cols;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int x = i;
                int y = j;
                Button cellButton = Instantiate(cellButtonPrefab, transform);
                cellButton.onClick.AddListener(() => OnCellButtonClick(x, y));

            }
        }
    }

    private void OnCellButtonClick(int row, int col)
    {
        Debug.Log(row + ", " + col);
        Button cellButton = transform.GetChild(row * cols + col).GetComponent<Button>();
        

        if (UIboard[row, col].isBomb == true && cellButton.interactable == true)
        {
            cellButton.interactable = false;
            cellButton.image.color = Color.red;
            Debug.Log("Game Over");
        }
        else if (UIboard[row, col].bombsAround == 0 && cellButton.interactable == true)
        {
            cellButton.interactable = false;
            QueueLogic(row, col);
        }
        else if(cellButton.interactable == true)
        {
            cellButton.interactable = false;
            cellButton.GetComponentInChildren<TextMeshProUGUI>().text = UIboard[row, col].bombsAround.ToString();
            uncoveredCells++;
            if (uncoveredCells == (rows * cols) - mines)
            {
                Debug.Log("You win!");
            }
        }
    }

    private void QueueLogic(int row, int col)
    {

        m_queue.Enqueue(UIboard[row, col]);

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i < 0) continue;
                if (i >= rows) continue;
                if (j < 0) continue;
                if (j >= cols) continue;
                if (UIboard[i, j].isBomb == true) continue;

                OnCellButtonClick(i, j);
            }
        }
    }
}
