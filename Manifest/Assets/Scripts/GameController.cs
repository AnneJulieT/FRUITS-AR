using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Camera _mainCam;
    [SerializeField] Transform _camParent;
    [SerializeField] GameObject _camLight;
    [SerializeField] GameObject _bg;

    [SerializeField] public float _aTime = 2f;

    public GameObject _targetObject;
    public GameObject _prevTargetObject;

    public bool hasTouched = false;
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
        int layerMask = 1 << 2;
        layerMask = ~layerMask;

        #region RayCast touch and mouse
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //hasTouched = true;
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Ray ray = _mainCam.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, layerMask))
                {
                    if (hit.collider.CompareTag("Forme"))
                    {
                        if (_targetObject == hit.collider.gameObject) // If reselect same shape, move back to origin
                        {
                            _targetObject = null;
                            MoveToOrigin(hit.collider.gameObject);
                        }
                        else if (_targetObject != _prevTargetObject)
                        {
                            _targetObject = hit.collider.gameObject;
                            MoveToCam(_targetObject);
                        }
                        _prevTargetObject = _targetObject;
                    }
                }
                //hasTouched = false;
                return;
            }
        }
        //else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    hasTouched = true;
        //}
        //this will not be executed if condition is true () 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                if (hit.collider.CompareTag("Forme"))
                {
                    //Debug.Log(hit.collider.name);
                    //_targetObject = hit.collider.gameObject;

                    if (_targetObject == hit.collider.gameObject)
                    {
                        _targetObject = null;
                        MoveToOrigin(hit.collider.gameObject);
                    }
                    else
                    {
                        _targetObject = hit.collider.gameObject;
                        MoveToCam(_targetObject);
                    }
                }
            }
        }
        #endregion
    }

    void MoveToCam(GameObject _obj)
    {
        //Debug.Log("Moving object to Cam!");
        LeanTween.cancelAll();
        _obj.GetComponent<Animator>().SetBool("Spin", false);
        _obj.GetComponent<Forme>()._desAnim.SetBool("Active", true);
        _obj.transform.SetParent(_camParent.transform);
        LeanTween.move(_obj, _camParent.position, _aTime).setEaseInOutQuint().setOnComplete(ActivateCamLight);
    }

    void MoveToOrigin(GameObject _obj)
    {
        //Debug.Log("Moving object to Origin!");
        LeanTween.cancelAll();
        _obj.GetComponent<Animator>().SetBool("Spin", true);
        _obj.GetComponent<Forme>()._desAnim.SetBool("Active", false);
        _obj.transform.SetParent(_obj.GetComponent<Forme>()._origin.transform);
        LeanTween.move(_obj, _obj.GetComponent<Forme>()._origin.transform, _aTime).setEaseInOutQuint().setOnComplete(DeactivateCamLight);
    }

    void SetBackground(bool state) {
        _bg.SetActive(state);
    }

    void ActivateCamLight()
    {
        SetBackground(true);
        _camLight.SetActive(true);
    }

    void DeactivateCamLight()
    {
        SetBackground(false);
        _camLight.SetActive(false);
    }

}
