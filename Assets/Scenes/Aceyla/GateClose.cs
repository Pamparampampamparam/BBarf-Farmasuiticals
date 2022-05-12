using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    [SerializeField] GameObject[] doors; //FIIIIIXXXXX

    private void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].transform.position.y >= 34f)
            {
                doors[i].transform.position -= new Vector3(0, 10, 0);
            }
            else if (doors[i].transform.position.y <= 24f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 24f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].transform.position.y >= 34f)
            {
                doors[i].transform.position -= new Vector3(0, 10, 0);
                Vector3 upPosition = new Vector3(doors[i].transform.position.x, 34f, doors[i].transform.position.z);
                doors[i].transform.position = upPosition;
            }
            else if (doors[i].transform.position.y <= 24f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 20f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
            }
        }
    }
}