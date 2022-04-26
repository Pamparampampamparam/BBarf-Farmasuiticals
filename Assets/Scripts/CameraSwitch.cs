using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private AudioListener[] aud_list;

    //public Camera Camera1;
    //public GameObject Camera2;
    //public AudioListener CamAuLis1;
    //public AudioListener CamAuLis2;
    private Camera activeCam;
    private int currCam = 0;
    private bool laserActive = true;

    //private [SerializeField] KeyCode;

    // Start is called before the first frame update
    void Start()
    {
        this.aud_list = new AudioListener[cameras.Length];
        for(int i = 0; i < cameras.Length; i++)
        {
            aud_list[i] = cameras[i].GetComponent<AudioListener>();
            aud_list[i].enabled = false;
        }
        cameras[0].enabled = true;
        aud_list[0].enabled = true;
        this.activeCam = cameras[0];
        //cameraPositionChange(0);
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
            //int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
            
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
            //PlayerPrefs.SetInt("CameraPosition", 0);
        }

        //PlayerPrefs.SetInt("CameraPosition", camPos);

        //if (camPos == 0)
        //{
        //    this.activeCam = Camera1.GetComponent<Camera>();
        //    Camera1.enabled = true;
        //    CamAuLis1.enabled = true;
        //
        //    Camera2.SetActive(false);
        //    CamAuLis2.enabled = false;
        //}
        //
        //if (camPos == 1)
        //{
        //    //activeCam.enabled = false;
        //    this.activeCam = Camera2.GetComponent<Camera>();
        //    Camera2.SetActive(true);
        //    CamAuLis2.enabled = true;
        //
        //    Camera1.enabled = false;
        //    CamAuLis1.enabled = false;
        //}

        for (int i = 0; i < cameras.Length; i++)
        {
            //if(i == camPos) ++i;

            //else
            //{
            //if (this.currCam == 0) i--;

                cameras[i].enabled = false;
                aud_list[i].enabled = false;
            if (i == this.currCam)
            {
                cameras[currCam].enabled = true;
                aud_list[currCam].enabled = true;
                this.activeCam = cameras[currCam];
                //i++;
            }
            //}

        }
        //cameras[camPos].enabled = true;
        //aud_list[camPos].enabled = true;
        //this.activeCam = cameras[camPos];
    }
}



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] Cameras;
    private AudioListener[] CamAuLis;
    private Camera activeCam;

    //private [SerializeField] KeyCode;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i <= Cameras.Length; i++)
        {
            this.CamAuLis[i] = Cameras[i].GetComponent<AudioListener>();
        }
        Cameras[0].active = true;
        CamAuLis[0].enabled = true;
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        switchCamera();
        Ray laserRay = activeCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(laserRay, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }
    }

    private void switchCamera()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            int camPosCounter = PlayerPrefs.GetInt("CameraPosition");
            camPosCounter++;
            cameraPositionChange(camPosCounter);
        }
    }

    private void cameraPositionChange(int camPos)
    {
        


        if (camPos > Cameras.Length)
        {
            camPos = 0;
        }

        PlayerPrefs.SetInt("CameraPosition", camPos);

        Cameras[camPos].active = true;
        CamAuLis[camPos].enabled = true;
        this.activeCam = Cameras[camPos].GetComponent<Camera>();


        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == camPos) i++;
            Cameras[i].active= false;
            CamAuLis[i].enabled = false;
        }

        //disableOtherCameras(camPos);
    }
}
*/
