using System.Collections;
using UnityEngine;
using RootMotion.FinalIK;

[RequireComponent(typeof(Animator))]
public class Man : MonoBehaviour
{
    [Header("IK")]   
    [SerializeField] private OffsetPose _offsetPose;
    private InteractionSystem _manIk;
    private FullBodyBipedIK _manBody;
    private float _holdWeight;

    [Header("Animation")]
    private Animator _animatorMan;
    public Animator animationMan => _animatorMan;

    private void Start()
    {
        _animatorMan = GetComponent<Animator>();
        _manIk = GetComponent<InteractionSystem>();
        _manBody = GetComponent<FullBodyBipedIK>();
    }

    private void LateUpdate()
    {
        if (_manIk == null) return;

        _offsetPose.Apply(_manBody.solver, _holdWeight, _manBody.transform.rotation);
        
    }

    public IEnumerator PickUp(InteractionObject interObject)
    {
        _manIk.StartInteraction(FullBodyBipedEffector.LeftHand, interObject, true);

        while (_holdWeight < 1f)
        {
            _holdWeight += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        _animatorMan.SetTrigger("Grab");

    }


}
