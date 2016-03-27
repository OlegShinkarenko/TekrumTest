using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;
using UnityEngine.UI;

public class ServerScript : MonoBehaviour {

    int[] idNumber = new int[6];
    int[] numAuthor = new int [6];
    string[] artName = new string[6];

    int _numAuthor = 0;
    int _idNumber = 0;
    int count1 = 0;
    int count2 = 0;

    void Start() {
        Queri(); 
    }

    public void Queri() 
    {
        ParseQuery<ParseObject> query = ParseObject.GetQuery("Articles");
        query.GetAsync("bIpwjWOnlL").ContinueWith(t =>
        {
            ParseObject articlesName = t.Result;
            numAuthor[0] = articlesName.Get<int>("theNumberOfAuthors");
            idNumber[0] = articlesName.Get<int>("idNumber");
            artName[0] = articlesName.Get<string>("articlesName");
        });

        query.GetAsync("EbdbkEWo0W").ContinueWith(t =>
        {
            ParseObject articlesName = t.Result;
            numAuthor[1] = articlesName.Get<int>("theNumberOfAuthors");
            idNumber[1] = articlesName.Get<int>("idNumber");
            artName[1] = articlesName.Get<string>("articlesName");
        });

        query.GetAsync("wu0tJTJy8h").ContinueWith(t =>
        {
            ParseObject articlesName = t.Result;
            numAuthor[2] = articlesName.Get<int>("theNumberOfAuthors");
            idNumber[2] = articlesName.Get<int>("idNumber");
            artName[2] = articlesName.Get<string>("articlesName");
        });

        query.GetAsync("QqNTHtZ65s").ContinueWith(t =>
        {
            ParseObject articlesName = t.Result;
            numAuthor[3] = articlesName.Get<int>("theNumberOfAuthors");
            idNumber[3] = articlesName.Get<int>("idNumber");
            artName[3] = articlesName.Get<string>("articlesName");
        });

        query.GetAsync("4LCYfHxd7N").ContinueWith(t =>
        {
            ParseObject articlesName = t.Result;
            numAuthor[4] = articlesName.Get<int>("theNumberOfAuthors");
            idNumber[4] = articlesName.Get<int>("idNumber");
            artName[4] = articlesName.Get<string>("articlesName");
        });

        query.GetAsync("ck3rWwhdoe").ContinueWith(t =>
        {
            ParseObject articlesName = t.Result;
            numAuthor[5] = articlesName.Get<int>("theNumberOfAuthors");
            idNumber[5] = articlesName.Get<int>("idNumber");
            artName[5] = articlesName.Get<string>("articlesName");
        });
        
    } 

   public void Info()
    {
    
       for (int j = 0; j < idNumber.Length; j++)
        { 
            _idNumber = idNumber[j]; 
        }
       Debug.Log("Всего статей: " + _idNumber);

       foreach (int value in numAuthor)
        {
            _numAuthor += value;  
        }
        Debug.Log("Всего авторов: " + _numAuthor);

        for (int i = 0; i < numAuthor.Length; i++)
        {
            if (numAuthor[i].Equals(1))
                count1++;
            if (numAuthor[i] >= 4)
            {
                count2++;
               Debug.Log("Название статьи: " + artName[i] + " Количество со-авторов: " + numAuthor[i]);
            }
        }
        Debug.Log("Количество статей, у которых один автор: " + count1);
        
    }
}

