using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AnswerSet : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;
    [SerializeField] private QuestionGenerator questionGenerator;
    [SerializeField]private Questions currentQuestion;
    [SerializeField]private List<Questions> currentQuestionList = new List<Questions>();
    [SerializeField]private JsonParser parser;
    [SerializeField] private int currentLevelIndex;
    [SerializeField] private int totalNumberOfQuestion;
    [SerializeField] private List<Button> options = new List<Button>();
    [SerializeField] private JsonParser _jsonParser;


    public void  InitialSetUp()
    {
        
        Debug.Log("Its working");
        
        for (int i = 0; i < 5; i++)
        {
            currentQuestionList = parser.GetQuestion(i);
        }
       
        totalNumberOfQuestion = currentQuestionList.Count;

       
    }

   

    public void GetData()
    {

        if (currentQuestionList.Count <=2)
        {
            StartCoroutine(_jsonParser.ReadData());
        }
        int randomQuestion = Random.Range(0, (currentQuestionList.Count));
        questionGenerator.GetQuestion(currentQuestionList[randomQuestion]);
        inputManager.GetAnswerString(currentQuestionList[randomQuestion].options[0]);
        currentQuestionList.Remove(currentQuestionList[randomQuestion]);

    }
}


[Serializable]
public struct Questions
{
    public string question;
    public string[] options;
    public Questions(string _question, string[] _options)
    {
        question = _question;
        options = _options;
    }
}