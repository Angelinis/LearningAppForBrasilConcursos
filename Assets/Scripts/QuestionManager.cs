using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    public GameObject congratulations;
    public GameObject fail;
    public GameObject feedbackCanvas;
    public TMP_Text m_TextComponent;
    public TMP_Text option_A, option_B, option_C, option_D, option_E;
    public Button send_Button;
    public CSVReaderExam csv_questions;
    private string answer;
    private bool onlyOnce = true;
    private int questsIndex = 0;
    private string chosenAnswer = "";
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (csv_questions.readAllFile && onlyOnce){
            m_TextComponent.text = csv_questions.quests[questsIndex].question;
            option_A.text = csv_questions.quests[questsIndex].option_A;
            option_B.text = csv_questions.quests[questsIndex].option_B;
            option_C.text = csv_questions.quests[questsIndex].option_C;
            option_D.text = csv_questions.quests[questsIndex].option_D;
            option_E.text = csv_questions.quests[questsIndex].option_E;
            answer = csv_questions.quests[questsIndex].answer;
            answer = "option_" + answer;

            onlyOnce = false;

        }
    }

    public void CheckAnswer(Button button)
    {
        string buttonName = button.gameObject.name;
        
        chosenAnswer = buttonName;

        if (chosenAnswer != "")
        {
            send_Button.interactable = true;
        }

    }

    public void SendAnswer()
    {
        feedbackCanvas.SetActive(true);        
        if (chosenAnswer == answer)
        {
            
            congratulations.SetActive(true);
        }
        else
        {
            fail.SetActive(true);
        }
    }

    public void TryAgain()
    {
        feedbackCanvas.SetActive(false); 
        fail.SetActive(false);
    }

    public void Next()
    {
        questsIndex = 1;
        onlyOnce = true;
        feedbackCanvas.SetActive(false); 
        congratulations.SetActive(false);
    }
}

