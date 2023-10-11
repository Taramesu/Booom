using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMusicController : MonoBehaviour
{
    public AudioClip BeginRoomMusic;
    public AudioClip MonsterRoomMusic;
    public AudioClip BossRoomMusic;
    public AudioSource audioSource;
    private int previousroomid;
    private Room previousroom;
    private int currentroomid;
    private Room currentroom;
    // Start is called before the first frame update
    void Start()
    {
        previousroom = null;
        previousroomid = -1;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentroom = PlayerGenerator.Instance.fsmManager.GetCurrentRoom();
        currentroomid = currentroom.roomID;
        if(currentroom.roomID != previousroomid)
        {
            previousroom = currentroom;
            previousroomid = currentroomid;
            audioSource.Stop();
            var roomtype = currentroom.type;
            if(roomtype == RoomType.BOSS)
            {
                audioSource.clip = BossRoomMusic;
                audioSource.Play();
            }
            else if(roomtype == RoomType.SpawnPoint)
            {
                audioSource.clip = BeginRoomMusic; 
                audioSource.Play();
            }
            else
            {
                audioSource.clip = MonsterRoomMusic;
                audioSource.Play();
            }
        }
        if (currentroom.isCleared)
        {
            audioSource.Stop();
        }
    }
}
