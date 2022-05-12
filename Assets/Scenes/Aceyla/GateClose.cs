using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    [SerializeField] GameObject[] doors; //FIIIIIXXXXX

    //bool isOpened = false;

    //void Update()
    //{
        //for (int i = 0; i < doors.Length; i++)
        //{
            //if (doors[i].transform.position.y >= 5.5f)
            //{
                //isOpened = true;
            //}
            //else if (doors[i].transform.position.y <= 1.5f)
            //{
                //isOpened = false;
            //}
        //}
    //}

    private void OnTriggerEnter(Collider col)
    {
        //if (isOpened == false)
        //{
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].transform.position.y >= 34f)
            {
                //isOpened = true;
                doors[i].transform.position -= new Vector3(0, 10, 0);
            }
            else if (doors[i].transform.position.y <= 24f)
            {
                Vector3 downPosition = new Vector3(doors[i].transform.position.x, 24f, doors[i].transform.position.z);
                doors[i].transform.position = downPosition;
            }
            //else
            //{
            //isOpened = true;
            //doors[i].transform.position -= new Vector3(0, 4, 0);
            //}

        }
        //}
    }

    private void OnTriggerExit(Collider col)
    {
        //if (isOpened == true)
        //{
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

            //isOpened = false;
            //doors[i].transform.position += new Vector3(0, 4, 0);
        }
        //}
    }
}