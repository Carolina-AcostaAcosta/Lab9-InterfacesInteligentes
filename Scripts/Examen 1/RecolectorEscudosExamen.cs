using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecolectorEscudosExamen : MonoBehaviour
{
    public TMP_Text textoPuntuacion;
    public TMP_Text textoRecompensa;
    private int puntuacion = 0;
    private int siguienteRecompensa = 100;

    private void Start()
    {
        if (textoPuntuacion != null)
            textoPuntuacion.text = "Puntuación: 0";
        if (textoRecompensa != null)
            textoRecompensa.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        int puntos = 0;

        if (other.CompareTag("EscudoTipo1"))
        {
            puntos = 10;
            if (puntuacion > 100)
            {
                puntos *= 2;
            }
        }
        else if (other.CompareTag("EscudoTipo2"))
        {
            puntos = 20;
            if (puntuacion > 100)
            {
                other.transform.localScale *= 1.5f;
            }
        }
        else if (other.CompareTag("EscudoTipo1Especial"))
        {
            puntos = 10;
            if (puntuacion > 100)
            {
                puntos *= 2;
            }

            EventManager.EscudoTipo1EspecialRecogido();
        }
        if (puntos > 0)
        {
            puntuacion += puntos;
            EventManager.PuntosPositivos();
            Destroy(other.gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.OnEscudoTipo1EspecialRecogido += ManejarEscudoTipo1Especial;
        EventManager.OnPuntosPositivos += ManejarPuntosPositivos;
    }

    private void OnDisable()
    {
        EventManager.OnEscudoTipo1EspecialRecogido -= ManejarEscudoTipo1Especial;
        EventManager.OnPuntosPositivos -= ManejarPuntosPositivos;
    }
    
    private void ManejarPuntosPositivos()
    {

            if (textoPuntuacion != null)
            {
                textoPuntuacion.text = "Puntuación: " + puntuacion;
            }
            if (puntuacion >= siguienteRecompensa)
            {
                if (textoRecompensa != null)
                {
                    textoRecompensa.text = $"¡Recompensa obtenida por {siguienteRecompensa} puntos!";
                }
                Debug.Log($"¡Recompensa obtenida por {siguienteRecompensa} puntos!");

                siguienteRecompensa += 100;
            }
    }
    private void ManejarEscudoTipo1Especial()
    {
        // Guerrero de tipo 2 se aleja al recoger el escudo especial
        GameObject guerrero2 = GameObject.FindWithTag("GuerreroTipo2");
        if (guerrero2 != null)
        {
            Vector3 direccionLejana = (guerrero2.transform.position - transform.position).normalized;
            guerrero2.transform.position = Vector3.MoveTowards(
                guerrero2.transform.position,
                guerrero2.transform.position + direccionLejana * 10f,
                5f
            );
        }
        // Escudos tipo 1 se acercan a su guerrero de tipo 1, tipo 2 se alejan
        GameObject[] escudosTipo1 = GameObject.FindGameObjectsWithTag("EscudoTipo1");
        foreach (GameObject escudo in escudosTipo1)
        {
            GameObject guerrero1 = GameObject.FindWithTag("GuerreroTipo1");
                if (guerrero1 != null)
                {
                    Vector3 direccionCercana = (guerrero1.transform.position - escudo.transform.position).normalized;
                    escudo.transform.position = Vector3.MoveTowards(
                        escudo.transform.position,
                        guerrero1.transform.position,
                        2f
                    );
                }
            }
            GameObject[] escudosTipo2 = GameObject.FindGameObjectsWithTag("EscudoTipo2");
            foreach (GameObject escudo in escudosTipo2)
            {
                if (guerrero2 != null)
                {
                    Vector3 direccionLejana = (escudo.transform.position - guerrero2.transform.position).normalized;
                    escudo.transform.position = Vector3.MoveTowards(
                        escudo.transform.position,
                        guerrero2.transform.position,
                        50f * Time.deltaTime
                    );
                }
            }
    }
}
