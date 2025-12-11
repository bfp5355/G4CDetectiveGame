using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_box : MonoBehaviour
{
    public GameObject self;//the box
    public GameObject text;//the item text
    public GameObject done;//done button
    public GameObject itemName;//the name text
    public GameObject controllerObj;//the scene controller, for variable toggling

    public string str = "Lorem Ipsum";
    public string strName = "Lorem Ipsum";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.GetComponent<TextMeshProUGUI>().text = str;
        itemName.GetComponent<TextMeshProUGUI>().text = strName;

        //Removes the dialogue box and toggles variable
        done.GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(self);
            Debug.Log("done");
            controllerObj.GetComponent<controller>().itemBoxClosed++;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
