using UnityEngine;

public class GreekBookInteraction : MonoBehaviour
{
    public float interactDistance = 6f;
    public GameObject greekBookUI;
    public GameObject crosshair;

    public MonoBehaviour playerLookScript;
    public MonoBehaviour playerMoveScript;

    private bool isBookOpen = false;

    void Update()
    {
        if (!isBookOpen && Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        if (isBookOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseBook();
        }
    }

    void TryInteract()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("GreekBook"))
            {
                OpenBook();
            }
        }
    }

    void OpenBook()
    {
        isBookOpen = true;

        if (greekBookUI != null)
            greekBookUI.SetActive(true);

        if (crosshair != null)
            crosshair.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerLookScript != null)
            playerLookScript.enabled = false;

        if (playerMoveScript != null)
            playerMoveScript.enabled = false;

        GreekBookManager manager = greekBookUI.GetComponent<GreekBookManager>();

        if (manager != null)
        {
            manager.OpenCoverPage();
        }
        else
        {
            Debug.LogError("GreekBookManager nu este pe GreekBookUI");
        }
    }

    void CloseBook()
    {
        isBookOpen = false;

        GreekBookManager manager = greekBookUI.GetComponent<GreekBookManager>();

        if (manager != null)
        {
            manager.CloseBook();
        }

        if (greekBookUI != null)
            greekBookUI.SetActive(false);

        if (crosshair != null)
            crosshair.SetActive(true);

        if (playerLookScript != null)
            playerLookScript.enabled = true;

        if (playerMoveScript != null)
            playerMoveScript.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}