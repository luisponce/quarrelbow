using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    [SerializeField]
    private EArrowState state;

	void Start(){
		GetComponent<BoxCollider2D>().usedByEffector = false;
	}

	void Update () {
        if (State == EArrowState.Moving)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            transform.rotation = Quaternion.Euler(Vector3.forward * (Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg));
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (state != EArrowState.Moving)
        {
            return;
        }
        if (collision.gameObject.layer == (int)ELayer.Wall)
        {
            float angle = Mathf.Abs(Vector2.Angle(Vector2.right, transform.right));
            State = EArrowState.Platform;
			LockInPlace(collision.contacts[0].point);
			this.transform.SetParent(collision.gameObject.transform);
        }
        else if (collision.gameObject.layer == (int)ELayer.Enemy)
        {
            transform.Translate(transform.forward * 1.5f);
            transform.SetParent(collision.transform);
            collision.transform.GetComponent<Shoky>().Kill();
            collision.transform.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<BoxCollider2D>());
            State = EArrowState.Ignored;
        }
        else
        {
            Debug.Log(((ELayer)collision.gameObject.layer) + ", " + collision.gameObject.name);
            State = EArrowState.Ignored;
            Destroy(gameObject, 10f);
        }
    }

	void LockInPlace(Vector2 place){
		transform.position = new Vector2(transform.position.x, place.y);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, -Vector3.Cross(Vector3.right,Vector3.forward));

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		rb.velocity = new Vector3(0,0,0);
		rb.isKinematic = true;
		GetComponent<BoxCollider2D>().usedByEffector = true;
	}

    public EArrowState State
    {
        get { return state; }
        set
        {
            state = value;
            //Debug.Log(state);
            if (value == EArrowState.Ignored)
            {
                gameObject.layer = (int)ELayer.Ignore;
            }
            else if (value == EArrowState.Platform)
            {
                gameObject.layer = (int)ELayer.Ground;
            }
        }
    }
}