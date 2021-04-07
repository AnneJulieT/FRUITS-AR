using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forme : MonoBehaviour
{
    public GameObject _origin;
    [SerializeField] GameObject _description;
    public Animator _desAnim;

    private void Awake()
    {
        _desAnim = _description.GetComponent<Animator>();
    }
}
