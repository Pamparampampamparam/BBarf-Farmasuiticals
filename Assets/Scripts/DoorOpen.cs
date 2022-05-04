using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    //[SerializeField] GameObject door;
    [SerializeField] GameObject[] doors;

    bool isOpened = false;

    private void OnTriggerEnter(Collider col)
    {
        if(isOpened == false)
        {
            for(int i = 0; i < doors.Length; i++)
            {
                if (doors[i].transform.position.y >= 5.5f)
                {
                    Vector3 upPosition = new Vector3(doors[i].transform.position.x, 5.5f, doors[i].transform.position.z);
                    doors[i].transform.position = upPosition;
                }
                else if (doors[i].transform.position.y <= 1.5f)
                {
                    isOpened = true;
                    doors[i].transform.position += new Vector3(0, 4, 0);
                }
                //else
                //{
                    //isOpened = true;
                    //doors[i].transform.position += new Vector3(0, 4, 0);
                //}
            }
        }
        //if(isOpened == false)
        //{
            //isOpened = true;
            //door.transform.position += new Vector3(0, 4, 0);
        //}
    }

    private void OnTriggerExit(Collider col)
    {
        //if (isOpened == true)
        //{
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].transform.position.y >= 5.5f)
                {
                    doors[i].transform.position -= new Vector3(0, 4, 0);
                }
                else if (doors[i].transform.position.y <= 1.5f)
                {
                    Vector3 downPosition = new Vector3(doors[i].transform.position.x, 1.5f, doors[i].transform.position.z);
                    doors[i].transform.position = downPosition;
                }
                //isOpened = false;
                //doors[i].transform.position -= new Vector3(0, 4, 0);
            }
        //}
        //if (isOpened == true)
        //{
            //isOpened = false;
           // door.transform.position -= new Vector3(0, 4, 0);
        //}
    }
}
