using UnityEngine;

public class invaderLaser : MonoBehaviour
{
    [SerializeField] private float speed = -10f;
    private void Update()
    {
        Vector3 move = new Vector3(0, speed, 0) * Time.deltaTime;
        transform.position += move;
    }
}
