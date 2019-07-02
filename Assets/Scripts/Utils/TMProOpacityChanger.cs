using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMProOpacityChanger : MonoBehaviour
{
    public TextMeshProUGUI myText;

    public void changeOpacity(float opacity)
    {
        myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, opacity);
    }
}
