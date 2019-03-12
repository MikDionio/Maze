using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo: MonoBehaviour {
    public float rotateSpeed;
    public GameObject endGameLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You did it!!");
            collision.transform.position = endGameLocation.transform.position;
        }
    }
}
