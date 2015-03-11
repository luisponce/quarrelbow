using UnityEngine;
using System.Collections;

public class Android : MonoBehaviour
{
    public GameObject arms;

    void Start()
    {

    }

    void Update()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arms.transform.position;
        float angle = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg+ 90f;
        arms.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
