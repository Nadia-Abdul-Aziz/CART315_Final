using UnityEngine;

public class RotateHead : MonoBehaviour
{
   public Transform HeadObject, TargetObject, HeadForward;

    public float MaxAngle, MinAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
       Vector3 Direction = (TargetObject.position - HeadObject.position).normalized;
        float angle = Vector3.SignedAngle(Direction, HeadForward.forward, HeadForward.up);
        if (angle < MaxAngle && angle > MinAngle)
        {
            HeadObject.LookAt(TargetObject);
        }
    }
}
