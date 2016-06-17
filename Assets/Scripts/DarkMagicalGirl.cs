using UnityEngine;
using System.Collections;

public class DarkMagicalGirl : Enemy
{
    public int _maxHp;
    public int _speed;
    public int _attack;
    public int _deffence;
    public int _addScore;
    protected override void Move()
    {
        Debug.Log("move");
    }
    protected override void Shot()
    {
        Debug.Log("shot");
    }

    // Use this for initialization
    void Start()
    {
        base.InitStatus(_maxHp, _speed, _attack, _deffence, _addScore);
        Move();
        Shot();
        base.DebugLog();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
