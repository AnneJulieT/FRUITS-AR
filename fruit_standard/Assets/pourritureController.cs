using System.Collections;
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
   private ArrayList cherryList = new ArrayList();

    private void Start()
    {
        smoke.SetActive(false);
        cocktailWrapper.SetActive(false);
        bottleSmash.color = new Color(Random.Range(0,0.9f), Random.Range(0,0.5f), Random.Range(0.05f,0.9f)); 
        lva.level = 0.68f;
        musique.Stop();
    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
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
        musique.Pause();
    }

    public void InstanciateCherry() {
        
        GameObject go = Instantiate(cherryPrefab, instRef.transform.position, Quaternion.identity);
        go.transform.localScale = new Vector3(9, 9, 9);
        cherryList.Add(go);
    }
}
