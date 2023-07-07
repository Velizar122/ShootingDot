using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject[] go;
    public GameObject spawndObject;


    GameObject currentPoint;
    int index;
    float startTime;
    float checker = 0;
    float elapsedTime= 0;


    void Start()
    {
        index = Random.Range(0, 3);
        currentPoint = go[index];
        spawndObject= Instantiate(currentPoint, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        elapsedTime= Time.time - startTime;
        if (checker==1&&elapsedTime>=15)
        {
            index = Random.Range(0, 3);
            currentPoint = go[index];
            spawndObject = Instantiate(currentPoint, transform.position, Quaternion.identity);
            startTime = Time.time;
            checker = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|collision.gameObject.CompareTag("Enemy")) 
        {
            if (spawndObject!=null)
            {
                if (index == 0)
                {
                    Destroy(spawndObject);
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        WeaponScript Counter = collision.gameObject.GetComponent<WeaponScript>();
                        ShootingScript ss = collision.gameObject.GetComponentInChildren<ShootingScript>();
                        ss.counter = 0;
                        Counter.counterWeapongChange = 2;
                    }
                    if (collision.gameObject.CompareTag("Enemy"))
                    {
                        EnemyWeapon enemyWeapon = collision.gameObject.GetComponent<EnemyWeapon>();
                        EnemyShooting enemyShooting = collision.gameObject.GetComponentInChildren<EnemyShooting>();
                        enemyShooting.counter = 0;
                        enemyWeapon.counter = 2;
                    }
                    checker = 1;
                    startTime = Time.time;
                }
                if (index == 1)
                {
                    Destroy(spawndObject);
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        WeaponScript Counter = collision.gameObject.GetComponent<WeaponScript>();
                        ShootingScript ss = collision.gameObject.GetComponentInChildren<ShootingScript>();
                        ss.counter = 0;
                        Counter.counterWeapongChange = 1;
                    }
                    if (collision.gameObject.CompareTag("Enemy"))
                    {
                        EnemyWeapon enemyWeapon = collision.gameObject.GetComponent<EnemyWeapon>();
                        EnemyShooting enemyShooting = collision.gameObject.GetComponentInChildren<EnemyShooting>();
                        enemyShooting.counter = 0;
                        enemyWeapon.counter = 1;
                    }
                    checker = 1;
                    startTime = Time.time;
                }
                if (index == 2)
                {
                    Destroy(spawndObject);
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        WeaponScript Counter = collision.gameObject.GetComponent<WeaponScript>();
                        ShootingScript ss = collision.gameObject.GetComponentInChildren<ShootingScript>();
                        ss.counter = 0;
                        Counter.counterWeapongChange = 3;
                    }
                    if (collision.gameObject.CompareTag("Enemy"))
                    {
                        EnemyWeapon enemyWeapon = collision.gameObject.GetComponent<EnemyWeapon>();
                        EnemyShooting enemyShooting = collision.gameObject.GetComponentInChildren<EnemyShooting>();
                        enemyShooting.counter = 0;
                        enemyWeapon.counter = 3;
                    }
                    checker = 1;
                    startTime = Time.time;
                }
            }
        }
    }
}
