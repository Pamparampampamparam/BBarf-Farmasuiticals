using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    //put into laser object
    //[SerializeField] private Camera mainCamera;
    //CameraSwitch camswitch = new CameraSwitch();

    private Camera activeCamera;
    public LayerMask laserMask;

    // Start is called before the first frame update
    void Start()
    {
        //laserMask.value = 1 << 6;
        //laserMask = ~laserMask;
    }

    // Update is called once per frame
    void Update()
    {
        //int laserMask = 1 << 6;
        //laserMask = ~laserMask;

        Ray laserRay = activeCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(laserRay, out RaycastHit raycastHit))
        {
            //if(Physics.Linecast(laserRay, out, laserMask) )
            transform.position = raycastHit.point;
        }
    }
    public void setMainCamera(Camera setCam)
    {
        activeCamera = setCam;
    }
}
//comment to commit
