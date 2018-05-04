using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeFade : MonoBehaviour {
    // Variables
    public bool bool_isChanging = false;
    [Range(0f, 0.1f)] public float f_sceneFadeSpeed;   
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		if (bool_isChanging == true)
        {
            StartCoroutine("SceneFade");
        }
        if (this.GetComponent<Image>().color.a <= 0)
        {
            bool_isChanging = false;
            StopCoroutine("SceneFade");
        }
	}

    IEnumerator SceneFade()
    {
        Color image_toFadeColor = this.GetComponent<Image>().color;
        image_toFadeColor.a = image_toFadeColor.a - f_sceneFadeSpeed;
        this.GetComponent<Image>().color = image_toFadeColor;        
        yield return new WaitForEndOfFrame();
    }
}
