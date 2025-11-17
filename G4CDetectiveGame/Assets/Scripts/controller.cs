using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class controller : MonoBehaviour
{
    public TextAsset json;
    private List<Item> items = new List<Item>();

    public GameObject red_square;
    public GameObject blue_square;
    public GameObject green_square;
    public GameObject yellow_square;
    public GameObject image;
    public Canvas canvas;
    public GameObject dialogue_box;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        items = jsonParse.DeserializeList(json.text);//parses items into a list
        //GameObject sqr = new GameObject();

        //This is super temp to get this to work as a proof of concept. Will have to do more work to get file pathing working for sprites and images
        for (int i = 0; i < items.Count; i++)//debug logs items and populates them on the screen
        {
            //Less Jank Item creation
            
            //sqr.name = items[i].name;
            //
            //switch (items[i].name)
            //{
            //    case "red_square":
            //            sqr = Instantiate(red_square);
            //        break;
            //    case "blue_square":
            //        sqr = Instantiate(blue_square);
            //        break;
            //    case "green_square":
            //        sqr = Instantiate(green_square);
            //        break;
            //    case "yellow_square":
            //        sqr = Instantiate(yellow_square);
            //        break;
            //
            //}

            //Jank item creation
            GameObject sqr = Instantiate(image);//creates new object
            sqr.name = i.ToString();
            
            switch(items[i].name)//Setting color
            {
                case "red_square":
                    sqr.GetComponent<Image>().color = Color.red;
                    break;
                case "blue_square":
                    sqr.GetComponent<Image>().color = Color.blue;
                    break;
                case "yellow_square":
                    sqr.GetComponent<Image>().color = Color.yellow;
                    break;
                case "green_square":
                    sqr.GetComponent<Image>().color = Color.green;
                    break;
            }

            //setting item transform
            //sqr.transform.localScale = new Vector3(2f,2f,1);
            sqr.transform.SetParent(canvas.transform);
            sqr.transform.position = new Vector3((i*5f)-7.5f, 0, 0);

            //add event listener for item clicking
            sqr.GetComponent<Button>().onClick.AddListener(() => 
            {
                //Create Dialogue Box
                GameObject box = Instantiate(dialogue_box);
                box.transform.SetParent(canvas.transform);
                box.GetComponent<dialogue_box>().str = items[int.Parse(sqr.name)].text;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
