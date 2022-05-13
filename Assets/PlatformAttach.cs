//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
   public GameObject Cat;

   private void OnTriggerEnter(Collider other){
      if(other.gameObject == Cat){
         Cat.transform.parent = transform;
      }

}

private void OnTriggerExit(Collider other){
if(other.gameObject == Cat){
         Cat.transform.parent = null;
      }
}

}
