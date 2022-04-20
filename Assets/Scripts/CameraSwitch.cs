using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public AudioListener CamAuLis1;
    public AudioListener CamAuLis2;
    private Camera activeCam;

    //private [SerializeField] KeyCode;

    // Start is called before the first frame update
    void Start()
    {
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
            cameraChangeIterator();
        }
    }

    private void cameraChangeIterator()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    private void cameraPositionChange(int camPos)
    {
        


        if (camPos > 1)
        {
            camPos = 0;
        }

        PlayerPrefs.SetInt("CameraPosition", camPos);

        if (camPos == 0)
        {
            this.activeCam = Camera1.GetComponent<Camera>();
            Camera1.SetActive(true);
            CamAuLis1.enabled = true;

            Camera2.SetActive(false);
            CamAuLis2.enabled = false;
        }

        if (camPos == 1)
        {
            this.activeCam = Camera2.GetComponent<Camera>();
            Camera2.SetActive(true);
            CamAuLis2.enabled = true;

            Camera1.SetActive(false);
            CamAuLis1.enabled = false;
        }



        //for (int i = 0; i < Cameras.Length; i++)
        //{
        //    if(i != camPos)
        //    {
        //        Cameras[camPos].SetActive(false);
        //        CameraAudioListener[camPos].enabled = false;
        //    }
        //    else
        //    {
        //        Cameras[i].SetActive(true);
        //        CameraAudioListener[i].enabled = true;
        //    }
        //}

        //disableOtherCameras(camPos);
    }
}
