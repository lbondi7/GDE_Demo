using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWallCam : MonoBehaviour {

    public GameStates currentStates;
    public float exitTime = 5.0f;
    private float elapsedTime = 0;
    public int wallVal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (currentStates.currentPlayerState == GameStates.PlayerStates.PAINTING)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= exitTime)
            {
                currentStates.currentPlayerState = GameStates.PlayerStates.GRINDING;
                elapsedTime = 0;
            }
        }
	}

    void OnMouseOver()
    {

        if (Input.GetMouseButtonUp(0))
        {
            currentStates.currentPlayerState = GameStates.PlayerStates.PAINTING;
            currentStates.currentWallVal = wallVal;
        }
    }
}
