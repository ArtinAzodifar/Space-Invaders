using System.Data;
using UnityEditor;
using UnityEngine;

public class InvaderGrid : MonoBehaviour
{
    public static float invaderSpeed = 3f;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 6;

    void Awake()
    {
        float x = -3.1f;
        float xChange = 1.2f;
        float y = 3.3f;
        float yChange = 0.8f;
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                Instantiate(prefabs[i], new Vector3(x, y, 0), transform.rotation);
                x += xChange;
            }
            x = -3.1f;
            y -= yChange;
        }
    }
}
