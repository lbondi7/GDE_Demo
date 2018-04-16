using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class RenderScore : MonoBehaviour {

    public GameStates currentState;
	// Use this for initialization
	void Start () {
        currentState.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Score: " + currentState.score;
    }
}
