using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<Animator>().SetBool("Pressed", true);
        door.GetComponent<Animator>().SetBool("Open", true);
    }
}
