using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor; 
#endif
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class DialogueParser : MonoBehaviour {

    struct DialogueLine {
        public string name;
        public string content;
        public int pose;
        public string position;
        public string[] options;

        public DialogueLine(string Name, string Content, int Pose, string Position) {
            name = Name;
            content = Content;
            pose = Pose;
            position = Position;
            options = new string[0];
        }
    }

    List<DialogueLine> lines;

    // Use this for initialization
    void Start () {
        string file = "Assets/Data/";
		#if UNITY_EDITOR
        string sceneNum = EditorApplication.currentScene;
		#endif
        //sceneNum = Regex.Replace (sceneNum, "[^0-9]", "");
        //file += sceneNum;
        file += "Dialogue1.txt";

        lines = new List<DialogueLine>();

		lines.Add(new DialogueLine("Kyle", "Where is the Guardian?", 0 , "R"));
		lines.Add(new DialogueLine("Orien", "Master is not in his sanctum at the moment. How may i help?", 0 , "L"));
		lines.Add(new DialogueLine("Kyle", "Since you are his apprentice, you should be informed about it as well.", 1 , "R"));
		lines.Add(new DialogueLine("Kyle", "The realm is facing some unknown enemies, we received reports on sightings of dark energies on the border skirmishes. We are not exactly sure what it is, but the council suspects it's magic that's ancient and forbidden.", 1 , "R"));
		lines.Add(new DialogueLine("Orien", "Ancient and forbidden?", 0 , "L"));
		lines.Add(new DialogueLine("Kyle", "Yes", 1 , "R"));
		lines.Add(new DialogueLine("Orien", "I don't like the sound of this, something is really amiss, truth be told, the Guardian haven't returned since 2 weeks ago.", 0 , "L"));
		lines.Add(new DialogueLine("Kyle", "...", 1 , "R"));

        //LoadDialogue (file);
    }

    // Update is called once per frame
    void Update () {

    }

    void LoadDialogue(string filename) {
        string line;
        StreamReader r = new StreamReader (filename);

        using (r) {
            do {
                line = r.ReadLine();
                if (line != null) {
                    string[] lineData = line.Split(';');
                    if (lineData[0] == "Player") {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "", 0, "");
                        lineEntry.options = new string[lineData.Length-1];
                        for (int i = 1; i < lineData.Length; i++) {
                            lineEntry.options[i-1] = lineData[i];
                        }
                        lines.Add(lineEntry);
                    } else {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]), lineData[3]);
                        lines.Add(lineEntry);
                    }
                }
            }
            while (line != null);
            r.Close();
        }
    }

    public string GetPosition(int lineNumber) {
        if (lineNumber < lines.Count) {
            return lines[lineNumber].position;
        }
        return "";
    }

    public string GetName(int lineNumber) {
        if (lineNumber < lines.Count) {
            return lines[lineNumber].name;
        }
        return "";
    }

    public string GetContent(int lineNumber) {
        if (lineNumber < lines.Count) {
            return lines[lineNumber].content;
        }
        return "";
    }

    public int GetPose(int lineNumber) {
        if (lineNumber < lines.Count) {
            return lines[lineNumber].pose;
        }
        return 0;
    }

    public string[] GetOptions(int lineNumber) {
        if (lineNumber < lines.Count) {
            return lines[lineNumber].options;
        }
        return new string[0];
    }
    
}