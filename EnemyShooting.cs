using CodeMonkey.Utils;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{
    public Animator animator;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float startTime;
    public float shootingSpeed;
    public Rigidbody2D rbEM;
    public GameObject bullet; 
    public int counter=0;
    public GameObject weapons;
    public int maxBullet=0;


    private GameObject target;


    private void Start()
    {
        startTime = Time.time;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        Vector3 targetPostion = target.transform.position;
        float rangePosition = Vector3.Distance(transform.position, targetPostion);
        if (counter >= maxBullet)
        {
            EnemyWeapon Counter = weapons.GetComponent<EnemyWeapon>();
            Counter.counter = 0;
            counter = 0;
        }

        if (rangePosition<=10 && elapsedTime>=shootingSpeed)
        { 
            counter++;  
            animator.SetBool("Shooting", true);
            Vector3 direction = (targetPostion - bulletSpawnPoint.position).normalized;
            bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            startTime = Time.time;
        }
    }

    public void IsntShooting()
    {
        animator.SetBool("Shooting", false);
    }
}
