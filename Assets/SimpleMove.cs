using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    private CharacterController controller;
    private float rotationX = 0f;
    private float speed = 5f;
    private float gravity = 9.81f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDirection -= transform.right;
        if (Input.GetKey(KeyCode.D)) moveDirection += transform.right;

        moveDirection.y = 0;
        moveDirection = moveDirection.normalized * speed;

        moveDirection.y -= gravity;

        if (controller != null)
        {
            controller.Move(moveDirection * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * 2f;
            float mouseY = Input.GetAxis("Mouse Y") * 2f;

            transform.Rotate(0, mouseX, 0);

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -60f, 60f); 

            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
        }
    }
}