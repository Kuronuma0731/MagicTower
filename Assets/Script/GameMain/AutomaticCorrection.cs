using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticCorrection : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 GameObjcetVector2;
    // 自動校正位置
    void Start()
    {
        GameObjcetVector2 = transform.position;

        float fx = Mathf.Floor(GameObjcetVector2.x);
        float fy = Mathf.Floor(GameObjcetVector2.y);

        transform.position = new Vector2(fx, fy);
    }
}
