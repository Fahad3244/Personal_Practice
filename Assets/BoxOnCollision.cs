using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxOnCollision : MonoBehaviour
{
   public Color[] randomColor;
   private void Start()
   {
      Color random = randomColor[Random.Range(0, randomColor.Length)];
      for (int i = 0; i < this.transform.childCount; i++)
      {
         this.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = random;
      }
      
      Destroy(this.gameObject,5f);
   }

   private void OnCollisionEnter(Collision other)
   {
      OnDestroy();
   }

   public void OnDestroy()
   {
      for (int i = 0; i < this.transform.childCount; i++)
      {
         this.transform.GetChild(i).GetComponent<BoxCollider>().isTrigger = false;
         transform.GetChild(i).GetComponent<Rigidbody>().AddExplosionForce(30f, transform.position - Vector3.up, 5f);
      }

      GetComponent<RandomRotate>().enabled = false;
   }
}
