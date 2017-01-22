using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class Subtitles : MonoBehaviour {

    private static List<string> subs = new List<string>();

    static Text textField;

    static bool title = false;

	// Use this for initialization
	void Start ()
    {
        readTextFile("Assets\\Resources\\Subtitles\\SubtitleList.txt");
        textField = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (title)
        {
            int rng = Random.Range(0, subs.Count);
            textField.text = subs[rng];
            StartCoroutine(wait());
        }

    }

    void readTextFile(string file_path)
    {
        StreamReader input = new StreamReader(file_path);

        while(!input.EndOfStream)
        {
            subs.Add(input.ReadLine());
        }

        input.Close();
    }

    public static void ChangeTitle()
    {

        title = true;
    }

    IEnumerator wait()
    {
        title = false;
        yield return new WaitForSeconds(3);
        textField.text = "";        
    }
}
