using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GeminiManager geminiManager;
    private bool updatedCSV = false;
    private bool updatedCSVObjects = false;
    private string preprompt, posprompt, prompt;

    void Start()
    {
        preprompt = "You will provide to Unity certain objects for creating a graphic according to the next CSV data. I need you to \n";
        posprompt = "\nEach line is an object. You should return the response in CSV format: \nobject_name,scale_x,scale_y,scale_z,position_x,position_y,position_z" + 
        "\ncube,1,1,1,0,0,0";

    }

    // Update is called once per frame
    void Update()
    {
        if(!updatedCSV && geminiManager.responseCSV != "")
        {   
            prompt = preprompt + geminiManager.responseCSV + posprompt;
            StartCoroutine(geminiManager.SendDataToGAS(prompt, false));
            updatedCSV = true;
        }

        if(!updatedCSVObjects && geminiManager.responseCSVObjects !="")
        {
            string[] dataLines = geminiManager.responseCSVObjects.Split("\n");
            foreach(string s in dataLines)
            {
                Debug.Log("here!!!");
                string[] splitData = s.Split(",");
                // GraphicUnit graphicUnit = ScriptableObject.CreateInstance<GraphicUnit>();
                // graphicUnit.graphicName = splitData[0];
                // graphicUnit.graphicScaleX = float.Parse(splitData[1]);
                // graphicUnit.graphicScaleY = float.Parse(splitData[2]);
                // graphicUnit.graphicScaleZ = float.Parse(splitData[3]);
                // graphicUnit.graphicPositionX= float.Parse(splitData[4]);
                // graphicUnit.graphicPositionY= float.Parse(splitData[5]);
                // graphicUnit.graphicPositionZ= float.Parse(splitData[6]);

                // AssetDataBase.CreateAsset(graphicUnit, $"Assets/Graphics/{graphicUnit.graphicName}.asset");
            }
            
            // AssetDataBase.SaveAssets();
            updatedCSVObjects = true;
        }
    }
}
