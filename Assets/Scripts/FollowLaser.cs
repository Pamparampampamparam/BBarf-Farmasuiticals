using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLaser : MonoBehaviour
{
    //put script into cat object
    [SerializeField] private GameObject laser;
    [SerializeField] private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, laser.transform.position) < 5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, laser.transform.position, speed * Time.deltaTime);
            transform.up = laser.transform.position - transform.position;
        }
        
    }
}
