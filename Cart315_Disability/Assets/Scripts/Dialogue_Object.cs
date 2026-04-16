using UnityEngine;
using System.Collections.Generic;

public class Dialogue_Object
{
    private List <string[]> dialogueLines;

    public Dialogue_Object(){
        dialogueLines = new List<string[]>();
    }
    public Dialogue_Object(List<string[]> dialogueLines){
        this.dialogueLines = dialogueLines;
    }

    public List<string[]> GetDialogueLines(){
        return dialogueLines;
    }

    public string[] GetDialogueLines(int index){
        return dialogueLines[index];
    }

    public void NewDialogueLines(string[] line){
        dialogueLines.Add(line);
    }

    public void AddTextLine(string speaker, string line){
        dialogueLines.Add(new string[] {speaker, line});
    }   

}
