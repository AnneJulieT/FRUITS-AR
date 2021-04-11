using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flot_v2 : MonoBehaviour
{

    public GameObject prefabBulle;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(popBubble());
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
            //orangeBub.transform.localPosition = new Vector3(0f, 6f, 0f);
            //orangeBub.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360), 0f));

            //Destroy(orangeBub.gameObject, 5f);

            yield return new WaitForSeconds(2f);
        }
    
    }

}
