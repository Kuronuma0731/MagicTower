using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private List<NPCDetail> NPCDetails;

}
[Serializable]
public class NPCDetail
{
    public NPC NPCName;
    private int floor;
    private string message;
}
public enum NPC
{
    Elder,
    Merchat,
    Princess,
    Thief
}
