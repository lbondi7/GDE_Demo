using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public int fallingState;
	
	// Update is called once per frame
	void Awake () {
        fallingState = Animator.StringToHash("Fall");
    }
}
