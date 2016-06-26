using UnityEngine;
using System.Collections;

public class GameButton : MonoBehaviour {

    [SerializeField]
    private TitleManager titleManager;

    public void OnClick()
    {
        titleManager.LoadGameScene();
    }

}
