using TMPro;
using UnityEngine;

public class MorsePuzzleManager : MonoBehaviour
{
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;

    public SecretPassageMover secretPassageMover;

    public GameObject bookUI;
    public GameObject crosshair;

    public MonoBehaviour playerLookScript;
    public MonoBehaviour playerMoveScript;

    private bool solved = false;

    public void CheckSolution()
    {
        if (solved) return;

        string code1 = input1.text.Trim();
        string code2 = input2.text.Trim();
        string code3 = input3.text.Trim();

        if (code1 == "..." &&
              code2 == "..-." &&
              code3 == "--.")
        {
            solved = true;
            Debug.Log("CORRECT MORSE!");

            if (secretPassageMover != null)
                secretPassageMover.OpenSecretPassage();

            if (bookUI != null)
                bookUI.SetActive(false);

            if (crosshair != null)
                crosshair.SetActive(true);

            if (playerLookScript != null)
                playerLookScript.enabled = true;

            if (playerMoveScript != null)
                playerMoveScript.enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.Log("WRONG MORSE!");
        }
    }
}