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

    public void Intercept(Transform targetPos)
    {
        float vr = targetPos.position.normalized.magnitude - transform.position.normalized.magnitude;
        float sr = Vector2.Distance(targetPos.position, transform.position);
        float tc = Mathf.Abs(sr) / Mathf.Abs(vr);
        Vector2 pos = targetPos.position + (targetPos.position.normalized - transform.position.normalized) * tc;
        pos = pos.normalized  * Time.deltaTime;
        transform.position = pos;
    }

}
