/* CS 352 Project: Rise Up
 * Win.cs
 * 
 * Brian Langejans And Chris Jeong
 * Date: 4/15/2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Help From: https://www.youtube.com/watch?v=AfwmRYQRsbg
// and https://forum.unity.com/threads/make-text-appear-then-disappear.716453/
public class Win : MonoBehaviour
{
    public Text textElement;
    public string textValue;
    private float disappearTime = 300;
    private float timeToAppear = 1;
    private void OnTriggerEnter(Collider collider) {
        textElement.text = textValue;
        // set disappear time for the text
        disappearTime = Time.time + timeToAppear;

    }

    void Update()
    {
        if (textElement.enabled && (Time.time >= disappearTime)) {
            textElement.enabled = false;
            // load back to the beginning
            SceneManager.LoadScene(0);
        }
    }
}
