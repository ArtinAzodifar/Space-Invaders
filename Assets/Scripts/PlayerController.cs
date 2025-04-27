using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxX = 4.9f;
    [SerializeField] private float minX = -4.9f;
    private int health = 3;
    private bool isDead = false;
    private Manager manager = Manager.getInstance();

    private Vector2 movingInput;

    public void Awake()
    {
        manager.setScore(0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movingInput = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //faghat vaghti tiri nabashe mitoone shelik kone
            if (!manager.getIsPlayerLaserActive())
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.1f, 0);
                Instantiate(laser, position, transform.rotation);
                manager.setPlayerLaserActive(true);
            }
        }
    }

    private void Update()
    {
        if (health <= 0 && !isDead)
        {
            Explode();
            isDead = true;
        }
        Vector2 move = new Vector2(movingInput.x, 0) * speed * Time.deltaTime;
        move.x = Mathf.Clamp(move.x + transform.position.x, minX, maxX);
        transform.position = new Vector3(move.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("invaderLaser"))
        {
            Damage();

            Debug.Log(health);
        }
        if (other.CompareTag("invader1") || other.CompareTag("invader2") || other.CompareTag("invader3"))
        {
            health = 0;
        }
    }

    private void Damage()
    {
        switch (health) // object motenazer ba joono miterekoone
        {
            case 3:
                hearts[2].GetComponent<Heart>().Delete();
                break;
            case 2:
                hearts[1].GetComponent<Heart>().Delete();
                break;
            case 1:
                hearts[0].GetComponent<Heart>().Delete();
                break;
        }
        Explode();
        health--;
    }

    private void Explode()
    {
        //gheire faal kardane movaghat player
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = false;
        //pakhsh animatione destroyPlayer
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Explode");
    }

    public void Loose()
    {
        //too akharin keyframe animation destroyPlayer seda zade mishe, vaziat bakht ya edame ro check mikone
        if (health <= 0)
        {
            manager.loose();
        }
        else
        {
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = true;
        }

    }
}