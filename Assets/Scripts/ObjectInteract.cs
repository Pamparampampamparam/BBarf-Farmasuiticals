using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    //put script into cat object
    private GameObject heldObj;
    private GameObject boolObj;
    private GameObject composite;
    Vector3 currentPosition;

    //From how far away are you able to pick up objects
    [SerializeField] private float pickUpRange = 5;

    //How Strong is the movement force of the player
    [SerializeField] private float moveForce = 250;

    //How far away from the player will the objects be held?
    //Add an empty gameobject as a child of the player character, position it in front of the character and set it as the holdParent
    [SerializeField] private Transform holdParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
    }

    private void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange) && hit.transform.gameObject.tag == "PickUp")
                {
                    PickupObject(hit.transform.gameObject);
                    //print(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (Input.GetMouseButtonDown(0) && heldObj != null)//Perform Boolean Subtraction
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                boolObj = hit.transform.gameObject;
            }
            //DoBooleanOperation(true);
        }
        else if (Input.GetMouseButtonDown(1) && heldObj != null)//perform Boolean Subtraction
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                boolObj = hit.transform.gameObject;
            }
            //DoBooleanOperation(false);
        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    //Object Handling Stuff
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;
            objRig.transform.parent = holdParent;
            heldObj = pickObj;
            pickObj.GetComponent<Collider>().enabled = false;
        }
    }

    void DropObject()
    {
        heldObj.GetComponent<Collider>().enabled = true;

        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
