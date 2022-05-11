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
    }

    private void cameraPositionChange()
    {
        if (this.cam_it >= cameraPos.Length) { this.cam_it = 0; }
        else if (this.cam_it < 0) { this.cam_it =  cameraPos.Length - 1; }

        this.curr_camera.transform.position = cameraPos[this.cam_it].position;
        this.curr_camera.transform.rotation = cameraPos[this.cam_it].rotation;
    }
}