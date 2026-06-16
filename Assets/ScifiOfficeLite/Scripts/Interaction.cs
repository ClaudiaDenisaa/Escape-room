using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static bool isUIOpen = false;

    [Header("Interaction Settings")]
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public Camera playerCamera;

    [Header("UI")]
    public GameObject interactionPrompt;

    private Interactable currentInteractable;

    void Update()
    {
        if (isUIOpen)
        {
            currentInteractable = null;
            if (interactionPrompt != null) interactionPrompt.SetActive(false);
            return;
        }

        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponentInParent<Interactable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                interactionPrompt.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        interactionPrompt.SetActive(false);
    }
}