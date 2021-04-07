using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pourritureController : MonoBehaviour
{
    [SerializeField] private GameObject smoke;
    [SerializeField] private BottleSmash bottleSmash;
    [SerializeField] private LiquidVolumeAnimator lva;
    [SerializeField] private GameObject cocktailWrapper;

    private void Start()
    {
        smoke.SetActive(false);
        cocktailWrapper.SetActive(false);
        bottleSmash.color = new Color(Random.Range(0,0.9f), Random.Range(0,0.5f), Random.Range(0.05f,0.9f)); 
        lva.level = 0.68f;
    }
    public void Appear() {
        bottleSmash.color = new Color(Random.Range(0, 0.9f), Random.Range(0, 0.5f), Random.Range(0.05f, 0.9f));
        lva.level = 0.68f;
        smoke.SetActive(true);
        cocktailWrapper.SetActive(true);
    }

    public void Disapear() {
        smoke.SetActive(false);
        cocktailWrapper.SetActive(false);
    }

}
