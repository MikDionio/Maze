using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

    public Camera playerCamera;
	public GameObject playerObject;
	public Transform reciever;

	public bool playerIsOverlapping = false;
    public bool alt;
    private bool playerIsBehind = false;

    public Vector3 playerRelative;
    
    private Transform player;
    private void Start()
    {
        player = playerObject.transform;
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

                if(alt == true)
                {
                    float rotationDiff = -(transform.eulerAngles.y - reciever.transform.eulerAngles.y);
                    //rotationDiff += 180;

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;


                    playerObject.GetComponent<FirstPersonController>().m_MouseLook.LookRotation(player, playerCamera.transform, true, rotationDiff);
                    player.position = reciever.position + positionOffset;

                    playerIsOverlapping = false;
                    playerIsBehind = false;
                }
                else
                {
                    //Debug.Log("Teleport!");
                    float rotationDiff = -(transform.eulerAngles.y - reciever.transform.eulerAngles.y);
                    rotationDiff += 180;

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;


                    playerObject.GetComponent<FirstPersonController>().m_MouseLook.LookRotation(player, playerCamera.transform, true, rotationDiff);
                    player.position = reciever.position + positionOffset;

                    playerIsOverlapping = false;
                    playerIsBehind = false;
                }

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
