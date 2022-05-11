using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            //SceneManager.LoadScene(currentScene);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Level 0 Portal")
        {
            SceneManager.LoadScene("Level0_Tutorial");
        }
        if (other.gameObject.tag == "Level1")
        {
            SceneManager.LoadScene("Level1_Emma");
        }
        if (other.gameObject.tag == "Level2")
        {
            SceneManager.LoadScene("Level2_Acelya");
        }
        if (other.gameObject.tag == "Level3")
        {
            SceneManager.LoadScene("Level3_Ben");
        }
        if (other.gameObject.tag == "Level4")
        {
            SceneManager.LoadScene("Level4_Andres");
        }
        if (other.gameObject.tag == "Level5")
        {
            SceneManager.LoadScene("Level5_Joyce");
        }
    }
}