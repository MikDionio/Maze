using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform reciever;

	public bool playerIsOverlapping = false;
    private bool playerIsBehind = false;

    public Vector3 playerRelative;

    private void Start()
    {
        //WorldRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update () {
        Vector3 portalToPlayer = player.position - transform.position;
        playerRelative = Mathf.Cos(transform.rotation.y) * transform.InverseTransformDirection(portalToPlayer);
        //Debug.Log(playerRelative);
        
        if (playerIsOverlapping)
		{
            
            //Quaternion LocalRotation = Quaternion.Inverse(player.transform.rotation) * WorldRotation;
            //float dotProduct = Vector3.Dot(transform.forward, portalToPlayer.normalized);
            //Debug.Log("PortalToPlayer: " + portalToPlayer + " Dot Product: " + dotProduct);
            // If this is true: The player has moved across the portal
            if (playerRelative.z < 0f)
			{
                // Teleport him!
                Debug.Log("Teleport!");
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

				playerIsOverlapping = false;
                playerIsBehind = false;
            }
            else
            {
                //Debug.Log("Behind!");
                playerIsBehind = true;
            }
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
            //Debug.Log("Exit!");
			playerIsOverlapping = false;
            playerIsBehind = false;
		}
	}

}
