using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System.Linq;

public class TracingBulletEnemy : MonoBehaviour
{
    public Transform target;
    public Transform objectt;
    public List<Transform> positions = new List<Transform>();
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;
    GameObject closest;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FindClosestEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") | collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Spawner"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        target = closest.transform;
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        moveDirection = direction;
        rb.velocity = moveDirection * moveSpeed;
        rb.rotation = angle;
        return closest;
    }

}

