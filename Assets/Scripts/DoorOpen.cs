using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] indicator;
    Color red = new Color(200, 0, 0, 1);
    Color green = new Color(0, 200, 0, 1);

    [SerializeField] float lift_height;

    private void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].transform.position = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y+lift_height, doors[i].transform.position.z);
            //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", green);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].transform.position = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y - lift_height, doors[i].transform.position.z);
            //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
        }
    }
}
