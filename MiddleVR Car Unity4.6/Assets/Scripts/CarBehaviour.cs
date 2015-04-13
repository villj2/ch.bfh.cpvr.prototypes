using UnityEngine;
using System.Collections;

public class CarBehaviour : MonoBehaviour {

	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public float maxTorque = 50;
	public GUIText guiSpeed;
	public Texture2D guiSpeedDisplay;
	public Texture2D guiSpeedPointer;

	private float currentSpeedKMH = 20.0f;

	// Use this for initialization
	void Start () {
		rigidbody.centerOfMass = new Vector3 (0, 0, 0);
	}

	// Update is called once per frame constanc time per frame
	void FixedUpdate () {
		wheelFL.motorTorque = maxTorque * Input.GetAxis("Vertical");
		wheelFR.motorTorque = wheelFL.motorTorque;
		wheelFL.steerAngle = 10 * Input.GetAxis("Horizontal");
		wheelFR.steerAngle = wheelFL.steerAngle;

		//guiSpeed.text = wheelFL.rpm.ToString("0");
		currentSpeedKMH = (rigidbody.velocity.magnitude * 3.6f);
		guiSpeed.text = currentSpeedKMH.ToString("0");
	}

	void OnGUI()
	{
		GUI.Box(new Rect (0, 0, 140, 140), guiSpeedDisplay);

		float angle = Mathf.Abs(currentSpeedKMH) + 40;

		GUIUtility.RotateAroundPivot (angle, new Vector2 (70, 70));
		GUI.DrawTexture (new Rect (0, 0, 140, 140), guiSpeedPointer, ScaleMode.StretchToFill);
	}
}
