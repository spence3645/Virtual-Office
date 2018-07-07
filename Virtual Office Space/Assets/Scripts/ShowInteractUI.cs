using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteractUI : MonoBehaviour
{

    GameObject interact_ui;
    bool interact_chair = false;
    public Interact interact;

    void Start()
    {
        interact_ui = GameObject.FindGameObjectWithTag("InteractUI");
        interact_ui.SetActive(false);
    }

    void Update()
    {
        if(interact_chair == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact.SitDown();
                interact_ui.SetActive(false); 
            }
        }
    }

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Interact Object")
        {
            interact_ui.SetActive(true);
            interact_chair = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Interact Object")
        {
            interact_ui.SetActive(false);
            interact_chair = false;
        }
    }
}
