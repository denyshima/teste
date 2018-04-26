using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveEffect : MonoBehaviour {
    private Material mat_materialToFade;    
    public float f_fadeSpeed;
    public float f_riseSpeed;

    void Start()
    {
        mat_materialToFade = gameObject.GetComponent<Renderer>().material;       
    }

    void FixedUpdate()
    {
        StartCoroutine("FadeOut");
        StartCoroutine("Rise");
        if (mat_materialToFade.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator FadeOut()
    {
        while (mat_materialToFade.color.a > 0)
        {
            Color color_newColor = mat_materialToFade.color;
            color_newColor.a -= Time.deltaTime;
            mat_materialToFade.color = color_newColor;
            gameObject.GetComponent<Renderer>().material = mat_materialToFade;            
            yield return new WaitForSeconds(f_fadeSpeed);
        }
    }

    IEnumerator Rise()
    {
        transform.Translate(0f,Time.deltaTime,0f);
        yield return new WaitForSeconds(f_riseSpeed);
    }
}
