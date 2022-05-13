using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera curr_camera;
    [SerializeField] private Component buttonsOverlay;
    private Component[] buttons;
    public int cam_it = 0;
    [SerializeField] private Transform[] cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        buttons = buttonsOverlay.GetComponentsInChildren<Button>();
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            ++this.cam_it;
            cameraPositionChange();
        
        }
        if (Input.GetKeyDown(KeyCode.Q))
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

    private void UpdateCameraButtons()
    {
        string buttonNum = this.cam_it.ToString();
        foreach (Button b in buttons)
        {
            ColorBlock cb = b.colors;
            if (b.gameObject.name == buttonNum && b.gameObject.tag == "CamButton")
            {
                cb.normalColor = Color.green;
                b.colors = cb;
            }
            if (b.gameObject.name != buttonNum && b.gameObject.tag == "CamButton")
            {
                cb.normalColor = Color.white;
                b.colors = cb;
            }
        }
    }

    private void ButtonClick()
    {

    }

    private void cameraPositionChange()
    {
        if (this.cam_it >= cameraPos.Length) { this.cam_it = 0; }
        else if (this.cam_it < 0) { this.cam_it =  cameraPos.Length - 1; }

        this.curr_camera.transform.position = cameraPos[this.cam_it].position;
        this.curr_camera.transform.rotation = cameraPos[this.cam_it].rotation;

        UpdateCameraButtons();
    }
}