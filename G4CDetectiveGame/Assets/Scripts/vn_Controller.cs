using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Intended for standalone visual novel scenes
public class vn_Controller : MonoBehaviour
{
    public TextAsset json;//dialogue json
    private List<string> dialogue = new List<string>();//the dialogue list

    public GameObject button;//button to progress
    private int index = 0;//index
    public GameObject text;//dialogue text
    public GameObject buttonText;//buttontext
    public bool finale = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue = jsonParse.DeserializeDialogue(json.text);//gets dialogue in a list

        button.GetComponent<Button>().onClick.AddListener(() =>
        {
            if(index == dialogue.Count)//Changes scene when dialogue reaches the end
            {
                if(finale == false)
                {
                    SceneManager.LoadScene("point_n_click_Scene");
                }
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
        if(index < dialogue.Count)//Sets text
        {
            text.GetComponent<TextMeshProUGUI>().text = dialogue[index];
        }
        
        if(index == dialogue.Count - 1)//changes button text to make clear what happens
        {
            buttonText.GetComponent<TextMeshProUGUI>().text = "Done";
        }
    }
}
