using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    private Camera activeCamera;
    void Start()
    {
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
