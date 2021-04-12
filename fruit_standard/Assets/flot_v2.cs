using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flot_v2 : MonoBehaviour
{

    public GameObject prefabBulle;
    private ArrayList bubbleList = new ArrayList();
    private bool isTracking;

    // Start is called before the first frame update
    void Start()
    {
       isTracking = false;
       StartCoroutine(popBubble());
       StartCoroutine(DestroyBubble());
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    IEnumerator popBubble()
    {
        while (true) 
        {
            if (isTracking) 
            {
                
                GameObject orangeBub = Instantiate(prefabBulle, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, Random.Range(0, 360), 0f));


                float scale = Random.Range(0.5f, 1.5f);
                orangeBub.transform.localScale = new Vector3(scale, scale, scale);
                orangeBub.SetActive(true);
                bubbleList.Insert(0, orangeBub);
            }

            yield return new WaitForSeconds(2f);
        }
    
    }
    IEnumerator DestroyBubble() {
        while (true)
        {   
            if(bubbleList.Count>8)
            {
                Destroy((GameObject)bubbleList[8]);
                bubbleList.RemoveAt(8);
            }

            yield return new WaitForSeconds(2f);
        }
    }

    public void startExperience()
    {
        isTracking = true;
    }

    public void endExperience()
    {
        isTracking = false;
    }

}
