using System.Collections.Generic;
using UnityEngine;
public enum Direct
{
    FORWARD = 0,
    BACK = 1,
    LEFT = 2,
    RIGHT = 3,
    NONE = 4
}
public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask brickLayer;
    [SerializeField] private float checkBrickDistance;
    [SerializeField] private float speed;

    [SerializeField] public List<Transform> brickList = new List<Transform>();
    [SerializeField] private Transform playerBrickPrefabs;
    [SerializeField] private Transform brickHolder;
    [SerializeField] private Transform playerSkin;

    private bool isMoving = false;
    private Vector3 mouseUp, mouseDown;
    private Vector3 targetPos;

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouseUp = Input.mousePosition;
                targetPos = GetNextPoint(GetDirect(mouseDown, mouseUp));
                isMoving = true;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                isMoving = false;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }


    }

    private Direct GetDirect(Vector3 mouseDown, Vector3 mouseUp)
    {
        float deltaX = mouseUp.x - mouseDown.x;
        float deltaY = mouseUp.y - mouseDown.y;
        Direct direct = Direct.NONE;

        if (Vector3.Distance(mouseDown, mouseUp) < 100f)
        {
            direct = Direct.NONE;
        }
        else
        {
            if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
            {
                if (deltaY > 0)
                {
                    direct = Direct.FORWARD;
                }
                else
                {
                    direct = Direct.BACK;
                }
            }
            else
            {
                if (deltaX > 0)
                {
                    direct = Direct.RIGHT;
                }
                else
                {
                    direct = Direct.LEFT;
                }
            }
        }

        return direct;
    }

    private Vector3 GetNextPoint(Direct direct)
    {
        RaycastHit hit;
        Vector3 nextPoint = transform.position;
        Vector3 dir = Vector3.zero;

        switch (direct)
        {
            case Direct.FORWARD:
                dir = Vector3.forward;
                break;
            case Direct.BACK:
                dir = Vector3.back;
                break;
            case Direct.LEFT:
                dir = Vector3.left;
                break;
            case Direct.RIGHT:
                dir = Vector3.right;
                break;
            case Direct.NONE:
                dir = Vector3.zero;
                break;
        }
        for (int i = 0; i < 100; i++)
        {
            Vector3 offset = transform.position + i * dir + Vector3.up * 2f;
            if (Physics.Raycast(offset, Vector3.down, out hit, checkBrickDistance, brickLayer))
            {
                nextPoint = hit.collider.transform.position;
            }
            else
            {
                break;
            }
        }
        return nextPoint;
    }

    public void AddBrick()
    {
        int index = brickList.Count;
        Transform brickSpawn = Instantiate(playerBrickPrefabs, brickHolder);
        brickList.Add(brickSpawn);

        brickSpawn.localPosition = Vector3.down + index * 0.2f * Vector3.up;
        playerSkin.localPosition = Vector3.zero + index * 0.2f * Vector3.up;
    }

    public void RemoveBrick()
    {
        int index = brickList.Count - 1;
        Transform brickSpawn = brickList[index];

        if (index >= 0)
        {
            //Xoa phan tu cuoi khoi list
            brickList.Remove(brickSpawn);
            //Destroy gameobj cua phan tu cuoi
            Destroy(brickSpawn.gameObject);
            //Di chuyen nhan vat thap xuong
            playerSkin.localPosition = playerSkin.localPosition - 0.2f * Vector3.up;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.Unbrick) && brickList.Count <= 0)
        {
            UnbrickBlock unbrik = other.GetComponent<UnbrickBlock>();

            if (!unbrik.isCollect)
            {
                targetPos = other.transform.position - Vector3.forward;
            }
        }
    }
}
