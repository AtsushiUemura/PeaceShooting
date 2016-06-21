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

    public bool arrived;
    public Vector2 _destination;

    protected override void Move()
    {
        if (base.target == null) return;
        else
        {
            if (!arrived) ai.Tracking(destination, 0f, base.speed);
            else ai.Tracking(base.target.position, distance, base.speed / 2);
        }
    }
    protected override void Shot()
    {
        if (base.target == null) return;
        else
        {
            if (!arrived) return;
            else
            {
                for (int i = 0; i < 8; i++)
                    Instantiate(base.bullet, transform.position, Quaternion.AngleAxis(45 * i, Vector3.forward));
                Instantiate(base.bullet, transform.position, transform.rotation);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<AI>();
        base.InitStatus(_maxHp, _speed, _attack, _deffence, _addScore, _lookAtTarget, _lookAtTargetSpan, _destination, _bullet, _hpBar, _target);
        base.LookAtTarget();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Vector2.Distance(transform.position, base.destination) < 0.1f) arrived = true;
        else if (Vector2.Distance(transform.position, base.destination) >= 2.0f) arrived = false;

    }

    private void OnBecameVisible()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

}
