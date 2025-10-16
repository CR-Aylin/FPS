using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    tipoEnemigo tipo;
    enemi enemigo;

    NavMeshAgent agent;
    private GameObject player;
    private Transform target;

    [Header("Configuracion")]//probando jii
    [Tooltip("lista de puntos a seguir el enemigo")]
    [SerializeField] Transform[] waypoints;

    [Header("Patrulla")]
    [SerializeField] public int destinationIndex = 0;
    [SerializeField] float distanceLimit = 5f;

    [SerializeField] float limite = 5f;
    float distanceToNextPoint;// dis entre npc y el punto

    [Header("Persecucion")]
    [SerializeField] public float maxFollowDistance = 5f;
    float explosionRadius = 4f;
    private Collider[] explosionHits = new Collider[20];



    void Start()
    {
        enemigo = GetComponent<enemi>();
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent <GameObject>();

        if (enemigo.estado == estado_enemy.Patrull)
        {
            destinationIndex = 0;

            if (waypoints.Length > 0)//
            {
                agent.destination = waypoints[0].position;// mov auto hacia waypointy en la lista
            }

        }
    }


    void set_tipo()
    {
        switch (this.tipo)
        {
            case tipoEnemigo.A:
                enemigo.salud = 3;
                break;
            case tipoEnemigo.B:
                enemigo.salud = 4;
                break;
        }
    }
    
    public void Patrulla()
    {
        distanceToNextPoint = Vector3.Distance(transform.position, waypoints[destinationIndex].position);

        if (enemigo.tipo == tipo_enemy.B)
        {
            enemigo.detecto();
        }

        Debug.Log(distanceToNextPoint);
        if (distanceToNextPoint < distanceLimit)
        {
            ChangeIndex();
            agent.velocity = agent.velocity / 2f;

        }
    }

    public void ChangeIndex()
    {
        destinationIndex++;
        if (destinationIndex >= waypoints.Length)
        {
            destinationIndex = 0;
        }

        agent.destination = waypoints[destinationIndex].position;
    }

    public void Persecucion()
    {
            target = player.transform;

            if (Vector3.Distance(target.position, this.gameObject.transform.position) <= maxFollowDistance)
            {
                agent.destination = target.position;//sigue al personaje
            }
            else if (Vector3.Distance(target.position, this.gameObject.transform.position) >= maxFollowDistance && enemigo.estado == estado_enemy.Transicion)
            {
                Transicion();
            }

        

    }



    public void Transicion()
    {
        /*el enemigo debe calcular el waypoint más cercano a su posición,
        para dirigirse hacia allá, y volver a Modo Patrulla*/

        Transform waypoint_cerca = null;
        float distancia_menor = Mathf.Infinity;// pa que cualquier distancia sea mas chica
        Vector3 currentposition = transform.position;

            foreach (Transform punto in waypoints)
            {
                float distancia = Vector3.Distance(currentposition, punto.position);
                if (distancia < distancia_menor)
                {
                    distancia_menor = distancia;
                    waypoint_cerca = punto;
                }
            }

            agent.destination = waypoint_cerca.position;

    }


}

public enum tipoEnemigo
{ A, B }
public enum tipoArmas
{
    Pistola, Metralleta
};
