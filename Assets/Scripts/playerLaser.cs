using UnityEngine;

public class playerLaser : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    private void Update()
    {
        Vector3 move = new Vector3(0, speed, 0) * Time.deltaTime;
        transform.position += move;
    }
}
