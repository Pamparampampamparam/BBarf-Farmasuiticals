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
        ComeOut();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        ContactPoint contact = collision.contacts[0];
        spawnpos = contact.point;
        rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        if (gameObject.tag == "Box" && hidden == false)
        {
            hidden = true;
            cat.SetActive(false);
            Debug.Log("Box detected!");
            Debug.Log(hidden);
        }
    }

    void ComeOut()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hidden == true)
        {
            cat.SetActive(true);
            Debug.Log(cat.activeSelf);
            Instantiate(cat, spawnpos, rotation);
            //Debug.Log("Coming out!");
        }
    }
}
