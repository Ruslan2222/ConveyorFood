using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(InteractionObject))]
public class Pineapple : MonoBehaviour
{
    [Header("Particle")]
    [Space]
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private ParticleSystem _aura;

    private InteractionObject _pineappleObject;
    private Rigidbody _rigidbody;

    public InteractionObject interactionObject => _pineappleObject;
    public Rigidbody rigidbodyPineapple => _rigidbody;

    private void Start()
    {
        _pineappleObject = GetComponent<InteractionObject>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Grab()
    {
        Destroy(_aura);
        Instantiate(_confetti, new Vector3(transform.position.x, -1.25f, 0f), Quaternion.Euler(-90, 0, 0));
    }

}
