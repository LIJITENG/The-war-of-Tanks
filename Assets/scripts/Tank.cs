using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {

    public float moveSpeed ;
    public float rotateSpeed ;

    private TankWeapon tw;
    // Use this for initialization
    void Start()
    {
        tw = GetComponent<TankWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(Input.GetAxis("HorizontalUI"));
        float horizontal = Input.GetAxis("HorizontalUI");//ad
        float vertical = Input.GetAxis("VerticalUI");//ws
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vertical);//ws
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);//ad

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tw.Shoot();
        }
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        //}
    }
}
