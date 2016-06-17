using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    public void Tracking(Transform targetPos)
    {        
        Vector2 direction = targetPos.position - gameObject.transform.position;
        direction.Normalize();
        Vector2 pos = transform.position;
        pos += direction * Time.deltaTime;
        transform.position = pos;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
