using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JetControls : MonoBehaviour {


	public Text txt;


	private Rigidbody rb;
	private HingeJoint hj;

	private float roll_value;
	private float pitch_value;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		//hj = GetComponent<HingeJoint> ();
	
		rb.AddRelativeForce (Vector3.forward*10,ForceMode.VelocityChange);
		//roll_value = 0.0f; pitch_value = 0.0f;
	}

	// Update is called once per frame
	void Update () {

		// Get joystick values

		float moveRoll = Input.GetAxis ("Roll");
		float movePitch = Input.GetAxis ("Pitch");
		float moveThrust = Input.GetAxis ("Thrust");

		// Nullify input if too small

		if(Mathf.Abs(moveThrust)<0.01f){moveThrust = 0.0f;}

		//Add or remove hinge
		//if hinge exists
			//if no movement - remove hinge
			//else - adjust hinge parameters
		//else
			//if no movement - do nothing
			//else - create hinge and set parameters

		if(Mathf.Abs(moveRoll) < 0.01f){
			roll_value = 0;}
		else{
			roll_value = 2 / moveRoll;}

		if(Mathf.Abs(movePitch) < 0.01f){
			pitch_value = 0;}
		else{
			pitch_value = 2 / movePitch;}

		if (hj != null) {
			if (roll_value == 0 && pitch_value == 0) {
				Destroy(hj);
			} else {
				hj.anchor = new Vector3 (roll_value, pitch_value, 0);
				hj.axis = Vector3.Normalize(new Vector3 (pitch_value, roll_value, 0));
			}
		} else {
			if (roll_value == 0 && pitch_value == 0) {
				//Do nothing
			} else {
				hj = gameObject.AddComponent<HingeJoint>();
				hj.autoConfigureConnectedAnchor = true;
				hj.anchor = new Vector3 (roll_value, pitch_value, 0);
				hj.axis = Vector3.Normalize(new Vector3 (pitch_value, roll_value, 0));
			}
		}

		//Position hinge location
		//if(Mathf.Abs(moveRoll) < 0.01f){
		//	roll_value = 2;}
		//else{
		//	roll_value = 2 / moveRoll;}

		//if(Mathf.Abs(movePitch) < 0.01f){
		//	pitch_value = 0;}
		//else{
		//	pitch_value = 2 / movePitch;}
		//
		//hj.anchor = new Vector3 (roll_value, pitch_value, 0);
		//hj.axis = Vector3.Normalize(new Vector3 (pitch_value, roll_value, 0));


		// Apply velocity change
		rb.AddRelativeForce (new Vector3(0,0,moveThrust*10));

		// View parameters

		txt.text = "roll_Value: " + roll_value.ToString() + " Speed: "+ Vector3.Magnitude(rb.velocity).ToString();

		// Check for application quit

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

	}
}
