using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    public GameObject thing;

	// Use this for initialization
	void Start () {
        thing.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Show!");
            thing.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Disappear!");
            thing.gameObject.SetActive(false);
        }
    }
}
