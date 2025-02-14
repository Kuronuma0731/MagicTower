using System;
using UnityEngine;
//步伐 x = 1 y = 1
public class Characters : People
{
    //
    [SerializeField] private UIManager uiMananger;

    //Control Animtor
    [SerializeField] private Animation Character_Animation;

    // Change Floor  1f,2f,3f,4f,5f,
    //[SerializeField] private int currentFloor;  // 角色目前樓層，預設 1F
    [SerializeField] private Grid PeopleGrid; // 將場景中的 Grid 拖入這裡

    [SerializeField] private GameObject FloorGameObject; // 將場景中的 Floor (包含floor 1, 2, 3...)
    //[SerializeField] private Text Number_Of_AttacksText; // Text 上的數據顯示
    [SerializeField] private Camera MainCamera;
    [SerializeField] private int Characters_Gold;
    [SerializeField] public LayerMask floorLayer; // 地e層
    [SerializeField] public LayerMask wallLayer;  // 牆壁層
    [SerializeField] public LayerMask DoorLayer;  // 牆壁層

    //[SerializeField] private GameObject otherCharacters;
    [SerializeField] private Rigidbody2D RigidbodyCharacters;


    // Scenes Object get use 
    [SerializeField] private int _GetSceneIndex;
    private Vector2 moveDirection;

    // 樓梯狀態讀取
    private bool StairsStats = true;

    private Action<PeopleInfo> updateUI;

    void Start()
    {
        Lv = 1;
        HP = 1000;
        AttackPower = 10;
        Defense = 10;
        Agile = 2;
        Experience_Value = 0;
        Number_Of_Attacks = 1;
        YellowKey = 1;
        BlueKey = 1;
        RedKey = 1;
        MagicMoney = 0;
        CurrentFloor = 0;

        RigidbodyCharacters.freezeRotation = true;

        if (MainCamera != null)
        {
            MainCamera.transform.position = new Vector3(0, 0, -10);
        }

        //updateUI = peopleInfo =>Debug.Log("hi");
        updateUI?.Invoke(peopleInfo);
        Init(updateUI);
    }

    public void Init(Action<PeopleInfo> updateUI)
    {
        this.updateUI = updateUI;
    }

    private void Update()
    {
        CharacterGridMove();
       
        //updateUI?.Invoke(peopleInfo);
    }
    

    void CharacterGridMove()
    {
        // 獲取玩家輸入（上下左右）
        if (Input.GetKeyDown(KeyCode.UpArrow)) moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) moveDirection = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) moveDirection = Vector2.down;
        else return;


        // 取得當前位置並確保其對齊格子（強制設定為 .5 或 1.5）
        Vector2 currentPosition = transform.position;

        // 強制將 x 和 y 軸設為 .5 或 1.5
        float targetX = Mathf.Floor(currentPosition.x) + 0.5f;
        float targetY = Mathf.Floor(currentPosition.y) + 0.5f;


        // 檢查下一步是否為地板且不是牆壁
        Vector2 targetPosition = new Vector2(targetX, targetY) + moveDirection;
        //Vector2 targetPosition = (Vector2)transform.position + moveDirection;
        if (IsFloor(targetPosition) && !IsWall(targetPosition))
        {

            if (IsDoor(targetPosition))
            {
                OnTriggerDoor(targetPosition);
            }

            StartCoroutine(MoveToNextGrid(targetPosition));

            // 確定移動更改 StairsStats True
            StairsStats = true;
        }


    }
    public void OnTriggerDoor(Vector2 targetPosition)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, targetPosition, 0, DoorLayer);
        Debug.Log(targetPosition);
        //if (hits != null)
        //{
        //Debug.Log($"物件 {hits[0].gameObject.name} 在矩形範圍內！");
        foreach (var hit in hits)
        {
            Debug.Log($"物件 {hit.gameObject.name} 在矩形範圍內！");
            if (hit.gameObject.name == "YellowDoor" || hit.gameObject.name == "BlueDoor" || hit.gameObject.name == "RedDoor")
            {
                Debug.Log($"物件 {hit.gameObject.name} 在矩形範圍內！");
                DoorControl doorControl = hit.GetComponent<DoorControl>();
            }

        }
    }
    private System.Collections.IEnumerator MoveToNextGrid(Vector2 targetPosition)
    {
        transform.position = targetPosition;
        //紀錄 當下位置
        Vector3Int cellPosition = PeopleGrid.WorldToCell(transform.position);
        Vector3 worldPosition = PeopleGrid.CellToWorld(cellPosition);
        PeoplepositionStats = worldPosition;
        Debug.Log(PeoplepositionStats);
        yield return null;
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

    private bool IsDoor(Vector2 targetPosition)
    {
        Collider2D DoorCheck = Physics2D.OverlapPoint(targetPosition, DoorLayer);
        return DoorCheck != null;
    }


    private void OnTriggerEnter2D(Collider2D _Tag)
    {
        //Debug.Log(_Tag.tag);
        //Debug.Log(_Tag.name);
        try
        {
            //Debug.Log("Monster");
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
                        }
                        break;
                    case "GoDownStairs":
                        if (StairsStats == true)
                        {
                            CurrentFloor = CurrentFloor - 1;
                            StairsStats = ChangeFloor.SetFloorStats(CurrentFloor, MainCamera, _Tag, gameObject, FloorGameObject, "GoUpStairs", wallLayer);
                        }
                        break;
                    default:
                        break;

                }
            }
            else if (_Tag.gameObject.tag == "Monster")
            {
                Monster monster = _Tag.GetComponent<Monster>();
                BattleScript.StartBattle(this, monster);
                //uiMananger.UpdateMessage();
            }
            else
            {
                // 除了樓梯跟怪物以外的物件
                string OtherText = OtherObjectScript.GetOther(_Tag.gameObject, gameObject);

                if (OtherText != null && OtherText != "")
                {
                    uiMananger.UpdateMessage(OtherText);
                }
                Destroy(_Tag.gameObject);
            }

            updateUI?.Invoke(peopleInfo);
        }
        catch (Exception e)
        {
            Debug.LogError(DateTime.Now.ToString("hh:mm:ss"));
            Debug.LogError(e);
        }


    }

}
