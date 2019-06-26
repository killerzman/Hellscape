using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeTransform : MonoBehaviour
{
    public GameObject parent;
    public GameObject child;

    private Vector2 relativePosition;
    private void Start()
    {
        relativePosition = child.GetComponent<RectTransform>().position - parent.GetComponent<RectTransform>().position;
    }

    private void Update()
    {
        child.GetComponent<RectTransform>().position = relativePosition + (Vector2)parent.GetComponent<RectTransform>().position; 
    }
}
