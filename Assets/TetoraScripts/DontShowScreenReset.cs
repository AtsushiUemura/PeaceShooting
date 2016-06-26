//http://tsubakit1.hateblo.jp/entry/20140524/1400943348

using UnityEngine;
using System.Collections;

public class DontShowScreenReset : MonoBehaviour
{
    [Range(0, 10)]
    public float
        speed = 10;
    public int spriteCount = 3;
    Vector3 spriteSize;

    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
    }

    void Update()
    {
        transform.position += Vector3.down* speed * Time.deltaTime;

#if UNITY_EDITOR

        var spritex = (transform.position + spriteSize / 2).y;
        if (spritex < ScreenManager.Instance.screenRect.y)
        {
            OnBecameInvisible();
        }

#endif
    }

    void OnBecameInvisible()
    {
        float width = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position += Vector3.up * width * spriteCount;
    }
}


