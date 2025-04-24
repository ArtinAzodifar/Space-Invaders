using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxX = 4.9f;
    [SerializeField] private float minX = -4.9f;
    public int health = 3;

    public Vector2 movingInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        movingInput = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Manager manager = Manager.getInstance();
        if (context.performed)
        {
            if (!manager.getIsPlayerLaserActive())
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.1f, 0);
                Instantiate(laser, position, transform.rotation);
                manager.setPlayerLaserActive(true);
            }
        }
    }

    public void Update()
    {
        Vector2 move = new Vector2(movingInput.x, 0) * speed * Time.deltaTime;
        move.x = Mathf.Clamp(move.x + transform.position.x, minX, maxX);
        transform.position = new Vector3(move.x, transform.position.y, transform.position.z);
    }
}