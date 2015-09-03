using UnityEngine;
using System.Collections;

public class ForwardTrackingStopScript : MonoBehaviour {
	
	public float distanceZ = 0.8f;
	public float distanceY = -0.3f;
	private float angleY;
	private float angleZ;
	private float arrowAngleX;
	private float arrowAngleY;
	private float arrowAngleZ;
	private CardboardHead head;
	private Quaternion rot;
	private Quaternion arrowRot;
	private Vector3 lookDir;

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update () {
		GameObject FPSController = GameObject.Find ("Head");
		FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
		rot = Cardboard.SDK.HeadPose.Orientation;
		arrowRot = head.transform.rotation;
		angleY = rot.eulerAngles.y;
		angleZ = rot.eulerAngles.z;
		arrowAngleX = arrowRot.eulerAngles.x;
		arrowAngleY = arrowRot.eulerAngles.y;
		arrowAngleZ = arrowRot.eulerAngles.z;
		rot.eulerAngles = new Vector3 (0, angleY, angleZ);
		arrowAngleX = Mathf.Clamp (arrowAngleX, 55, 55);
		arrowRot = Quaternion.Euler (arrowAngleX, arrowAngleY, arrowAngleZ);
		if (autowalk.checkAutoWalk == false) {
			lookDir = rot * (Quaternion.Euler (0, 180, 0) * new Vector3 (0, distanceY + 5, distanceZ + 5));
		} else {
			lookDir = rot * (Quaternion.Euler (0, 0, 0) * new Vector3 (0, distanceY, distanceZ));
		}
		transform.rotation = arrowRot;
		transform.position = head.transform.position + lookDir;
		
	}
}
