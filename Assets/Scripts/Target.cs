using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private AudioClip destroyedClip;
    [SerializeField] private AudioSource audioSource;

    public float velocidad = 5f;
    public float rangoMovimiento = 10f;

    private bool moverDerecha = true;

    private Vector3 dimensionesPlano;

    void Awake() {
        dimensionesPlano = GameController.main.dimensionesPlano;
    }

    void Update()
    {
        if (moverDerecha) {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);

            // Verificar si ha alcanzado el límite derecho del plano
            if (transform.position.x >= dimensionesPlano.x / 2)
            {
                // Cambiar dirección
                moverDerecha = false;
            }
        }
        else{
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);

            // Verificar si ha alcanzado el límite izquierdo del plano
            if (transform.position.x <= -dimensionesPlano.x / 2)
            {
                // Cambiar dirección
                moverDerecha = true;
            }
        }
    }

    public void bulletHit() {
        audioSource.PlayOneShot(destroyedClip);
        Invoke("DestroyBullet", 1.0f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
        GameController.main.SpawnTarget();
    }
}
