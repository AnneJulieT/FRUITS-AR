using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petalController : MonoBehaviour
{
    Transform transfromRef;

    bool hasPos = false;
    public void DisableAnim()
    {
        GetCurrentPos();
        StartCoroutine(DisableAnimator());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Animator>().enabled)
        {
            DisableAnim();
        }
    }

    IEnumerator DisableAnimator()
    {
        yield return new WaitUntil(() => hasPos);
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void GetCurrentPos() {
        transfromRef = gameObject.transform;
        hasPos = true;
    }
}
