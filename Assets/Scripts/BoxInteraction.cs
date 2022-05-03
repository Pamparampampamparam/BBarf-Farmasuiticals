using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;
    bool hidden = false;
    private Vector3 spawnpos;
    private Quaternion rotation;


    void Update()
    {
        if (hidden == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Coming out!");
            cat.SetActive(true);
            Instantiate(cat, spawnpos, rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        ContactPoint contact = collision.contacts[0];
        spawnpos = contact.point;
        rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        if (gameObject.tag == "Box" && hidden == false)
        {
            cat.SetActive(false);
            hidden = true;
            Debug.Log("Box detected!");
        }
    }
}
