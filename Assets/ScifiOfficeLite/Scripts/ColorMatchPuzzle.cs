using UnityEngine;
using UnityEngine.UI;

public class ColorMatchPuzzle : MonoBehaviour, Interactable
{
    [Header("Target")]
    public Color targetColor = new Color(0.7f, 0.3f, 0.5f);
    [Range(0f, 1f)] public float tolerance = 0.1f;

    [Header("UI References")]
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Image targetSwatch;
    public Image currentSwatch;
    public GameObject feedbackText;

    [Header("Puzzle UI Panel")]
    public GameObject puzzleUI;
    private GameObject interactionPrompt;
    public bool isOpen = false;

    private bool solved = false;

    private void Awake()
    {
        interactionPrompt = GameObject.Find("PressF");
    }

    private void Start()
    {
        puzzleUI.SetActive(false);

        if (targetSwatch != null) targetSwatch.color = targetColor;

        if (redSlider != null) redSlider.onValueChanged.AddListener(_ => UpdateCurrentSwatch());
        if (greenSlider != null) greenSlider.onValueChanged.AddListener(_ => UpdateCurrentSwatch());
        if (blueSlider != null) blueSlider.onValueChanged.AddListener(_ => UpdateCurrentSwatch());

        UpdateCurrentSwatch();
    }

    public void Interact()
    {
        if (solved) return;

        isOpen = !isOpen;
        Interaction.isUIOpen = isOpen;

        puzzleUI.SetActive(isOpen);
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOpen;

        if (interactionPrompt != null)
            interactionPrompt.SetActive(!isOpen);

        if (feedbackText != null) feedbackText.SetActive(false);
    }

    void UpdateCurrentSwatch()
    {
        if (currentSwatch == null) return;
        currentSwatch.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
    }

    public void Submit()
    {
        Color current = new Color(redSlider.value, greenSlider.value, blueSlider.value);

        bool matches = Mathf.Abs(current.r - targetColor.r) <= tolerance &&
                       Mathf.Abs(current.g - targetColor.g) <= tolerance &&
                       Mathf.Abs(current.b - targetColor.b) <= tolerance;

        if (matches)
        {
            Debug.Log("Color match puzzle solved!");
            solved = true;
            isOpen = false;
            Interaction.isUIOpen = false;

            if (feedbackText != null) feedbackText.SetActive(false);

            GameManager.Instance.PuzzleSolved(2);

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
            Debug.Log("Color does not match - try again");
            if (feedbackText != null) feedbackText.SetActive(true);
        }
    }
}