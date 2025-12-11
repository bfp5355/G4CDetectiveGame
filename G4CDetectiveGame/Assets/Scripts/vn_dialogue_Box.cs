using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This is intended for dialogue within the point and click scenese
public class vn_dialogue_Box : MonoBehaviour
{
    public GameObject self;//the box itself
    public List<string> dialogue = new List<string>();//the dialogue list

    public GameObject button;//button to progress
    private int index = 0;//index
    public GameObject text;//dialogue text
    public GameObject buttonText;//buttontext
    public GameObject controllerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("opened");
        button.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (index == dialogue.Count)//Ends this series of dialogue
            {
                Destroy(self);
            }
            else//increments index
            {
                index++;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (index < dialogue.Count)//Sets text
        {
            text.GetComponent<TextMeshProUGUI>().text = dialogue[index];
        }

        if (index == dialogue.Count)//changes button text to make clear what happens
        {
            buttonText.GetComponent<TextMeshProUGUI>().text = "Done";
        }
    }
}
