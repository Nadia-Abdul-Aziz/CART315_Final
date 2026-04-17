using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;


[Serializable]
public class Line
{
    public string speaker;
    public string text;
}

[Serializable]
public class DialogueData
{
    public List<Line> lines;
}

public static class DialogueLoader
{
    public static DialogueData LoadDialogue(TextReader reader)
    {
        try
        {
            string json = reader.ReadToEnd();
            DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(json);
            return dialogueData;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load dialogue: {e.Message}");
            return null;
        }
    }
     
}
