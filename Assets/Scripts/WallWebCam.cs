using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWebCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Material materialParedCamaraWeb;
    WebCamTexture camaraTexture;
    void Start()
    {
        // Verificar si hay cámaras web disponibles
        if (WebCamTexture.devices.Length > 0)
        {
            // Seleccionar la primera cámara web disponible
            camaraTexture = new WebCamTexture(WebCamTexture.devices[0].name);

            if (!camaraTexture.isPlaying) {
                camaraTexture.Stop();
            } 
            camaraTexture.Play();
            // Asignar la textura de la cámara web al material
            materialParedCamaraWeb.mainTexture = camaraTexture;
            
        }
        else
        {
            Debug.LogError("No se encontraron cámaras web disponibles.");
        }
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (camaraTexture != null)
        {
            camaraTexture.Stop();
        }
    }
}
