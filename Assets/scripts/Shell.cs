using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public int damage;
    public float explosionForce;
    public float explosionRadius;
    public GameObject explosionEffect;
    public float explosionTimeUp;
	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
        Destroy(obj,explosionTimeUp);

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        if(cols.Length > 0)
        {
            for(int i = 0;i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();
                if (r != null)
                {
                    //对碰到的物体进行施力，因此得遍历对象
                    r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }

                Unit u = cols[i].GetComponent<Unit>();
                if(u != null)
                {
                    u.ApplyDamage(damage);
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}
