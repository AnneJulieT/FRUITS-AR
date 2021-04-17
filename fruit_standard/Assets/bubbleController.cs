using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleController : MonoBehaviour
{
    public ParticleSystem gouttes;
    // private audioSource[] orgasmeList = new audioSource[10];

    //public GameObject bubbleWrapper;
    public GameObject bubble;

    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObject() 
    {
        bubble.SetActive(false);

        gouttes.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        gouttes.transform.position = gameObject.transform.position;
        gouttes.Play();
        
        // audioSource.Play();
    }

}
