using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                Debug.Log(collider);

                if (collider.TryGetComponent(out NPCInteract npcInteract)) {
                    npcInteract.interact();
                }
            }
        }
    }
}