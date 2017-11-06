using UnityEngine;
 using System.Collections;
 
 public class enemyAI : MonoBehaviour {
     public Transform target;
     public int moveSpeed;
     public int rotationSpeed;
 
     private Transform myTransform;
 
     //
     void Awake() {
         myTransform = transform;
     }
 
     void Start () {
         GameObject go = GameObject.FindGameObjectWithTag("Player");
 
         target = go.transform;
     }
     
     // Update e povika na sekoj frame
     void Update () {    
         Vector3 dir = target.position - myTransform.position;
         dir.z = 0.0f; // Only needed if objects don't share 'z' value
         if (dir != Vector3.zero) {
             myTransform.rotation = Quaternion.Slerp (myTransform.rotation,Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
         }
 
             //ide nakaj targetata
         myTransform.position += myTransform.position * moveSpeed * Time.deltaTime;
     
     }
 }