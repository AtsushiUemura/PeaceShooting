using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleManager : MonoBehaviour {

    [SerializeField]
    private FadeScript fade;

	// Use this for initialization
	void Start () {
        StartCoroutine(fade.SetRayCastTartget(false));	    
	}

    public IEnumerator LoadGameScene()
    {
        yield return StartCoroutine(fade.SetRayCastTartget(true));
        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
