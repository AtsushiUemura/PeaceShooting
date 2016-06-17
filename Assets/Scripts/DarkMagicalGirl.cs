using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DarkMagicalGirl : Enemy
{
    public int _maxHp;
    public int _speed;
    public int _attack;
    public int _deffence;
    public int _addScore;
    public Slider _hpBar;
    public AI ai;
    public GameObject test;
    protected override void Move()
    {
        Debug.Log("move");
        ai.Tracking(test.transform);
    }
    protected override void Shot()
    {
        Debug.Log("shot");
    }

    // Use this for initialization
    void Start()
    {
        ai = GetComponent<AI>();
        base.InitStatus(_maxHp, _speed, _attack, _deffence, _addScore, _hpBar);
        //Move();
        Shot();
        base.DebugLog();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
