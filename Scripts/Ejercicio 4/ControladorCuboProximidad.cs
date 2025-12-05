using UnityEngine;
using System;

public static class EventManagerProximidad
{
    public static event Action OnCuboCercaReferencia;

    public static void CuboCercaReferencia() => OnCuboCercaReferencia?.Invoke();
}

public class ControladorCuboProximidad : MonoBehaviour
{
    private bool eventoDisparado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (eventoDisparado) return;

        if (other.CompareTag("Cubo"))
        {
            eventoDisparado = true;
            Debug.Log("Cubo entró en el trigger de referencia");
            EventManagerProximidad.CuboCercaReferencia();
        }
    }
}
