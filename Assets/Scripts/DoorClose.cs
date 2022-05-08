using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    private void OnTriggerEnter(Collider col)
    {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].transform.position.y >= 20f)
                {
                    doors[i].transform.position -= new Vector3(0, 10, 0);
                }
                else if(doors[i].transform.position.y <= 10f) 
                {
                    Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                    doors[i].transform.position = downPosition;
                }
            }
    }

    private void OnTriggerExit(Collider col)
    {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].transform.position.y >= 20f)
                {
                    doors[i].transform.position -= new Vector3(0, 10, 0);
                }
                else if (doors[i].transform.position.y <= 10f)
                {
                    Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                    doors[i].transform.position = downPosition;
                }
            }
    }
}