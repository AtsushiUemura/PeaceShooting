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
    public GameObject _bullet;
    public Slider _hpBar;
    public float distance;
    public Transform _target;
    public bool _lookAtTarget;
    public float _lookAtTargetSpan;

    protected override void Move()
    {
        ai.Tracking(base.target, distance, base.speed);
    }
    protected override void Shot()
    {
        Instantiate(base.bullet, transform.position, transform.rotation);
    }

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<AI>();
        base.InitStatus(_maxHp, _speed, _attack, _deffence, _addScore, _lookAtTarget, _lookAtTargetSpan, _bullet, _hpBar, _target);
        base.LookAtTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
