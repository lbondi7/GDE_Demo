using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public GameStates currentState;

    public PlayerMovement rot;
    public GameObject player;
    GameObject rail;

    [Range(0f, 1000f)]
    public float jumpForce;
    private Rigidbody rb;
    [HideInInspector]
    public bool grounded = true;
    public AudioSource jumpingAudio;
    public AudioSource landingAudio;
    private bool firstTime = true;
    public float z_rotation;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rail = GameObject.FindGameObjectWithTag("Rail");
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.localEulerAngles.z < 10f || player.transform.localEulerAngles.z > 350f)
        {
            if (Input.GetKeyUp(KeyCode.Space) && grounded)
            {
                z_rotation = player.transform.localEulerAngles.z;
                rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
                SortRoatation();
                grounded = false;


                if (!jumpingAudio.isPlaying)
                {
                    jumpingAudio.Play();
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Rail")
        grounded = true;
        Debug.Log("Hlo");

        if (!landingAudio.isPlaying && !firstTime)
        {
            landingAudio.Play();
        }
        firstTime = false;

    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Rail")
        {
            if (transform.position.y < rail.transform.position.y)
            {
                currentState.currentPlayerState = GameStates.PlayerStates.FALLING;
                Debug.Log("HEllo");
            }
        }
    }

    void SortRoatation()
    {
        switch (rot.goToPosition)
        {
            case 1:
                {
                    if (rot.prevPos == 4)
                        player.transform.eulerAngles = new Vector3(0, 0, z_rotation);
                    else if (rot.prevPos == 5 || rot.prevPos == 2)
                        player.transform.eulerAngles = new Vector3(0, 90, z_rotation);
                    break;
                }
            case 2:
                {
                    if (rot.prevPos == 3)
                        player.transform.eulerAngles = new Vector3(0, 0, z_rotation);
                    else if (rot.prevPos == 5 || rot.prevPos == 1)
                        player.transform.eulerAngles = new Vector3(0, -90, z_rotation);
                    break;
                }
            case 3:
                {
                    if (rot.prevPos == 2)
                        player.transform.eulerAngles = new Vector3(0, 180, z_rotation);
                    else if (rot.prevPos == 6 || rot.prevPos == 4)
                        player.transform.eulerAngles = new Vector3(0, -90, z_rotation);
                    break;
                }
            case 4:
                {
                    if (rot.prevPos == 1)
                        player.transform.eulerAngles = new Vector3(0, 180, z_rotation);
                    else if (rot.prevPos == 6 || rot.prevPos == 3)
                        player.transform.eulerAngles = new Vector3(0, 90, z_rotation);
                    break;
                }
            case 5:
                {
                    if (rot.prevPos == 6)
                        player.transform.eulerAngles = new Vector3(0, 0, z_rotation);
                    else if (rot.prevPos == 2)
                        player.transform.eulerAngles = new Vector3(0, 90, z_rotation);
                    else if (rot.prevPos == 1)
                        player.transform.eulerAngles = new Vector3(0, -90, z_rotation);
                    break;
                }
            case 6:
                {
                    if (rot.prevPos == 4)
                        player.transform.eulerAngles = new Vector3(0, -90, z_rotation);
                    else if (rot.prevPos == 5)
                        player.transform.eulerAngles = new Vector3(0, 180, z_rotation);
                    else if (rot.prevPos == 3)
                        player.transform.eulerAngles = new Vector3(0, 90, z_rotation);
                    break;
                }
        }
    }
}
