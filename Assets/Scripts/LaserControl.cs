using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    private Camera activeCamera;
    private bool laseractive = true;
    void Start()
    { }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (laseractive)
            {
                gameObject.SetActive(false);
                this.laseractive = false;
                //return false;
            }
            else
            {
                gameObject.SetActive(true);
                this.laseractive = true;
                //return true;
            }
            laserActive();
        }
    }

    public bool laserActive()
    {
        return this.laseractive;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = 1 << 0;

        Ray laserRay = activeCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(laserRay, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            transform.position = raycastHit.point;
        }
    }
    public void setMainCamera(Camera setCam)
    {
        activeCamera = setCam;
    }
}
