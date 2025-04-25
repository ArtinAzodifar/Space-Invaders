using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour
{
    private int health = 5;
    private TextMeshPro healthShow;

    private void Awake()
    {
        healthShow = GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        healthShow.text = "" + health;
    }
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
