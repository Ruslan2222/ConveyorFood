using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(InteractionObject))]
public class Banana : MonoBehaviour
{
    private InteractionObject _bananaObject;

    public InteractionObject interactionObject => _bananaObject;

    private void Start()
    {
        _bananaObject = GetComponent<InteractionObject>();
    }

}
