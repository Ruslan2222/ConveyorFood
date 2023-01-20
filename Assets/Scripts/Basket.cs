using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Basket : MonoBehaviour
{
    [Header("Particle")]
    [Space]
    [SerializeField] private ParticleSystem _plusOne;

    private UI _uiScript;

    private Vector3 basketPos = new Vector3(-0.01f, 0.002f, 0.003f);

    private bool _throw;

    private void Start()
    {
        _uiScript = FindObjectOfType<UI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_throw)
        {
            if (other.TryGetComponent(out Orange orange))
            {
                orange.transform.parent = transform;
                orange.transform.DOLocalMove(basketPos, 0.5f);
                orange.transform.DOScale(new Vector3(0.107f, 0.107f, 0.107f), 1f);
                orange.rigidbodyOrange.isKinematic = false;

                if (_uiScript.goalNameFruit == "Orange")
                {
                    Instantiate(_plusOne, new Vector3(transform.position.x - 1.3f, transform.position.y + 2f, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                    _uiScript.GoalUpdate();
                }
            }
            else if (other.TryGetComponent(out Pear pear))
            {
                pear.transform.parent = transform;
                pear.transform.DOLocalMove(basketPos, 0.5f);
                pear.transform.DOScale(new Vector3(0.05f, 0.06f, 0.05f), 1f);
                pear.rigidbodyPear.isKinematic = false;

                if (_uiScript.goalNameFruit == "Pear")
                {
                    Instantiate(_plusOne, new Vector3(transform.position.x - 1.3f, transform.position.y + 2f, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                    _uiScript.GoalUpdate();
                }
            }
            else if (other.TryGetComponent(out Pineapple pineapple))
            {
                pineapple.transform.parent = transform;
                pineapple.transform.DOLocalMove(basketPos, 0.5f);
                pineapple.transform.DOScale(new Vector3(0.03f, 0.03f, 0.03f), 1f);
                pineapple.rigidbodyPineapple.isKinematic = false;

                if (_uiScript.goalNameFruit == "Pineapple")
                {
                    Instantiate(_plusOne, new Vector3(transform.position.x - 1.3f, transform.position.y + 2f, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                    _uiScript.GoalUpdate();
                }
            }

            _throw = true;
        }

        StartCoroutine(ThrowInBucket());

    }

    private IEnumerator ThrowInBucket()
    {
        yield return new WaitForSeconds(1f);
        _throw = false;
    }

}
