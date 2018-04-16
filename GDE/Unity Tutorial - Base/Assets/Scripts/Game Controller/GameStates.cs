using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour {

    public enum PlayerStates { GRINDING, FALLING, PAINTING };
    public int overlayIndex;
    public PlayerStates currentPlayerState;
    public CheckLine[]  lineStates = new CheckLine[6];
    public int currentWallVal;
    public AudioSource correctAudio;
    public int score;
    // Use this for initialization
    void Start () {
        currentPlayerState = PlayerStates.GRINDING;
        overlayIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentPlayerState)
        {
            case PlayerStates.GRINDING:
                overlayIndex = -1;
                break;

            case PlayerStates.PAINTING:


                if (Input.GetMouseButtonUp(0) && overlayIndex == -1)
                {
                    overlayIndex ++;
                }
                else if (Input.GetMouseButtonUp(0) && !lineStates[overlayIndex + currentWallVal*3].failed)
                {
                    if (overlayIndex != 2)
                    {
                        overlayIndex++;
                    }
                    else if (overlayIndex == 2)
                    {
                        currentPlayerState = PlayerStates.GRINDING;
                        overlayIndex = -1;
                    }

                    score += 100;

                    if(!correctAudio.isPlaying)
                    {
                        correctAudio.Play();
                    }
                }
                break;

            case PlayerStates.FALLING:
               
      
                break;
        }
    }

    void FixedUpdate()
    {
        if(currentPlayerState==PlayerStates.GRINDING)
        {
            score++;
        }
    }
}
