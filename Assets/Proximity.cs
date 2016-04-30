using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Proximity : MonoBehaviour {

	public GameObject ship;

	private Rigidbody srb;
	private Rigidbody brb;
	private float mydistance;

	//Other Public Parameters
	public Text displayText;

	// Use this for initialization
	void Start () {
		srb = ship.GetComponent<Rigidbody> ();
		brb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		mydistance = Vector3.Magnitude (srb.transform.position - brb.transform.position); // Not based on perpindicular distance

		displayText.text = "Between Positions:  " + mydistance.ToString ();
		//if (Vector3.Magnitude(srb.transform.position - brb.transform.position) < 50.0f) {
		//	//mr.enabled = false;
		//	displayText.text = "shipspeed: " + shipspeed.ToString ();
		//}
		//else{
		//	//mr.enabled = true;
	}
}

