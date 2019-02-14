using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;
    public Vector3 playerOffsetFromPortal;
    public bool alt;
    public float altValue;

    // Update is called once per frame
    void Update () {
        if (alt == true)
        {
            playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            float angularDifferenceBetweenPortalRotations = portal.transform.eulerAngles.y - otherPortal.transform.eulerAngles.y;

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations+180, Vector3.up);

            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;


            transform.position = portal.position + (portalRotationalDifference * playerOffsetFromPortal);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else
        {
            playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            float angularDifferenceBetweenPortalRotations = portal.transform.eulerAngles.y - otherPortal.transform.eulerAngles.y;

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;


            transform.position = portal.position + (portalRotationalDifference * playerOffsetFromPortal);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

            //Debug.Log(this.gameObject.name + ": "+ angularDifferenceBetweenPortalRotations);
            //Debug.Log(portalRotationalDifference);
            //Debug.Log(otherPortal.GetComponentInChildren<PortalTeleporter>().playerRelative);
        }

    }
}
