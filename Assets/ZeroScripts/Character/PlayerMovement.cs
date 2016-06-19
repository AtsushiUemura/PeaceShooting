using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    private Vector3 playerPos;
    private Vector3 mousePos;

    [SerializeField]
    private Vector3 minPos;
    [SerializeField]
    private Vector3 maxPos;

    void Update()
    {
        MovePosition();
    }

    /// <summary>
    /// プレイヤーが画面外に出ないようにポジション制御する関数
    /// </summary>
    Vector3 ControlPosition(Vector3 Pos)
    {
        Vector3 nextPos = Pos;
        if (nextPos.x > maxPos.x)
        {
            nextPos.x = maxPos.x;
        }
        if (nextPos.x < minPos.x)
        {
            nextPos.x = minPos.x;
        }
        if (nextPos.y > maxPos.y)
        {
            nextPos.y = maxPos.y;
        }
        if (nextPos.y < minPos.y)
        {
            nextPos.y = minPos.y;
        }
        return nextPos;
    }

    /// <summary>
    /// タッチしてスライドした分だけ移動する関数
    /// </summary>
    private void MovePosition()
    {

        if (Input.GetMouseButtonDown(0))
        {
            playerPos = this.transform.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {

//            Vector3 prePos = this.transform.position;
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

            //タッチ対応デバイス向け、1本目の指にのみ反応
            if (Input.touchSupported)
            {
                diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
            }
            diff.z = 0.0f;
            this.transform.position = ControlPosition( playerPos + diff );
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerPos = Vector3.zero;
            mousePos = Vector3.zero;
        }
    }
}
