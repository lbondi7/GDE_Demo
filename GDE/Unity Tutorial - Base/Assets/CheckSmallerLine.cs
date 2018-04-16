using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSmallerLine : MonoBehaviour {

    public bool failed;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            failed = false;
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
