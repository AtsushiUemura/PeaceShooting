using UnityEngine;
using System.Collections;

public class GameButton : MonoBehaviour {

    [SerializeField]
    private TitleManager titleManager;
    [SerializeField]
    private int nextSceneNumber;

    public void OnClick()
    {
        StartCoroutine(titleManager.LoadGameScene(nextSceneNumber));
    }

}
