using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveButton : MonoBehaviour
{

    public string waveName;
    public Vector2 originalSize;
    Vector2 transformSize;
    public bool selected;

    void Start()
    {
        originalSize = GetComponent<Button>().GetComponent<Image>().rectTransform.sizeDelta;
        transformSize = originalSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            GetComponent<Button>().GetComponent<Image>().rectTransform.sizeDelta = transformSize;
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().GetComponent<Image>().rectTransform.sizeDelta = originalSize;
            GetComponent<Button>().interactable = true;
        }
    }
}
