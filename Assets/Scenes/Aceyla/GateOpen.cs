using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    private void OnTriggerEnter(Collider col)
    {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].transform.position.y >= 34f)
                {
                    Vector3 upPosition = new Vector3(doors[i].transform.position.x, 34f, doors[i].transform.position.z);
                    doors[i].transform.position = upPosition;
                }
                else if (doors[i].transform.position.y <= 24f)
                {
                    doors[i].transform.position += new Vector3(0, 10, 0);
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
            }
            else if (doors[i].transform.position.y <= 24f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 24f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
            }
        }
    }
}