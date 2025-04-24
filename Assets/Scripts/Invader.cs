using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] Animator animator;
    private InvaderGrid grid;
    void Awake()
    {
        animator = GetComponent<Animator>();
        grid = FindAnyObjectByType<InvaderGrid>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerLaser"))
        {
            InvaderGrid.invaderCount--;
            grid.editSpeed();
            Debug.Log(InvaderGrid.invaderCount);
            animator.SetTrigger("Explode");
            Destroy(gameObject, 0.4f);
        }
    }
}
