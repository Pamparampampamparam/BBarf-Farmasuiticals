using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : MonoBehaviour
{
    //improvements need to be made to this!!!
    Rigidbody cat;

    // Start is called before the first frame update
    void Start()
    {
        cat = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "climb")
        {
            cat.useGravity = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        cat.useGravity = true;
    }
}
