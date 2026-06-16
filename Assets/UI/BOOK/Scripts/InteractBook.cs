using UnityEngine;

public class InteractBook : MonoBehaviour
{
    public float interactDistance = 6f;
    public GameObject bookUI;
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
            if (hit.collider.CompareTag("Book"))
            {
                OpenBook();
            }
        }
    }

    void OpenBook()
    {
        isBookOpen = true;

        if (bookUI != null)
            bookUI.SetActive(true);

        if (crosshair != null)
            crosshair.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerLookScript != null)
            playerLookScript.enabled = false;

        if (playerMoveScript != null)
            playerMoveScript.enabled = false;

        BookManager manager = bookUI.GetComponent<BookManager>();

        if (manager != null)
        {
            manager.OpenCoverPage();
        }
        else
        {
            Debug.LogError("BookManager nu este pe BookUI");
        }
    }

    void CloseBook()
    {
        isBookOpen = false;

        BookManager manager = bookUI.GetComponent<BookManager>();

        if (manager != null)
        {
            manager.CloseBook();
        }

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
}