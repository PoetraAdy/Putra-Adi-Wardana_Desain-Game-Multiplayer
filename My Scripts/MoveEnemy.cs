using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    public float speed, speed2;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public string pos;
    [SerializeField] Animator anim;

    float TimerShot = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerShot += Time.deltaTime;
        Collider[] hits = Physics.OverlapSphere(transform.position, 8);
        foreach(Collider hit in hits)
        {
            if(hit.tag == "Player")
            {
                float step = speed * Time.deltaTime;
                if (GameObject.Find("Player").GetComponent<HealthNotNetwork>().thisHealth > 50)
                {
                    anim.SetTrigger("Idle");
                }
                transform.LookAt(GameObject.Find("Player").GetComponent<Transform>().position);
            }
        }

        Collider[] hits2 = Physics.OverlapSphere(transform.position, 5);
        foreach (Collider hit in hits2)
        {
            if (hit.tag == "Player")
            {
                float step = speed * Time.deltaTime;
                if (GameObject.Find("Player").GetComponent<HealthNotNetwork>().thisHealth > 50)
                {
                    anim.SetTrigger("Run");
                    transform.position = Vector3.MoveTowards(transform.position, GameObject.Find(pos).GetComponent<Transform>().position, step);
                }

                if (GameObject.Find("Player").GetComponent<HealthNotNetwork>().thisHealth <= 50)
                {
                    if (TimerShot >= 3)
                    {
                        CmdFire();
                        TimerShot = 0;
                    }
                }
            }
        }
    }

    void CmdFire()
    {
        anim.SetTrigger("Shot");
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;
        Destroy(bullet, 2);
    }
}
