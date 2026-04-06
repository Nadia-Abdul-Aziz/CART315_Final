using UnityEngine;

public class NPCInteract : MonoBehaviour
{
private Animator animator;

private void Awake() {
    animator = GetComponent<Animator>();
 }

public void Interact() {
    //ChatBubble3D.Create(transform.transform, new Vector3(-.3f, 1.7f, 0f), ChatBubble3D.IconType.Happy, "Hello there!");
    animator.SetTrigger("Talk");
    }

}
