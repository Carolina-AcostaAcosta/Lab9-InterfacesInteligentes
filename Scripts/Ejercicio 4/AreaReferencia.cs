using UnityEngine;

public class AreaReferencia : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cubo"))
        {
            Debug.Log("Cubo entró en el área de referencia");
            EventManagerProximidad.CuboCercaReferencia();
        }
    }
}
