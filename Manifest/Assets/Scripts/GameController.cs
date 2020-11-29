using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Camera _mainCam;
    [SerializeField] Transform _camParent;

    public GameObject _targetObject;

    public bool isTriggered = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        GetTouchInput();
    }

    void GetTouchInput()
    {
        #region RayCast touch and mouse
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = _mainCam.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Forme"))
                    {
                        
                    }
                }
            }
            return;
        }
        //this will not be executed if condition is true () 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Forme"))
                {
                    Debug.Log(hit.collider.name);
                }
            }
        }
        #endregion
    }

    void MoveTo() {
        
    }

}
