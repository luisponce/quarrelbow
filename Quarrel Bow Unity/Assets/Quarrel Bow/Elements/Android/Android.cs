using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Android : MonoBehaviour
{
    public GameObject arms;

    private PlatformerCharacter2D character;
    private GameObject respawnPlace;

    void Start()
    {
        character = GetComponent<PlatformerCharacter2D>();
        respawnPlace = new GameObject("Spawn");
        respawnPlace.transform.position = transform.position;
    }

    void Update()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arms.transform.position;


        float angle = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg+ 90f;
        while (angle < 0)
        {
            angle += 360;
        }

        if (angle > 180 && character.FacingRight)
        {
            character.Flip();
        }
        else if (angle < 180 && !character.FacingRight)
        {
            character.Flip();
        }

        if (angle > 180)
        {
            angle = 360f - angle;
        }
        arms.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Kill()
    {
        transform.position = respawnPlace.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == (int)ELayer.Enemy)
        {
            if (collider.gameObject.GetComponent<Shoky>())
            {
                if (collider.gameObject.GetComponent<Shoky>().alive)
                {
                    Kill();
                }
            }
            else
            {
                Kill();
            }
        }
    }
}
