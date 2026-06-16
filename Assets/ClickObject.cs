using UnityEngine;

public class ClickObject : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Ai găsit o parte din cod: 12...");
        Destroy(gameObject);
    }
}