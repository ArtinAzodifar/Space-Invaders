using UnityEngine;

public class Shield : MonoBehaviour
{
    private int health = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("playerLaser") || other.CompareTag("invaderLaser"))
        {
            health--;
            if(health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
