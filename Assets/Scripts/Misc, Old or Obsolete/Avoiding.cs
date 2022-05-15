using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoiding : MonoBehaviour
{
    private Vector3 target;
    public float smoothtime = 100f;
    public float maxspeed = 50f;
    private Vector3 vel = Vector3.zero;
    private bool escaping = false;
    private IEnumerator co;
  
    // Update is called once per frame
    void Update()
    {
        if (!escaping)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, 0, 5), ref vel, smoothtime * Time.deltaTime, maxspeed);
    }
      
    private void OnTriggerEnter(Collider other)
    {
        target = other.transform.position * -3;
        escaping = true;
        co = Escape(target, (float)(smoothtime / 1.5));
        StartCoroutine(co);
        print("Running towards " + target);
        }

    private IEnumerator Escape(Vector3 tar, float speed)
    {
        while (escaping)
        {
            yield return transform.position = Vector3.SmoothDamp(transform.position, tar, ref vel, speed * Time.deltaTime, maxspeed);
        }
        if (Vector3.Distance(transform.position, tar) <= 0.2)
            yield return escaping = false;
    }

}
