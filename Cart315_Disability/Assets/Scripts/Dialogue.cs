using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public UIDocument uiDocument;

    private bool playerNearby = false;
    private VisualElement dialogueBox;
    private Label dialogueLabel;
    private Label npcName;

    private int dialogueIndex = 0;

    private (string speaker, string line)[] lines = new (string, string)[]
    {
        ("JORDAN", "Ugh. This just feels… heavy?"),
        ("DOG WALKER", "They say the statue is about resilience."),
        ("JORDAN", "It looks like anybody to me."),
        ("DOG WALKER", "Hm."),
        ("DOG WALKER", "Fair enough. I guess you don't see yourself in it."),
        ("JORDAN", "What does that even mean? I'm not resilient? It's not because I feel pain differently that I don't feel pain at all. What would he even know about —"),
    };

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        dialogueBox = root.Q<VisualElement>("DialogueBox");
        dialogueLabel = root.Q<Label>("DialogueLabel");
        npcName = root.Q<Label>("NPCName");

        dialogueBox.style.display = DisplayStyle.None;
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueIndex < lines.Length)
            {
                dialogueBox.style.display = DisplayStyle.Flex;
                npcName.text = lines[dialogueIndex].speaker;
                dialogueLabel.text = lines[dialogueIndex].line;
                dialogueIndex++;
            }
            else
            {
                // End of dialogue
                dialogueBox.style.display = DisplayStyle.None;
                dialogueIndex = 0;
            }
        }
        if (lines[dialogueIndex].line.Contains("pain"))
{
    dialogueBox.style.backgroundColor = new StyleColor(new Color(42f/255f, 40f/255f, 44f/255f, 0.88f));
dialogueLabel.style.color = new StyleColor(new Color(172f/255f, 168f/255f, 170f/255f));
dialogueLabel.style.unityFontStyleAndWeight = FontStyle.Italic;
npcName.style.color = new StyleColor(new Color(140f/255f, 136f/255f, 138f/255f));
}

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            dialogueIndex = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueIndex = 0;
            dialogueBox.style.display = DisplayStyle.None;
        }
    }
}