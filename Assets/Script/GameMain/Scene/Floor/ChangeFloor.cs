using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeFloor
{
    public int position_x;
    public int position_y;
    public int position_z;

    //上樓往右 下樓往左
    private static Dictionary<int, ChangeFloor> FloorStats =
        new Dictionary<int, ChangeFloor>
        {
            {0,new ChangeFloor{ position_x = 0,position_y = 0, position_z = -10} },
            {1,new ChangeFloor{ position_x = 16,position_y = 0, position_z = -10 } },
            {2,new ChangeFloor{ position_x = 32,position_y = 0, position_z = -10 } },
            {3,new ChangeFloor{ position_x = 48,position_y = 0, position_z = -10 } },
            {4,new ChangeFloor{ position_x = 64,position_y = 0, position_z = -10 } },
            {5,new ChangeFloor{ position_x = 80,position_y = 0, position_z = -10 } },
            {6,new ChangeFloor{ position_x = 96,position_y = 0, position_z = -10 } },
            {7,new ChangeFloor{ position_x = 112,position_y = 0, position_z = -10 } },
            {8,new ChangeFloor{ position_x = 128,position_y = 0, position_z = -10 } },
            {9,new ChangeFloor{ position_x = 144,position_y = 0, position_z = -10 } },
            {10,new ChangeFloor{ position_x = 160,position_y = 0, position_z = -10 } }
        };
    public static bool SetFloorStats(int GetFloor, Camera camera, Collider2D collider, GameObject characters, GameObject FloorGameObject, string StairsStates, LayerMask wallLayer)
    {
        try
        {
            //Debug.Log("GetFloor" + GetFloor);
            if (FloorStats.ContainsKey(GetFloor))
            {
                // 取得 Floor 層中屬於 Name = floor 的任何物件
                GameObject[] gameFloorObjects = GetAllFloorObject(FloorGameObject.transform);
                // 取出當樓層控管物件
                GameObject closestStairs = gameFloorObjects[GetFloor];
                // 取得控管 中有 stairs 物件
                GameObject[] gameStairsDown = GetAllStairsObject(closestStairs.transform, StairsStates);

                // 判斷樓梯是否存在
                if (gameStairsDown.Length > 0 && gameStairsDown != null)
                {
                    //取得當前物件設置內容
                    int stats = collider.GetComponent<StairsScript>().StairsMask;

                    GameObject stairs = gameStairsDown[stats];
                    Vector2 targetPosition = stairs.transform.position;
                    characters.transform.position = targetPosition;


                    // 最後再轉畫面 晚點再設定秒數 1秒 切換畫面
                    camera.transform.position = new Vector3(
                        FloorStats[GetFloor].position_x,
                        FloorStats[GetFloor].position_y,
                        FloorStats[GetFloor].position_z
                        );

                    return false;
                }
                else
                {
                    Debug.LogWarning("未找到可用的最近樓梯物件！");
                }

            }
            else
            {
                Debug.LogError("傳入錯誤資訊");
                return true;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(DateTime.Now.ToString("hh:mm:ss"));
            Debug.LogError(e);
        }
        return true;
    }

    private static GameObject[] GetAllFloorObject(Transform parent)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        foreach (Transform child in parent)
        {
            // 遞迴檢索嵌套的子物件
            if (child.name.Contains("Floor"))
            {
                gameObjects.Add(child.gameObject);
                //Debug.Log("Found child: " + child.gameObject.name);

            }
            //GameObject[] childObjects = GetAllFloorObject(child);
            //gameObjects.AddRange(childObjects); // 將遞迴結果加入 List
        }
        return gameObjects.ToArray();
        // 遞迴檢索嵌套的子物件

    }
    private static GameObject[] GetAllStairsObject(Transform parent, string StairsStates)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        foreach (Transform child in parent)
        {
            // 遞迴檢索嵌套的子物件
            if (child.name.Contains(StairsStates))
            {
                gameObjects.Add(child.gameObject);
                //Debug.Log("Found child: " + child.gameObject.name);

            }
            //GameObject[] childObjects = GetAllFloorObject(child);
            //gameObjects.AddRange(childObjects); // 將遞迴結果加入 List
        }
        return gameObjects.ToArray();
        // 遞迴檢索嵌套的子物件

    }
}

