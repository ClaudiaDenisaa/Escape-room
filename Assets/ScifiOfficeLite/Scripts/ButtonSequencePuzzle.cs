using UnityEngine;
using UnityEngine.UI;

public class ButtonSequencePuzzle : MonoBehaviour, Interactable
{
    [Header("Sequence Settings")]
    public int[] correctSequence = { 0, 2, 1, 3 };
    private int[] playerSequence;
    private int currentStep = 0;

    [Header("Buttons")]
    public Button[] buttons;

    [Header("UI")]
    public GameObject puzzleUI;
    public GameObject feedbackText;
    private GameObject interactionPrompt;
    public bool isOpen = false;

    private bool solved = false;

    private void Awake()
    {
        interactionPrompt = GameObject.Find("PressF");
        Debug.Log("Awake - Gasit: " + (interactionPrompt != null));
        playerSequence = new int[correctSequence.Length];
    }

    private void Start()
    {
        puzzleUI.SetActive(false);
    }

    public void Interact()
    {
        if (solved) return;

        isOpen = !isOpen;
        Interaction.isUIOpen = isOpen;

        Debug.Log("Interact called! isOpen = " + isOpen);

        puzzleUI.SetActive(isOpen);
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOpen;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(!isOpen);

        if (feedbackText != null) feedbackText.SetActive(false);
    }

    public void PressButton0() { PressButton(0); }
    public void PressButton1() { PressButton(1); }
    public void PressButton2() { PressButton(2); }
    public void PressButton3() { PressButton(3); }

    void PressButton(int buttonIndex)
    {
        if (currentStep >= correctSequence.Length) return;

        if (feedbackText != null) feedbackText.SetActive(false);

        playerSequence[currentStep] = buttonIndex;
        currentStep++;
        if (currentStep >= correctSequence.Length)
            CheckSequence();
    }

    void CheckSequence()
    {
        bool correct = true;
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            Debug.Log("Puzzle 1 rezolvat!");
            solved = true;
            isOpen = false;
            Interaction.isUIOpen = false;

            if (feedbackText != null) feedbackText.SetActive(false);

            GameManager.Instance.PuzzleSolved(1);

            puzzleUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            int defaultLayer = LayerMask.NameToLayer("Default");
            gameObject.layer = defaultLayer;
            foreach (Transform t in GetComponentsInChildren<Transform>(true))
                t.gameObject.layer = defaultLayer;
        }
        else
        {
            Debug.Log("Secventa gresita!");
            if (feedbackText != null) feedbackText.SetActive(true);
            ResetSequence();
        }
    }

    void ResetSequence()
    {
        currentStep = 0;
        playerSequence = new int[correctSequence.Length];
    }
}