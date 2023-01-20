using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(InteractionObject))]
public class Orange : MonoBehaviour
{
    [Header("Particle")]
    [Space]
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private ParticleSystem _aura;

    private InteractionObject _objectOrange;
    private Rigidbody _rigidbody;
    public InteractionObject interactionObject => _objectOrange;
    public Rigidbody rigidbodyOrange => _rigidbody;

    private void Start()
    {
        _objectOrange = GetComponent<InteractionObject>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Grab()
    {
        Destroy(_aura);
        Instantiate(_confetti, new Vector3(transform.position.x, -1.47f, 0f), Quaternion.Euler(-90, 0, 0));
    }

}
