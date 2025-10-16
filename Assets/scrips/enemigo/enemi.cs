using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum estado_enemy
{ Patrull, Persecucion, Transicion }


public class enemi : MonoBehaviour
{

    private GameObject player;

    EnemyController movimiento;
    PlayerController pc;

    [Header("Configuracion Enemigo")]//probando jii
    [SerializeField] public estado_enemy estado;
    [SerializeField] public tipoEnemigo tipo;
    [SerializeField] public int salud;
    [SerializeField] private int tiempo_inven = 4;
    [SerializeField] private int dura_ataque = 3;
    [SerializeField] float distanAtaque = 3f;

    [SerializeField] float distandetec = 4f;

    [SerializeField] int retrocede = 2;

    bool cooldown = false;
    bool atacando = false;
    Transform pos_player;
    
    void Awake()
    {
       movimiento = GetComponent<EnemyController>();
       //player = GameplayManager.instance.GetPlayerGameObject();
        pos_player = GameObject.FindWithTag("Player").transform;
        set_tipo();
    }
    
    void Start()
    {
        set_estado();
        
    }

    void Update()
    {
        set_estado();
        StartCoroutine(aatacar());
    }


    void set_estado() //asigno estado
    {
        switch (this.tipo)
        {
            case 0:
                movimiento.Patrulla();
                break;
            case tipoEnemigo.B:
               movimiento.Persecucion();
                break;

        }

    }
    void set_tipo()
    {
        switch (this.tipo)
        {
            case tipoEnemigo.A:
                this.salud = 3;
                break;
            case tipoEnemigo.B:
                this.salud = 4;
                break;
        }
    }


    void dano()
    {
        if (salud >= 1)
        {
            salud--;
        }
        else if (salud == 0)
        {
            Destroy(this.gameObject);
        }
        /*
        if (tipo == tipo_enemy.B && !detecto())
        {
            Destroy(this.gameObject);
        }*/

    }

    IEnumerator invencibilidad()
    {
        yield return new WaitForSeconds(dura_ataque);
        atacando = true;
        yield return new WaitForSeconds(tiempo_inven);
        atacando = false;
    }

    /*    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("ataque");
            }


        }

        public void Ondano(PlayerCharacterController player)
        {
            Debug.Log("ataque");
            //dano();
            if (player.isAttacking)
            {
                dano();
            }
        }
        */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().isAttacking && !atacando)
            {
                //Debug.Log("daño ene");
                if (tipo == tipoEnemigo.A)
                {
                    dano();
                    transform.Translate(Vector3.back * retrocede);
                    //retroceder
                }
                dano();
                StartCoroutine(invencibilidad());
            }
            //Destroy(gameObject);
        }
    }


    IEnumerator aatacar()
    {
        atacando = true;
        cooldown = true;

        if (estado == estado_enemy.Persecucion && Vector3.Distance(transform.position, pos_player.position) < distanAtaque)
        {
            if (Physics.Raycast(transform.position, (pos_player.position - transform.position).normalized, out RaycastHit hit, distanAtaque))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hit.collider.gameObject.GetComponent<Playerstats>().vidas--;
                }
            }

            yield return new WaitForSeconds(dura_ataque);
            atacando = false;
            yield return new WaitForSeconds(tiempo_inven);
            cooldown = false;
        }

    }

    public bool detecto()
    {
        if (Physics.Raycast(transform.position, (pos_player.position - transform.position).normalized, out RaycastHit hit, distandetec) )
        {
            if (hit.collider.CompareTag("Player"))
            {
                estado = estado_enemy.Persecucion;
                return true;
            }
        }

        return false;

    }

}
