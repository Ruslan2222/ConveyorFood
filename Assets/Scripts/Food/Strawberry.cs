using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(InteractionObject))]
public class Strawberry : MonoBehaviour
{
    private InteractionObject _strawberryObject;

    public InteractionObject interactionObject => _strawberryObject;

    private void Start()
    {
        _strawberryObject = GetComponent<InteractionObject>();
    }

}
