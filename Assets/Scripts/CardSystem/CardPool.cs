using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public List<List<Transform>> poolGrid = new List<List<Transform>>();
    public GameObject currentShape;
    public float offset = 1;
    public bool currentShapeCoubeBePutDown;
    public int couldDeleteShapeNumber;

    private int gridXOffset;
    private int gridYOffset;
    //private SpriteRenderer[] currentShapeRendererList;

    private void Start()
    {
        InitializeGrid(offset);

        //测试代码，实际请需要在卡池中放置时再调用
        //GetCurrentShape("Card_1");

        gridXOffset = 5;
        gridYOffset = 5;
        //currentShape.transform.position = poolGrid[gridYOffset][gridXOffset].position;
        currentShapeCoubeBePutDown = false;
        
    }

    private void Update()
    {
        ControlShape();
        PutShapeDown();
        DeleteShape();
    }

    #region API_FOR_UI
    /// <summary>
    /// 输入卡牌名字为卡池送入选中卡牌
    /// </summary>
    /// <param name="cardName"></param>
    public void GetCurrentShape(string cardName)
    {

        //currentShape = Instantiate(PathAndPrefabManager.Instance.GetCardPrefab(cardName), poolGrid[gridYOffset][gridXOffset].position, Quaternion.identity);
        var cardPrefab = PathAndPrefabManager.Instance.GetCardPrefab(cardName);
        currentShape = Instantiate(cardPrefab, poolGrid[gridYOffset][gridXOffset].position, Quaternion.identity, gameObject.transform);
    }

    public void GetCurrentShape(GameObject card)
    {
        currentShape = card;
        card.transform.position = poolGrid[gridYOffset][gridXOffset].position;
    }

    /// <summary>
    /// 调用一次补齐一个空格，未设置按键，请使用UI按钮响应
    /// </summary>
    public void CompleteSpace()
    {
        GetCurrentShape("Card_0");
    }

    /// <summary>
    /// 鼠标点击消除卡池卡牌
    /// </summary>
    public void DeleteShape()
    {
        if (couldDeleteShapeNumber > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Collider2D clickedObject = Physics2D.OverlapPoint(worldPosition);

                if (clickedObject != null && clickedObject.CompareTag("Block"))
                {
                    //Debug.Log("Clicked object: " + clickedObject.name);

                    // 获取到点击物体的父物体
                    Transform parentObject = clickedObject.transform.parent;

                    // 销毁父物体，这样子物体就会一起被销毁
                    Destroy(parentObject.gameObject);

                    couldDeleteShapeNumber--;
                }
            }
        }
    }
    #endregion
    /// <summary>
    /// 输入空格放置当前选中卡牌
    /// </summary>
    private void PutShapeDown()
    {
        if (currentShapeCoubeBePutDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //foreach (SpriteRenderer sr in currentShapeRendererList)
                //{
                //    sr.color = Color.white;
                //}
                currentShapeCoubeBePutDown = false;
                currentShape.GetComponent<Card>().isEffective = false;
                CheckRowAndColumn();
                currentShape = null;
            }
        }
    }

    /// <summary>
    /// 使用JKLI控制当前准备放入卡牌的移动
    /// </summary>
    private void ControlShape()
    {
        if (currentShape == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {   
            if (gridXOffset > 0)
            {
                gridXOffset--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (gridYOffset > 0)
            {
                gridYOffset--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (gridXOffset < 9)
            {
                gridXOffset++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (gridYOffset < 9)
            {
                gridYOffset++;
            }
        }

        MoveShape();
    }


    private void CheckRowAndColumn()
    {
        for (int y = 0; y <= 9; y++)
        {
            bool flag = true;
            for (int x = 0; x<= 9; x++)
            {
                var pos = poolGrid[y][x].position;

                Collider2D collider = Physics2D.OverlapPoint(pos);
                
                if(collider != null && collider.CompareTag("Block"))
                {

                }
                else
                {
                    flag = false;
                    break;
                }      
            }
            if(flag)
            {
                couldDeleteShapeNumber++;
                PlayerGenerator.Instance.fsmManager.parameter.level++;
            } 
        }


        for (int x = 0; x <= 9; x++)
        {
            bool flag = true;
            for (int y = 0; y <= 9; y++)
            {
                var pos = poolGrid[y][x].position;

                Collider2D collider = Physics2D.OverlapPoint(pos);

                if (collider != null && collider.CompareTag("Block"))
                {

                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                couldDeleteShapeNumber++;
                PlayerGenerator.Instance.fsmManager.parameter.level++;
            }
        }
    }

    

//    private void ShapeTips()
//    {
//        if (currentShape == null)
//        {
//            return;
//        }

//        if (currentShapeCoubeBePutDown)
//        {
//#if UNITY_EDITOR
//            Debug.Log(currentShapeCoubeBePutDown);
//#endif

//            if (currentShapeRendererList != null)
//            {
//                Debug.Log("get renderer");
//            }
//            foreach (SpriteRenderer sr in currentShapeRendererList)
//            {
//                sr.color = Color.green;
//#if UNITY_EDITOR
//                Debug.Log("green");
//#endif
//            }
//        }
//        else
//        {
//            foreach (SpriteRenderer sr in currentShapeRendererList)
//            {
//                sr.color = Color.red;
//            }
//        }
//    }

    

    private void MoveShape()
    {
        if (currentShape == null)
        {
#if UNITY_EDITOR
            Debug.Log("didnt get card");
#endif
            return;
        }

        currentShape.transform.position = poolGrid[gridYOffset][gridXOffset].position;
    }

    void InitializeGrid(float offset)
    {
        Transform cardPoolTransform = gameObject.transform;

        float gridSize = 10f; // 网格大小为10x10
        float centerIndex = (gridSize - 1f) / 2f; // 中心索引

        for (int i = 0; i < gridSize; i++)
        {
            List<Transform> row = new List<Transform>();

            for (int j = 0; j < gridSize; j++)
            {
                float x = (j - centerIndex) * offset;
                float y = (i - centerIndex) * offset;

                GameObject pointGO = new GameObject($"Point_{i}_{j}");
                pointGO.transform.position = cardPoolTransform.position + new Vector3(x, y, 0f); // 根据偏移量设置位置
                pointGO.transform.SetParent(cardPoolTransform);

                Transform point = pointGO.transform;
                row.Add(point);
            }

            poolGrid.Add(row);
        }
    }

    void OnDrawGizmos()
    {
        if (poolGrid != null)
        {
            foreach (List<Transform> row in poolGrid)
            {
                foreach (Transform point in row)
                {
                    // 绘制Gizmos标识
                    Gizmos.DrawSphere(point.position, 0.1f);
                }
            }
        }
    }
}
