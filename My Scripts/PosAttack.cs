using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Collider[] hits = Physics.OverlapSphere(transform.position, 5);
        foreach (Collider hit in hits)
        {
            if (hit.tag == "Player")
            {
                GameObject.Find("Player").GetComponent<HealthNotNetwork>().thisHealth--;
            }
        }
    }
}
