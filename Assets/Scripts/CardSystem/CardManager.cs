using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CardManager : Singleton2Manager<CardManager>
{
    private int randomID;
    private string cardName;
    private string cardPoolName;
    private List<Card> cardBag = new List<Card>();

    #region API
    /// <summary>
    /// 在position处生成卡池
    /// </summary>
    /// <param name="position"></param>
    public void InstantiateCardPool(Vector2 position)
    {
        cardPoolName = "CardPool";
        var cardPool = PathAndPrefabManager.Instance.GetCardPoolPrefab(cardPoolName);
        Instantiate(cardPool,new Vector3(position.x, position.y, 0),Quaternion.identity);
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
}
