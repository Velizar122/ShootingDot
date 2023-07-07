using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 2.50f; 
    private float timeSinceLastSpawn; 
    private float startTime;


    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (elapsedTime >= 10f )
        {
            startTime = Time.time;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position;
            Instantiate(objectToSpawn, spawnPosition , Quaternion.identity);

            timeSinceLastSpawn = 0f;
        }
    }
}





