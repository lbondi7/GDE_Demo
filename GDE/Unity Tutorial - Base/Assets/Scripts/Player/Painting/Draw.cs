using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {

    public GameStates currentGameState;
    public float depth = 3f;
    public Camera wallCam;
    public float decayTime = 10.0f;
    private bool colourSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && currentGameState.currentPlayerState==GameStates.PlayerStates.PAINTING)
        {
            GetComponent<TrailRenderer>().time = decayTime;

            if(!colourSelected )
            {
                var colour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                GetComponent<TrailRenderer>().startColor = colour;
                GetComponent<TrailRenderer>().endColor = colour;               
                colourSelected = true;
            }
            var mousePos = Input.mousePosition;
            Vector3 destPosVec = new Vector3(mousePos.x, mousePos.y, depth);
            var destPos = wallCam.ScreenToWorldPoint(destPosVec);
            transform.position = destPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<TrailRenderer>().time = 0;
            colourSelected = false;
        }
	}
}
