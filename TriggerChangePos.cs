using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TriggerChangePos : MonoBehaviour
{

    Vector3 pos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls")==true)
        {
            AIDestinationSetter AI = GetComponent<AIDestinationSetter>();
           float x = Random.Range(-40, 40);
           float y = Random.Range(-40, 40);
            pos = new Vector3(x, y, 0);
            transform.position =pos;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AIDestinationSetter AI = GetComponent<AIDestinationSetter>();
        float x = Random.Range(-40, 40);
        float y = Random.Range(-40, 40);
        pos = new Vector3(x, y, 0);
        transform.position = pos;
    }
}
