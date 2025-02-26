using UnityEngine;

public class AutoMaticallyCorrectPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 取得當前位置並確保其對齊格子（強制設定為 .5 或 1.5）
        Vector2 currentPosition = transform.position;

        // 強制將 x 和 y 軸設為 .5 或 1.5
        float targetX = Mathf.Floor(currentPosition.x) + 0.5f;
        float targetY = Mathf.Floor(currentPosition.y) + 0.5f;

        Vector2 targetPosition = new Vector2(targetX, targetY);

        transform.position = targetPosition;
    }

    
}
