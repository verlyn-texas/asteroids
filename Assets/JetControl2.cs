using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JetControl2 : MonoBehaviour {

	//Low Speed Factors
	public float shipAngularDrag;
	public float torqueFactor;
	public float thrustFactor;
	public float maxTurnFactor; //In degrees (0 to 90)

	//High Speed Factors
	public float shipAngularDragHighSpeed;
	public float torqueFactorHighSpeed;
	public float thrustFactorHighSpeed;

	//Other Public Parameters
	public Text speedText;
	public Text boundaryText;
	public Text distText;
	public Text timeText;
	public Text powerText;
	public GameObject expl;

	//Private variables
	private Rigidbody rb;
	private float shipspeed;
	private Vector3 rotationVector;
	private Vector3 thrustVector;
	private Vector3 velVector;
	private Vector3 towardVectorLocal;
	private Vector3 towardVectorGlobal;
	private Vector3 towardVectorGlobalAtMag;
	private Vector3 rotatedVelVector;
	private Ray CollisionRay;
	private RaycastHit hitInfo;
	private MeshRenderer mr;
	private float powerUsed;
	private Vector3 previousLocation;
	private Vector3 currentLocation;
	private float distanceTraveled;
	private int minutes;
	private int seconds;
	private Transform thisExpl;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		previousLocation = rb.position;
		rb.AddRelativeForce (new Vector3(0,0,5.0f),ForceMode.VelocityChange);
	}

	//Detect and react to collission
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Rock"))
		{
			Instantiate (expl, other.transform.position, other.transform.rotation);
			other.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		// Get joystick values

		float moveYaw = Input.GetAxis ("Yaw"); 
		float movePitch = Input.GetAxis ("Pitch");
		float moveThrust = Input.GetAxis ("Thrust");
		float moveRoll = Input.GetAxis ("Roll");
		bool rocketStop = Input.GetKey(KeyCode.Y);

		//General Algorithm
		// 1. At low speeds treat roll and pitch as merely damped rotations (DONE)
		//	1.1 Add thrust in local z direction. (DONE)
		// 2. At higher speeds treat roll and pitch as thursts in the x and y direction (DONE)
		//	2.1 Rotate ship to be facing in direction of global velocity vector (DONE)
		//		2.1.1 Add torque based on cross product between velocity (global) and ship forward (in global) (DONE)
		//	2.2 Apply forward thrust force (local z) (DONE)
		// 	2.3. Apply turning force (DONE)
		//		2.2.1 Build desired velocity change vector (local) (DONE)
		//			2.2.1.c magnitude less than speed (DONE)
		//			2.2.1.d scaled in x and y based on moveRoll and movePitch values (DONE)

		//Apply ship manuvering

		shipspeed =  Vector3.Magnitude (rb.velocity); //Validated

		if (shipspeed < 0.0001f) {
			rb.angularDrag = shipAngularDrag; //Validated
			rotationVector = torqueFactor * new Vector3 (movePitch, moveYaw, moveRoll); //Validated
			rb.AddRelativeTorque (rotationVector); //Validated
			rb.AddRelativeForce (thrustFactor * Vector3.forward * moveThrust); //Validated
			powerUsed = powerUsed + Vector3.Magnitude(thrustFactor * Vector3.forward * moveThrust);
		} else {
			rb.angularDrag = shipAngularDragHighSpeed; //Validated
			rotationVector = torqueFactorHighSpeed * Vector3.Cross (Vector3.Normalize (rb.velocity), Vector3.Normalize (rb.transform.forward)); //Validated
			rb.AddTorque (-1*rotationVector); //Validated
			rb.AddRelativeForce (thrustFactorHighSpeed * Vector3.forward * moveThrust); //Validated
			powerUsed = powerUsed + Vector3.Magnitude(thrustFactorHighSpeed * Vector3.forward * moveThrust);

			// Code below handles changing velocity vector
			// ERROR - ship speed is changing with a change in direction.
			shipspeed = Vector3.Magnitude (rb.velocity);
			towardVectorLocal = new Vector3 (moveYaw, movePitch, 0.0f);
			towardVectorGlobal = transform.TransformVector (towardVectorLocal) / 8; //8 neccessary to accomodate ship scaling.
			towardVectorGlobalAtMag = shipspeed * Vector3.Normalize (towardVectorGlobal);
			rotatedVelVector = Vector3.RotateTowards (rb.velocity, towardVectorGlobalAtMag, 1.570796f * maxTurnFactor/90.0f, 0.0f);
			thrustVector = rotatedVelVector - rb.velocity;
			rb.AddForce (thrustVector);
			powerUsed = powerUsed + Vector3.Magnitude(thrustVector);
			rotationVector = torqueFactor * new Vector3 (0.0f, 0.0f, moveRoll);
			rb.AddRelativeTorque (rotationVector);
		}

		//Add "all stop" function
		if (rocketStop) {
			rb.AddForce (-1 * rb.velocity, ForceMode.VelocityChange);
		}

		//Check for Boundary Proximity

		CollisionRay = new Ray(transform.position,rb.transform.forward);
		if (Physics.Raycast (CollisionRay, out hitInfo, 1500)) {
			if (hitInfo.collider.tag == "boundary"){
				boundaryText.text = "Boundary Distance: " + hitInfo.distance;
				mr = hitInfo.transform.gameObject.GetComponent<MeshRenderer> ();
				if (hitInfo.distance < 150) {
					mr.enabled = true;
				} else {
					mr.enabled = false;
				}
			}
		}

		//Populate Dashboard
		speedText.text = Mathf.RoundToInt(shipspeed).ToString() + ",000 km/s";
		powerText.text = Mathf.RoundToInt (powerUsed).ToString ();
		currentLocation = rb.position;
		distanceTraveled = distanceTraveled + Vector3.Magnitude (currentLocation - previousLocation);
		previousLocation = currentLocation;
		distText.text = Mathf.RoundToInt (distanceTraveled).ToString () + ",000 km";
		minutes = Mathf.FloorToInt (Time.time / 60);
		if (minutes < 1) {
			seconds = Mathf.RoundToInt(Time.time);
		} else {
			seconds = Mathf.RoundToInt(Time.time - minutes * 60);
		}
		timeText.text = minutes.ToString() + " : " + seconds.ToString();







		// Display Information at run-time
		//displayText.text = "moveThrust: " + moveThrust.ToString() + " moveRoll: " + moveRoll.ToString() + " Speed: "+ Vector3.Magnitude(rb.velocity).ToString();
		//displayText.text = "moveThrust: " + moveThrust.ToString() + "  rotationVector: " + rotationVector.ToString() + "  Speed: "+ Vector3.Magnitude(rb.velocity).ToString();
		//displayText.text = "moveThrust: " + moveThrust.ToString() + "  Speed: "+ Vector3.Magnitude(rb.velocity).ToString();
		//displayText.text = "moveThrust: " + moveThrust.ToString() + "  speedchange: "+ speedchange.ToString() + "  Speed: "+ Vector3.Magnitude(rb.velocity).ToString();
		//displayText.text = "shipspeed " + shipspeed.ToString() + "  thrustVector "+ thrustVector.ToString() + " mag.thrustVector: " + Vector3.Magnitude(thrustVector).ToString();
		//displayText.text = "shipspeed " + shipspeed.ToString () + "  rotatedVelVector: " + rotatedVelVector.ToString () + " mag.thrustVector: " + Vector3.Magnitude(thrustVector).ToString() + " mag.towardVector: " + Vector3.Magnitude(towardVectorGlobal).ToString();
		//displayText.text = "shipspeed: " + shipspeed.ToString () +
		//" towardVectorLocal: " + towardVectorLocal.ToString () +
		//" towardVectorGlobal: " + towardVectorGlobal.ToString () +
		//" towardVectorGlobalAtMag: " + towardVectorGlobalAtMag.ToString () +
		//" rotatedVector: " + rotatedVelVector.ToString () +
		//" thrustVector: " + thrustVector.ToString();

		// Check for application quit

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
