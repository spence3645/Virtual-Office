using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Type : MonoBehaviour
{

    public List<Text> allText;
    public Text textPrefab;
    public GameObject textSpawn;
    string userInput = "";
    int pages = 0;
    Interact interact;
    public Mouse mouse;
    int frames = 3;
    int numOfTextFiles = 0;

    void Start()
    {
        allText = new List<Text>();
        interact = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Interact>();
    }

    // Update is called once per frame
    void Update()
    {
        Typing();
    }

    public void SaveFile()
    {
        userInput = "";
        var fileName = "VirtualOffice";

        foreach (Text text in allText)
        {
            if (text == null)
            {

            }
            else
            {
                userInput += text.text;
                userInput += " ";
            }
        }

        while (File.Exists(fileName.ToString() + ".txt"))
        {
            numOfTextFiles += 1;
            fileName += numOfTextFiles.ToString();
        }

        var textFile = File.CreateText(fileName + ".txt");
        textFile.WriteLine(userInput);
        textFile.Close();
    }

    void Typing()
    {
        if(mouse.word_doc_open == true && interact.locked == true && interact.seated == true)
        {
            if (Input.GetKey(KeyCode.Backspace))
            {
                if(Time.frameCount % frames == 0)
                {
                    userInput = userInput.Substring(0, userInput.Length - 1);
                    allText[pages].text = userInput;
                }
            }
            else
            {
                foreach (char letter in Input.inputString)
                {
                    userInput += letter;
                    allText[pages].text = userInput;
                }
            }
        }
    }

    public void NextPage()
    {
        userInput = "";
        pages += 1;
        if (pages < allText.Count)
        {
            userInput = allText[pages].text.ToString();
            foreach (Text text in allText)
            {
                text.enabled = false;
                allText[pages].enabled = true;
            }
        }
        else if (pages >= allText.Count)
        {
            allText.Add(Instantiate(textPrefab, GameObject.FindGameObjectWithTag("Content").transform));
            foreach (Text text in allText)
            {
                if(text == null)
                {

                }
                else
                {
                    text.enabled = false;
                    allText[pages].enabled = true;
                }
            }
        }
    }

    public void PreviousPage()
    {
        if(pages <= 0)
        {

        }
        else if(pages > 0)
        {
            pages -= 1;
            userInput = allText[pages].text.ToString();
            foreach (Text text in allText)
            {
                text.enabled = false;
                allText[pages].enabled = true;
            }
        }
    }
}

