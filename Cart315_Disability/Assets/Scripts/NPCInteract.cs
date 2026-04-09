using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private Animator animator;
    private bool playerNearby = false;

    

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (playerNearby && Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }
    public void Interact() {
        //ChatBubble3D.Create(transform.transform, new Vector3(-.3f, 1.7f, 0f), ChatBubble3D.IconType.Happy, "Hello there!");

        animator.SetTrigger("Talk");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

}
