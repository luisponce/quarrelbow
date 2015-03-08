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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * -90f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * -90f);
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}
