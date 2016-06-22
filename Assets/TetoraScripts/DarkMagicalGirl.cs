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
    public int _survivalTime;
    public bool _enableShot;
    public Vector2 _destination;
    public Vector2 _homePos;
    public bool moveStop;

    protected override void Move()
    {
        if (moveStop) return;
        else
        {
            if (!arrived) ai.Tracking(destination, 0f, base.speed);
            else ai.Tracking(base.target.position, distance, base.speed / 2);
        }
    }
    protected override void Shot()
    {
        if (base.enableShot)
        {
            if (base.target == null) return;
            else
            {
                if (!arrived) return;
                else
                {
                    for (int i = 0; i < 12; i++)
                        Instantiate(base.bullet, transform.position, Quaternion.AngleAxis(30 * i, Vector3.forward));
                    Instantiate(base.bullet, transform.position, transform.rotation);
                }
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<AI>();
        base.InitStatus(_maxHp, _speed, _attack, _deffence, _addScore, _lookAtTarget, _lookAtTargetSpan, _destination, _homePos, _survivalTime, _enableShot, _bullet, _hpBar, _target);
        base.LookAtTarget();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Vector2.Distance(transform.position, base.destination) < 0.1f) base.arrived = true;
        else if (Vector2.Distance(transform.position, base.destination) >= 2.0f) base.arrived = false;

    }

    private void OnBecameVisible()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

}
