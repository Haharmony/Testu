using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    const int rows = 10;
    const int cols = 10;
    private int mines;
    public Button cellButtonPrefab;
    MapGenerator mGenerator = new MapGenerator();
    public Tile[,] UIboard = new Tile[rows, cols];
    private int uncoveredCells = 0;
    private int flagsLeft = 20;
    Queue<Tile> m_queue = new Queue<Tile>();
    public TextMeshProUGUI flagsLeftText;
    public GameObject menuPanel;
    public GameObject lostPanel;
    public GameObject winPanel;


    public void hardBoard()
    {
        mines = 30;
        flagsLeft = mines;
        mGenerator.bombsNumber = mines;
        mGenerator.Generator();
        mGenerator.BombsCounterTile();
        mGenerator.PrintBoard();
        UpdateMineCountText();
        UIboard = mGenerator.board;
        menuPanel.SetActive(false);
        GenerateBoardUI();
    }

    public void MediumBoard()
    {
        mines = 20;
        flagsLeft = mines;
        mGenerator.bombsNumber = mines;
        mGenerator.Generator();
        mGenerator.BombsCounterTile();
        mGenerator.PrintBoard();
        UpdateMineCountText();
        UIboard = mGenerator.board;
        menuPanel.SetActive(false);
        GenerateBoardUI();
    }

    public void EasyBoard()
    {
        mines = 10;
        flagsLeft = mines;
        mGenerator.bombsNumber = mines;
        mGenerator.Generator();
        mGenerator.BombsCounterTile();
        mGenerator.PrintBoard();
        UpdateMineCountText();
        UIboard = mGenerator.board;
        menuPanel.SetActive(false);
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
                cellButton.onClick.AddListener(() => GoThroughQueue());
                cellButton.GetComponent<MouseButtons>().onRightClick.AddListener(() => OnCellRightClick(x, y));
            }
        }
    }

    public void FlagFunction(int row, int col)
    {
        UIboard[row, col].isFlagged = true;
    }

    private void OnCellButtonClick(int row, int col)
    {
        Debug.Log(row + ", " + col);
        Button cellButton = transform.GetChild(row * cols + col).GetComponent<Button>();
        

        if (UIboard[row, col].isBomb == true && cellButton.interactable == true && UIboard[row, col].isFlagged == false)
        {
            cellButton.interactable = false;
            cellButton.image.color = Color.red;
            Debug.Log("Game Over");
            lostPanel.SetActive(true);

        }
        else if (UIboard[row, col].bombsAround == 0 && cellButton.interactable == true && UIboard[row, col].isFlagged == false)
        {
            uncoveredCells++;
            cellButton.interactable = false;
            QueueLogic(row, col);
        }
        else if(cellButton.interactable == true && UIboard[row, col].isFlagged == false)
        {
            cellButton.interactable = false;
            cellButton.GetComponentInChildren<TextMeshProUGUI>().text = UIboard[row, col].bombsAround.ToString();
            uncoveredCells++;
            if (uncoveredCells == (rows * cols) - mines)
            {
                Debug.Log("You win!");
                winPanel.SetActive(true);
            }
        }
    }

    private void OnCellRightClick(int row, int col)
    {
        Button cellButton = transform.GetChild(row * cols + col).GetComponent<Button>();

        if (cellButton.interactable)
        {
            // Toggle flag
            if (cellButton.GetComponentInChildren<TextMeshProUGUI>().text == "F")
            {
                cellButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
                flagsLeft++;
                UIboard[row, col].isFlagged = false;
            }
            else
            {
                cellButton.GetComponentInChildren<TextMeshProUGUI>().text = "F";
                flagsLeft--;
                UIboard[row, col].isFlagged = true;
            }
            UpdateMineCountText();
        }
    }

    private void QueueLogic(int row, int col)
    {

        //m_queue.Enqueue(UIboard[row, col]);

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i < 0) continue;
                if (i >= rows) continue;
                if (j < 0) continue;
                if (j >= cols) continue;
                if (UIboard[i, j].isBomb == true) continue;
                if (UIboard[i, j].isFlagged == true) continue;
                if (m_queue.Contains(UIboard[i, j])) continue;


                //OnCellButtonClick(i, j);
                m_queue.Enqueue(UIboard[i, j]);
            }
        }
    }

    void GoThroughQueue()
    {
        while (m_queue.Count > 0)
        {
            Tile temp = m_queue.Dequeue();
            OnCellButtonClick(temp.x, temp.y);
        }
    }

    private void UpdateMineCountText()
    {
        flagsLeftText.text = "Flags: " + flagsLeft.ToString();
    }
}
