using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOpacityChanger : MonoBehaviour
{
    public Image myImage;

    public void changeOpacity(float opacity)
    {
        myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, opacity);
    }

}
