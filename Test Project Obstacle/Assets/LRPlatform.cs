// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class LRPlatform : MonoBehaviour
// {
//     [SerializeField] float xValue = .0001f;

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {

//         transform.Translate(xValue, 0, 0);
//     }

// }

 using UnityEngine;
 using System.Collections;
 
 // Help from: https://www.youtube.com/watch?v=AfwmRYQRsbg
 public class LRPlatform : MonoBehaviour {
 
     public Transform LR_Platform;
     public Transform position1;
     public Transform position2;
     public Vector3 newPosition;
     public string currentState;
     public float smooth;
     public float resetTime;
 
     // Use this for initialization
     void Start () {
         ChangeTarget();
     }
     
     // Update is called once per frame
     void FixedUpdate () {
         LR_Platform.position = Vector3.Lerp (LR_Platform.position, newPosition, smooth * Time.deltaTime);
     }
 
     void ChangeTarget () {
         if(currentState == "Moving To Position 1")
         {
             currentState = "Moving To Position 2";
             newPosition = position2.position;
         }
         else if (currentState == "Moving To Position 2")
         {
             currentState = "Moving To Position 1";
             newPosition = position1.position;
         }
         else if (currentState == "")
         {
             currentState = "Moving To Position 2";
             newPosition = position2.position;
         }
         Invoke ("ChangeTarget", resetTime);
     }
 
 }