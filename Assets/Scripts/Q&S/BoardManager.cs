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

    public void MapGenerator()
    {
        mGenerator.Generator();
        mGenerator.BombsCounterTile();
        mGenerator.PrintBoard();

        UIboard = mGenerator.board;

        GenerateBoardUI();
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
        cellButton.interactable = false;

        if (UIboard[row, col].isBomb == true)
        {
            cellButton.image.color = Color.red;
            Debug.Log("Game Over");
        }
        else
        {
            cellButton.GetComponentInChildren<TextMeshProUGUI>().text = UIboard[row, col].bombsAround.ToString();
            uncoveredCells++;
            if (uncoveredCells == (rows * cols) - mines)
            {
                Debug.Log("You win!");
            }
        }
    }
}
