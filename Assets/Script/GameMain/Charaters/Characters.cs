using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//步伐 x = 1 y = 1
public class Characters : People
{
    //
    [SerializeField] private UIManager uiMananger;
    //Control Animtor
    [SerializeField] private Animator Hero_Animator;
    // Change Floor  1f,2f,3f,4f,5f,
    //[SerializeField] private int currentFloor;  // 角色目前樓層，預設 1F
    [SerializeField] private Grid PeopleGrid; // 將場景中的 Grid 拖入這裡

    [SerializeField] private GameObject FloorGameObject; // 將場景中的 Floor (包含floor 1, 2, 3...)
    [SerializeField] private Camera MainCamera;
    [SerializeField] private int Characters_Gold;
    [SerializeField] public LayerMask floorLayer; // 地e層
    [SerializeField] public LayerMask wallLayer;  // 牆壁層
    [SerializeField] public LayerMask DoorLayer;  // 門層
    [SerializeField] public LayerMask NPCLayer;  // NPC層
    KeyMeanager keyManager;
    //[SerializeField] private GameObject otherCharacters;
    [SerializeField] private Rigidbody2D RigidbodyCharacters;


    // Scenes Object get use 
    [SerializeField] private int _GetSceneIndex;
    //當前位置紀錄
    Vector2 currentPosition;
    private Vector2 moveDirection;

    // 樓梯狀態讀取
    private bool StairsStats = true;
    // 移動讀取
    [SerializeField] private bool canMove = true;
    private void Awake()
    {
        //腳色設定值
        Lv = 1;
        HP = 1000;
        AttackPower = 10;
        Defense = 10;
        Agile = 2;
        Experience_Value = 0;
        Number_Of_Attacks = 1;
        MagicMoney = 200;
        CurrentFloor = 0;
    }

    void Start()
    {
        Hero_Animator = GetComponent<Animator>();
        // 禁止重力
        RigidbodyCharacters.freezeRotation = true;
        //uiMananger.ShowFloor(CurrentFloor);
        if (MainCamera != null)
        {
            MainCamera.transform.position = new Vector3(0, 0, -10);
        }

    }


