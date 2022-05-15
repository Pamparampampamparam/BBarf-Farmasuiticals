using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : MonoBehaviour
{
    //improvements need to be made to this!!!
    Rigidbody cat;
    public bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        cat = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionStay(Collision collision)
    {
        isClimbing = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        isClimbing = false;
    }
}
