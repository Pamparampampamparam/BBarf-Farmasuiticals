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

    //public void OnCollisionEnter(Collision collision)
    //{
    //if (collision.gameObject.layer == 6)
    //{
    //isClimbing = true;
    //Debug.Log("Climbing");
    //}
    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //isClimbing = false;
    //Debug.Log("Not Climbing");
    //}

    public void OnCollisionStay(Collision collision)
    {
        isClimbing = true;
        Debug.Log("Climbing!!!!");
    }

    public void OnCollisionExit(Collision collision)
    {
        isClimbing = false;
    }
}
