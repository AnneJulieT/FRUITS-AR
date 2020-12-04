using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Camera _mainCam;
    [SerializeField] Transform _camParent;
    [SerializeField] GameObject _camLight;
    [SerializeField] GameObject _bg;
    [SerializeField] GameObject _trackingCallToAction;
    [SerializeField] GameObject _objectCTA;

    [SerializeField] GameObject _shapes;

    [SerializeField] Material _bgColor;

    Color blackIn = new Color(0,0,0,0.8f);
    Color blackOut = new Color(0, 0, 0, 0f);

    [SerializeField] public float _aTime = 2f;

    public GameObject _targetObject = null;
    public GameObject _prevTargetObject = null;

    public bool hasTouched = false;
    public bool isTriggered = false;
    public bool isTracking = false;

    void Start()
    {
        _bgColor = _bg.GetComponent<MeshRenderer>().material;
    }


    void Update()
    {
        GetTouchInput();

        if (hasTouched && _targetObject == null)
        {
            if (isTracking)
            {
                _objectCTA.SetActive(false);
            }
            else
            {
                _objectCTA.SetActive(true);
            }
        }
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
                    OnHit(hit.collider);
                }
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
                OnHit(hit.collider);
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

    void OnHit(Collider collider)
    {
        if (collider.CompareTag("Forme"))
        {
            //Debug.Log(hit.collider.name);
            //_targetObject = hit.collider.gameObject;

            if (_targetObject == collider.gameObject)
            {
                _targetObject = null;
                MoveToOrigin(collider.gameObject);
                _objectCTA.SetActive(true);
            }
            else
            {
                _targetObject = collider.gameObject;
                MoveToCam(_targetObject);
                _objectCTA.SetActive(false);
            }
        }
        else if (collider.CompareTag("Manifest") && !hasTouched)
        {
            SetShapes();
            //_trackingCallToAction.SetActive(false);
        }
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

    public void SetTrackingState(bool state)
    {
        isTracking = !state;
        if (_targetObject == null)
        {
            _trackingCallToAction.SetActive(!state);
        }
    }
}
   
