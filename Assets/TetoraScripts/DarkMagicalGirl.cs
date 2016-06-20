using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DarkMagicalGirl : Enemy
{
    private AI ai;
    public int _maxHp;
    public float _speed;
    public int _attack;
    public int _deffence;
    public int _addScore;
    public Sprite _bullet;
    public Slider _hpBar;
    public float distance;
    public Transform _target;
    public bool lookAtTarget;
    protected override void Move()
    {
        Debug.Log("move");
        ai.Tracking(base.target, distance, base.speed);
    }
    protected override void Shot()
    {
        Debug.Log("shot");
    }

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<AI>();
        base.InitStatus(_maxHp, _speed, _attack, _deffence, _addScore, _bullet, _hpBar, _target);
        Shot();
        base.DebugLog();
    }

    // Update is called once per frame
    void Update()
    {
        base.LookAt(lookAtTarget);
        Move();
    }
}
