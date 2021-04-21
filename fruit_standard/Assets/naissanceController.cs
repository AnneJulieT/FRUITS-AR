using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naissanceController : MonoBehaviour
{
    [SerializeField] GameObject petalContainer;
    [SerializeField] private GameObject vase;
    [SerializeField] private GameObject vaseCase;
    [SerializeField] private GameObject vaseCaseContainer;
    [SerializeField] private GameObject petalWrapper;
    private ArrayList petalList = new ArrayList();
    private bool vaseBroken;
    private bool GoCoroutine;

    private void Start()
    {
        vase.SetActive(false);
        vaseBroken = false;
        GoCoroutine = false;
        StartCoroutine(InstantiatePetals());
    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                OnScreenTouch();
            }
        }
    }
    public void Appear()
    {
        vase.SetActive(true);
        GameObject brokenVase = GameObject.Find("vase_case");
        if (brokenVase != null)
        {
            Destroy(brokenVase);
        }
        vaseBroken = false;
        GoCoroutine = true;
        }
    private IEnumerator InstantiatePetals(){
        while (true)
        {
            if (GoCoroutine)
            {
                GameObject go = Instantiate(petalWrapper, petalContainer.transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
                go.SetActive(true);
                petalList.Add(go);
            }
            yield return new WaitForSeconds(2.1f);
        }
        
    }
    public void Disappear()
    {
        vase.SetActive(false);

        for (int i = 0; i < petalList.Count; i++)
        {
            Destroy((GameObject)petalList[i]);
        }
        petalList.Clear();
        GameObject brokenVase = GameObject.Find("vase_case(Clone)");
        if (brokenVase != null)
        {
            Destroy(brokenVase);
        }
        GoCoroutine = false;
    }

    public void OnScreenTouch() {
        if (vaseBroken == false && GoCoroutine == true) 
        {
            //GameObject go = Instantiate(vaseCase, new Vector3(-0.00999999978f, 0.888999999f, 0.805999994f), Quaternion.identity, vaseCaseContainer.transform);
            GameObject go = Instantiate(vaseCase, vaseCaseContainer.transform.position, Quaternion.identity);
            go.SetActive(true);
            go.transform.rotation = new Quaternion(0, 0, -0.707106829f, 0.707106829f);
            go.transform.localScale = new Vector3(1.24161148f, 1.24161148f, 1.24161148f);
            vaseBroken = true;
        }

        vase.SetActive(false);
    }
}
