using UnityEngine;

public class InvaderLaser : MonoBehaviour, Laser
{
    [SerializeField] private float speed = -7f;
    public void Update()
    {
        Vector3 move = new Vector3(0, speed, 0) * Time.deltaTime;
        transform.position += move;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Manager manager = Manager.getInstance();
        if (other.CompareTag("side") || other.CompareTag("shield") || other.CompareTag("Player"))
        {
            manager.setInvaderLaserActive(false);
            Destroy(gameObject);
        }
    }
}
