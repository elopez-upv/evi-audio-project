using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickStart;
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame updat
    [Header("References")]
    private Transform target;
    private Rigidbody rb;

    private float speed;
    private GameObject shooter;

    public void Seek(Transform _target) {
        target = _target;
        Debug.Log("Target set: " + target.name);
    }

    public void SetShooter(GameObject _shooter)
    {
        shooter = _shooter;
    }

    void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró el componente Rigidbody.");
        }
    }

    void Start()
    {

    }

    // Update is called once per fram
    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        if (dir.magnitude <= 0.6f) {
            HitTarget();
            return;
        }
    }

    public void SetSpeed(float _speed) {
        speed = _speed;
        rb.velocity= transform.forward * speed;
        Debug.Log("Speed set: " + speed);
    }

    private void HitTarget() {
        Debug.Log("Bullet Hit Target");
        shooter.GetComponent<Player>().CmdUpdateHitsCounter();
        //Destroy(target.gameObject);
        target.GetComponent<Target>().bulletHit();
        Destroy(gameObject);
        //GameController.main.SpawnTarget();
    }
}
