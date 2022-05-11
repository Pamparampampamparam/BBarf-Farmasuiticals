using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera curr_camera;
    public int cam_it = 0;
    [SerializeField] private Transform[] cameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        this.curr_camera.transform.position = cameraPos[this.cam_it].position;
        this.curr_camera.transform.rotation = cameraPos[this.cam_it].rotation;
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
            ++this.cam_it;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            --this.cam_it;
            cameraPositionChange();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            this.cam_it = 0;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.cam_it = 1;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.cam_it = 2;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.cam_it = 3;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.cam_it = 4;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            this.cam_it = 5;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            this.cam_it = 6;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            this.cam_it = 7;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            this.cam_it = 8;
            cameraPositionChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            this.cam_it = 9;
            cameraPositionChange();
        }
    }

    private void cameraPositionChange()
    {
        if (this.cam_it >= cameraPos.Length) { this.cam_it = 0; }
        else if (this.cam_it < 0) { this.cam_it =  cameraPos.Length - 1; }

        this.curr_camera.transform.position = cameraPos[this.cam_it].position;
        this.curr_camera.transform.rotation = cameraPos[this.cam_it].rotation;
    }

   
}