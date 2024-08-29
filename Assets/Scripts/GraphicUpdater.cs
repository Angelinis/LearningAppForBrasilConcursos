using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicUpdater : MonoBehaviour
{
    public GameObject column_1;
    public GameObject column_2;
    public GameObject column_3;
    public CSVReader csvReader;
    private bool updated = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if(!updated && csvReader.readAllFile){
            UpdateScale();
            updated = true;
        }
    }

    void UpdateScale(){
        int total = csvReader.mySalesItemList.salesItem[0].y_2022 +   csvReader.mySalesItemList.salesItem[0].y_2023 + csvReader.mySalesItemList.salesItem[0].y_2024;
        Debug.Log(total);
        if (column_1 != null)
        {
            Vector3 scale_1 = column_1.transform.localScale;
            
            Vector3 scale_2 = column_2.transform.localScale;
            Vector3 scale_3 = column_3.transform.localScale;
            // scale_1.y = 0.1f;
            float scale_1_y =  (float)csvReader.mySalesItemList.salesItem[0].y_2022/total;
            float scale_2_y =  (float)csvReader.mySalesItemList.salesItem[0].y_2023/total;
            float scale_3_y =  (float)csvReader.mySalesItemList.salesItem[0].y_2024/total;

            scale_1.y = scale_1_y;
            scale_2.y = scale_2_y;
            scale_3.y = scale_3_y;


            Debug.Log(scale_1.y);
            Debug.Log(csvReader.mySalesItemList.salesItem[0].y_2022);
            
            column_1.transform.localScale = scale_1;
            column_2.transform.localScale = scale_2;
            column_3.transform.localScale = scale_3;
        }
        else
        {
            Debug.LogWarning("column_1 is not assigned in the Inspector.");
        }
    }
}
