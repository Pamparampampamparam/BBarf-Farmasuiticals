using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;
    bool hidden = false;
    private Vector3 spawnpos = new Vector3 (2, 0, 0);
    //private Quaternion rotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ComeOut();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        ContactPoint contact = collision.contacts[0];
        //spawnpos = contact.point;
        //rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        if (gameObject.tag == "In_Box" && hidden == false)
        {
            hidden = true;
            cat.transform.position = new Vector3(1000, 1000, 1000);
            Debug.Log("Box detected!");
            Debug.Log(hidden);
        }
    }

    void ComeOut()
    {
        if (hidden == true)
        {
            GameObject outBox = GameObject.FindGameObjectWithTag("Out_Box");
            cat.transform.position = outBox.transform.position + spawnpos;
            hidden = false;
            Debug.Log("Coming out!");
        }
    }
}
