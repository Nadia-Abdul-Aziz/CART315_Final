using UnityEngine;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public UIDocument uiDocument;

    private bool playerNearby = false;
    private VisualElement dialogueBox;
    private Label dialogueLabel;
    private Label npcName;

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
            dialogueBox.style.display = DisplayStyle.Flex;
            npcName.text = "David";
            dialogueLabel.text = "test dialogue";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialogueBox.style.display = DisplayStyle.None;
        }
    }
}