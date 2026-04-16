using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class NPCInteract : MonoBehaviour
{
    private Animator animator;
    private bool playerNearby = false;
    private Dialogue_New Dialogue_New;
    [SerializeField] private Dialogue_New.NPCNames npcNames;
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private UIDocument interactUIDocument;
    private int dialogueIndex = 0;
    private Dialogue_Object dialogueObject;
    private bool isInteracting = false;
    private VisualElement dialogueBox;
    private Label dialogueLabel;
    private Label npcName;
    private Label interactPrompt;
    private List<Dialogue_Object> dialogues;


    private void Awake() {
        animator = GetComponent<Animator>();

        var root = uiDocument.rootVisualElement;
        dialogueBox = root.Q<VisualElement>("DialogueBox");
        dialogueLabel = root.Q<Label>("DialogueLabel");
        npcName = root.Q<Label>("NPCName");

        dialogueBox.style.display = DisplayStyle.None;

        var interactRoot = interactUIDocument.rootVisualElement;
        interactPrompt = interactRoot.Q<Label>("Interact");
        interactPrompt.style.display = DisplayStyle.None;
        
    }

    void Start() {
        dialogues = Dialogue_New.GetDialogue(npcNames);
        dialogueAmount = dialogues.Count;
    }

    private void Update() {
        if (playerNearby && Input.GetKeyDown(KeyCode.E)) {
            SoundManager.PlaySound(SoundType.Interact);
            isInteracting = true;
            Interact();
        }

        if (!isInteracting && playerNearby) {
            interactPrompt.style.display = DisplayStyle.Flex;
        }
        else
        {
            interactPrompt.style.display = DisplayStyle.None;
        }
    }
    void Interact() {
        if (npcNames != Dialogue_New.NPCNames.Statue) {
            animator.SetTrigger("Talk");
        }
        playDialogue(npcNames, dialogueIndex);
        dialogueIndex = (dialogueIndex + 1) % dialogueAmount; // Loop through dialogues
    }

    void playDialogue(Dialogue_New.NPCNames npc, int dialogueIndex)
    {
        int dialogueLength = dialogues[dialogueIndex].GetDialogueLines().Count;
        for (int i = 0; i < dialogueLength; i++)
        {
            string[] line = dialogues[dialogueIndex].GetDialogueLines(i);
            Debug.Log(line[0] + ": " + line[1]);
            
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

        // End of dialogue
        dialogueBox.style.display = DisplayStyle.None;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            isInteracting = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            isInteracting = false;
            dialogueBox.style.display = DisplayStyle.None;
        }
    }

}
