using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Armas ar;
    NavMeshAgent agent;
    private GameObject player;
    private Transform target;



    [Header("General")]
    public float maxDistance = 5;
    public Transform[] waypoints;
    public int destinationIndex = 0;
    float distanceToNextPoint;
    public tipoEnemigo tipo;
    public int vida;
    private tipoArmas arma;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void set_tipo()
    {
        switch (this.tipo)
        {
            case tipoEnemigo.A:
                vida = 10;
                break;
            case tipoEnemigo.B:
                vida = 10;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
/*
    void walker()
    {
        if (GameplayManager.instance != null)
        {
            player = GameplayManager.instance.GetPlayerGameObject();
            target = player.transform;

            if(Vector3.Distance(target.position, this.gameObject.transform.position) <= maxDistance)
            {
                agent.destination = target.position;
            }
            
        }
        
    }*/

    void Patrol()
    {
        distanceToNextPoint = Vector3.Distance(transform.position, waypoints[destinationIndex].position);

        Debug.Log(distanceToNextPoint);
        if(distanceToNextPoint < maxDistance)
        {
            ChangeIndex();
            agent.velocity = agent.velocity / 2f;

        }

    }
    
        public void ChangeIndex()
    {
        destinationIndex++;
        if(destinationIndex >= waypoints.Length)
        {
            destinationIndex = 0;
        }

        agent.destination = waypoints[destinationIndex].position;


    }
}

public enum tipoEnemigo
{ A, B }
public enum tipoArmas
{
    Pistola, Metralleta
};
