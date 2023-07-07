using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletScript : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject eventSystem = GameObject.FindGameObjectWithTag("EventSystem");
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allObjects)
            {
                if (go.activeInHierarchy)
                {
                    go.SetActive(false);
                }
            }
            eventSystem.SetActive(true);
            Instantiate(gameOverScreen, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }   
        if (collision.gameObject.CompareTag("Enemy"))
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

}
