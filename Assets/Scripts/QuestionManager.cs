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
    public GameObject zoom;
    public GameObject gameOver;
    public TMP_Text m_TextComponent;
    public TMP_Text zoom_TextComponent;
    public TMP_Text pointsText;
    public TMP_Text option_A, option_B, option_C, option_D, option_E;
    public Button send_Button;
    public CSVReaderExam csv_questions;
    private string answer;
    private bool onlyOnce = true;
    private int questsIndex = 0;
    private string chosenAnswer = "";
    public int points = 0;
    private AudioManager audioManager;
    private bool lastTime = false;
   
   
    void Start()
    {
        audioManager = AudioManager.instance;
        pointsText.text = ""+points;
        feedbackCanvas.SetActive(false);
        zoom.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (csv_questions.readAllFile && onlyOnce){

            if(lastTime){
                gameOver.SetActive(true);
                onlyOnce = false;
                return;
            }

            m_TextComponent.text = csv_questions.quests[questsIndex].question;
            zoom_TextComponent.text = csv_questions.quests[questsIndex].question;

            option_A.text = csv_questions.quests[questsIndex].option_A;
            option_B.text = csv_questions.quests[questsIndex].option_B;
            option_C.text = csv_questions.quests[questsIndex].option_C;
            option_D.text = csv_questions.quests[questsIndex].option_D;
            option_E.text = csv_questions.quests[questsIndex].option_E;
            answer = csv_questions.quests[questsIndex].answer;
            answer = "option_" + answer;

            if(questsIndex + 1 < csv_questions.quests.Count)
            {
                questsIndex += 1;
            } else {
                lastTime = true;
            }

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
            // audioManager.PlaySFX(0);
            audioManager.PlaySFX(3);
        }

    }

    public void SendAnswer()
    {
        feedbackCanvas.SetActive(true);        
        if (chosenAnswer == answer)
        {
            
            congratulations.SetActive(true);
            points += 10;
            pointsText.text = ""+points;
            audioManager.PlaySFX(1);
        }
        else
        {
            fail.SetActive(true);
            audioManager.PlaySFX(2);
        }
    }

    public void TryAgain()
    {
        audioManager.PlaySFX(3);
        feedbackCanvas.SetActive(false); 
        fail.SetActive(false);
    }

    public void Next()
    {
        // questsIndex = 1;
        audioManager.PlaySFX(3);
        onlyOnce = true;
        feedbackCanvas.SetActive(false); 
        congratulations.SetActive(false);
    }
}

