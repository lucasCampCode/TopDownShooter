using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [Tooltip("The object that will be instantiated.")]
    [SerializeField]
    private GameObject _spawnObject;
    [SerializeField]
    private SpawnManagerScriptableObject _spawnManager;
    [Tooltip("If false, the spawner will stop instantiating clones of the reference.")]
    [SerializeField]
    private bool _canSpawn;
    [Tooltip("The enemy object's target.")]
    [SerializeField]
    private GameObject _enemyTarget;
    [SerializeField]
    private ClosestTargetBehaviour _targetBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    /// <summary>
    /// Spawns objects continuously while canSpawn is true.
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpawnObjects()
    {
        for(int i = 0; i > _spawnManager.spawnCount; i++)
        {
            //Create a new enemy in the scene
            GameObject spawnedEnemy = Instantiate(_spawnObject, transform.position, new Quaternion());
            //Set the enemy target to be the target the spawner was given
            spawnedEnemy.GetComponent<EnemyMovementBehaviour>().Target = _enemyTarget;
            spawnedEnemy.name = spawnedEnemy.name + i;
            //add enemy to the blackboard
            _targetBehaviour.Targets.Add(spawnedEnemy);
            //Pause for the given time in seconds before resuming the function
            yield return new WaitForSeconds(_spawnManager.timePerSpawn);
        }
    }
}
