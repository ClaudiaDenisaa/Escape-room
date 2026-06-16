using System.Collections;
using UnityEngine;

public class SecretPassageMover : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.left;
    public float moveDistance = 3f;
    public float moveDuration = 2f;

    private bool opened = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + moveDirection.normalized * moveDistance;
    }

    public void OpenSecretPassage()
    {
        if (opened) return;

        opened = true;
        StartCoroutine(MovePassage());
    }   

    IEnumerator MovePassage()
    {
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            t = t * t * (3f - 2f * t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}