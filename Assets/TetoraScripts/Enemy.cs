using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{

    protected int maxHp { get; set; }
    protected int hp { get; set; }
    protected float speed { get; set; }
    protected int attack { get; set; }
    protected int defence { get; set; }
    protected int addScore { get; set; }
    protected bool lookAtTarget { get; set; }
    protected float lookAtTargetSpan { get; set; }
    protected bool isDead { get; set; }
    protected GameObject bullet { get; set; }
    protected Slider hpBar { get; set; }
    protected Transform target { get; set; }
    protected int timer { get; set; }
    protected Vector2 destination { get; set; }

    protected abstract void Move();

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
        if (target == null) return;
        else
        {
            if (!lookAtTarget) return;
            else transform.LookAt2D(target, Vector2.up);
        }
    }
    protected void InitStatus(
        int maxHp,
        float speed,
        int attack,
        int deffence,
        int addScore,
        bool lookAtTarget,
        float lookAtTargetSpan,
        Vector2 destination,
        GameObject bullet,
        Slider hpBar,
        Transform target)
    {
        hp = maxHp;
        this.speed = speed;
        this.attack = attack;
        this.defence = deffence;
        this.addScore = addScore;
        this.lookAtTarget = lookAtTarget;
        this.lookAtTargetSpan = lookAtTargetSpan;
        this.destination = destination;
        isDead = false;
        this.bullet = bullet;
        this.hpBar = hpBar;
        this.target = target;
    }

    protected void LookAtTarget()
    {
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        while (true)
        {
            timer++;
            Debug.Log(timer);
            if (timer == 30) destination = new Vector2(0, 10);
                 LookAt2D();
            Shot();
            yield return new WaitForSeconds(lookAtTargetSpan);
        }
    }

    /// <summary>
    /// デバッグ
    /// </summary>
    protected void DebugLog()
    {
 
    }
}
