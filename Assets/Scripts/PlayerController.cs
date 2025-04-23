using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float maxX = 4.9f;
    [SerializeField] float minX = -4.9f;

    public Vector2 movingInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        movingInput = context.ReadValue<Vector2>();
    }

    public void Update()
    {
        Vector2 move = new Vector2(movingInput.x, 0) * speed * Time.deltaTime;
        move.x = Mathf.Clamp(move.x + transform.position.x, minX, maxX);
        transform.position = new Vector3(move.x, transform.position.y, transform.position.z);
    }
}