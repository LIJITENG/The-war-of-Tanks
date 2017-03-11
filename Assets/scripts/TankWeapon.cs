using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {

    public GameObject shell;//子弹
    public float shootPower;//飞行速度
    public Transform shootPoint;//初始点

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Shoot()
    {
        GameObject newShell = Instantiate(shell, shootPoint.position, shootPoint.rotation) as GameObject;//创建子弹
        Rigidbody r = newShell.GetComponent<Rigidbody>();//获得子弹的刚体
        r.velocity = shootPoint.forward * shootPower;//刚体的速度 是矢量
        audioSource.Play();//播放声音
    }
}
