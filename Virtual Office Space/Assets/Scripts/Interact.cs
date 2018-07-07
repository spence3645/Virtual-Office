using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    GameObject main;
    GameObject player;
    GameObject playerPoint;
    GameObject computer_instructions;
    public GameObject interact_object;

    public bool seated = false;
    public bool locked = true;
    bool computer_instructions_active = false;

	// Use this for initialization
	void Start ()
    {
        main = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        playerPoint = GameObject.FindGameObjectWithTag("Player_Point");
        computer_instructions = GameObject.FindGameObjectWithTag("Computer Instructions");
        interact_object = GameObject.FindGameObjectWithTag("Interact Object");

        computer_instructions.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if(seated == true)
        {
            SeatControls();
        }
        CursorLock();	
	}

    public void SitDown()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = playerPoint.transform.position;
        seated = true;
        computer_instructions.SetActive(true);
        computer_instructions_active = true;
        interact_object.SetActive(false);
    }

    void SeatControls()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.GetComponent<CharacterController>().enabled = true;
            computer_instructions.SetActive(false);
            computer_instructions_active = false;
            seated = false;
            interact_object.SetActive(true);
        }

        else if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q) && computer_instructions_active == true)
        {
            computer_instructions.SetActive(false);
            computer_instructions_active = false;
        }

        else if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q) && computer_instructions_active == false)
        {
            computer_instructions.SetActive(true);
            computer_instructions_active = true;
        }
    }

    void CursorLock()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H) && locked == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            locked = true;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H) && locked == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            locked = false;
        }
    }
}
