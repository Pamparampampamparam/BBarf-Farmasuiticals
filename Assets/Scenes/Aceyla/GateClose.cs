using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] indicator;
    [SerializeField] AudioSource gateClose;
    Color red = new Color(200, 0, 0, 1);
    Color green = new Color(0, 200, 0, 1);

    private void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].transform.position.y >= 20f)
            {
                doors[i].transform.position -= new Vector3(0, 10, 0);
                indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
                gateClose.Play();
            }
            else if (doors[i].transform.position.y <= 10f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
                indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }
        }
    }

    //private void OnTriggerExit(Collider col)
    //{
        //for (int i = 0; i < doors.Length; i++)
        //{
            //if (doors[i].transform.position.y >= 20f)
            //{
                //doors[i].transform.position -= new Vector3(0, 10, 0);
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            //}
            //else if (doors[i].transform.position.y <= 25f)
            //{
                //Vector3 downPosition = new Vector3(doors[i].transform.position.x, 10f, doors[i].transform.position.z);
                //doors[i].transform.position = downPosition;
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            //}
        //}
    //}
}