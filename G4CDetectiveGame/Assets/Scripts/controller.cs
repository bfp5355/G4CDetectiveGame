using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public TextAsset json;
    private List<Item> items = new List<Item>();

    public GameObject image;
    public Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        items = jsonParse.DeserializeList(json.text);//parses items into a list


        //This is super temp to get this to work as a proof of concept. Will have to do more work to get file pathing working for sprites and images
        for(int i = 0; i < items.Count; i++)//debug logs items and populates them on the screen
        {
            Debug.Log(items[i].name);

            //Jank item creation
            GameObject sqr = Instantiate(image);//creates new object
            sqr.name = i.ToString();

            switch(items[i].image)//Setting color
            {
                case "red":
                    sqr.GetComponent<Image>().color = Color.red;
                    break;
                case "blue":
                    sqr.GetComponent<Image>().color = Color.blue;
                    break;
                case "yellow":
                    sqr.GetComponent<Image>().color = Color.yellow;
                    break;
                case "green":
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
                Debug.Log("click");
                canvas.GetComponent<Text>().text = items[int.Parse(sqr.name)].text;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
