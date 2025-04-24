using UnityEngine;

public class PlayerLaser : MonoBehaviour, Laser
{
    [SerializeField] private float speed = 13f;
    private Manager manager = Manager.getInstance();
    public void Update()
    {
        Vector3 move = new Vector3(0, speed, 0) * Time.deltaTime;
        transform.position += move;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("side") || other.CompareTag("shield") || other.CompareTag("invader1") || other.CompareTag("invader2") || other.CompareTag("invader3") || other.CompareTag("mysteryInvader"))
        {
            manager.setPlayerLaserActive(false);
            Destroy(gameObject);
        }
    }
}
