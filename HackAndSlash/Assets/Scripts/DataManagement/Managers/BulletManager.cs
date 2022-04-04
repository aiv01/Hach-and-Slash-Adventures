using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {
    normal,
    piercing,
    enemy,
    boss,
    creatura,
    firebolt,
    fireball,
    lightning,
    last
}
public class BulletManager : MonoBehaviour
{
    [SerializeField] private int bulletNumber;
    private Projectile[,] bullets;
    [SerializeField] private Projectile originalNormalBullet;
    [SerializeField] private Projectile originalPiercingBullet;
    [SerializeField] private Projectile originalEnemyBullet;
    [SerializeField] private Projectile originalBossBullet;
    [SerializeField] private Projectile originalCreaturaBullet;
    [SerializeField] private Projectile originalFireboltBullet;
    [SerializeField] private Projectile originalFireballBullet;
    [SerializeField] private Projectile originalLightningBullet;

    void Awake()
    {
        bullets = new Projectile[(int)ProjectileType.last, bulletNumber * (int)ProjectileType.last];
        CreateBullets();
    }

    private void CreateBullets() {
        for (int j = 0; j < (int)ProjectileType.last; j++) {
            for (int i = 0; i < bullets.GetLength(1)/(int)ProjectileType.last + 1; i++) {
                switch ((ProjectileType)j) {
                    case ProjectileType.normal:
                        bullets[j, i] = Instantiate(originalNormalBullet);
                        bullets[j, i].name = "NormalPlayerBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.piercing:
                        bullets[j, i] = Instantiate(originalPiercingBullet);
                        bullets[j, i].name = "PiercingPlayerBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.enemy:
                        bullets[j, i] = Instantiate(originalEnemyBullet);
                        bullets[j, i].name = "EnemyBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.boss:
                        bullets[j, i] = Instantiate(originalBossBullet);
                        bullets[j, i].name = "BossBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.creatura:
                        bullets[j, i] = Instantiate(originalCreaturaBullet);
                        bullets[j, i].name = "CreaturaBullet_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.firebolt:
                        bullets[j, i] = Instantiate(originalFireboltBullet);
                        bullets[j, i].name = "Firebolt_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.fireball:
                        bullets[j, i] = Instantiate(originalFireballBullet);
                        bullets[j, i].name = "Fireball_" + i;
                        bullets[j, i].transform.parent = gameObject.transform;
                        bullets[j, i].gameObject.SetActive(false);
                        break;
                    case ProjectileType.lightning:
                        bullets[j, i] = Instantiate(originalLightningBullet);
                        bullets[j, i].name = "Lightning_" + i;
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
