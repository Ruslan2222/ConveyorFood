using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(InteractionObject))]
public class Watermelon : MonoBehaviour
{
    private InteractionObject _watermelonObject;

    public InteractionObject interactionObject => _watermelonObject;

    private void Start()
    {
        _watermelonObject = GetComponent<InteractionObject>();
    }

}
