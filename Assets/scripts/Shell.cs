using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public int damage;//爆炸造成伤害
    public float explosionForce;//爆炸造成冲击的力度
    public float explosionRadius;//爆炸冲击半径
    public GameObject explosionEffect;//爆炸特效对象
    public float explosionTimeUp;//特效播放后消失，时间段
	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;//爆炸特效
       

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        if(cols.Length > 0)
        {
            for(int i = 0;i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();//获得当前爆炸范围内对象的刚体
                if (r != null)//如果有刚体，因为地面等等的，不存在刚体
                {
                    //对碰到的有刚体的对象进行施力，因此得遍历对象
                    r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }

                Unit u = cols[i].GetComponent<Unit>();//获得当前爆炸范围内对象的unit
                if(u != null)//如果有unit，只有坦克有
                {
                    u.ApplyDamage(damage);
                }
            }
        }
        Destroy(gameObject);
        Destroy(obj, explosionTimeUp);
    }

    // Update is called once per frame
    void Update () {
        
	}
}
