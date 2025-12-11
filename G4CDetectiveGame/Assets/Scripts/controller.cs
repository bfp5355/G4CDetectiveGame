using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public GameObject self;
    public TextAsset firstJson;//dialogue json
    public TextAsset secondJson;//dialogue json
    public TextAsset thirdJson;//dialogue json
    public GameObject dialogue_box;

    public List<GameObject> items = new List<GameObject>();//List of itemes in the scene
    public Canvas canvas;//the main scene canvas
    public GameObject item_box;//the dialogue box for items
    public int itemsClicked = 0;
    public int itemBoxClosed = 0;
    private bool firstDialogue = false;
    private bool secondDialogue = false;
    private bool thirdDialogue = false;

    public GameObject notebook_Icon;
    public GameObject notebook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemBoxClosed = 0;
        //Sets Item on click behavior
        foreach (GameObject item in items)
        {
            item.GetComponent<Button>().onClick.AddListener(() =>
            {
                if(item.GetComponent<itemScript>().clicked == false)//increments items clicked
                {
                    item.GetComponent<itemScript>().clicked = true;
                    itemsClicked++;
                }
                //creates and populates dialogue box
                GameObject box = Instantiate(item_box);
                box.transform.SetParent(canvas.transform);
                box.GetComponent<dialogue_box>().str = item.GetComponent<itemScript>().text;
                box.GetComponent<dialogue_box>().strName = item.name;
                box.GetComponent<dialogue_box>().controllerObj = self;
            });
        }
        notebook_Icon.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject box = Instantiate(notebook);
            box.transform.SetParent(canvas.transform);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(itemsClicked == itemBoxClosed)//If not itemboxes are open
        {
            if (itemsClicked >= items.Count && thirdDialogue == false)//If all items are clicked
            {
                thirdDialogue = true;
                GameObject box = Instantiate(dialogue_box);
                box.transform.SetParent(canvas.transform);
                box.GetComponent<vn_dialogue_Box>().dialogue = jsonParse.DeserializeDialogue(thirdJson.text);

            }
            else if (itemsClicked == 5 && secondDialogue == false)
            {
                secondDialogue = true;
                GameObject box = Instantiate(dialogue_box);
                box.transform.SetParent(canvas.transform);
                box.GetComponent<vn_dialogue_Box>().dialogue = jsonParse.DeserializeDialogue(secondJson.text);
            }
            else if (itemsClicked == 2 && firstDialogue == false)
            {
                firstDialogue = true;
                GameObject box = Instantiate(dialogue_box);
                box.transform.SetParent(canvas.transform);
                box.GetComponent<vn_dialogue_Box>().dialogue = jsonParse.DeserializeDialogue(firstJson.text);
            }
        }
    }
}
