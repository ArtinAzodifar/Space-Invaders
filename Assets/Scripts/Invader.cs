using UnityEngine;

public class Invader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerLaser"))
        {
            InvaderGrid.invaderCount--;
            Debug.Log(InvaderGrid.invaderCount);
            Destroy(gameObject);
        }
    }
}
