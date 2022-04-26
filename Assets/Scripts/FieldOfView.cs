using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0f, 360f)]
    public float angle;

    public GameObject laserPointer;
    [SerializeField] private float checkDelay = 0.2f;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool laserPointerVisible;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer = GameObject.FindGameObjectWithTag("LaserPointer");
        StartCoroutine(FOVRoutiune(checkDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FOVRoutiune(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        while (true)
        {
            yield return wait;
            FOVCheck();
        }
    }
    private void FOVCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    laserPointerVisible = true;
                else
                    laserPointerVisible = false;
            }
            else
                laserPointerVisible = false;
        }
        else if (laserPointerVisible)
            laserPointerVisible = false;
    }
}
