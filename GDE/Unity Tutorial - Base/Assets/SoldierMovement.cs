using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour {

    public PlayerMovement player;
    public GameStates currentState;
    public GameObject firstPos;
    public GameObject secondPos;
    public GameObject thirdPos;
    public GameObject fourthPos;
    public GameObject fifthPos;
    public GameObject sixthPos;
    public GameObject[] playerPos = new GameObject[6];
    //public float prevPos = 4;
    private bool turned = false;
    //[HideInInspector]
    public int goToPosition = 1;
    [Range(0f, 100f)]
    public float speed;
    public float z_rotation;

    [Range(0, 100f)]
    public float startingDelay;
    public float elapsedTime;

    public AudioSource sirenAudio;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * speed;
        elapsedTime += Time.deltaTime;
        //if ((player.transform.position != playerPos[goToPosition - 1].transform.position))
        //{
        //    player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos[goToPosition - 1].transform.position, step);
        //}
        //else if (player.transform.position == playerPos[goToPosition - 1].transform.position)
        //{
        //    player.transform.Translate(Vector3.forward * speed);
        //}
        if (currentState.currentPlayerState == GameStates.PlayerStates.GRINDING && elapsedTime >= startingDelay)
        {
            MoveSoldier(step);

            if(!sirenAudio.isPlaying)
            {
                sirenAudio.Play();
            }

        }
            //StraightOn();
    }

    private void MoveSoldier(float step)
    {
        switch (goToPosition)
        {
            case 1:
                if (transform.position != firstPos.transform.position)
                    transform.position = Vector3.MoveTowards(transform.position, firstPos.transform.position, step);

                else if (transform.position == firstPos.transform.position)
                    transform.Translate(Vector3.forward * speed);
                break;
            case 2:
                if (transform.position != secondPos.transform.position)
                    transform.position = Vector3.MoveTowards(transform.position, secondPos.transform.position, step);

                else if (transform.position == secondPos.transform.position)
                    transform.Translate(Vector3.forward * speed);
                break;
            case 3:
                if (transform.position != thirdPos.transform.position)
                    transform.position = Vector3.MoveTowards(transform.position, thirdPos.transform.position, step);

                else if (transform.position == thirdPos.transform.position)
                    transform.Translate(Vector3.forward * speed);
                break;
            case 4:
                if (transform.position != fourthPos.transform.position)
                    transform.position = Vector3.MoveTowards(transform.position, fourthPos.transform.position, step);

                else if (transform.position == fourthPos.transform.position)
                    transform.Translate(Vector3.forward * speed);
                break;
            case 5:
                if (transform.position != fifthPos.transform.position)
                    transform.position = Vector3.MoveTowards(transform.position, fifthPos.transform.position, step);

                else if (transform.position == fifthPos.transform.position)
                    transform.Translate(Vector3.forward * speed);
                break;
            case 6:
                if (transform.position != sixthPos.transform.position)
                    transform.position = Vector3.MoveTowards(transform.position, sixthPos.transform.position, step);

                else if (transform.position == sixthPos.transform.position)
                    transform.Translate(Vector3.forward * speed);
                break;
        }
    }

    void OnTriggerStay(Collider col)
    {
        z_rotation = transform.localEulerAngles.z;
        switch (goToPosition)
        {
            case 1:
                if (col.name == "bR_turn_Trigger")
                {
                    TurnAtPositionOne();
                }
                break;
            case 2:
                if (col.name == "tR_turn_Trigger")
                {
                    TurnAtPositionTwo();
                }
                break;
            case 3:
                if (col.name == "tL_turn_Trigger")
                {
                    TurnAtPositionThree();
                }
                break;
            case 4:
                if (col.name == "bL_turn_Trigger")
                {
                    TurnAtPositionFour();
                }
                break;
            case 5:
                if (col.name == "mR_turn_Trigger")
                {
                    TurnAtPositionFive();
                }
                break;
            case 6:
                if (col.name == "mL_turn_Trigger")
                {
                    TurnAtPositionSix();
                }
                break;
        }
    }

    private void TurnAtPositionOne()
    {
        if (player.goToPosition == 5)
        {
            goToPosition = 5;
            transform.eulerAngles = new Vector3(0, -90, z_rotation);
            transform.position = firstPos.transform.position;
        }
        if (player.goToPosition == 4)
        {
            goToPosition = 4;
            transform.eulerAngles = new Vector3(0, 180, z_rotation);
            transform.position = firstPos.transform.position;
        }
    }

    private void TurnAtPositionTwo()
    {
        if (player.goToPosition == 3)
        {
            goToPosition = 3;
            transform.eulerAngles = new Vector3(0, 180, z_rotation);
            transform.position = secondPos.transform.position;
        }
        if (player.goToPosition == 5)
        {
            goToPosition = 5;
            transform.eulerAngles = new Vector3(0, 90, z_rotation);
            transform.position = secondPos.transform.position;
        }
    }

    private void TurnAtPositionThree()
    {
        if (player.goToPosition == 6)
        {
            goToPosition = 6;
            transform.eulerAngles = new Vector3(0, 90, z_rotation);
            transform.position = thirdPos.transform.position;
        }
        if (player.goToPosition == 2)
        {
            goToPosition = 2;
            transform.eulerAngles = new Vector3(0, 0, z_rotation);
            transform.position = thirdPos.transform.position;
        }
    }

    private void TurnAtPositionFour()
    {
        if (player.goToPosition == 1)
        {
            goToPosition = 1;
            transform.eulerAngles = new Vector3(0, 0, z_rotation);
            transform.position = fourthPos.transform.position;
        }
        if (player.goToPosition == 6)
        {
            goToPosition = 6;
            transform.eulerAngles = new Vector3(0, -90, z_rotation);
            transform.position = fourthPos.transform.position;
        }
    }

    private void TurnAtPositionFive()
    {
        if (player.goToPosition == 6)
        {
            goToPosition = 6;
            transform.eulerAngles = new Vector3(0, 180, z_rotation);
            transform.position = fifthPos.transform.position;
        }
        else if (player.goToPosition == 2)
        {
            goToPosition = 2;
            transform.eulerAngles = new Vector3(0, -90, z_rotation);
            transform.position = fifthPos.transform.position;
        }
        else if (player.goToPosition == 1)
        {
            goToPosition = 1;
            transform.eulerAngles = new Vector3(0, 90, z_rotation);
            transform.position = fifthPos.transform.position;
        }
    }

    private void TurnAtPositionSix()
    {
        if (player.goToPosition == 5)
        {
            goToPosition = 5;
            transform.eulerAngles = new Vector3(0, 0, z_rotation);
            transform.position = sixthPos.transform.position;
        }
        else if (player.goToPosition == 4)
        {
            goToPosition = 4;
            transform.eulerAngles = new Vector3(0, 90, z_rotation);
            transform.position = sixthPos.transform.position;
        }
        else if (player.goToPosition == 3)
        {
            goToPosition = 3;
            transform.eulerAngles = new Vector3(0, -90, z_rotation);
            transform.position = sixthPos.transform.position;
        }
    }
}
