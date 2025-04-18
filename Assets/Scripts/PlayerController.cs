using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public Vector2 movingInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        movingInput = context.ReadValue<Vector2>();
    }
    
    public void Update()
    {
        Vector2 move = new Vector2(movingInput.x, 0) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}