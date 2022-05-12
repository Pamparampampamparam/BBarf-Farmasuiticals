using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] indicator;
    Color red = new Color(200, 0, 0, 1);
    Color green = new Color(0, 200, 0, 1);

    private void OnTriggerEnter(Collider col)
    {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].transform.position.y >= 20f)
                {
                    Vector3 upPosition = new Vector3(doors[i].transform.position.x, 20f, doors[i].transform.position.z);
                    doors[i].transform.position = upPosition;
                    indicator[i].GetComponent<Renderer>().material.SetColor("_Color", green);
                }
                else if (doors[i].transform.position.y <= 10f)
                {
                    doors[i].transform.position += new Vector3(0, 10, 0);
                    indicator[i].GetComponent<Renderer>().material.SetColor("_Color", green);
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
                indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }
            else if (doors[i].transform.position.y <= 10f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
                indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }
        }
    }
}