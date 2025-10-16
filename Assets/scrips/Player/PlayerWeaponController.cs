using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    // Control de armas/weapon
    public List<WeaponController> Armas = new List<WeaponController>();

    public Transform weaponParentSocket;//Armas
    public Transform defaultWeaponPosition;//posicion inical de las armas
    public Transform aimingPosition;//posicion de apunte
    public int ArmasIndex { get; private set; }//pos del Arma activa
    private WeaponController[] Invetario_Ar = new WeaponController[2];
    void Start()
    {
        ArmasIndex = -1;
        foreach (WeaponController arma in Armas)
        {
            addArma(arma);
        }
    }

    public void cambiarArma(int index)
    {
        if (index != ArmasIndex && index >= 0)
        {
            Invetario_Ar[index].gameObject.SetActive(true);
            ArmasIndex = index;
        }
    }

    public void addArma(WeaponController ArmaPrefab)
    {
        weaponParentSocket.position = defaultWeaponPosition.position;

        //anadir arma 
        for (int i = 0; i<Invetario_Ar.Length; i++)
        {
            if (Invetario_Ar[i] == null)
            {
                WeaponController ArmaIns = Instantiate(ArmaPrefab, weaponParentSocket);
                ArmaIns.gameObject.SetActive(false);

                Invetario_Ar[i] = ArmaIns;
                return;
            }
        }
    }


}
