using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    [SerializeField] private Mesh staffMesh, gunMesh, creaturaMesh;
    [SerializeField] private Material staffMat, gunMat, creaturaMat;
    [SerializeField] private WeaponData weapon;
    [SerializeField] private float playerDistanceToEquip;
    [SerializeField] private WeaponDrop originalDrop;

    //References
    private MeshFilter mf;
    private MeshRenderer mr;

    private void Awake() {
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();
    }

    private void Update() {
        CheckIfPlayerInteracting();
    }
    public void Spawn() {
        switch (weapon.type) {
            case WeaponType.melee:
                mf.mesh = staffMesh;
                mr.material = staffMat;
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case WeaponType.ranged:
                mf.mesh = gunMesh;
                mr.material = gunMat;
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case WeaponType.magic:
                mf.mesh = staffMesh;
                mr.material = staffMat;
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case WeaponType.creatura:
                mf.mesh = creaturaMesh;
                mr.material = creaturaMat;
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                break;
            default:
                break;
        }
    }

    private void CheckIfPlayerInteracting() {
        float playerDistance = (transform.position - PlayerLogic.Instance.transform.position).magnitude;
        if(playerDistance < playerDistanceToEquip) {
            ClassData playerClass = (ClassData) PlayerLogic.Instance.playerStats.stats;
            mr.material.color = Color.yellow;
            if (PlayerLogic.Instance.isInteracting) {
                if(weapon.type == playerClass.weaponRestriction || weapon.type == WeaponType.creatura) {
                    InstancePlayerWeapon();
                    PlayerLogic.Instance.playerStats.equippedWeapon = weapon;
                    Destroy(gameObject);
                }
            }
        }
        else {
            mr.material.color = Color.white;
        }
    }

    private void InstancePlayerWeapon() {
        WeaponDrop instance = Instantiate<WeaponDrop>(originalDrop);
        instance.transform.position = PlayerLogic.Instance.transform.position;
        instance.weapon = PlayerLogic.Instance.playerStats.equippedWeapon;
        instance.name = instance.weapon.weaponName;
        instance.Spawn();
    }
}
