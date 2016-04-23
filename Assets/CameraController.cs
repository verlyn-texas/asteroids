using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject ship;
	//public Text txt;

	private bool firstperson;
	//private Vector3 offset;
	//private Vector3 offset2;
	//private Vector3 toffset;
	//private Vector3 toffset2;
	private ConfigurableJoint cj;

	// Use this for initialization
	void Start () {
		//offset = transform.position - ship.transform.position;
		//offset2 = offset + new Vector3 (0, 2, -6);
		//firstperson = true;
		//cj = GetComponent<ConfigurableJoint>();
	}

	// Update is called once per frame
	void Update () {

		//Get Camera View
		//float view = Input.GetAxis ("View");
		//txt.text = "ShipX: " + ship.transform.position.x.ToString ();

		// Set bool based on inputs
		//if(view > 0.0f){
		//	firstperson = true;
		//}

		//if(view < 0.0f){
		//	firstperson = false;
		//}

		// Locate Camera

		//toffset = ship.transform.InverseTransformDirection (offset);
		//toffset2 = ship.transform.InverseTransformDirection (offset2);

		//if (firstperson) {
		//	transform.position = transform.TransformDirection (ship.transform.localPosition + toffset);
		//}
		//else {
		//	transform.position = transform.TransformDirection (ship.transform.localPosition + toffset2);
		//}

		//if(firstperson){
		//	cj.connectedAnchor.Set(0.0f, 5.0f, 4.0f);
		//}
		//else
		//{	
		//	cj.connectedAnchor.Set(0.0f, 2.0f, -6.0f);
		//}

		// Rotate Camera
		transform.rotation = ship.transform.rotation;
	}
}
