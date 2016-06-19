using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// スコア管理をシングルトンで利用
/// スコア、ベストスコア、コンボ、それに関するUI等の実装
/// </summary>
public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;

    private int currentScore;
    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
        //とりあえずプライベートにしておく
        private
        set { }
    }

    private int bestScore;
    public int BestScore
    {
        get
        {
            return bestScore;
        }
        private
        set { }
    }

    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text escapeEnemyNumText;
    [SerializeField]
    private Text comboText;

    private int escapeEnemyNum = 0;
    private int combo = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        currentScoreText.text = currentScore.ToString();
        escapeEnemyNumText.text = escapeEnemyNum.ToString();
        comboText.text = combo.ToString();
	}

    void Init()
    {
        currentScore = 0;
        combo = 0;
        escapeEnemyNum = 0;
    }

    /// <summary>
    /// スコア加算
    /// 逃がした敵の数とコンボも
    /// </summary>
    public void AddScore(int score)
    {
        currentScore += score;
        escapeEnemyNum++;
        combo++;
    }

    /// <summary>
    /// コンボのストップ
    /// </summary>
    public void StopCombo()
    {
        combo = 0;
    }

    /// <summary>
    /// セーブ関数
    /// ベストスコアやコンボ、敵の逃がした数のセーブ
    /// </summary>
    public void Save()
    {

    }

}
