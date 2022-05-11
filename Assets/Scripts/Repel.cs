using System.Collections.Generic;
 using UnityEngine;
 
 internal class Repel : MonoBehaviour
 {
     List<MagnetizedObject> mo;
     public float range;
    public float strength;
    //public GameObject laser_go;

    
    public void Start()
     {
         mo = new List<MagnetizedObject>();
         gameObject.GetComponent<SphereCollider>().radius = range;
     }
 
     public void FixedUpdate()
     {
         for(int i = 0; i < mo.Count; i++)
         {
             ApplyMagneticForce(mo[i]);
         }
     }
 
     public void OnTriggerEnter(Collider other)
     {
        
        if (other.gameObject.CompareTag("Attract"))
         {
             MagnetizedObject newMag = new MagnetizedObject();
             newMag.col = other;
             newMag.rb = other.GetComponent<Rigidbody>();
             newMag.t = other.transform;
             newMag.polarity = 1;
             mo.Add(newMag);
         }
         else if(other.gameObject.CompareTag("Repel"))
         {
            //laser_go.SetActive(false);
            MagnetizedObject newMag = new MagnetizedObject();
             newMag.col = other;
             newMag.rb = other.GetComponent<Rigidbody>();
             newMag.t = other.transform;
             newMag.polarity = -10;
             mo.Add(newMag);
         }
     }
 
     public void OnTriggerExit(Collider other)
     {
        //laser_go.SetActive(true);
        if (other.CompareTag("Attract") || other.CompareTag("Repel"))
         {
             for(int i = 0; i < mo.Count; i++)
             {
                 if(mo[i].col == other)
                 {
                     mo.RemoveAt(i);
                     break;
                 }
             }
         }
      }
 
     private void ApplyMagneticForce(MagnetizedObject obj)
     {
         Vector3 rawDirection = transform.position - obj.t.position;
 
         float distance = rawDirection.magnitude;
         float distanceScale = Mathf.InverseLerp(range, 0f, distance);
         float attractionStrength = Mathf.Lerp(0f, strength, distanceScale);
 
         obj.rb.AddForce(rawDirection.normalized * attractionStrength * obj.polarity, ForceMode.Force);
         
         
     }
 }
 
 public class MagnetizedObject
 {
     public Collider col;
     public Rigidbody rb;
     public Transform t;
     public int polarity;
 }