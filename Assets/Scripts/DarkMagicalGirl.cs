using UnityEngine;
using System.Collections;

public class DarkMagicalGirl : Enemy
{

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
        Move();
        Shot();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
