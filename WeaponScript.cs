using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using TMPro;

public class WeaponScript : MonoBehaviour
{
    public Transform aimTransform;
    public GameObject weapons;
    public GameObject pistol;
    public GameObject uzi;
    public GameObject tracingGun;
    public GameObject sniper;
    public int counterWeapongChange = 0;
    public GameObject flashLight;
    public GameObject UIPistol;
    public GameObject UIUzi;
    public GameObject UITracingGun;
    public GameObject UISniper;
    public TextMeshPro textMeshPro;


    int counterPistol = 0;
    int counterUZI = 0;
    int counterTracingGun = 0;
    int counterSniper = 0;
    int counterFPressed = 0;


    private void Start()
    {
        aimTransform = transform.Find("Weapons");
    }

    private void Update()
    {
        Aiming();
        if (counterWeapongChange == 0 && counterPistol == 0)
        {
            textMeshPro.text = Mathf.Infinity.ToString();
            UIPistol.SetActive(true);
            UIUzi.SetActive(false);
            UITracingGun.SetActive(false);
            UISniper.SetActive(false);

            pistol.SetActive(true);
            uzi.SetActive(false);
            tracingGun.SetActive(false);
            sniper.SetActive(false);
            counterPistol++;
            counterUZI = 0;
            counterTracingGun = 0;
            counterSniper = 0;
            ShootingScript sspistol = pistol.GetComponent<ShootingScript>();
            sspistol.startTime = Time.time;
        }

        if (counterWeapongChange == 1 && counterUZI == 0)
        {
            textMeshPro.text=10.ToString();
            UIPistol.SetActive(false);
            UIUzi.SetActive(true);
            UITracingGun.SetActive(false);
            UISniper.SetActive(false);

            uzi.SetActive(true);
            pistol.SetActive(false);
            tracingGun.SetActive(false);
            sniper.SetActive(false);
            counterUZI++;
            counterPistol=0;
            counterTracingGun=0;
            counterSniper = 0;
            ShootingScript ssUzi = uzi.GetComponent<ShootingScript>();
            ssUzi.startTime = Time.time;
        }

        if (counterWeapongChange == 2 && counterTracingGun == 0)
        {
            textMeshPro.text=5.ToString();
            UIPistol.SetActive(false);
            UIUzi.SetActive(false);
            UITracingGun.SetActive(true);
            UISniper.SetActive(false);

            uzi.SetActive(false);
            pistol.SetActive(false);
            tracingGun.SetActive(true);
            sniper.SetActive(false);
            counterTracingGun++;
            counterPistol=0;
            counterUZI=0;
            counterSniper = 0;
            ShootingScript ssTracing = tracingGun.GetComponent<ShootingScript>();
            ssTracing.startTime = Time.time;
        }

        if (counterWeapongChange == 3 && counterSniper == 0)
        {
            textMeshPro.text= 5.ToString();
            UIPistol.SetActive(false);
            UIUzi.SetActive(false);
            UITracingGun.SetActive(false);
            UISniper.SetActive(true);

            uzi.SetActive(false);
            pistol.SetActive(false);
            tracingGun.SetActive(false);
            sniper.SetActive(true);
            counterTracingGun = 0;
            counterPistol = 0;
            counterUZI = 0;
            counterSniper ++;
            ShootingScript ssSniper = sniper.GetComponent<ShootingScript>();
            ssSniper.startTime = Time.time;
        }

        if (Input.GetKeyDown("f"))
        {
            counterFPressed++;
            if (counterFPressed==1)
            {
                flashLight.SetActive(false);
            }
            if (counterFPressed == 2)
            {
                flashLight.SetActive(true);
                counterFPressed = 0;
            }
        }
    }

    private void Aiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDir = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
