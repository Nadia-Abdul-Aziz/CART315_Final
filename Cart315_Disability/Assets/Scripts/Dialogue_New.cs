using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Dialogue_New : MonoBehaviour
{

    public enum NPCNames
    {
        Statue,
        Hiker
    }

    public List<Dialogue_Object>[] dialogues = new List<Dialogue_Object>[System.Enum.GetValues(typeof(NPCNames)).Length];
    private VisualElement dialogueBox;
    private Label dialogueLabel;
    private Label npcName;

    

    void Awake()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogues[i] = new List<Dialogue_Object>();
        }

        StatueDialogue();
        HikerDialogue();
    }

    void StatueDialogue()
    {
        //Example dialogue for the statue NPC
        Dialogue_Object dialogue1 = new Dialogue_Object();
        dialogue1.AddTextLine("Statue", "I am a statue.");
        dialogue1.AddTextLine("Player", "Wow, you look really solid!");
        dialogue1.AddTextLine("Statue", "Thank you, I take pride in my durability.");

        dialogues[(int)NPCNames.Statue].Add(dialogue1);
    }

    void HikerDialogue()
    {
        Dialogue_Object dialogue1 = new Dialogue_Object();

        dialogue1.AddTextLine("JORDAN", "Ugh. This just feels… heavy?");
        dialogue1.AddTextLine("HIKER", "They say the statue is about resilience.");
        dialogue1.AddTextLine("JORDAN", "It looks like anybody to me.");
        dialogue1.AddTextLine("HIKER", "Hm.");
        dialogue1.AddTextLine("HIKER", "Fair enough. I guess you don't see yourself in it.");
        dialogue1.AddTextLine("JORDAN", "What does that even mean? I'm not resilient? It's not because I feel pain differently that I don't feel pain at all. What would he even know about —");

        dialogues[(int)NPCNames.Hiker].Add(dialogue1);
    }

    public int GetDialogueAmount(NPCNames npc)
    {
        return dialogues[(int)npc].Count;
    }

    public List<Dialogue_Object> GetDialogue(NPCNames npc)
    {
        return dialogues[(int)npc];
    }

}
