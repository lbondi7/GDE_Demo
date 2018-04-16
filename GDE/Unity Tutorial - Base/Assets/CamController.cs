using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public Camera avatarCam;
    public Camera topCam;
    public Camera[] wallCams = new Camera[2];
    public GameStates currentState;
    public GameObject[] drawingOverlays = new GameObject[6];
    public GameObject avatar;

    // Use this for initialization
    void Start()
    {
        avatarCam.enabled = true;
        topCam.enabled = false;
    }

    // Update is called once per frame
    void Update () {
	switch (currentState.currentPlayerState)
    {
        case GameStates.PlayerStates.GRINDING:

                avatarCam.enabled = true;

            for (int i = 0; i < wallCams.Length;i++)
            {
                wallCams[i].enabled = false;
            }
            for (int i = 0; i < drawingOverlays.Length; i++)
            {
                drawingOverlays[i].SetActive(false);
            }
            break;

        case GameStates.PlayerStates.PAINTING:
            avatarCam.enabled = false;
            wallCams[currentState.currentWallVal].enabled = true;
            for (int i = 0; i < wallCams.Length; i++)
            {
                if (i != currentState.currentWallVal)
                {
                    wallCams[i].enabled = false;
                }
            }
            drawingOverlays[currentState.overlayIndex + currentState.currentWallVal * 3].SetActive(true);
            for (int i = 0; i < drawingOverlays.Length; i++)
            {
                if (i != currentState.overlayIndex + currentState.currentWallVal * 3)
                {
                    drawingOverlays[i].SetActive(false);
                }
            }
            break;

            case GameStates.PlayerStates.FALLING:

                avatarCam.enabled = false;
                topCam.enabled = true;

                avatar.transform.eulerAngles = new Vector3(0, 0, 0);
                avatar.transform.Translate(Vector3.forward * 5);

                break;
        }
	}
}
