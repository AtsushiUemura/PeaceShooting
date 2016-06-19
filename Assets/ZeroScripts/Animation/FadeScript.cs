using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeScript : MonoBehaviour {

    private Image image;
    [SerializeField]
    private float fadeLeap;

	// Use this for initialization
	void Start () {
        image = this.GetComponent<Image>();
        StartCoroutine("SetRayCastTartget",false);
	}

    IEnumerator SetRayCastTartget(bool isTarget)
    {
        if(isTarget){
            yield return StartCoroutine("FadeOut");
        }
        else
        {
            yield return StartCoroutine("FadeIn");
        }
        image.raycastTarget = isTarget;
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        while(image.color.a > 0){
            t += Time.deltaTime;
            var c = image.color;
            c.a = Mathf.Lerp(c.a, 0, t * fadeLeap);
            image.color = c;            
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        while (image.color.a < 1)
        {
            t += Time.deltaTime;
            var c = image.color;
            c.a = Mathf.Lerp(0, c.a, t * fadeLeap);
            image.color = c;
            yield return null;
        }
    }


}
