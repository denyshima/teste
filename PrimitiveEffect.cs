using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple death effect (destroys object at the end)
public class PrimitiveEffect : MonoBehaviour {
    private Material mat_materialToFade;    
    public float f_fadeSpeed;
    public float f_riseSpeed;

    void Start()
    {
        //Get the material of this gameObject
        mat_materialToFade = gameObject.GetComponent<Renderer>().material;       
    }
    
    void FixedUpdate()
    {
        StartCoroutine("FadeOut");
        StartCoroutine("Rise");
        
        //"Kills" the gameObject when it goes completely transparent
        if (mat_materialToFade.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    //Speed adjustable by public float f_fadeSpeed
    IEnumerator FadeOut()
    {
        //While the material is still visible, make it less visible according to time passed
        while (mat_materialToFade.color.a > 0)
        {
            Color color_newColor = mat_materialToFade.color;
            color_newColor.a -= Time.deltaTime;
            mat_materialToFade.color = color_newColor;
            gameObject.GetComponent<Renderer>().material = mat_materialToFade;
            /* Instead of the above 2 lines, it could be done as only one line as follows:
            gameObject.GetComponent<Renderer>().material.color = color_newColor; */
            yield return new WaitForSeconds(f_fadeSpeed);
        }
    }   
    
    //Speed adjustable by public float f_riseSpeed
    IEnumerator Rise()
    {
        transform.Translate(0f,Time.deltaTime,0f);
        yield return new WaitForSeconds(f_riseSpeed);
    }
}
