using UnityEngine;

public class Touch : MonoBehaviour
{
    private Man _manScript;

    private void Start()
    {
        _manScript = FindObjectOfType<Man>();
    }

    private void Update()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<Man>())
                {
                    _manScript.animationMan.SetTrigger("Tap");
                }
                else if (hit.transform.GetComponent<Orange>())
                {
                    Orange orange;
                    orange = hit.transform.gameObject.GetComponent<Orange>();

                    if (orange.interactionObject)
                    {
                        orange.interactionObject.enabled = false;
                        orange.Grab();
                        _manScript.StartCoroutine(_manScript.PickUp(orange.interactionObject));
                    }
                }
                else if (hit.transform.GetComponent<Pear>())
                {
                    Pear pear;
                    pear = hit.transform.gameObject.GetComponent<Pear>();

                    if (pear.interactionObject.enabled)
                    {
                        pear.interactionObject.enabled = false;
                        pear.Grab();
                        _manScript.StartCoroutine(_manScript.PickUp(pear.interactionObject));
                    }

                }
                else if (hit.transform.GetComponent<Pineapple>())
                {
                    Pineapple pineapple;
                    pineapple = hit.transform.gameObject.GetComponent<Pineapple>();

                    if (pineapple.interactionObject.enabled)
                    {
                        pineapple.interactionObject.enabled = false;
                        pineapple.Grab();
                        _manScript.StartCoroutine(_manScript.PickUp(pineapple.interactionObject));
                    }
                }

            }

        }
    }
}
