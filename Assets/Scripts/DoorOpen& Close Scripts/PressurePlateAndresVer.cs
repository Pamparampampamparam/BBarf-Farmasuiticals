using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAndresVer : MonoBehaviour
{
    [SerializeField] GameObject doors;

    [SerializeField] float lift_height;

    private void OnTriggerEnter(Collider col)
    {
        GameObject Cat = col.gameObject;

        if (Cat.tag == "Repel")
        {
            doors.transform.position = new Vector3(doors.transform.position.x, doors.transform.position.y + lift_height, doors.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        GameObject Cat = col.gameObject;

        if (Cat.tag == "Repel")
        {
            doors.transform.position = new Vector3(doors.transform.position.x, doors.transform.position.y - lift_height, doors.transform.position.z);
        }
    }
}
