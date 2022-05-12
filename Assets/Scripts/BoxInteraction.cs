using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    [SerializeField] Vector3 spawnPointOffset = new Vector3(0.0f, 1f, 0f);
    public bool isInputOnly;
    public bool isOutputOnly;
    [SerializeField] GameObject ConnectedBox;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Cat = collision.gameObject;

        if(Cat.tag == "Repel")
        {
            if (isInputOnly && ConnectedBox.GetComponent<BoxInteraction>().isOutputOnly)
            {
                Cat.transform.position = ConnectedBox.transform.position + spawnPointOffset;
            }
        }
    }
}
