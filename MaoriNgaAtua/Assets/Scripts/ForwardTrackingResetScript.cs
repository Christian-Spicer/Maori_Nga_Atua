using UnityEngine;
using System.Collections;

public class ForwardTrackingResetScript : MonoBehaviour {
	
	public float distanceZ = 1f;
	public float distanceY = -0.4f;
	private float angleY;
	private float angleZ;
	private float resetAngleX;
	private float resetAngleY;
	private float resetAngleZ;
	private CardboardHead head;
	private Quaternion rot;
	private Quaternion resetRot;

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update () {
		//transform.position = head.transform.position + (head.Gaze.direction + distance);
		rot = Cardboard.SDK.HeadPose.Orientation;
		resetRot = head.transform.rotation;
		angleY = rot.eulerAngles.y;
		angleZ = rot.eulerAngles.z;
		resetAngleX = resetRot.eulerAngles.x;
		resetAngleY = resetRot.eulerAngles.y;
		resetAngleZ = resetRot.eulerAngles.z;
		rot.eulerAngles = new Vector3 (0, angleY, angleZ);
		resetAngleX = Mathf.Clamp (resetAngleX, -45, -45);
		resetAngleZ = Mathf.Clamp (resetAngleZ, 0, 0);
		//resetAngleZ = Mathf.Clamp (resetAngleZ, -0, 0);
		resetRot = Quaternion.Euler (resetAngleX, resetAngleY + 180f, resetAngleZ);
		Vector3	lookDir = rot * (Quaternion.Euler (0, 0, 0) * new Vector3(0, distanceY, distanceZ));
		transform.rotation = resetRot;
		transform.position = head.transform.position + lookDir;
		
	}
}
