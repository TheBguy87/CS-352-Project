/* CS 352 Project: Rise Up
 * HoldCharacter.cs
 * 
 * Brian Langejans And Chris Jeong
 * Date: 4/15/2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help From: https://www.youtube.com/watch?v=AfwmRYQRsbg
public class HoldCharacter : MonoBehaviour
{
    // Make the player a child of the platform
    private void OnTriggerEnter(Collider collider) {
        collider.transform.parent = gameObject.transform;
    }

    // remove the player from the platform
    private void OnTriggerExit(Collider collider) {
        collider.transform.parent = null;
    }
}
