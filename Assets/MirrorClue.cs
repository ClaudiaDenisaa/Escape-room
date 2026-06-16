using UnityEngine;

public class MirrorClue : MonoBehaviour
{
    private bool esteIndreptata = false;

    void OnMouseDown()
    {
        if (!esteIndreptata)
        {
            string codSecret = ExitDoor.codAleator;
            if (string.IsNullOrEmpty(codSecret) || codSecret.Length < 4) return;

            char cifraMea = codSecret[3];
            Debug.Log(" Ai indreptat oglinda si in spatele ei era scris: ___" + cifraMea);

           
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

            esteIndreptata = true;
        }
    }
}