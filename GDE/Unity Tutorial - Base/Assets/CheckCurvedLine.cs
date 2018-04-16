using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurvedLine : MonoBehaviour {

    public CheckSmallerLine line1State;
    public CheckSmallerLine line2State;
    public bool failed;
    public AudioSource incorrectAudio;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            failed = false;
        }

        if (Input.GetMouseButtonUp(0) && failed && !incorrectAudio.isPlaying)
        {
            incorrectAudio.Play();
        }
    }
    void OnMouseExit()
    {
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if ((screenRect.Contains(Input.mousePosition) && Input.GetMouseButton(0))
            || line1State.failed || line2State.failed)
        {
            failed = true;
        }
    }
}
