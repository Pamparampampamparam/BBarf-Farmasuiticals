using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    [SerializeField] private Camera currentCamera;
    private bool laseractive = true;
    [SerializeField] private MeshRenderer lasermesh;
    void Start()
    { }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (laseractive)
            {
                lasermesh.enabled = false;
                this.laseractive = false;
                //return false;
            }
            else
            {
                lasermesh.enabled = true;
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

        Ray laserRay = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(laserRay, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            transform.position = raycastHit.point;
        }
    }
}
