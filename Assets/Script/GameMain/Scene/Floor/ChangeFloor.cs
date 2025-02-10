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

    //�W�ө��k �U�ө���
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
                // ���o Floor �h���ݩ� Name = floor �����󪫥�
                GameObject[] gameFloorObjects = GetAllFloorObject(FloorGameObject.transform);
                // ���X��Ӽh���ު���
                GameObject closestStairs = gameFloorObjects[GetFloor];
                // ���o���� ���� stairs ����
                GameObject[] gameStairsDown = GetAllStairsObject(closestStairs.transform, StairsStates);

                // �P�_�ӱ�O�_�s�b
                if (gameStairsDown.Length > 0 && gameStairsDown != null)
                {
                    //���o��e����]�m���e
                    int stats = collider.GetComponent<StairsScript>().StairsMask;

                    GameObject stairs = gameStairsDown[stats];
                    Vector2 targetPosition = stairs.transform.position;
                    characters.transform.position = targetPosition;


                    // �̫�A��e�� ���I�A�]�w��� 1�� �����e��
                    camera.transform.position = new Vector3(
                        FloorStats[GetFloor].position_x,
                        FloorStats[GetFloor].position_y,
                        FloorStats[GetFloor].position_z
                        );

                    return false;
                }
                else
                {
                    Debug.LogWarning("�����i�Ϊ��̪�ӱ誫��I");
                }

            }
            else
            {
                Debug.LogError("�ǤJ���~��T");
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
            // ���j�˯��O�M���l����
            if (child.name.Contains("Floor"))
            {
                gameObjects.Add(child.gameObject);
                //Debug.Log("Found child: " + child.gameObject.name);

            }
            //GameObject[] childObjects = GetAllFloorObject(child);
            //gameObjects.AddRange(childObjects); // �N���j���G�[�J List
        }
        return gameObjects.ToArray();
        // ���j�˯��O�M���l����

    }
    private static GameObject[] GetAllStairsObject(Transform parent, string StairsStates)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        foreach (Transform child in parent)
        {
            // ���j�˯��O�M���l����
            if (child.name.Contains(StairsStates))
            {
                gameObjects.Add(child.gameObject);
                //Debug.Log("Found child: " + child.gameObject.name);

            }
            //GameObject[] childObjects = GetAllFloorObject(child);
            //gameObjects.AddRange(childObjects); // �N���j���G�[�J List
        }
        return gameObjects.ToArray();
        // ���j�˯��O�M���l����

    }
}

