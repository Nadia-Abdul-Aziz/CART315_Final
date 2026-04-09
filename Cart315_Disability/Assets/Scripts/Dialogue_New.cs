using UnityEngine;

public class Dialogue_New : MonoBehaviour
{

    public enum NPCNames
    {
        Statue,
        Hiker
    }

    public List<Dialogue_Object>[] dialogues;
    private VisualElement dialogueBox;
    private Label dialogueLabel;
    private Label npcName;

    

    void Start()
    {
        dialogues = new List<Dialogue_Object>[System.Enum.GetValues(typeof(NPCNames)).Length];
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

    void playDialogue(NPCNames npc, int dialogueIndex)
    {
        int dialogueLength = dialogues[(int)npc][dialogueIndex].GetDialogueLines().Count;
        for (int i = 0; i < dialogueLength; i++)
        {
            string[] line = dialogues[(int)npc][dialogueIndex].GetDialogueLines(i);
            
            dialogueBox.style.display = DisplayStyle.Flex;

            npcName.text = line[0];
            dialogueLabel.text = line[1];
            if (line[1].Contains("pain"))
            {
                dialogueBox.style.backgroundColor = new StyleColor(new Color(42f/255f, 40f/255f, 44f/255f, 0.88f));
                dialogueLabel.style.color = new StyleColor(new Color(172f/255f, 168f/255f, 170f/255f));
                dialogueLabel.style.unityFontStyleAndWeight = FontStyle.Italic;
                npcName.style.color = new StyleColor(new Color(140f/255f, 136f/255f, 138f/255f));
            }
            
        }
    }

}
