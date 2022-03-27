using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Projectile[] bullets;
    [SerializeField] private Projectile originalBullet;

    void Awake()
    {
        CreateBullets();
    }

    private void CreateBullets() {
        for(int i = 0; i < bullets.Length; i++) {
            bullets[i] = Instantiate(originalBullet);
            bullets[i].name = "PlayerBullet_" + i;
            bullets[i].transform.parent = gameObject.transform;
            bullets[i].gameObject.SetActive(false);
        }
        originalBullet.gameObject.SetActive(false);
    }

    public Projectile GetBullet() {
        foreach(Projectile bullet in bullets) {
            if (!bullet.gameObject.activeSelf) {
                Debug.Log("Preso: " + bullet.name);
                return bullet;
            }
        }
        Debug.Log("Non esistono proiettili");
        return null;
    }
}
