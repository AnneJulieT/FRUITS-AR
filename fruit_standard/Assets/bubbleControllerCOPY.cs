using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleControllerCOPY : MonoBehaviour
{
    public ParticleSystem gouttes;
    public GameObject bubble;

    [SerializeField] private AudioSource SoundEmetor;
    [SerializeField] private List<AudioClip> clipList;


    // Start is called before the first frame update
    void Start()
    {
        bubble.SetActive(true);

    }


    public void DestroyObject() 
    {
        bubble.SetActive(false);

        gouttes.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        gouttes.transform.position = gameObject.transform.position;
        gouttes.Play();

        int clipNumber = (int)Random.Range(0,(float)clipList.Count);
        SoundEmetor.clip = clipList[clipNumber];
        SoundEmetor.Play();
    }

}
