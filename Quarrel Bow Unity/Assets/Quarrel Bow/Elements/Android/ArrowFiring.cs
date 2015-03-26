using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ArrowFiring : MonoBehaviour {

	public GameObject arrowPrefab;
	public Vector2 characterSize = new Vector2(0.4f, 3f);
    public GameObject androidBody;

	public float timeToReachMaxForce;
	public float maxForce;
	public float minForce;
    public float reloadTime; 

	private Vector3 dir;
	private float timerFiring; //time between the press of the button and the release and shoot of the arrow
    private bool shooting = false;

	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		dir = mousePosition - transform.position; //direction from shoter to mouse position
		dir.Normalize();

		Debug.DrawLine(transform.position, mousePosition, Color.blue);
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			ShootArrow(dir, maxForce * timerFiring/timeToReachMaxForce);
			timerFiring = 0;
		} else if(Input.GetKey(KeyCode.Mouse0)){
			if(timerFiring < timeToReachMaxForce){
				timerFiring += Time.deltaTime;
			} else {
				timerFiring = timeToReachMaxForce;
			}
		}
	}

	void ShootArrow(Vector3 dir, float force){
        if (shooting)
        {
            return;
        }
        shooting = true;
        androidBody.GetComponent<Animator>().SetBool("Shoot", shooting);
		if (force < minForce){
			force = minForce;
		}
		Vector3 pos = transform.position;
		pos.x += dir.x * characterSize.x;
		pos.y += dir.y * characterSize.y;

		Quaternion r = transform.rotation;
		r.SetLookRotation(Vector3.forward, -Vector3.Cross(dir,Vector3.forward));

		Debug.DrawRay(pos, dir*(force/maxForce)*10, Color.red, 5f);

		GameObject cur =  (GameObject) Transform.Instantiate((Object) arrowPrefab, pos, r);
		cur.GetComponent<Rigidbody2D>().AddForce(cur.transform.right * force);
        StartCoroutine(Reload());
	}

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        shooting = false;
        androidBody.GetComponent<Animator>().SetBool("Shoot", shooting);
    }
}
