using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreen_GameManager : MonoBehaviour
{
    public enum Scene
    {
        Level0_Tutorial, 
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Load(Scene.Level0_Tutorial);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Load(Scene.Level0_Tutorial);
        }
    }
}
