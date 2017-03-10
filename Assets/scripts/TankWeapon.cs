using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {

    public GameObject shell;
    public float shootPower;
    public Transform shootPoint;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        GameObject newShell = Instantiate(shell, shootPoint.position, shootPoint.rotation) as GameObject;
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward * shootPower;
        audioSource.Play();
    }
}
