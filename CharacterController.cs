using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public bool forward;
    public bool left;
    public bool right;
    public bool back;
    public bool inventory;
    public bool pause;
    public bool jump;
    public bool fire;
    public bool aim;
    public bool weaponSwapL;
    public bool weaponSwapR;
    public bool action;
    public bool map;
    public bool sheath;
    public bool camSwitch;


    public Rigidbody rb;
    public float speed;
    public float weight;
    public bool isTriggered;
    public Camera fps;
    public Camera tps;




	// Use this for initialization
	void Start () {
        weight = rb.mass * 100;
        speed = (weight / 4);
        fps.enabled = true;
        tps.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        CharControl();

	}

    void CharControl()
    {
        forward = Input.GetKey(KeyCode.W);
        if (forward)
        {
            rb.AddForce(transform.forward * speed);
        }
        back = Input.GetKey(KeyCode.S);
        if (back)
        {
            rb.AddForce(-transform.forward * speed);
        }
        left = Input.GetKey(KeyCode.A);
        if (left)
        {
            rb.AddForce(-transform.right * speed);
        }
        right = Input.GetKey(KeyCode.D);
        if (right)
        {
            rb.AddForce(transform.right * speed);
        }
        jump = Input.GetKey(KeyCode.Space);
        if (jump)
        {
            Jump();
        }
        inventory = Input.GetKey(KeyCode.I);
        if (inventory)
        {

        }
        camSwitch = Input.GetKeyDown(KeyCode.Keypad5);
        if (camSwitch)
        {
            fps.enabled = !fps.enabled;
            tps.enabled = !tps.enabled;
        }
    }

    void Jump()
    {
        if (isTriggered)
        {
            rb.AddForce(transform.up *2, ForceMode.Impulse);
        }
        
            


    }
    void OnTriggerEnter()
    {
       isTriggered = true;
    }
    void OnTriggerExit()
    {
        isTriggered = false;
    }
}
