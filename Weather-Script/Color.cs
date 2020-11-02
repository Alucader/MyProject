using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Color : MonoBehaviour
{
    Image image;
    UnityEngine.Color color;
    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        UnityEngine.Color color = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new UnityEngine.Color(color.r,color .g,color .b,Random.Range (50,255));
    }
}
