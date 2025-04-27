using System;
using System.Data;
using UnityEditor;
using UnityEngine;

public class InvaderGrid : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject laser;
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 6;
    [SerializeField] private float invaderXSpeed = 1f;
    [SerializeField] private float InvaderYSpeed = -1.5f;
    [SerializeField] private float maxX = 4.5f;
    [SerializeField] private float minX = -4.5f;
    private GameObject[] invaders = new GameObject[30];
    public static int invaderCount = 0;
    private bool goDown = false;
    private float downTime = 0;
    private float shootTime;
    private float estimatedShootTime = 0;
    private Manager manager = Manager.getInstance();

    private void Awake()
    {
        invaderCount = 0;
        float x = -2.8f;
        float xChange = 1.1f;
        float y = 2.6f;
        float yChange = 0.8f;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                invaders[invaderCount++] = Instantiate(prefabs[i], new Vector3(x, y, 0), transform.rotation, transform);
                x += xChange;
            }
            x = -2.8f;
            y -= yChange;
        }
        Debug.Log(invaderCount);
    }

    private void Start()
    {
        setShootTime();
    }

    private void Update()
    {
        if (invaderCount <= 0)
        {
            manager.win();
        }
        Move();
        ShootManage();
    }

    private void Move()
    {
        if (goDown)
        {
            Vector3 moveDown = new Vector3(0, InvaderYSpeed, 0) * Time.deltaTime;
            downTime += Time.deltaTime;
            transform.position += moveDown;
            if (downTime >= 0.15)
            {
                Vector3 moveFromSide = new Vector3(invaderXSpeed, 0, 0) * Time.deltaTime;
                transform.position += moveFromSide;
                goDown = false;
                downTime = 0;
                return;
            }
            return;
        }
        foreach (GameObject invader in invaders)
        {
            if (invader == null)
            {
                continue;
            }
            if (invader.transform.position.x >= maxX || invader.transform.position.x + transform.position.x <= minX)
            {
                invaderXSpeed *= -1;
                goDown = true;
                break;
            }
        }
        Vector3 move = new Vector3(invaderXSpeed, 0, 0) * Time.deltaTime;
        transform.position += move;
    }

    private void ShootManage()
    {
        estimatedShootTime += Time.deltaTime;
        if (estimatedShootTime >= shootTime)
        {
            estimatedShootTime = 0;
            manager.setInvaderLaserActive(true);
            Shoot();
            setShootTime();
        }
    }

    private void Shoot()
    {
        if (invaderCount == 0)
        {
            return;
        }
        int invaderIndicator;
        while (true)
        {
            invaderIndicator = UnityEngine.Random.Range(0, 30);
            if (invaders[invaderIndicator] != null)
            {
                break;
            }
        }
        Vector3 position = new Vector3(invaders[invaderIndicator].transform.position.x, invaders[invaderIndicator].transform.position.y - 0.1f, 0);
        Instantiate(laser, position, transform.rotation);
    }

    private void setShootTime()
    {
        shootTime = UnityEngine.Random.Range(0f, 5f);
    }
}
