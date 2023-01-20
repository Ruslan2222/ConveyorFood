using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(InteractionObject))]
public class Pear : MonoBehaviour
{
    [Header("Particle")]
    [Space]
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private ParticleSystem _aura;

    private InteractionObject _pearObject;
    private Rigidbody _rigidbody;
    public InteractionObject interactionObject => _pearObject;
    public Rigidbody rigidbodyPear => _rigidbody;
    private void Start()
    {
        _pearObject = GetComponent<InteractionObject>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Grab()
    {
        Destroy(_aura);
        Instantiate(_confetti, new Vector3(transform.position.x, -1.5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
    }

}
