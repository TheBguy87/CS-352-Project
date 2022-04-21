/* CS 352 Project: Rise Up
 * LRPlatform.cs
 * 
 * Brian Langejans And Chris Jeong
 * Date: 4/15/2022
 */

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
 
     void Start () {
         ChangeTarget();
     }
     
     void FixedUpdate () {
         LR_Platform.position = Vector3.Lerp (LR_Platform.position, newPosition, smooth * Time.deltaTime);
     }
 
 // Handle moving positions
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