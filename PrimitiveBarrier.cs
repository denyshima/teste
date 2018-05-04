using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveBarrier : MonoBehaviour {
    // IMPORTANT ** THIS SCRIPT SHOULD BE PLACED IN A CHILD OBJECT THAT HAD ITS TRANSFORM RESETED (0, 0, 0) - It needs to be centered on its parent
    // PrimitiveBarrier should make the gameObject appear above its parent origin in a smaller size, increase in size while falls and spin, stopping at the origin (possibly fading)    
    // Declared variables
    private Renderer render_this;
    private Vector3 vec_move = new Vector3();
    private Vector3 vec_scale = new Vector3();
    private Vector3 vec_originScale = new Vector3();
    [Range(0f, 10f)] public float f_scaleSize;
    [Range(0f, 0.5f)] public float f_scaleSpeed;
    [Range(0f, 2f)] public float f_fallTime;
    [Range(0f, 20f)] public float f_rotSpeed;
    [Range(0f, 0.1f)] public float f_fadeSpeed;
    [Range(0, 10)] public int int_startDistance;
    public bool bool_isAnimating = true;
    public bool bool_isFadeIn = true;
    public bool bool_isFadeOut = true;

    // Use this for initialization
    void Start () {
        // Initial Renderer setting
        render_this = gameObject.GetComponent<Renderer>();
        if (bool_isFadeIn == true)
        {
            Color color_invisible = gameObject.GetComponent<Renderer>().material.color;
            color_invisible.a = 0f;
            gameObject.GetComponent<Renderer>().material.color = color_invisible;
        }
        // Initial displacement of the object
        vec_move = gameObject.transform.localPosition;
        gameObject.transform.Translate(vec_move.x, vec_move.y + int_startDistance, vec_move.z);
        // Saving the original scale of the object for returning reference
        vec_originScale = gameObject.transform.localScale;
        // Initial scaling of the object
        vec_scale.Set(f_scaleSize, f_scaleSize, f_scaleSize);
        gameObject.transform.localScale = vec_scale;
        // Starting the IEnumerator
        StartCoroutine("Animate");      
    }
	
	// Update is called once per frame
	void Update () {
         if (gameObject.transform.localPosition.y <= vec_move.y)
        {
            bool_isAnimating = false;
            StopAllCoroutines();
            // Uncomment line bellow if original scale is required at the end - be careful, some animations might look choppy at the end
            // gameObject.transform.localScale = vec_originScale;
        }
         if (render_this.material.color.a >= 1)
        {
            bool_isFadeIn = false;            
        }
        if (render_this.material.color.a <= 0)
        {
            bool_isFadeOut = false;           
        }
    }  

   IEnumerator Animate()
    {      
        // Animation
        while (bool_isAnimating == true)
        {
            // Scale, spin and fall
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, vec_originScale, f_scaleSpeed);
            gameObject.transform.Rotate(Vector3.up * f_rotSpeed);
            gameObject.transform.Translate(vec_move.x, (vec_move.y - 1) * Time.deltaTime, vec_move.z);

            // Fade in
            if (bool_isFadeIn == true && bool_isFadeOut == false)
            {
                Color color_fadeIn = render_this.material.color;
                color_fadeIn.a = color_fadeIn.a + f_fadeSpeed;
                gameObject.GetComponent<Renderer>().material.color = color_fadeIn;               
            }          

            // Fade out
            if (bool_isFadeOut == true && bool_isFadeIn == false)
            {                
                Color color_fadeOut = render_this.material.color;
                color_fadeOut.a = color_fadeOut.a - f_fadeSpeed;
                gameObject.GetComponent<Renderer>().material.color = color_fadeOut;                
            }

            // Fade mix
            if (bool_isFadeIn == true && bool_isFadeOut == true)
            {                
                Color color_faded = render_this.material.color;
                if (color_faded.a <= 1)
                {
                    color_faded.a = color_faded.a + (2 * f_fadeSpeed);
                }
                if (color_faded.a >= 1)
                {
                    color_faded.a = color_faded.a - f_fadeSpeed;
                }
                gameObject.GetComponent<Renderer>().material.color = color_faded;
            }
            yield return new WaitForSeconds(f_fallSpeed * Time.deltaTime);
        }
    }
}
