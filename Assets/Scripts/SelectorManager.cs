using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GeminiManager geminiManager;
    private string preprompt;
    public TextAsset textAssetData;
    private string prompt;
    private string posprompt;
    public string request = "the Total Revenue per Region";
    private string csvData;

    void Start()
    {
        csvData = textAssetData.text;
        posprompt = "\nYou should return the response in CSV format";
    }

    void UpdatePrompt(){
        preprompt = "You are a data analyst working with CSV data. I need you to" + request + "from the CSV data provided." + 
        "Here is the CSV data for reference:\n";
        prompt = preprompt + csvData + posprompt;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdatePrompt();
            StartCoroutine(geminiManager.SendDataToGAS(prompt, true));
        }
    }

        // Update is called once per frame
    // private void Update()
    // {
    //                     
    // }
}
