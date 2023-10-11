using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Playables;

public class CardManager : Singleton2Manager<CardManager>
{
    private int randomID;
    private string cardName;
    private string cardBagName;
    private List<Card> cardBag = new List<Card>();
    private GameObject instantiatedCardBag;
    private List<cardBagData> data = new List<cardBagData>();
    private GameObject instantiatedCardSelect;
    private GameObject[] instantiatedCard;

    class cardBagData
    {
        public cardBagData(Vector3 cardPosition, bool hasCard)
        {
            this.cardPosition = cardPosition;
            this.hasCard = hasCard;
        }
        public Vector3 cardPosition;
        public bool hasCard;
        public GameObject card;
    }


    #region API
    /// <summary>
    /// 生成CardBag到屏幕中心
    /// </summary>
    /// <param name="position"></param>
    public void ControlCardBag()
    {
        if (instantiatedCardBag == null)
        {
            cardBagName = "CardBag";
            var cardBag = PathAndPrefabManager.Instance.GetCardBagPrefab(cardBagName);

            var position = GetScreenCenterWorldPosition(Camera.main);
            position.z = 0;
            instantiatedCardBag = Instantiate(cardBag, new Vector2(position.x, position.y), Quaternion.identity);
            return;
        }

        if(instantiatedCardBag.activeInHierarchy)
        {
            instantiatedCardBag.SetActive(false);
        }
        else
        {
            var position = GetScreenCenterWorldPosition(Camera.main);
            position.z = 0;
            instantiatedCardBag.transform.position = position;
            
            instantiatedCardBag.SetActive(true);
        }
    }

    /// <summary>
    /// 指定生成中心和间距后，随机生成3张卡牌
    /// </summary>
    /// <param name="centerCardPosition"></param>
    /// <param name="offset"></param>
    public void InstantiateCards(Vector2 centerCardPosition, float offset)
    {
        GameObject[] cards = GetRandomCard();
        Instantiate(cards[0],new Vector3(centerCardPosition.x-offset,centerCardPosition.y,0),Quaternion.identity);
        Instantiate(cards[1],new Vector3(centerCardPosition.x,centerCardPosition.y,0),Quaternion.identity);
        Instantiate(cards[2],new Vector3(centerCardPosition.x+offset,centerCardPosition.y,0),Quaternion.identity);
    }

    /// <summary>
    /// 获取卡牌组成的列表（卡牌背包）
    /// </summary>
    /// <returns></returns>
    public List<Card> GetCardBagList()
    {
        return cardBag;
    }

    /// <summary>
    /// 向背包中添加一张卡牌
    /// </summary>
    /// <param name="card"></param>
    public void AddCardToBag(Card card)
    {
        cardBag.Add(card);
    }

    /// <summary>
    /// 移除传进来的卡牌
    /// </summary>
    /// <param name="card"></param>
    public void DeleteCardFromBag(Card card)
    {
        cardBag.Remove(card);
    }

    #endregion
    private GameObject[] GetRandomCard()
    {   
        GameObject[] cards = new GameObject[3];
        for(int i = 0; i < 3; i++)
        {
            randomID = Random.Range(1, 11);
            cards[i] = GetCardPrefab();
        }

        if(cards != null)
        {
            return cards;
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Can't get cards");
#endif
            return null;
        }
    }

    private GameObject GetCardPrefab()
    {
        cardName = "Card_" + randomID.ToString();
        return PathAndPrefabManager.Instance.GetCardPrefab(cardName);
    }

    private Vector3 GetScreenCenterWorldPosition(Camera camera)
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenCenter);
        return worldPosition;
    }

    private void InitializeBagGrid()
    {
        var spawnPoitn = GetScreenCenterWorldPosition(Camera.main) + new Vector3(-3,3);
        spawnPoitn.z = 0;
        //var offset = 1;

        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                Vector3 position = spawnPoitn + new Vector3(x, -y , 0f);
                data.Add(new cardBagData(position, false));
            }
        }
    }

    /// <summary>
    /// 将卡牌预制体放到对应的地方
    /// </summary>
    /// <param name="card"></param>
    public void GetCardToBag(GameObject card)
    {
        if (data == null)
        {
            InitializeBagGrid();
        }
        else
        {
            foreach( var data in data)
            {
                if(data.hasCard == false)
                {
                    card.transform.position = data.card.transform.position;
                    data.card = card;
                    data.hasCard = true;                   
                    return;
                }
            }
        }

    }


    // 生成卡牌和恶魔的立绘
    public void InstantiateCardSelect()
    {
        if (instantiatedCardSelect == null)
        {
            var cardSelectName = "CardSelect";
            var cardSelect = PathAndPrefabManager.Instance.GetCardBagPrefab(cardSelectName);

            var position = GetScreenCenterWorldPosition(Camera.main);
            position.z = 0f;
            instantiatedCardSelect = Instantiate(cardSelect, new Vector2(position.x, position.y), Quaternion.identity);
            InstantiateCards(new Vector2(position.x, position.y), 5);
        }
    }
    // 消除卡牌和恶魔的立绘
    public void DestroyCardSelect()
    {
        Destroy(instantiatedCardSelect);
        instantiatedCardSelect = null;
        for (int i = 0; i < instantiatedCard.Length; i++)
        {
            Destroy(instantiatedCard[i]);
        }
        instantiatedCard = null;
    }

    /// <summary>
    /// 获取点击card的GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject ClickToGetCardObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Collider2D clickedObject = Physics2D.OverlapPoint(worldPosition);

            if (clickedObject != null && clickedObject.CompareTag("Block"))
            {
                

                // 获取到点击物体的父物体
                Transform parentTransform = clickedObject.transform.parent;

                GameObject parentGameObject = parentTransform.gameObject;
                return parentGameObject;
            }
        }

        return default;
    }

    public void GetCardIntoPool()
    {
        var card = ClickToGetCardObject();
        if (card == null) 
        {
            return;
        }
        else
        {
            instantiatedCardBag.transform.Find("CardPool").GetComponent<CardPool>().GetCurrentShape(card);
        }    
    }

}
