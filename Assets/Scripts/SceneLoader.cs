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

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Level 0 Portal")
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (other.gameObject.tag == "Level1")
        {
        //    SceneManager.LoadScene("Level One");
        }
        if (other.gameObject.tag == "Level2")
        {
            SceneManager.LoadScene("AcelyaLvl");
        }
        if (other.gameObject.tag == "Level3")
        {
        //    SceneManager.LoadScene("Level Three");
        }

        if (other.gameObject.tag == "Level4")
        {
            SceneManager.LoadScene("Andres Sample Scene 2");
        }

        if (other.gameObject.tag == "Level5")
        {
        //    SceneManager.LoadScene("Level Five");
        }
    }
}