using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private LaserControl laser;
    [SerializeField] private Camera[] cameras;
    private AudioListener[] aud_list;

    private Camera activeCam;
    private int currCam = 0;
    

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
        laser.setMainCamera(activeCam);
    }

    // Update is called once per frame
    void Update()
    {
        keyCodeCheck();
    }

    private void keyCodeCheck()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cameraPositionChangeUp();
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    cameraPositionChangeDown();
        //}



    }

    private void cameraPositionChangeUp()
    {
        this.currCam++;

        if (this.currCam >= cameras.Length) this.currCam = 0;

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
            aud_list[i].enabled = false;
            if (i == this.currCam)
            {
                cameras[currCam].enabled = true;
                aud_list[currCam].enabled = true;
                this.activeCam = cameras[currCam];
                laser.setMainCamera(activeCam);
            }
        }
    }
    private void cameraPositionChangeDown()
    {
        this.currCam++;

        if (this.currCam <= cameras.Length) this.currCam = cameras.Length;

        for (int i = 0; i < cameras.Length; i--)
        {
            cameras[i].enabled = false;
            aud_list[i].enabled = false;
            if (i == this.currCam)
            {
                cameras[currCam].enabled = true;
                aud_list[currCam].enabled = true;
                this.activeCam = cameras[currCam];
                laser.setMainCamera(activeCam);
            }
        }
    }
}