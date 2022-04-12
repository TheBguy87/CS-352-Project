using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help From: https://www.youtube.com/watch?v=AfwmRYQRsbg
public class HoldCharacter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        collider.transform.parent = gameObject.transform;
    }

    private void OnTriggerExit(Collider collider) {
        collider.transform.parent = null;
    }
}
