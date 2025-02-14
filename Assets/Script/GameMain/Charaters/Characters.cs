using System;
using UnityEngine;
//�B�� x = 1 y = 1
public class Characters : People
{
    //
    [SerializeField] private UIManager uiMananger;

    //Control Animtor
    [SerializeField] private Animation Character_Animation;

    // Change Floor  1f,2f,3f,4f,5f,
    //[SerializeField] private int currentFloor;  // ����ثe�Ӽh�A�w�] 1F
    [SerializeField] private Grid PeopleGrid; // �N�������� Grid ��J�o��

    [SerializeField] private GameObject FloorGameObject; // �N�������� Floor (�]�tfloor 1, 2, 3...)
    //[SerializeField] private Text Number_Of_AttacksText; // Text �W���ƾ����
    [SerializeField] private Camera MainCamera;
    [SerializeField] private int Characters_Gold;
    [SerializeField] public LayerMask floorLayer; // �ae�h
    [SerializeField] public LayerMask wallLayer;  // ����h
    [SerializeField] public LayerMask DoorLayer;  // ����h

    //[SerializeField] private GameObject otherCharacters;
    [SerializeField] private Rigidbody2D RigidbodyCharacters;


    // Scenes Object get use 
    [SerializeField] private int _GetSceneIndex;
    private Vector2 moveDirection;

    // �ӱ説�AŪ��
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
        // ������a��J�]�W�U���k�^
        if (Input.GetKeyDown(KeyCode.UpArrow)) moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) moveDirection = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) moveDirection = Vector2.down;
        else return;


        // ���o��e��m�ýT�O������l�]�j��]�w�� .5 �� 1.5�^
        Vector2 currentPosition = transform.position;

        // �j��N x �M y �b�]�� .5 �� 1.5
        float targetX = Mathf.Floor(currentPosition.x) + 0.5f;
        float targetY = Mathf.Floor(currentPosition.y) + 0.5f;


        // �ˬd�U�@�B�O�_���a�O�B���O���
        Vector2 targetPosition = new Vector2(targetX, targetY) + moveDirection;
        //Vector2 targetPosition = (Vector2)transform.position + moveDirection;
        if (IsFloor(targetPosition) && !IsWall(targetPosition))
        {

            if (IsDoor(targetPosition))
            {
                OnTriggerDoor(targetPosition);
            }

            StartCoroutine(MoveToNextGrid(targetPosition));

            // �T�w���ʧ�� StairsStats True
            StairsStats = true;
        }


    }
    public void OnTriggerDoor(Vector2 targetPosition)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, targetPosition, 0, DoorLayer);
        Debug.Log(targetPosition);
        //if (hits != null)
        //{
        //Debug.Log($"���� {hits[0].gameObject.name} �b�x�νd�򤺡I");
        foreach (var hit in hits)
        {
            Debug.Log($"���� {hit.gameObject.name} �b�x�νd�򤺡I");
            if (hit.gameObject.name == "YellowDoor" || hit.gameObject.name == "BlueDoor" || hit.gameObject.name == "RedDoor")
            {
                Debug.Log($"���� {hit.gameObject.name} �b�x�νd�򤺡I");
                DoorControl doorControl = hit.GetComponent<DoorControl>();
            }

        }
    }
    private System.Collections.IEnumerator MoveToNextGrid(Vector2 targetPosition)
    {
        transform.position = targetPosition;
        //���� ��U��m
        Vector3Int cellPosition = PeopleGrid.WorldToCell(transform.position);
        Vector3 worldPosition = PeopleGrid.CellToWorld(cellPosition);
        PeoplepositionStats = worldPosition;
        Debug.Log(PeoplepositionStats);
        yield return null;
    }


    // �ˬd�O�_�b Floor �d��
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
                        // �w�] true �󴫼Ӽh��אּ false �K�o�@���`��
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
                // ���F�ӱ��Ǫ��H�~������
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
