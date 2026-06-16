using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public static bool hasKey = false;

    void OnMouseDown()
    {
        hasKey = true;
        Debug.Log("Ai luat cheia!");
        Destroy(gameObject); 
    }
}