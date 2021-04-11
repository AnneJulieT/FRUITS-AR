using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flot_v2 : MonoBehaviour
{

    public GameObject prefabBulle;
    private ArrayList bubbleList = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
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
            GameObject orangeBub = Instantiate(prefabBulle, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, Random.Range(0, 360), 0f));
            orangeBub.SetActive(true);
            bubbleList.Insert(0, orangeBub);

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

}
