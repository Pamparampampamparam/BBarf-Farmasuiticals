using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;
    //bool hidden = false;
    private Vector3 spawnpos = new Vector3 (0.0f, 0.0f, 1f);
    //private Quaternion rotation;
    [SerializeField] List<GameObject> inBoxes = new List<GameObject> ();
    [SerializeField] List<GameObject> outBoxes = new List<GameObject>();

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
            ComeOut();*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        ContactPoint contact = collision.contacts[0];
        //spawnpos = contact.point;
        //rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        if (gameObject.tag == "In_Box")
        {
            int index = inBoxes.IndexOf(gameObject);
            //hidden = true;
            Vector3 boxPos = outBoxes[index].transform.position;
            Debug.Log(boxPos);
            cat.transform.position = boxPos + spawnpos;
            Debug.Log(cat.transform.position);
            //Debug.Log(hidden);
        }
    }

    /*void ComeOut()
    {
        if (hidden == true)
        {
            GameObject outBox = GameObject.FindGameObjectWithTag("Out_Box");
            cat.transform.position = outBox.transform.position + spawnpos;
            hidden = false;
            Debug.Log("Coming out!");
        }
    }*/
}
