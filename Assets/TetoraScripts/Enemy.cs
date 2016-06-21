using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{

    protected int maxHp { get; set; }
    protected int hp { get; set; }
    protected float speed { get; set; }
    protected int attack { get; set; }
    protected int deffence { get; set; }
    protected int addScore { get; set; }
    protected bool lookAtTarget { get; set; }
    protected float lookAtTargetSpan { get; set; }
    protected bool isDead { get; set; }
    protected GameObject bullet { get; set; }
    protected Slider hpBar { get; set; }
    protected Transform target { get; set; }

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
        ScoreManager.instance.AddScore(addScore);
        gameObject.SetActive(false);
    }
    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            ScoreManager.instance.StopCombo();
            isDead = true;
            gameObject.SetActive(false);
        }
    }
    private void LookAt2D()
    {
        transform.LookAt2D(target, Vector2.up);
    }
    protected void InitStatus(
        int maxHp,
        float speed,
        int attack,
        int deffence,
        int addScore,
        bool lookAtTarget,
        float lookAtTargetSpan,
        GameObject bullet,
        Slider hpBar,
        Transform target)
    {
        hp = maxHp;
        this.speed = speed;
        this.attack = attack;
        this.deffence = deffence;
        this.addScore = addScore;
        this.lookAtTarget = lookAtTarget;
        this.lookAtTargetSpan = lookAtTargetSpan;
        isDead = false;
        this.bullet = bullet;
        this.hpBar = hpBar;
        this.target = target;
    }

    protected void LookAtTarget()
    {
        StartCoroutine(Wait(target, lookAtTargetSpan));
    }
    private IEnumerator Wait(Transform target, float time)
    {
        while (true)
        {
            if (lookAtTarget) LookAt2D();
            Shot();
            yield return new WaitForSeconds(time);
        }
    }
    /// <summary>
    /// デバッグ
    /// </summary>
    protected void DebugLog()
    {

    }
}
