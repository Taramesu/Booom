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
    /// ����CardBag����Ļ����
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
    /// ָ���������ĺͼ����������3�ſ���
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
    /// ��ȡ������ɵ��б����Ʊ�����
    /// </summary>
    /// <returns></returns>
    public List<Card> GetCardBagList()
    {
        return cardBag;
    }

    /// <summary>
    /// �򱳰������һ�ſ���
    /// </summary>
    /// <param name="card"></param>
    public void AddCardToBag(Card card)
    {
        cardBag.Add(card);
    }

    /// <summary>
    /// �Ƴ��������Ŀ���
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
    /// ������Ԥ����ŵ���Ӧ�ĵط�
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


    // ���ɿ��ƺͶ�ħ������
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
    // �������ƺͶ�ħ������
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
    /// ��ȡ���card��GameObject
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
                

                // ��ȡ���������ĸ�����
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
