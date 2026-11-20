using UnityEngine;

public class MinijuegoManager : MonoBehaviour
{
    [Header("Objetos del Personaje (Outfit Correcto)")]
    public GameObject[] outfitCorrecto; // Arrastra las prendas reales que la modelo tiene puestas

    [Header("Panel del Ropero")]
    public GameObject clothingPanel; // Arrastra el ClothingPanel

    void Start()
    {
        // 1. Al iniciar, el panel de selección empieza oculto
        clothingPanel.SetActive(false);

        // 2. Aquí puedes programar un temporizador (Invoke) para que el outfit desaparezca a los 3 segundos
        Invoke("OcultarOutfit", 3f);
    }

    void OcultarOutfit()
    {
        // Oculta las prendas correctas para que el jugador empiece a adivinar
        foreach (GameObject prenda in outfitCorrecto)
        {
            if (prenda != null) prenda.SetActive(false);
        }

        // Muestra el panel de selección para que el jugador elija
        clothingPanel.SetActive(true);
    }
}
