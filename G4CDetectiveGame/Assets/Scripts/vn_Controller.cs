using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vn_Controller : MonoBehaviour
{
    public TextAsset json;
    private List<string> dialogue = new List<string>();

    public GameObject button;
    private int index = 0;
    public GameObject text;
    public GameObject buttonText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue = jsonParse.DeserializeDialogue(json.text);//gets dialogue in a list

        button.GetComponent<Button>().onClick.AddListener(() =>
        {
            if(index == dialogue.Count)//Changes scene when dialogue reaches the end
            {
                SceneManager.LoadScene("point_n_click_Scene");
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