    private void Update()
    {
       
        CharacterGridMove();

    }
    void CharacterGridMove()
    {
        if (!canMove) { return; }
        // 獲取玩家輸入（上下左右）
        if (Input.GetKeyDown(KeyCode.UpArrow)) moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) moveDirection = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) moveDirection = Vector2.down;
        else return;


        // 取得當前位置並確保其對齊格子（強制設定為 .5 或 1.5）
        currentPosition = transform.position;

        // 強制將 x 和 y 軸設為 .5 或 1.5
        float targetX = Mathf.Floor(currentPosition.x) + 0.5f;
        float targetY = Mathf.Floor(currentPosition.y) + 0.5f;


        // 檢查下一步是否為地板且不是牆壁
        Vector2 targetPosition = new Vector2(targetX, targetY) + moveDirection;
        //Vector2 targetPosition = (Vector2)transform.position + moveDirection;
        TryNPC(targetPosition);
        if (IsFloor(targetPosition) && !IsWall(targetPosition))
        {
            //判斷開門
            TryOpenDoor(targetPosition);
            StairsStats = true;
        }


    }
    private bool TryNPC(Vector2 targetPosition) 
    {
        Collider2D doorCollider = Physics2D.OverlapPoint(targetPosition, NPCLayer);
        if (doorCollider != null)
        {
            Debug.Log("有資料)");
        }
        else 
        {
            Debug.Log("沒有資料)");
        }
        return true;
    }
    // 嘗試開門 
    private bool TryOpenDoor(Vector2 targetPosition)
    {
        keyManager = GameObject.Find("KeyMeanager").GetComponent<KeyMeanager>();
        Collider2D doorCollider = Physics2D.OverlapPoint(targetPosition, DoorLayer);
        if (doorCollider)
        {
            DoorControl doorControl = doorCollider.GetComponent<DoorControl>();
            if (doorControl)
            {
                Article doorArticle = doorControl.articleDoor;
                bool canOpen = keyManager.DeleteArticle(doorArticle);
                if (canOpen)
                {
                    // 開啟門動畫
                    doorControl.doorAnimation?.SetBool("OpenDoor", true);
                    StartCoroutine(MoveToNextGrid(targetPosition, moveDirection));
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else 
        {
            StartCoroutine(MoveToNextGrid(targetPosition, moveDirection));
        }
            // 若沒找到門，則返回 true 代表可以移動
            return true;
    }
    private System.Collections.IEnumerator MoveToNextGrid(Vector2 targetPosition, Vector2 moveDirection)
    {
        if (moveDirection == Vector2.up)
        {
            Hero_Animator.SetBool("PlayTop", true);
            Hero_Animator.SetBool("PlayLeft", false);
            Hero_Animator.SetBool("PlayRight", false);
            Hero_Animator.SetBool("PlayDown", false);
        }
        else if (moveDirection == Vector2.left)
        {
            Hero_Animator.SetBool("PlayTop", false);
            Hero_Animator.SetBool("PlayLeft", true);
            Hero_Animator.SetBool("PlayRight", false);
            Hero_Animator.SetBool("PlayDown", false);
        }
        else if (moveDirection == Vector2.right)
        {
            Hero_Animator.SetBool("PlayTop", false);
            Hero_Animator.SetBool("PlayLeft", false);
            Hero_Animator.SetBool("PlayRight", true);
            Hero_Animator.SetBool("PlayDown", false);
        }

        else if (moveDirection == Vector2.down)
        {
            Hero_Animator.SetBool("PlayTop", false);
            Hero_Animator.SetBool("PlayLeft", false);
            Hero_Animator.SetBool("PlayRight", false);
            Hero_Animator.SetBool("PlayDown", true);
        }

        transform.position = targetPosition;

        //紀錄 當下位置
        Vector3Int cellPosition = PeopleGrid.WorldToCell(transform.position);
        Vector3 worldPosition = PeopleGrid.CellToWorld(cellPosition);
        PeoplepositionStats = worldPosition;

        yield return new WaitForSeconds(0.1f);
    }
    

    // 檢查是否在 Floor 範圍內
    private bool IsFloor(Vector2 targetPosition)
    {
        Collider2D floorCheck = Physics2D.OverlapPoint(targetPosition, floorLayer);
        return floorCheck != null;
    }

    private bool IsWall(Vector2 targetPosition)
    {
        Collider2D wallCheck = Physics2D.OverlapPoint(targetPosition, wallLayer);
        return wallCheck != null;
    }

    private void OnTriggerEnter2D(Collider2D _Tag)
    {
        try
        {
            if (_Tag.gameObject.tag == "Stairs")
            {
                switch (_Tag.gameObject.name)
                {
                    case "GoUpStairs":
                        // 預設 true 更換樓層後改為 false 免得一直循環
                        if (StairsStats == true)
                        {
                            CurrentFloor = CurrentFloor + 1;
                            StairsStats = ChangeFloor.SetFloorStats(CurrentFloor, MainCamera, _Tag, gameObject, FloorGameObject, "GoDownStairs", wallLayer);
                            uiMananger.ShowFloor(CurrentFloor);
                        }
                        break;
                    case "GoDownStairs":
                        if (StairsStats == true)
                        {
                            CurrentFloor = CurrentFloor - 1;
                            StairsStats = ChangeFloor.SetFloorStats(CurrentFloor, MainCamera, _Tag, gameObject, FloorGameObject, "GoUpStairs", wallLayer);
                            uiMananger.ShowFloor(CurrentFloor);
                        }
                        break;
                    default:
                        break;

                }
            }
            else if (_Tag.gameObject.tag == "Monster")
            {
                BattleManager battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
                Monster monster = _Tag.GetComponent<Monster>();
                EventHander.CallUpdateBattleEvent();
                battleManager?.StartBattle(this, monster);

            }
            else if (_Tag.gameObject.name == "BlueMask")
            {
                //
                //uiMananger.ShowSkillUi(1);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(DateTime.Now.ToString("hh:mm:ss"));
            Debug.LogError(e);
        }


    }

    // 設定是否可以動作
    public void SetCanMove(bool Move)
    {
        canMove = Move;
    }


    




}
