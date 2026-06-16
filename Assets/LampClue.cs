using UnityEngine;

public class LampClue : MonoBehaviour
{
    public GameObject luminaLampa; 
    private bool aFostAprinsa = false;

    void OnMouseDown()
    {
        if (!aFostAprinsa)
        {
            string codSecret = ExitDoor.codAleator;
            if (string.IsNullOrEmpty(codSecret) || codSecret.Length < 4) return;

            char cifraMea = codSecret[2];
            Debug.Log(" Ai aprins lampa si ai gasit un indiciu pe bec! Indiciul este: __" + cifraMea + "_");

            if (luminaLampa != null)
            {
                luminaLampa.SetActive(true);
            }

            aFostAprinsa = true;
        }
    }
}