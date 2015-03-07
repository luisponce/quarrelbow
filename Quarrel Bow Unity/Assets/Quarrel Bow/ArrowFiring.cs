using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ArrowFiring : MonoBehaviour {

	public GameObject arrowPrefab;
	public Vector2 characterSize = new Vector2(0.4f, 3f);

	private Vector3 dir;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		dir = mousePosition - transform.position; //direction from shoter to mouse position
		dir.Normalize();


		Debug.DrawLine(transform.position, mousePosition, Color.blue);
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			ShootArrow(dir, 1000);

		}
	}

	void ShootArrow(Vector3 dir, float force){
		Vector3 pos = transform.position;
		pos.x += dir.x * characterSize.x;
		pos.y += dir.y * characterSize.y;

		Quaternion r = transform.rotation;
		r.SetLookRotation(Vector3.forward, -Vector3.Cross(dir,Vector3.forward));

		Debug.DrawRay(pos, dir*force, Color.red, 5f);

		GameObject cur =  (GameObject) Transform.Instantiate((Object) arrowPrefab, pos, r);
		cur.GetComponent<Rigidbody2D>().AddForce(cur.transform.right * force);
	}
}
