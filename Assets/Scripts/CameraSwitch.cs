using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private AudioListener[] aud_list;

    private Camera activeCam;
    private int currCam = 0;
    private bool laserActive = true;

    //private [SerializeField] KeyCode;

    // Start is called before the first frame update
    void Start()
    {
        this.aud_list = new AudioListener[cameras.Length];
        for (int i = 0; i < cameras.Length; i++)
        {
            aud_list[i] = cameras[i].GetComponent<AudioListener>();
            aud_list[i].enabled = false;
        }
        cameras[0].enabled = true;
        aud_list[0].enabled = true;
        this.activeCam = cameras[0];
    }

    // Update is called once per frame
    void Update()
    {
        keyCodeCheck();
        ActivateLaser();
    }

    private void keyCodeCheck()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (laserActive) this.laserActive = false;
            else { this.laserActive = true; }
        }
    }

    private void ActivateLaser()
    {
        if (laserActive)
        {
            Ray laserRay = activeCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(laserRay, out RaycastHit raycastHit))
            {
                transform.position = raycastHit.point;
            }
        }
    }

    private void cameraPositionChange()
    {
        this.currCam++;

        if (this.currCam >= cameras.Length)
        {
            this.currCam = 0;
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
            aud_list[i].enabled = false;
            if (i == this.currCam)
            {
                cameras[currCam].enabled = true;
                aud_list[currCam].enabled = true;
                this.activeCam = cameras[currCam];
            }
        }
    }
}