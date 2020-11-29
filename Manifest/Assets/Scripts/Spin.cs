using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] public float rotSpeed = 10f;
    float _startPosition;

    [SerializeField] Rigidbody _rb;
    [SerializeField] string _tag;

    bool hasTouched = false;
    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetTouchInput();
    }

    void GetTouchInput()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Ray ray = _camera.ScreenPointToRay(touch.position);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit))
        //        {
        //            if (hit.collider.CompareTag(_tag))
        //            {
        //                hasTouched = true;
        //                _startPosition = touch.position.x;
        //            }
        //        }
        //    }
        //    else if (touch.phase == TouchPhase.Moved && hasTouched)
        //    {
        //        //if (_startPosition > touch.position.x)
        //        //{
        //        //    transform.Rotate(Vector3.down, -rotSpeed * Time.deltaTime);
        //        //}
        //        //else if (_startPosition < touch.position.x)
        //        //{
        //        //    transform.Rotate(Vector3.down, rotSpeed * Time.deltaTime);
        //        //}
        //        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

        //        //_rb.AddTorque(_camera.transform.up * -touchDeltaPosition.x);
        //        _rb.AddTorque(transform.up * touchDeltaPosition.y);
        //    }
        //    else if (touch.phase == TouchPhase.Ended)
        //    {
        //    {
        //        hasTouched = false;
        //    }
        //}



        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    // Get movement of the finger since last frame
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

        //    // Add Torque to gameObject
        //    _rb.AddTorque(_camera.transform.up * -touchDeltaPosition.x/* * optionalForce*/);
        //    _rb.AddTorque(_camera.transform.right * touchDeltaPosition.y/* * optionalForce*/);
        //}
        //else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    // throw anker, stop rotating slowly
        //    _rb.angularDrag = 0.7f;
        //}


        if (Input.touchCount == 1)
        {
            float rotateSpeed = 0.09f;
            Touch touchZero = Input.GetTouch(0);

            //Rotate the model based on offset
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
            transform.localEulerAngles = localAngle;
        }
    }

    //void GetTouchInputRB()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        Ray ray = _camera.ScreenPointToRay(touch.position);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.collider.CompareTag("Manifest"))
    //            {
    //                if (touch.phase == TouchPhase.Moved)
    //                {
    //                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

    //                    //_rb.AddTorque(_camera.transform.up * -touchDeltaPosition.x);
    //                    _rb.AddTorque(transform.up * touchDeltaPosition.y);
    //                }
    //            }
    //        }
    //    }
    //}
}
