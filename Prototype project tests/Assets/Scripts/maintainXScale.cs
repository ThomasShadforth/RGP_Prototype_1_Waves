using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maintainXScale : MonoBehaviour
{
    Vector3 LocalScale;
    void Start()
    {
        LocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = LocalScale;
    }
}
