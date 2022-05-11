using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    private Component[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            foreach (Button b in buttons)
            {
                ColorBlock cb = b.colors;
                if (b.gameObject.name == "1" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.green;
                    b.colors = cb;
                }
                if (b.gameObject.name != "1" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.white;
                    b.colors = cb;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Button b in buttons)
            {
                ColorBlock cb = b.colors;
                if (b.gameObject.name == "2" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.green;
                    b.colors = cb;
                }
                if (b.gameObject.name != "2" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.white;
                    b.colors = cb;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Button b in buttons)
            {
                ColorBlock cb = b.colors;
                if (b.gameObject.name == "3" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.green;
                    b.colors = cb;
                }
                if (b.gameObject.name != "3" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.white;
                    b.colors = cb;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (Button b in buttons)
            {
                ColorBlock cb = b.colors;
                if (b.gameObject.name == "4" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.green;
                    b.colors = cb;
                }
                if (b.gameObject.name != "4" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.white;
                    b.colors = cb;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (Button b in buttons)
            {
                ColorBlock cb = b.colors;
                if (b.gameObject.name == "5" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.green;
                    b.colors = cb;
                }
                if (b.gameObject.name != "5" && b.gameObject.tag == "CamButton")
                {
                    cb.normalColor = Color.white;
                    b.colors = cb;
                }
            }
        }
    }
}
