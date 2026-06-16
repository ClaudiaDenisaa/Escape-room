using UnityEngine;
using System.Collections;
using TMPro;

public class ExitDoor : MonoBehaviour
{
    public TMP_InputField inputField;
    public string correctCode = "1234";

    [Header("Referinta Ecran Final")]
    public GameObject panouEvadareUI;

    public static string codAleator = "";

    void Awake()
    {
        int numarAsAscuns = Random.Range(1000, 9999);
        codAleator = numarAsAscuns.ToString();

        //Debug.Log("[Ajutor pentru debug] Codul generat pentru aceasta runda este: " + codAleator);
    }

    public void VerificaCodul()
    {
        bool areCheia = PickUpKey.hasKey;
        bool areCodulCorect = (inputField != null && inputField.text == codAleator);

        if (areCheia && areCodulCorect)
        {
            Debug.Log("USA S-A DESCHIS! AI EVADAT!");
            StartCoroutine(SecventaFinalJoc());
            return;
        }

        if (!areCheia && areCodulCorect)
        {
            Debug.Log("Codul este corect, dar ai nevoie si de cheie pentru a descuia usa! Cauta cheia prin camera.");
            if (inputField != null) inputField.text = "";
            return;
        }

        if (areCheia && !areCodulCorect)
        {
            Debug.Log("Cheia se potriveste in yala, dar codul introdus este incorect sau lipseste! Ai nevoie de codul din 4 cifre.");
            if (inputField != null) inputField.text = "";
            return;
        }

        if (!areCheia && !areCodulCorect)
        {
            Debug.Log("Usa este incuiata! Trebuie sa gasesti cheia si sa introduci codul corect.");
            if (inputField != null) inputField.text = "";
            return;
        }
    }

    IEnumerator SecventaFinalJoc()
    {
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        if (GetComponent<Collider>() != null)
        {
            GetComponent<Collider>().enabled = false;
        }

        yield return new WaitForSeconds(1f);

        if (panouEvadareUI != null)
        {
            panouEvadareUI.SetActive(true);
        }
    }
}