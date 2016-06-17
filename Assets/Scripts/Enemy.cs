using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{

    protected int maxHp { get; set; }
    protected int hp { get; set; }
    protected int speed { get; set; }
    protected int attack { get; set; }
    protected int deffence { get; set; }
    protected int addScore { get; set; }
    protected bool isDead { get; set; }
    protected Slider hpBar { get; set; }
    /// <summary>
    /// 敵の動き操作
    /// </summary>
    protected abstract void Move();
    /// <summary>
    /// 敵の弾幕操作
    /// </summary>
    protected abstract void Shot();

    protected void OnBecameInvisible()
    {
        // ScoreManager.instance.AddScore(addScore);
        gameObject.SetActive(false);
    }
    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // ScoreManager.instance.StopCombo();
            isDead = true;
            gameObject.SetActive(false);
        }
    }
    protected void InitStatus(int maxHp, int speed, int attack, int deffence, int addScore)
    {
        hp = maxHp;
        this.speed = speed;
        this.attack = attack;
        this.deffence = deffence;
        this.addScore = addScore;
        isDead = false;
    }
    protected void DebugLog()
    {
        Debug.Log("hp: " + hp + " sp: " + speed + " at: " + attack + " df: " + deffence + " as: " + addScore);
    }
}
