using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeScript : MonoBehaviour {

    [SerializeField]
    private Image image;
    [SerializeField]
    private float fadeLeap;

	// Use this for initialization
	void Start () {
	}

    public IEnumerator SetRayCastTartget(bool isTarget)
    {
        if(isTarget){
            image.raycastTarget = isTarget;
            yield return StartCoroutine("FadeOut");
        }
        else
        {
            yield return StartCoroutine("FadeIn");
            image.raycastTarget = isTarget;

        }
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
            if (image.color.a <= 0.01f)
            {
                c.a = 0;
                image.color = c;
                break;
            }
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        Debug.Log("fadeout");
        while (image.color.a < 1)
        {
            t += Time.deltaTime;
            var c = image.color;
            c.a = Mathf.Lerp(c.a, 1, t * fadeLeap);
            image.color = c;
            yield return null;
            
            if (image.color.a >= 0.99f)
            {
                c.a = 1;
                image.color = c;
                break;
            }
            Debug.Log(image.color.a);
        }

    }


}
