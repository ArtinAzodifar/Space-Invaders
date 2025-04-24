using System.Data;
using UnityEditor;
using UnityEngine;

public class InvaderGrid : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 6;
    [SerializeField] private float invaderXSpeed = 1.5f;
    [SerializeField] private float InvaderYSpeed = -1.5f;
    [SerializeField] private float maxX = 2f;
    [SerializeField] private float minX = -2f;
    private bool goDown = false;
    private float downTime = 0;

    private void Awake()
    {
        float x = -2.8f;
        float xChange = 1.1f;
        float y = 2.6f;
        float yChange = 0.8f;
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                Instantiate(prefabs[i], new Vector3(x, y, 0), transform.rotation, transform);
                x += xChange;
            }
            x = -2.8f;
            y -= yChange;
        }
    }

    private void Update()
    {
        if (goDown)
        {
            Vector3 moveDown = new Vector3(0, InvaderYSpeed, 0) * Time.deltaTime;
            downTime += Time.deltaTime;
            if (downTime >= 0.15)
            {
                goDown = false;
                downTime = 0;
                return;
            }
            transform.position += moveDown;
            return;
        }
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            invaderXSpeed *= -1;
            goDown = true;
        }
        Vector3 move = new Vector3(invaderXSpeed, 0, 0) * Time.deltaTime;
        transform.position += move;
    }
}
