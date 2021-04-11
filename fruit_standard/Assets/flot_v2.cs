using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flot_v2 : MonoBehaviour
{

    public Transform prefabBulle;
    // Start is called before the first frame update
    void Start()
    {
        startCoroutine("popBubble");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            InvokeRepeating("popBubble", 0f, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            CancelInvoke("popBubble");
        }

    }


    IEnumerator popBubble()
    {
        while (true) 
        {
            Transform orangeBub = Instantiate(prefabBulle);
            orangeBub.position = new Vector3(0f, 6f, 0f);
            orangeBub.rotation = Quaternion.Euler(new Vector3(0f, 0f, 35f));

            Destroy(orangeBub.gameObject, 5f);

            yield return new WaitForSeconds(0.5f);
        }
    
    }

}
