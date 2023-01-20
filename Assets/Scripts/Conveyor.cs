using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbodyConveyor;

    private void Start()
    {
        _rigidbodyConveyor = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = _rigidbodyConveyor.position;
        _rigidbodyConveyor.position += Vector3.right * _speed * Time.fixedDeltaTime;
        _rigidbodyConveyor.MovePosition(pos);
    }

}
