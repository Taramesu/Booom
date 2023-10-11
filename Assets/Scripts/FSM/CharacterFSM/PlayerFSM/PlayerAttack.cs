using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Transform topSpawn;
    private Transform bottomSpawn;
    private Transform leftSpawn;
    private Transform rightSpawn;

    private GameObject bulletPrefab;
    private TimeTools timeTools;

    public float shootRate;

    // Start is called before the first frame update
    void Start()
    {
        topSpawn = transform.Find("TopSpawn").GetComponent<Transform>();
        bottomSpawn = transform.Find("BottomSpawn").GetComponent<Transform>();
        leftSpawn = transform.Find("LeftSpawn").GetComponent<Transform>();
        rightSpawn = transform.Find("RightSpawn").GetComponent<Transform>();
        timeTools = GetComponent<TimeTools>();

        bulletPrefab = PathAndPrefabManager.Instance.GetBulletPrefab("PlayerBullet");

        shootRate = 0.5f;
        timeTools.StartTimer(shootRate);   
    }

    // Update is called once per frame
    void Update()
    {
        GenerateBullet();
    }

    private void GenerateBullet()
    {
        //计时时长超过射击间隔才可再次发射
        if(PlayerInputData.Instance.attackVal != Vector2.zero && timeTools.GetElapsedTime() >= shootRate)
        {
            Bullet bullet;
            var x = PlayerInputData.Instance.attackVal.x;
            var y = PlayerInputData.Instance.attackVal.y;

            if (x != 0)
            {
                switch (x) 
                {
                    case 1: bullet = Instantiate(bulletPrefab, rightSpawn.position, Quaternion.identity).GetComponent<Bullet>(); BulletDataInitailize(bullet, Bullet.Diraction.Right); break;
                    case -1: bullet = Instantiate(bulletPrefab, leftSpawn.position, Quaternion.identity).GetComponent<Bullet>(); BulletDataInitailize(bullet, Bullet.Diraction.Left); break;
                }
            }
            else
            {
                switch (y)
                {
                    case 1: bullet = Instantiate(bulletPrefab, topSpawn.position, Quaternion.identity).GetComponent<Bullet>(); BulletDataInitailize(bullet, Bullet.Diraction.Up); break;
                    case -1: bullet = Instantiate(bulletPrefab, bottomSpawn.position, Quaternion.identity).GetComponent<Bullet>(); BulletDataInitailize(bullet, Bullet.Diraction.Down); break;
                }
            }

            //发射后重置计时
            timeTools.ResetAndStartTimer();
        }
    }

    private void BulletDataInitailize(Bullet bullet, Bullet.Diraction dir)
    {
        bullet.damage = 1;
        bullet.shooter = "Player";
        bullet.shootDir = dir;
        bullet.speed = 7;
    }
}
