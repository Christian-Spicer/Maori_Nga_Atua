//this controls the position of the walk arrow
using UnityEngine;
using System.Collections;

public class ForwardTrackingArrowScript : MonoBehaviour {
	//this declares a variable for the distance of the arrow in front of the charactor
	public float distanceZ = 1f;
	//this declares a variable for the distance of the arrow in height of the charactor
	public float distanceY = -0.4f;
	//this declares a Y variable to be used for the head orientation
	private float angleY;
	//this declares a Z variable to be used for the head orientation
	private float angleZ;
	//this declares a variable for the X movement of the head 
	private float arrowAngleX;
	//this declares a variable for the Y movement of the head
	private float arrowAngleY;
	//this declares a variable for the Z movement of the head
	private float arrowAngleZ;
	//this declares a variable for the head in google cardboard
	private CardboardHead head;
	//this declaers a variable for the Headpose orientation
	private Quaternion rot;
	//this declaers a variable so that the head rotation can be assigned to it
	private Quaternion arrowRot;
	//this declears the a variable for the final calculation to be assigned to it
	private Vector3 lookDir;
	// Use this for initialization
	void Start() {
		//this sets the head variable to the Head component
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	// Update is called once per frame
	void Update () {
		//this gets the head component and holds in a variable
        GameObject controller = GameObject.Find("PlayerCapsule");
		//this finds the script that contains the boolean checkAutoWalk
        CharacterMotor autowalk = controller.GetComponent<CharacterMotor>();
		//the assigns the headpose orientation to the variable
		rot = Cardboard.SDK.HeadPose.Orientation;
		//this assigns the head rotation to the variable
		arrowRot = head.transform.rotation;
		//this assigns the Y value to the variable from the Headpose
		angleY = rot.eulerAngles.y;
		//this assigns the Z value to the variable from the Headpose
		angleZ = rot.eulerAngles.z;
		//this assigns the variable X from the head rotation
		arrowAngleX = arrowRot.eulerAngles.x;
		//this assigns the variable Y from the head rotation
		arrowAngleY = arrowRot.eulerAngles.y;
		//this assigns the variable Z from the head rotation
		arrowAngleZ = arrowRot.eulerAngles.z;
		//this basically sets the x eulerAngle to zero 
		rot.eulerAngles = new Vector3 (0, angleY, angleZ);
		//this stops the rotation of the object along the X axis
		arrowAngleX = Mathf.Clamp (arrowAngleX, 65, 65);
		//this stops the rotation of the object along the Z axis
		arrowAngleZ = Mathf.Clamp (arrowAngleZ, 0, 0);
		//this sets the new euler angles
		arrowRot = Quaternion.Euler (arrowAngleX, arrowAngleY, arrowAngleZ);
		//this the arrow to the front or behind the charactor
		if (autowalk.checkAutoWalk == false) {
			//this set the position to in front of the charactor
			lookDir = rot * (Quaternion.Euler (0, 0, 0) * new Vector3 (0, distanceY, distanceZ));
		} else {
			//this set the position to behind the charactor
			lookDir = rot * (Quaternion.Euler (0, 180, 0) * new Vector3 (0, distanceY + 5, distanceZ + 5));
		}
		//this does the actual movements of the rotation
		transform.rotation = arrowRot;
		//this does the actual movements of the position
		transform.position = head.transform.position + lookDir;
	}
}
