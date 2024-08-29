using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVReaderExam : MonoBehaviour
{
    public TextAsset textAssetData;
    public List<Question> quests = new List<Question>();
    public bool readAllFile = false;

    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] lines = textAssetData.text.Split(new[] { '\n' }, System.StringSplitOptions.None);
        
        // Regular expression pattern for the custom delimiter ",+," (or any other custom delimiter)
        string pattern = ",\\+,";

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            // Use regex to split the line by the custom delimiter pattern
            var row = Regex.Split(lines[i], pattern);

            if (row.Length > 1)
            {
                Question q = new Question
                {
                    number = int.TryParse(row[0], out var num) ? num : 0,
                    question = row[1],
                    option_A = row[2],
                    option_B = row[3],
                    option_C = row[4],
                    option_D = row[5],
                    option_E = row[6],
                    answer = row[7],
                    questionType = row[8],
                    contestName = row[9],
                    exam_number = int.TryParse(row[10], out var examNum) ? examNum : 0
                };

                quests.Add(q);
            }
        }

        foreach (Question q in quests)
        {
            Debug.Log(q.number + "," + q.contestName);
        }

        readAllFile = true;
    }
}

public class Question
{
    public int number { get; set; }
    public string question { get; set; }
    public string option_A { get; set; }
    public string option_B { get; set; }
    public string option_C { get; set; }
    public string option_D { get; set; }
    public string option_E { get; set; }
    public string answer { get; set; }
    public string questionType { get; set; }
    public string contestName { get; set; }
    public int exam_number { get; set; }
}
