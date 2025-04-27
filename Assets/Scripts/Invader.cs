using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private InvaderGrid grid;
    private Manager manager = Manager.getInstance();
    private bool isDead = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        grid = FindAnyObjectByType<InvaderGrid>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isDead)//jelogiri az kam shodan bishtar az 1vahed az invaderCount
        {
            return;
        }
        if (other.CompareTag("playerLaser"))
        {
            isDead = true;
            switch (this.gameObject.tag)
            {
                case "invader1":
                    manager.addScore(10);
                    break;
                case "invader2":
                    manager.addScore(20);
                    break;
                case "invader3":
                    manager.addScore(30);
                    break;
            }
            Debug.Log(manager.getScore());
            InvaderGrid.invaderCount--;//mordane object---> kam shodan tedad invader
            Debug.Log(InvaderGrid.invaderCount);
            animator.SetTrigger("Explode");
            Destroy(gameObject, 0.4f);
        }
    }
}
