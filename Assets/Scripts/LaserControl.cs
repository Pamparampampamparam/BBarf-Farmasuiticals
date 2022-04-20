using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    //put into laser object
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray laserRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(laserRay, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }
}
