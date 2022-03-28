using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {
    normal,
    piercing,
    last
}
public class BulletManager : MonoBehaviour
{
    [SerializeField] private int bulletNumber;
    private Projectile[,] bullets;
    [SerializeField] private Projectile originalNormalBullet;

    void Awake()
    {
        bullets = new Projectile[(int)ProjectileType.last, bulletNumber * (int)ProjectileType.last];
        CreateBullets();
    }

    private void CreateBullets() {
        for (int j = 0; j < (int)ProjectileType.last; j++) {
            for (int i = 0; i < bullets.Length/(int)ProjectileType.last; i++) {
                switch ((ProjectileType)j) {
                    case ProjectileType.normal:
                        bullets[j, i] = Instantiate(originalNormalBullet);
                        bullets[j, i].name = "NormalPlayerBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.piercing:
                        bullets[j, i] = Instantiate(originalNormalBullet);
                        bullets[j, i].name = "PiercingPlayerBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.last:
                        break;
                    default:
                        break;
                }
            }
        }
        originalNormalBullet.gameObject.SetActive(false);
    }

    public Projectile GetBullet(ProjectileType type) {
        for (int i = 0; i < bullets.Length; i++) {
            if (!bullets[(int)type, i].gameObject.activeSelf) {
                Debug.Log("Preso: " + bullets[(int)type, i].name);
                return bullets[(int)type, i];
            }
        }
        Debug.Log("Non esistono proiettili");
        return null;
    }
}
