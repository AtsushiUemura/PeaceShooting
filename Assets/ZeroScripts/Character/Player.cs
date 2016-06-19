using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// HPの管理（UIも含む）
/// 移動、攻撃以外の処理全て
/// </summary>
public class Player : MonoBehaviour {

    [SerializeField]
    private Status status;

    [SerializeField]
    private AudioClip damageSe;

    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Image hpImage;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerShooting playerShooting;


	// Use this for initialization
	void Start () {
        status.Init();
	}
	
	// Update is called once per frame
	void Update () {
        hpText.text = status.Hp.ToString();
	}

    /// <summary>
    /// ダメージ時の処理
    /// HP減算、コンボストップ、ゲームオーバー判定
    /// </summary>
    /// <param name="damage"></param>
    void Damage(int damage)
    {
        status.Hp -= damage;
        ScoreManager.instance.StopCombo();
        //ゲームオーバー処理
        if (status.Hp <= 0)
        {
            SetComponent(false);
        }
    }

    /// <summary>
    /// 敵を倒しすぎたときにプレイヤーを少しずつ黒くしていく
    /// </summary>
    void ChangeSpriteRenderereColor()
    {
        if (spriteRenderer.color.b >= 50)
        {
            spriteRenderer.color -= new Color(1,1,1);
        }
    }

    /// <summary>
    /// プレイヤーのコンポーネントをON、OFFにする
    /// </summary>
    /// <param name="active"></param>
    void SetComponent(bool active)
    {
        playerMovement.enabled = active;
        playerShooting.enabled = active;
    }

}

[System.Serializable]
public class Status
{
    [SerializeField]
    private int maxHp;
    public int MaxHp
    {
        get
        {
            return MaxHp;
        }
        set
        {
            MaxHp = value;
        }
    }

    [SerializeField]
    private int hp;
    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    [SerializeField]
    private int atk;
    public int Atk
    {
        get
        {
            return atk;
        }
        set
        {
            atk = value;
        }
    }

    [SerializeField]
    private int spd;
    public int Spd
    {
        get
        {
            return spd;
        }
        set
        {
            spd = value;
        }
    }

    //他に処理があれば追加
    public void Init()
    {
        hp = maxHp;
    }

}