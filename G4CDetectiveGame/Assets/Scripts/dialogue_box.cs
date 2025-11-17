using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_box : MonoBehaviour
{
    public GameObject self;
    public GameObject text;
    public GameObject done;

    public string str = "Lorem Ipsum";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.GetComponent<TextMeshProUGUI>().text = str;

        //Removes the dialogue box
        done.GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(self);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
