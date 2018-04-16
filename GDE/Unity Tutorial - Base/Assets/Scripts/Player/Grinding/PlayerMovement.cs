using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameStates currentState;
    public GameObject firstPos;
    public GameObject secondPos;
    public GameObject thirdPos;
    public GameObject fourthPos;
    public GameObject fifthPos;
    public GameObject sixthPos;
    public GameObject[] playerPos = new GameObject[6];
    public AudioSource grindingAudio;
    public GameObject  grindingObj;
    public AudioSource landingAudio;
    public Jump jumpState;
    public float prevPos = 4;
    private bool turned = false;
    //[HideInInspector]
    public int goToPosition = 1;
    [Range(0f, 100f)]
    public float speed;
    public float z_rotation;
    private Animator anim;
    private AnimationController animCon;


    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
        animCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<AnimationController>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.currentPlayerState == GameStates.PlayerStates.GRINDING)
        {
            float step = Time.deltaTime * speed;

            //if ((player.transform.position != playerPos[goToPosition - 1].transform.position))
            //{
            //    player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos[goToPosition - 1].transform.position, step);
            //}
            //else if (player.transform.position == playerPos[goToPosition - 1].transform.position)
            //{
            //    player.transform.Translate(Vector3.forward * speed);
            //}

            MovePlayer(step);
            StraightOn();

            if (!grindingAudio.isPlaying && !landingAudio.isPlaying && jumpState.grounded)
            {
                grindingObj.SetActive(true);
                grindingAudio.Play();
            }
            else if (!jumpState.grounded)
            {
                grindingObj.SetActive(false);
            }

        }
        else if (currentState.currentPlayerState == GameStates.PlayerStates.FALLING)
        {
            grindingAudio.Stop();
            anim.SetBool(animCon.fallingState, true);
        }
    }

    private void MovePlayer(float step)
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

    private void StraightOn()
    {
        if (transform.position == fifthPos.transform.position && prevPos == 1 && (transform.localEulerAngles.z > 180.0f))
        {
            goToPosition = 2;
        }
        else if (transform.position == fifthPos.transform.position && prevPos == 2 && (transform.localEulerAngles.z < 180.0f))
        {
            goToPosition = 1;
        }

        if (transform.position == sixthPos.transform.position && prevPos == 3 && (transform.localEulerAngles.z > 180.0f))
        {
            goToPosition = 4;
        }
        if (transform.position == sixthPos.transform.position && prevPos == 4 && (transform.localEulerAngles.z < 180.0f))
        {
            goToPosition = 3;
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
        if (prevPos == 4)
        {
            goToPosition = 5;
            transform.eulerAngles = new Vector3(0, -90, z_rotation);
            transform.position = firstPos.transform.position;
            prevPos = 1;
        }
        if (prevPos == 5 || prevPos == 2)
        {
            goToPosition = 4;
            transform.eulerAngles = new Vector3(0, 180, z_rotation);
            transform.position = firstPos.transform.position;
            prevPos = 1;
        }
    }

    private void TurnAtPositionTwo()
    {
        if (prevPos == 5 || prevPos == 1)
        {
            goToPosition = 3;
            transform.eulerAngles = new Vector3(0, 180, z_rotation);
            transform.position = secondPos.transform.position;
            prevPos = 2;
        }
        if (prevPos == 3)
        {
            goToPosition = 5;
            transform.eulerAngles = new Vector3(0, 90, z_rotation);
            transform.position = secondPos.transform.position;
            prevPos = 2;
        }
    }

    private void TurnAtPositionThree()
    {
        if (prevPos == 2)
        {
            goToPosition = 6;
            transform.eulerAngles = new Vector3(0, 90, z_rotation);
            transform.position = thirdPos.transform.position;
            prevPos = 3;
        }
        if (prevPos == 6 || prevPos == 4)
        {
            goToPosition = 2;
            transform.eulerAngles = new Vector3(0, 0, z_rotation);
            transform.position = thirdPos.transform.position;
            prevPos = 3;
        }
    }

    private void TurnAtPositionFour()
    {
        if (prevPos == 6 || prevPos == 3)
        {
            goToPosition = 1;
            transform.eulerAngles = new Vector3(0, 0, z_rotation);
            transform.position = fourthPos.transform.position;
            prevPos = 4;
        }
        if (prevPos == 1)
        {
            goToPosition = 6;
            transform.eulerAngles = new Vector3(0, -90, z_rotation);
            transform.position = fourthPos.transform.position;
            prevPos = 4;
        }
    }

    private void TurnAtPositionFive()
    {
        if (transform.localEulerAngles.z < 180.0f)
        {
            if (prevPos == 1)
            {
                goToPosition = 6;
                transform.eulerAngles = new Vector3(0, 180, z_rotation);
                transform.position = fifthPos.transform.position;
                prevPos = 5;
            }
            else if (prevPos == 6)
            {
                goToPosition = 2;
                transform.eulerAngles = new Vector3(0, -90, z_rotation);
                transform.position = fifthPos.transform.position;
                prevPos = 5;
            }
        }
        else if (transform.localEulerAngles.z > 180.0f)
        {
            if (prevPos == 2)
            {
                goToPosition = 6;
                transform.eulerAngles = new Vector3(0, 180, z_rotation);
                transform.position = fifthPos.transform.position;
                prevPos = 5;
            }
            else if (prevPos == 6)
            {
                goToPosition = 1;
                transform.eulerAngles = new Vector3(0, 90, z_rotation);
                transform.position = fifthPos.transform.position;
                prevPos = 5;
            }
        }
    }

    private void TurnAtPositionSix()
    {
        if (transform.localEulerAngles.z < 180.0f)
        {
            if (prevPos == 3)
            {
                goToPosition = 5;
                transform.eulerAngles = new Vector3(0, 0, z_rotation);
                transform.position = sixthPos.transform.position;
                prevPos = 6;
            }
            else if (prevPos == 5)
            {
                goToPosition = 4;
                transform.eulerAngles = new Vector3(0, 90, z_rotation);
                transform.position = sixthPos.transform.position;
                prevPos = 6;
            }
        }
        if (transform.localEulerAngles.z > 180.0f)
        {
            if (prevPos == 4)
            {
                goToPosition = 5;
                transform.eulerAngles = new Vector3(0, 0, z_rotation);
                transform.position = sixthPos.transform.position;
                prevPos = 6;
            }
            else if (prevPos == 5)
            {
                goToPosition = 3;
                transform.eulerAngles = new Vector3(0, -90, z_rotation);
                transform.position = sixthPos.transform.position;
                prevPos = 6;
            }
        }
    }
}
