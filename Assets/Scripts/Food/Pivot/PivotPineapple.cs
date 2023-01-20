using UnityEngine;
using RootMotion.FinalIK;
using DG.Tweening;

public class PivotPineapple : MonoBehaviour
{
    private InteractionTarget _interactionTarget;

    private GameObject _manForceArm;

    private void Start()
    {
        _interactionTarget = GetComponent<InteractionTarget>();
        _manForceArm = GameObject.Find("LeftHandIndex2");

        Pivot(_manForceArm);

    }

    private void Pivot(GameObject pivot)
    {
        _interactionTarget.pivot = pivot.transform;
    }

}
