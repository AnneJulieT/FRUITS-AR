using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleController : MonoBehaviour
{
    public ParticleSystem gouttes;
    public GameObject bubbleWrapper;
    public GameObject bubble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObject() 
    {
        StartCoroutine(DestroyAll());
    }


    private IEnumerator DestroyAll() 
    {
        bubble.SetActive(false);

        gouttes.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        gouttes.Play();
    

        Debug.Log("coroutine Start");
        yield return new WaitForSeconds(3f);
        Debug.Log("coroutine End");
        Destroy(bubbleWrapper);
    }
}
