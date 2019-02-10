using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;
    public Vector3 playerOffsetFromPortal;

    // Update is called once per frame
    void Update () {
        playerOffsetFromPortal = playerCamera.position - otherPortal.position;


        //float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);4

        float angularDifferenceBetweenPortalRotations =  portal.transform.eulerAngles.y - otherPortal.transform.eulerAngles.y;

        Debug.Log(this.gameObject.name + ": "+ angularDifferenceBetweenPortalRotations);
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        //Debug.Log(portalRotationalDifference);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

        //Debug.Log(otherPortal.GetComponentInChildren<PortalTeleporter>().playerRelative);
        //transform.position = portal.position + otherPortal.GetComponent<PortalTeleporter>().playerRelative;
        transform.position = portal.position + (portalRotationalDifference * playerOffsetFromPortal);
        //transform.position = portal.position + (playerOffsetFromPortal);

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        
	}
}
