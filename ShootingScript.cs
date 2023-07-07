using System;
using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Linq;
using UnityEditor;
using TMPro;

public class ShootingScript : MonoBehaviour
{
    public Animator animator;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float startTime;
    public float shootingSpeed;
    public GameObject bullet;
    public int counter = 0;
    public GameObject weapons;
    public int maxBullet=0;
    private float elapsedTime = 0;
    public TextMeshPro textMeshProRounds;
    public GameObject pistol;


    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        elapsedTime = Time.time - startTime;
        if (Input.GetMouseButton(0) && elapsedTime >= shootingSpeed)
        {
                counter++;
                animator.SetBool("Shooting", true);
                Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
                Vector3 direction = (mousePosition - bulletSpawnPoint.position).normalized;
                bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                startTime = Time.time;
            if (pistol.activeInHierarchy==true)
            {
                textMeshProRounds.text = Mathf.Infinity.ToString();
            }
            else
            {
                textMeshProRounds.text = (maxBullet - counter).ToString();
            }
        }
        if (counter>=maxBullet)
        {
            WeaponScript Counter = weapons.GetComponent<WeaponScript>();
            Counter.counterWeapongChange = 0;
            counter = 0;
        }
    }

public void IsntShooting()
    {
        animator.SetBool("Shooting", false);
    }
}
