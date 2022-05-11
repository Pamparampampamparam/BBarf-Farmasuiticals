using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] float lift_height;

    private void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].transform.position = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y+lift_height, doors[i].transform.position.z);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].transform.position = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y - lift_height, doors[i].transform.position.z);
        }
    }
}
