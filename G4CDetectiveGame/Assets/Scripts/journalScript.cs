using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class journalScript : MonoBehaviour
{
    public GameObject self;//the box
    public GameObject text;//the item text
    public GameObject done;//done button


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Removes the dialogue box and toggles variable
        done.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene("final_Scene");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
