using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSeguir : MonoBehaviour
{

    [SerializeField] private GameObject camerinha;

    // Start is called before the first frame update
    void Start()
    {
        camerinha = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camerinha.transform.rotation * 
            Vector3.forward, camerinha.transform.rotation * Vector3.up); 
    }
}
