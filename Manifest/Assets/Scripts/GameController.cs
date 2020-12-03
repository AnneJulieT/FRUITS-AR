using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Camera _mainCam;
    [SerializeField] Transform _camParent;
    [SerializeField] GameObject _camLight;
    [SerializeField] GameObject _bg;

    [SerializeField] GameObject _shapes;

    [SerializeField] Material _bgColor;

    Color blackIn = new Color(0,0,0,0.8f);
    Color blackOut = new Color(0, 0, 0, 0f);

    [SerializeField] public float _aTime = 2f;

    public GameObject _targetObject;
    public GameObject _prevTargetObject;

    public bool hasTouched = false;
    public bool isTriggered = false;

    void Start()
    {
        _bgColor = _bg.GetComponent<MeshRenderer>().material;
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
                        else
                        {
                            _targetObject = hit.collider.gameObject;
                            MoveToCam(_targetObject);
                        }
                    }
                    else if (hit.collider.CompareTag("Manifest") && !hasTouched)
                    {
                        SetShapes();
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
                else if (hit.collider.CompareTag("Manifest") && !hasTouched)
                {
                    SetShapes();
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
        ActivateCamLight();
        //StartCoroutine(FadeInObject(_bg));
        //TweenObjectColorIn(_bg);
        SetBackground(true);
        LeanTween.move(_obj, _camParent.position, _aTime).setEaseInOutQuint();
    }

    void MoveToOrigin(GameObject _obj)
    {
        //Debug.Log("Moving object to Origin!");
        LeanTween.cancelAll();
        _obj.GetComponent<Animator>().SetBool("Spin", true);
        _obj.GetComponent<Forme>()._desAnim.SetBool("Active", false);
        _obj.transform.SetParent(_obj.GetComponent<Forme>()._origin.transform);
        //StartCoroutine(FadeOutObject(_bg));
        SetBackground(false);
        DeactivateCamLight();
        LeanTween.move(_obj, _obj.GetComponent<Forme>()._origin.transform, _aTime).setEaseInOutQuint();
    }

    void SetBackground(bool state)
    {
        _bg.SetActive(state);
    }

    void BgOn() {
        _bg.SetActive(true);
    }

    void BgOff() {
        _bg.SetActive(false);
    }

    void ActivateCamLight()
    {
        _camLight.SetActive(true);
    }

    void DeactivateCamLight()
    {
        SetBackground(false);
        _camLight.SetActive(false);
    }

    void SetShapes()
    {
        _shapes.SetActive(true);
        LeanTween.scale(_shapes, Vector3.one, 2f).setEaseInOutExpo();
        hasTouched = true;
    }
}
   
