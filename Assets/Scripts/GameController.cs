using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController main;

    [Header("References")]
    [SerializeField] private GameObject floorObject;
    [SerializeField] private GameObject targetPrefab;

    public Vector3 dimensionesPlano;

    public GameObject target;
    void Awake() {
        main = this;
        dimensionesPlano = floorObject.GetComponent<Renderer>().bounds.size;
    }
    void Start()
    {
        SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTarget()
    {
        // Genera una posición aleatoria dentro del plano
        Vector3 randomPosition = new Vector3(
            Random.Range(-dimensionesPlano.x / 2, dimensionesPlano.x / 2),
            0f,
            Random.Range(-dimensionesPlano.z / 2, dimensionesPlano.z / 2)
        );


        target = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }

    public Transform getTarget() {
        return target.transform;
    }
}
