using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {

	GameObject highlighted;
	GameObject desktop;
	GameObject word_doc;

	Type type;

    public bool word_doc_open = false;

	void Start()
	{
		highlighted = GameObject.FindGameObjectWithTag ("Highlighter");
		desktop = GameObject.FindGameObjectWithTag ("Desktop");
		word_doc = GameObject.FindGameObjectWithTag ("Word_Doc");
		type = GameObject.FindGameObjectWithTag ("Player").GetComponent<Type> ();
        word_doc.SetActive (false);
		highlighted.SetActive (false);
	}

	void OnMouseOver()
	{
		highlighted.SetActive (true);
	}

	void OnMouseExit()
	{
		highlighted.SetActive (false);
	}

	public void ChangeWindows()
	{
		word_doc.SetActive (true);
        type.allText.Add(Instantiate(type.textPrefab, GameObject.FindGameObjectWithTag("Content").transform));
        word_doc_open = true;
        desktop.SetActive (false);
	}
}
