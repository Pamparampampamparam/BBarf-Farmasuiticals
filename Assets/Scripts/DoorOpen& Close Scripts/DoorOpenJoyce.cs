using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenJoyce : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] indicator;
    [SerializeField] AudioSource switchAudio;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    Color red = new Color(200, 0, 0, 1);
    Color green = new Color(0, 200, 0, 1);

    [SerializeField] float lift_height;
    List<GameObject> active = new List<GameObject>();

    private void OnTriggerEnter(Collider col)
    {
        active.Add(col.gameObject);
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].transform.position.y <= 10) 
            {
                doors[i].transform.position = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y+lift_height, doors[i].transform.position.z);
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", green);
            }
        }
        if (active.Count == 1)
        {
            switchAudio.clip = clip1;
            switchAudio.Play();
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        active.Remove(col.gameObject);
        for (int i = 0; i < doors.Length; i++)
        {
            if (active.Count == 0)
            {
                doors[i].transform.position = new Vector3(doors[i].transform.position.x, doors[i].transform.position.y - lift_height, doors[i].transform.position.z);
                //indicator[i].GetComponent<Renderer>().material.SetColor("_Color", red);
            }
        }
        if (active.Count == 0)
        {
            switchAudio.clip = clip2;
            switchAudio.Play();
        }
        
    }
}
