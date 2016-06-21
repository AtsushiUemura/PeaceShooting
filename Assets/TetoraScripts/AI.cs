using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    public void Tracking(Vector2 targetPos, float distance, float speed)
    {
        if (Vector2.Distance(targetPos, this.transform.position) < distance) return;
        else
        {
            Vector2 direction = targetPos - (Vector2)this.transform.position;
            direction.Normalize();
            Vector2 pos = this.transform.position;
            pos += direction * speed * Time.deltaTime;
            this.transform.position = pos;
        }
    }

    public void Intercept(Transform targetPos)
    {
        float vr = targetPos.position.normalized.magnitude - transform.position.normalized.magnitude;
        float sr = Vector2.Distance(targetPos.position, transform.position);
        float tc = Mathf.Abs(sr) / Mathf.Abs(vr);
        Vector2 pos = targetPos.position + (targetPos.position.normalized - transform.position.normalized) * tc;
        pos = pos.normalized * Time.deltaTime;
        transform.position = pos;
    }

}
