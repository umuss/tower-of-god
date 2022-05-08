using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour
{
   private Rigidbody magicSphereRigidBody;
   public float speed=10.0f;
   private float timeToDestroy = 3f;
   public static bool isDestroyed;

   private void Start()
   {
       isDestroyed=false;
	   magicSphereRigidBody = GetComponent<Rigidbody>();
       magicSphereRigidBody.velocity = transform.forward * speed;
       Destroy(gameObject,timeToDestroy);
	   isDestroyed=true;
       
   }

   private void OnTriggerEnter(Collider coll)
   {
       isDestroyed=false;
	   Destroy(gameObject);
	   isDestroyed=true;
   }
}
