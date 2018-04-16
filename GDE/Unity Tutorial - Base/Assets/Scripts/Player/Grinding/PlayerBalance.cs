using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalance : MonoBehaviour
{
    public GameStates currentState;
    public Jump jumping;
    public GameObject paintSpawn;
    public GameObject cams;
    //public GUIText scoreText;
    private float elapsedTime = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        //scoreText.text = "Score " + elapsedTime;


        {
            RoatatePlayer();
            ForcePlayerLeft();
            ForcPlayerRight();
        }
       
        if (transform.localRotation.eulerAngles.z == 0.0)
        {
            elapsedTime = 0;
        }
    }

    private void RoatatePlayer()
    {
        //rotate player right
        if (jumping.grounded && Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.back * 1);
            paintSpawn.transform.Rotate(Vector3.forward * 1);
            cams.transform.Rotate(Vector3.forward * 1);
            //transform.Translate(Vector3.forward * 0.008f);
        }

        //Rotate player left
        if (jumping.grounded && Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.forward * 1f);
            paintSpawn.transform.Rotate(Vector3.back * 1f);
            cams.transform.Rotate(Vector3.back * 1);       
            //player.transform.Translate(Vector3.back * 0.008f);
        }
    }

    private void ForcePlayerLeft()
    {
        //Force play off left
        if (jumping.grounded && (transform.localRotation.eulerAngles.z >= 0.0f && transform.localRotation.eulerAngles.z < 5.0f))
        {
            //Debug.Log("Left");
            transform.Rotate(Vector3.forward * 0.01f);
            paintSpawn.transform.Rotate(Vector3.back * 0.01f);
            cams.transform.Rotate(Vector3.back * 0.01f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z >= 5.0f && transform.localRotation.eulerAngles.z < 10.0f))
        {
            //Debug.Log("Left");
            transform.Rotate(Vector3.forward * 0.05f);
            paintSpawn.transform.Rotate(Vector3.back * 0.05f);
            cams.transform.Rotate(Vector3.back * 0.05f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z >= 10.0f && transform.localRotation.eulerAngles.z < 20.0f))
        {
            //Debug.Log("Left");
            transform.Rotate(Vector3.forward * 0.1f);
            paintSpawn.transform.Rotate(Vector3.back * 0.1f);
            cams.transform.Rotate(Vector3.back * 0.1f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z >= 20.0f && transform.localRotation.eulerAngles.z < 40.0f))
        {
            //Debug.Log("Left");
            transform.Rotate(Vector3.forward * 0.5f);
            paintSpawn.transform.Rotate(Vector3.back * 0.5f);
            cams.transform.Rotate(Vector3.back * 0.5f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z >= 40.0f && transform.localRotation.eulerAngles.z < 180.0f))
        {
            //Debug.Log("Left");
            transform.Rotate(Vector3.forward * 0.9f);
            paintSpawn.transform.Rotate(Vector3.back * 0.9f);
            cams.transform.Rotate(Vector3.back * 0.9f);
        }
    }

    private void ForcPlayerRight()
    {
        //Force player off right
        if (jumping.grounded && (transform.localRotation.eulerAngles.z < 360.0f && transform.localRotation.eulerAngles.z > 355f))
        {
            transform.Rotate(Vector3.back * 0.01f);
            paintSpawn.transform.Rotate(Vector3.forward * 0.01f);
            cams.transform.Rotate(Vector3.forward * 0.01f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z <= 355.0f && transform.localRotation.eulerAngles.z > 350.0f))
        {
            transform.Rotate(Vector3.back * 0.05f);
            paintSpawn.transform.Rotate(Vector3.forward * 0.05f);
            cams.transform.Rotate(Vector3.forward * 0.05f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z <= 350.0f && transform.localRotation.eulerAngles.z > 340.0f))
        {
            transform.Rotate(Vector3.back * 0.1f);
            paintSpawn.transform.Rotate(Vector3.forward * 0.1f);
            cams.transform.Rotate(Vector3.forward * 0.1f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z <= 340.0f && transform.localRotation.eulerAngles.z > 320.0f))
        {
            transform.Rotate(Vector3.back * 0.5f);
            paintSpawn.transform.Rotate(Vector3.forward * 0.5f);
            cams.transform.Rotate(Vector3.forward * 0.5f);
        }
        else if (jumping.grounded && (transform.localRotation.eulerAngles.z <= 320.0f && transform.localRotation.eulerAngles.z > 180.0f))
        {
            transform.Rotate(Vector3.back * 0.9f);
            paintSpawn.transform.Rotate(Vector3.forward * 0.9f);
            cams.transform.Rotate(Vector3.forward * 0.9f);
        }
    }
}
