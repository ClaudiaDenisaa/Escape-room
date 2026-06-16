using UnityEngine;

public class CluePaper : MonoBehaviour
{
    [Header("Setari Indiciu")]
    [Tooltip("0 pentru prima cifra, 1 pentru a doua, 2 pentru a treia, 3 pentru a patra")]
    public int pozitieCifra = 0;

    void OnMouseDown()
    {
        string codSecret = ExitDoor.codAleator;

        if (string.IsNullOrEmpty(codSecret) || codSecret.Length < 4)
        {
            Debug.Log("Ai gasit un bilet, dar usa nu a generat inca un cod!");
            return;
        }

        char cifraMea = codSecret[pozitieCifra];

        string indiciuVizual = "";
        for (int i = 0; i < 4; i++)
        {
            if (i == pozitieCifra)
                indiciuVizual += cifraMea;
            else
                indiciuVizual += "_";
        }

        Debug.Log("? Ai gasit un bilet ascuns! Indiciul este: " + indiciuVizual);

        Destroy(gameObject);
    }
}