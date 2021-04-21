using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdolescenceController : MonoBehaviour
{

    [SerializeField] private GameObject adolescenceWapper;
    [SerializeField] private GameObject juice;
    private ParticleSystem particles;

    [SerializeField] private AudioSource SourceAudio;
    [SerializeField] private List<AudioClip> clipList;

    void Start()
    {
        adolescenceWapper.SetActive(false);

        particles = juice.GetComponent<ParticleSystem>();
        particles.maxParticles = 0;
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                particles.maxParticles = 3500;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                particles.maxParticles = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            particles.maxParticles = 3500;
            int indexSon = (int)Random.Range(0, (float)clipList.Count);
            SourceAudio.clip = clipList[indexSon];
            SourceAudio.Play();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            particles.maxParticles = 0;
        }
    }

    public void Appear()
    {
        adolescenceWapper.SetActive(true);

    }

    public void Disapear()
    {
        adolescenceWapper.SetActive(false);

    }
}
