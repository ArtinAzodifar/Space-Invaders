using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerLaser"))
        {
            InvaderGrid.invaderCount--;
            Debug.Log(InvaderGrid.invaderCount);
            animator.SetTrigger("Explode");
            Destroy(gameObject, 0.4f);
        }
    }
}
