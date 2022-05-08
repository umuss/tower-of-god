using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    public Transform m_SpawnPoints;
    [SerializeField]
    private GameObject m_enemyPrefabs;

    private bool _spawnenemies=true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnRoutine()
    {
        while (_spawnenemies == true)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(m_enemyPrefabs, m_SpawnPoints.position, Quaternion.identity);
            _spawnenemies = false;
        }
    }
}
