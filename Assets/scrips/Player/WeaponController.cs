using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask hittableLayers;
    public GameObject HolePrefab;

    [Header("Shoot")]//hamilton
    public float fireRange = 200;//rango distancia
    private Transform cameraPlayer;
    void Start()
    {
        cameraPlayer = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {

    }
    
    private void Disparo()
    {
            RaycastHit hit;
            if (Physics.Raycast(cameraPlayer.position, cameraPlayer.forward, out hit, fireRange, hittableLayers))
            {
                GameObject oyoC = Instantiate(HolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                Destroy(oyoC, 4f);
            } 
    }
}
