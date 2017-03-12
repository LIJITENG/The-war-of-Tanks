using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITank : Unit {
    public GameObject player;
    public float attackRange;
    public float moveSpeed;
    public float shootCoolDown;

    private float timer;
    private TankWeapon tw;
    private NavMeshAgent nam;

    void Start()
    {
        nam = GetComponent<NavMeshAgent>();
        tw = GetComponent<TankWeapon>();   
    }
    /*
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;//计时器 攻击冷却

        if (player == null) return;//玩家死亡，就不移动 转向 开炮了
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist > attackRange)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);//ws  移动
        }

        transform.LookAt(player.transform.position);//转向

        if(timer > shootCoolDown)
        {
            tw.Shoot();//开炮
            timer = 0f;
        }
        */

   void FixedUpdate()
    {
        
        timer += Time.fixedDeltaTime;//计时器 攻击冷却

        if (player == null) return;//玩家死亡，就不移动 转向 开炮了
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > attackRange)
        {
            nam.SetDestination(player.transform.position);// 移动
           
        }
        else
        {
            nam.ResetPath();
            transform.LookAt(player.transform.position);//转向
            if (timer > shootCoolDown)
            {
                tw.Shoot();//开炮
                timer = 0f;
            }
        }

        

        
    }
}



