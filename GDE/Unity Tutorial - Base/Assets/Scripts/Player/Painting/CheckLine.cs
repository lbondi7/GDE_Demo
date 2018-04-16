using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLine : MonoBehaviour {

    public bool failed;
    public AudioSource incorrectAudio;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            failed = false;
        }

        if(Input.GetMouseButtonUp(0) && failed && !incorrectAudio.isPlaying)
        {
            incorrectAudio.Play();
        }
    }
    void OnMouseExit()
    {
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (screenRect.Contains(Input.mousePosition) && Input.GetMouseButton(0))
        {
            failed = true;
        }
    }
}
