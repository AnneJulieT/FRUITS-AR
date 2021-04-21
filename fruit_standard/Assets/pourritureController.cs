﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pourritureController : MonoBehaviour
{
    [SerializeField] private GameObject smoke;
    [SerializeField] private BottleSmash bottleSmash;
    [SerializeField] private LiquidVolumeAnimator lva;
    [SerializeField] private GameObject cocktailWrapper;
    [SerializeField] private GameObject cherryPrefab;
    [SerializeField] private GameObject parapluie;
    [SerializeField] GameObject instRef;
    [SerializeField] private AudioSource musique;
    private float speedCoef = 0.005f;
    private bool isTracking;



    private ArrayList cherryList = new ArrayList();
    

    private void Start()
    {
        smoke.SetActive(false);
        cocktailWrapper.SetActive(false);
        bottleSmash.color = new Color(Random.Range(0,0.9f), Random.Range(0,0.5f), Random.Range(0.05f,0.9f)); 
        lva.level = 0.68f;
        musique.Stop();
        musique.volume = 0;
        isTracking = false;

    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && isTracking == true)
            {
                GameObject go = Instantiate(cherryPrefab, instRef.transform.position, Quaternion.identity);
                go.transform.localScale = new Vector3(9, 9, 9);
                cherryList.Add(go);
            }
        }
    }
    public void Appear() {
        bottleSmash.color = new Color(Random.Range(0, 0.9f), Random.Range(0, 0.5f), Random.Range(0.05f, 0.9f));
        lva.level = 0.68f;
        smoke.SetActive(true);
        cocktailWrapper.SetActive(true);
        musique.Play();
        musique.volume = 0;
        StartCoroutine(VolumeUp());
        isTracking = true;
    }

    public void Disapear() {
        smoke.SetActive(false);
        cocktailWrapper.SetActive(false);
        parapluie.transform.localPosition = new Vector3(-0.00306017604f, 0.00423249509f, 0.0045483131f);
        parapluie.transform.localRotation = new Quaternion(-0.527507663f, 0.0597384758f, -0.800903678f, 0.276984423f);
        for (int i = 0; i < cherryList.Count; i++) {
            Destroy((GameObject)cherryList[i]);
        }
        cherryList.Clear();
        musique.volume = 1;
        StartCoroutine(VolumeDown());
        isTracking = false;
    }

    public void InstanciateCherry() {
        
        GameObject go = Instantiate(cherryPrefab, instRef.transform.position, Quaternion.identity);
        go.transform.localScale = new Vector3(9, 9, 9);
        cherryList.Add(go);
    }
    IEnumerator VolumeUp() {
        for (float i = 0; i < 1; i += speedCoef)
        {
            musique.volume = i;
            yield return null;
        }
    }
    IEnumerator VolumeDown()
    {
        for (float i = 1; i > 0; i -= speedCoef)
        {
            musique.volume = i;
            yield return null;
        }
        Debug.Log("PAUSE");
        musique.Pause();
        
    }
 

}
