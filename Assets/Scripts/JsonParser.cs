using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

[Serializable]
public class AnswerList
{
    public List<string> options;
    public AnswerList(int size)
    {
        options = new List<string>(new string[size]);
    }
}
public class JsonParser : MonoBehaviour
{
    
    [SerializeField] private string filePath;
    [SerializeField] private string gameName;
    [SerializeField] private TextAsset assetJson;
    [SerializeField] string subject;
    [SerializeField]List<Questions> questionsList = new List<Questions>();
    private JSONNode _parsedJson;
    [SerializeField] private int numOfOption =7;
    [SerializeField] private AnswerSet _answerSet;
    private void Start()
    {
        StartCoroutine(ReadData());
    }

    
    public IEnumerator ReadData()
    {
       
/*#if !UNITY_EDITOR
Debug.Log(filePath + "Path");    
         filePath = PlatformManager.instance.path;
        
        string gamePath = filePath + "/json/" + gameName + ".json";
        using ( UnityWebRequest www = UnityWebRequest.Get(gamePath))
        {
            
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string result = www.downloadHandler.text;
                _parsedJson = JSONNode.Parse(result);
                _answerSet.InitialSetUp();
                PlatformManager.instance.loadingPanel.SetActive(false);
              
            }
            www.Dispose();
        }
#endif

#if UNITY_EDITOR*/
        yield return new WaitForSeconds(0.1f);
        _parsedJson = JSONNode.Parse(assetJson.text);
        _answerSet.InitialSetUp();
        PlatformManager.instance.loadingPanel.SetActive(false);
/*#endif*/
    

    }
    
    public List<Questions> GetQuestion(int level)
    {
        List<string> question = new List<string>();
        JSONNode keyQuestion = _parsedJson[subject][level];
        foreach (KeyValuePair<string,JSONNode> tempQuestion in keyQuestion)
        {
            question.Add(tempQuestion.Key);
        }

        AnswerList[] answerLists = new AnswerList[keyQuestion.Count];

        for (int i = 0; i < _parsedJson[subject][level].Count; i++)
        {
            JSONNode currentLevelOption = _parsedJson[subject][level][i];
            answerLists[i] = new AnswerList(numOfOption);
            for (int j = 0; j < numOfOption; j++)
            {
                answerLists[i].options[j] = currentLevelOption[j];
            }
        }
        
        for (int i = 0; i < question.Count; i++)
        {
            questionsList.Add(new Questions(question[i], answerLists[i].options.ToArray()));
        }
        
        return questionsList;

    }


    public int CountLevel()
    {
        return _parsedJson[subject].Count;
    }
    
}
