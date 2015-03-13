using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Android : MonoBehaviour
{
    public GameObject arms;

    private PlatformerCharacter2D character; 

    void Start()
    {
        character = GetComponent<PlatformerCharacter2D>();
    }

    void Update()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arms.transform.position;


        float angle = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg+ 90f;

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
}
