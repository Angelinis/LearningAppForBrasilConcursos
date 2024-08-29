using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;
    public int numberOfColumns;
    public bool readAllFile = false;
    // Start is called before the first frame update
    [System.Serializable]
    public class SalesItem
    {
        public string name;
        public int y_2022;
        public int y_2023;
        public int y_2024;
    }
    [System.Serializable]
    public class SalesItemList
    {
        public SalesItem[] salesItem;
    }

    public SalesItemList mySalesItemList = new SalesItemList();

    void ReadCSV(){
        string[] data = textAssetData.text.Split(new string[] {",","\n"}, StringSplitOptions.None);

        int tableSize = data.Length / numberOfColumns - 1 ;
        mySalesItemList.salesItem = new SalesItem[tableSize];

        for(int i=0; i< tableSize; i++){
            mySalesItemList.salesItem[i] = new SalesItem();
            mySalesItemList.salesItem[i].name = data[numberOfColumns* (i+1)];
            mySalesItemList.salesItem[i].y_2022 = int.Parse(data[numberOfColumns* (i+1) + 1]);
            mySalesItemList.salesItem[i].y_2023 = int.Parse(data[numberOfColumns* (i+1) + 1]);
            mySalesItemList.salesItem[i].y_2024 = int.Parse(data[numberOfColumns* (i+1) + 1]);                
        }

        readAllFile = true;
    }

    void Start()
    {
        ReadCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
