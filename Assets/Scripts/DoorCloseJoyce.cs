using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseJoyce : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] indicator;
    Color red = new Color(200, 0, 0, 1);
    Color green = new Color(0, 200, 0, 1);
    [SerializeField] bool recovery;
    Vector3[] originPos;
    List<GameObject> active = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            originPos = new Vector3[doors.Length];
            originPos[i] = doors[i].transform.position;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        active.Add(col.gameObject);
        for (int i = 0; i < doors.Length; i++)
        {
            /*if (doors[i].transform.position.y >= 20f)
            {
                doors[i].transform.position -= new Vector3(0, 10, 0);
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }
            else if(doors[i].transform.position.y <= 10f) 
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }*/
            doors[i].transform.position = new Vector3(doors[i].transform.position.x, 5.13f, doors[i].transform.position.z);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        active.Remove(col.gameObject);
        for (int i = 0; i < doors.Length; i++)
        {
            if (recovery && active.Count == 0)
                doors[i].transform.position = originPos[i];
            else
                return;
            /*if (doors[i].transform.position.y >= 20f)
            {
                doors[i].transform.position -= new Vector3(0, 10, 0);
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }
            else if (doors[i].transform.position.y <= 10f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }*/
        }
    }
}
