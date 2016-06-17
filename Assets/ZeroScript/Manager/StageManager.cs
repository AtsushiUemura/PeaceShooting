using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

    [SerializeField]
    private int currentStageNum;

    [SerializeField]
    private GameObject[] enemies;

    private int enemyNum;
    private int currentEnemyNum;

	// Use this for initialization
	void Start () {
        enemyNum = enemies.Length;
        currentEnemyNum = enemyNum;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
