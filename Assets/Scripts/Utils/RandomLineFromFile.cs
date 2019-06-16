using UnityEngine;
using TMPro;

public class RandomLineFromFile : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public string frontText;
    public string endText;
    public TextAsset file;
    void Start()
    {
        myText.text = "";
        string[] lines = file.ToString().Split('\n');
        if (!string.IsNullOrEmpty(frontText))
        {
            myText.text += frontText;
        }
        myText.text += lines[Random.Range(0, max: lines.Length)];
        if (!string.IsNullOrEmpty(endText))
        {
            myText.text += endText;
        }
    }
}
