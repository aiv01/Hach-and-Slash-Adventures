using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    [SerializeField] private Mesh staffMesh, gunMesh;
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
        if(weapon.type == WeaponType.ranged) {
            mf.mesh = gunMesh;
        }
        else {
            mf.mesh = staffMesh;
        }
    }

    private void CheckIfPlayerInteracting() {
        float playerDistance = (transform.position - PlayerLogic.Instance.transform.position).magnitude;
        if(playerDistance < playerDistanceToEquip) {
            mr.material.color = Color.yellow;
            if (PlayerLogic.Instance.isInteracting) {
                InstancePlayerWeapon();
                PlayerLogic.Instance.playerStats.equippedWeapon = weapon;
                Destroy(gameObject);
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
