using UnityEngine;
using System.Collections;

public class Shoky : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * -90f);
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    public void Kill()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        enabled = false;
    }
}
