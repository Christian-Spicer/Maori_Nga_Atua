//this controls the position of the reset object
using UnityEngine;
using System.Collections;

public class ForwardTrackingResetScript : MonoBehaviour {
	//this declares a variable for the distance of the resst object in front of the charactor
	public float distanceZ = 1f;
	//this declares a variable for the distance of the resst object in height of the charactor
	public float distanceY = -0.4f;
	//this declares a Y variable to be used for the head orientation
	private float angleY;
	//this declares a Z variable to be used for the head orientation
	private float angleZ;
	//this declares a variable for the X movement of the head 
	private float resetAngleX;
	//this declares a variable for the Y movement of the head
	private float resetAngleY;
	//this declares a variable for the Z movement of the head
	private float resetAngleZ;
	//this declares a variable for the head in google cardboard
	private CardboardHead head;
	//this declaers a variable for the Headpose orientation
	private Quaternion rot;
	//this declaers a variable so that the head rotation can be assigned to it
	private Quaternion resetRot;
	// Use this for initialization
	void Start() {
		//this sets the head variable to the Head component
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	// Update is called once per frame
	void Update () {
		//the assigns the headpose orientation to the variable
		rot = Cardboard.SDK.HeadPose.Orientation;
		//this assigns the head rotation to the variable
		resetRot = head.transform.rotation;
		//this assigns the Y value to the variable from the Headpose
		angleY = rot.eulerAngles.y;
		//this assigns the Z value to the variable from the Headpose
		angleZ = rot.eulerAngles.z;
		//this assigns the variable X from the head rotation
		resetAngleX = resetRot.eulerAngles.x;
		//this assigns the variable Y from the head rotation
		resetAngleY = resetRot.eulerAngles.y;
		//this assigns the variable Z from the head rotation
		resetAngleZ = resetRot.eulerAngles.z;
		//this basically sets the x eulerAngle to zero 
		rot.eulerAngles = new Vector3 (0, angleY, angleZ);
		//this stops the rotation of the object along the X axis
		resetAngleX = Mathf.Clamp (resetAngleX, -45, -45);
		//this stops the rotation of the object along the Z axis
		resetAngleZ = Mathf.Clamp (resetAngleZ, 0, 0);
		//this sets the new euler angles
		resetRot = Quaternion.Euler (resetAngleX, resetAngleY + 180f, resetAngleZ);
		//this set the position to in front of the charactor
		Vector3	lookDir = rot * (Quaternion.Euler (0, 0, 0) * new Vector3(0, distanceY, distanceZ));
		//this does the actual movements of the rotation
		transform.rotation = resetRot;
		//this does the actual movements of the position
		transform.position = head.transform.position + lookDir;
	}
}
