using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject pistolGO;
    public GameObject uziGO;
    public GameObject tracingGunGO;
    public GameObject sniperGO;
    public int counter = 0;
    public GameObject pistol;
    public GameObject uzi;
    public GameObject tracingGun;
    public GameObject sniper;


     Transform aimTransform;
     GameObject target;
    int counter2 = 0;
    int counter3 = 0;
    int counter4 = 0;
    int counter5 = 0;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        aimTransform = transform.Find("PistolGO");
    }

    private void Update()
    {
        Aiming();
        if (counter == 0 && counter2 == 0)
        {
            pistolGO.SetActive(true);
            uziGO.SetActive(false);
            tracingGunGO.SetActive(false);
            sniperGO.SetActive(false);
            aimTransform = transform.Find("PistolGO");
            counter2++;
            counter3 = 0;
            counter4 = 0;
            counter5 = 0;
            EnemyShooting sspistol = pistol.GetComponent<EnemyShooting>();
            sspistol.startTime = Time.time;
        }

        if (counter == 1 && counter3 == 0)
        {
            uziGO.SetActive(true);
            pistolGO.SetActive(false);
            tracingGunGO.SetActive(false);
            sniperGO.SetActive(false);
            aimTransform = transform.Find("UZIGO");
            counter3++;
            counter2 = 0;
            counter4 = 0;
            counter5 = 0;
            EnemyShooting ssUzi = uzi.GetComponent<EnemyShooting>();
            ssUzi.startTime = Time.time;
        }

        if (counter == 2 && counter4 == 0)
        {
            uziGO.SetActive(false);
            pistolGO.SetActive(false);
            tracingGunGO.SetActive(true);
            sniperGO.SetActive(false);
            aimTransform = transform.Find("TracingGunGO");
            counter4++;
            counter2 = 0;
            counter3 = 0;
            counter5 = 0;
            EnemyShooting ssTracing = tracingGun.GetComponent<EnemyShooting>();
            ssTracing.startTime = Time.time;
        }

        if (counter == 3 && counter5 == 0)
        {
            uziGO.SetActive(false);
            pistolGO.SetActive(false);
            tracingGunGO.SetActive(false);
            sniperGO.SetActive(true);
            aimTransform = transform.Find("SniperGO");
            counter4=0;
            counter2 = 0;
            counter3 = 0;
            counter5++;
            EnemyShooting ssSniper = sniper.GetComponent<EnemyShooting>();
            ssSniper.startTime = Time.time;
        }
    }

    private void Aiming()
    {
        if (target==null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        Vector3 targetpos = target.transform.position ;
        Vector3 aimDir = (targetpos - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
