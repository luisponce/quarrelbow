using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public EArrowState state;

	void Update () {
        if (state == EArrowState.Moving)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            transform.rotation = Quaternion.Euler(Vector3.forward * (Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg));
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)ELayer.Wall)
        {
            state = EArrowState.Platform;
        }
        else
        {
            state = EArrowState.Ignored;
        }
    }
}
