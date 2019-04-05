using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnCreatures : MonoBehaviour
{
    //static nbWolves, nbPigs, etc etc counting total wolves
    // if object is Wolf, nbWolves ++...
    // always have same nb of wolves, so if nbWolves goes down, spawn wolf

    [SerializeField] private GameObject creature;//can convert into array to spawn miore than one creature in range 
    private NavMeshAgent nav;
    [Header("How many # creature do you want to spawn")]
    [SerializeField] private int creatureNumber;
    [Header("Range (starting from object)")]
    [SerializeField] private int spawnRange;
    // [SerializeField] private  Transform parent;

    private static int wolfCounter;


    private Vector3 point;



    // Start is called before the first frame update
    void Start()
    {

        Spawn();
    }
    //else if (creature is Pug)
    //{
    //    PugSpawnCnt++;
    //    Spawn();
    //}


    void Spawn()
    {
        for (int i = 0; i < creatureNumber; i++) // not an array, find better way to loop
        {

            point = RandomNavPoint(spawnRange);
            Instantiate(creature, point, Random.rotation, this.transform);


            // Will spawn clones inside itself instead of spamming heiarchy


            // Could have something here to prevent creatures from spawning too close to each other
        }
    }

    public Vector3 RandomNavPoint(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;

        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {

            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
