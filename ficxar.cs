using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ficxar : MonoBehaviour
{
    void Update()
    {
        transform.position += (transform.parent.position - transform.position) * 5 * Time.deltaTime;
    }
}
