using UnityEngine;
using System.Collections;

public class Shoky : MonoBehaviour
{

    public float speed;

    private bool alive = true;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (alive)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * -90f);
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
    }

    public void Kill()
    {
        alive = false;
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        enabled = false;
    }
}
