using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCamera : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //因为当前Camera的坐标为（0，0，0）所以一开始后与target左边一致，每一帧更新形成同步。
        if (target == null) return;
        transform.position = target.position;
    }
}
