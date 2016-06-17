using UnityEngine;
using System.Collections;

public class DarkMagicalGirl : Enemy
{
    public int _maxHp;
    public int _speed;
    public int _attack;
    public int _deffence;

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
        base.InitStatus();
        Move();
        Shot();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
