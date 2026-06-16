using UnityEngine;
using TMPro;   // add this

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Puzzles")]
    public bool puzzle1Solved = false;
    public bool puzzle2Solved = false;
    public int totalPuzzles = 2;

    [Header("UI")]
    public TextMeshProUGUI puzzleCounterText;

    [Header("Final Door")]
    public GameObject finalDoor;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateCounterUI();
    }

    public void PuzzleSolved(int puzzleNumber)
    {
        switch (puzzleNumber)
        {
            case 1: puzzle1Solved = true; break;
            case 2: puzzle2Solved = true; break;
        }

        UpdateCounterUI();
        CheckAllPuzzles();
    }

    void UpdateCounterUI()
    {
        int solved = 0;
        if (puzzle1Solved) solved++;
        if (puzzle2Solved) solved++;

        if (puzzleCounterText != null)
            puzzleCounterText.text = solved + "/" + totalPuzzles + " Solved";
    }

    void CheckAllPuzzles()
    {
        if (puzzle1Solved && puzzle2Solved)
        {
            Debug.Log("Toate puzzle-urile rezolvate! Usa se deschide!");
            OpenFinalDoor();
        }
    }

    void OpenFinalDoor()
    {
        if (finalDoor != null)
            finalDoor.SetActive(false);
    }
}