using UnityEngine;

public class FixPainting : MonoBehaviour
{
    public GameObject keyObject; 
    private bool isFixed = false;

    void OnMouseDown()
    {
        if (!isFixed)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); 

            if (keyObject != null)
            {
                Rigidbody rb = keyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }

            Debug.Log("Ai indreptat tabloul si a cazut o cheie!");
            isFixed = true;
        }
    }
}