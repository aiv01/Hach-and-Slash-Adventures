using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyLogic : MonoBehaviour {
    [Header("Level")]
    [SerializeField] public int level = 1;

    [Header("Dead")]
    private bool dead;

    [Header("References")]
    public CharacterStats enemyStats;
    [SerializeField] private GameObject[] disableOnDeath;
    private Animator anim;
    private SkinnedMeshRenderer mr;
    [SerializeField] private Material dissolveMaterial;
    private Material[] originalMaterials;
    [SerializeField] private float disappearSpeed;
    [SerializeField] private bool stopAnimation;
    private float disappearingTime;
    private MaterialPropertyBlock dissolveProperties;

    // Start is called before the first frame update
    private void Awake() {
        enemyStats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
        mr = GetComponentInChildren<SkinnedMeshRenderer>();
        dissolveProperties = new MaterialPropertyBlock();
        originalMaterials = mr.materials;
    }

    private void OnEnable() {
        Reactivate();
        enemyStats.InitializeCharacter();
        BalanceToLevel();
    }

    private void BalanceToLevel() {
        EnemyData currentEnemy = (EnemyData)enemyStats.stats;
        enemyStats.vigor += Mathf.CeilToInt((level * 0.5f) - 1);
        enemyStats.strength += level - 1;
        enemyStats.dexterity += level - 1;
        enemyStats.intelligence += level - 1;
        enemyStats.CalculateStats();
        enemyStats.hp = enemyStats.MaxHp;
        enemyStats.exp = currentEnemy.exp * level;
    }

    private void Update() {
        if (enemyStats.hp <= 0 && !dead) {
            Die();
        }
        if (dead) {
            disappearingTime += Time.deltaTime * disappearSpeed;
            mr.GetPropertyBlock(dissolveProperties);
            dissolveProperties.SetFloat("_DissolveAmount", Mathf.Lerp(0, 1, disappearingTime));
            mr.SetPropertyBlock(dissolveProperties);
            if (disappearingTime >= 1) {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void HitStart() {
        enemyStats.isHit = false;
    }

    private void Die() {
        PlayerLogic.Instance.GetExp(enemyStats.exp);
        DataManagement.enemyKilled++;
        for (int i = 0; i < disableOnDeath.Length; i++) {
            disableOnDeath[i].SetActive(false);
        }
        Material[] mats = new Material[mr.materials.Length];
        for (int i = 0; i < mats.Length; i++) {
            mats[i] = dissolveMaterial;
        }
        mr.materials = mats;
        disappearingTime = 0;
        if(stopAnimation) anim.speed = 0;
        dead = true;
    }

    private void Reactivate() {
        dead = false;
        anim.speed = 1;
        for (int i = 0; i < disableOnDeath.Length; i++) {
            if (disableOnDeath[i].layer == LayerMask.NameToLayer("Hitbox")) continue;
            disableOnDeath[i].SetActive(true);
        }
        mr.materials = originalMaterials;
    }
}
