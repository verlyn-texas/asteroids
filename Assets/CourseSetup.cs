using UnityEngine;
using System.Collections;

public class CourseSetup : MonoBehaviour {

	public Transform myRock1;
	public Transform myRock2;
	public Transform myRock3;
	public Transform myRock4;

	private Transform thisRock;
	private float xloc, yloc, zloc;
	private float xvel, yvel, zvel;
	private float xrot, yrot, zrot;
	private float xtorq, ytorq, ztorq;
	private Rigidbody rb;
	private GameObject myRockGameObject;
	private Vector3 locVector;
	private Vector3 mytoDirection;
	private Vector3 torqueVector;
	private Vector3 forceVector;

	// Use this for initialization
	void Start () {
		//myRock1
		for (var x = 0; x < 1000; x++) {

			xloc = Random.Range (-200, 1300);
			yloc = Random.Range (-200, 200);
			zloc = Random.Range (-200, 1700);
			locVector = new Vector3 (xloc, yloc, zloc);
			thisRock = (Transform)Instantiate (myRock1, locVector, Quaternion.identity);
			rb = thisRock.GetComponent<Rigidbody> ();

			xvel = Random.Range (-10, 10);
			yvel = Random.Range (-10, 10);
			zvel = Random.Range (-10, 10);
			forceVector = new Vector3 (xvel, yvel, zvel);
			rb.AddRelativeForce(forceVector,ForceMode.VelocityChange);

			xrot = Random.Range (-10, 10);
			yrot = Random.Range (-10, 10);
			zrot = Random.Range (-10, 10);
			mytoDirection = new Vector3 (xrot, yrot, zrot);
			rb.rotation.SetFromToRotation (rb.transform.forward, mytoDirection);

			xtorq = Random.Range (-2, 2);
			ytorq = Random.Range (-2, 2);
			ztorq = Random.Range (-2, 2);
			torqueVector = new Vector3 (xtorq, ytorq, ztorq);
			rb.AddRelativeTorque (torqueVector, ForceMode.VelocityChange);
		}
		//myRock2
		for (var x = 0; x < 1000; x++) {

			xloc = Random.Range (-200, 1300);
			yloc = Random.Range (-200, 200);
			zloc = Random.Range (-200, 1700);
			locVector = new Vector3 (xloc, yloc, zloc);
			thisRock = (Transform)Instantiate (myRock2, locVector, Quaternion.identity);
			rb = thisRock.GetComponent<Rigidbody> ();

			xvel = Random.Range (-10, 10);
			yvel = Random.Range (-10, 10);
			zvel = Random.Range (-10, 10);
			forceVector = new Vector3 (xvel, yvel, zvel);
			rb.AddRelativeForce(forceVector,ForceMode.VelocityChange);

			xrot = Random.Range (-10, 10);
			yrot = Random.Range (-10, 10);
			zrot = Random.Range (-10, 10);
			mytoDirection = new Vector3 (xrot, yrot, zrot);
			rb.rotation.SetFromToRotation (rb.transform.forward, mytoDirection);

			xtorq = Random.Range (-2, 2);
			ytorq = Random.Range (-2, 2);
			ztorq = Random.Range (-2, 2);
			torqueVector = new Vector3 (xtorq, ytorq, ztorq);
			rb.AddRelativeTorque (torqueVector, ForceMode.VelocityChange);
		}
		//myRock3
		for (var x = 0; x < 1000; x++) {

			xloc = Random.Range (-200, 1300);
			yloc = Random.Range (-200, 200);
			zloc = Random.Range (-200, 1700);
			locVector = new Vector3 (xloc, yloc, zloc);
			thisRock = (Transform)Instantiate (myRock3, locVector, Quaternion.identity);
			rb = thisRock.GetComponent<Rigidbody> ();

			xvel = Random.Range (-10, 10);
			yvel = Random.Range (-10, 10);
			zvel = Random.Range (-10, 10);
			forceVector = new Vector3 (xvel, yvel, zvel);
			rb.AddRelativeForce(forceVector,ForceMode.VelocityChange);

			xrot = Random.Range (-10, 10);
			yrot = Random.Range (-10, 10);
			zrot = Random.Range (-10, 10);
			mytoDirection = new Vector3 (xrot, yrot, zrot);
			rb.rotation.SetFromToRotation (rb.transform.forward, mytoDirection);

			xtorq = Random.Range (-2, 2);
			ytorq = Random.Range (-2, 2);
			ztorq = Random.Range (-2, 2);
			torqueVector = new Vector3 (xtorq, ytorq, ztorq);
			rb.AddRelativeTorque (torqueVector, ForceMode.VelocityChange);
		}
		//myRock4
		for (var x = 0; x < 1000; x++) {

			xloc = Random.Range (-200, 1300);
			yloc = Random.Range (-200, 200);
			zloc = Random.Range (-200, 1700);
			locVector = new Vector3 (xloc, yloc, zloc);
			thisRock = (Transform)Instantiate (myRock4, locVector, Quaternion.identity);
			rb = thisRock.GetComponent<Rigidbody> ();

			xvel = Random.Range (-10, 10);
			yvel = Random.Range (-10, 10);
			zvel = Random.Range (-10, 10);
			forceVector = new Vector3 (xvel, yvel, zvel);
			rb.AddRelativeForce(forceVector,ForceMode.VelocityChange);

			xrot = Random.Range (-10, 10);
			yrot = Random.Range (-10, 10);
			zrot = Random.Range (-10, 10);
			mytoDirection = new Vector3 (xrot, yrot, zrot);
			rb.rotation.SetFromToRotation (rb.transform.forward, mytoDirection);

			xtorq = Random.Range (-2, 2);
			ytorq = Random.Range (-2, 2);
			ztorq = Random.Range (-2, 2);
			torqueVector = new Vector3 (xtorq, ytorq, ztorq);
			rb.AddRelativeTorque (torqueVector, ForceMode.VelocityChange);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
