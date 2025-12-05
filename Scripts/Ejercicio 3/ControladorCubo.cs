using UnityEngine;

public class ControladorCubo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HumanoideBehavior h = other.GetComponent<HumanoideBehavior>();
        if (h == null) return;

        if (h.tipo == HumanoideBehavior.Tipo.Tipo1)
        {
            Debug.Log("Cubo tocó un humanoide Tipo 1");
            EventManager.CuboTocoTipo1();
        }
        else if (h.tipo == HumanoideBehavior.Tipo.Tipo2)
        {
            Debug.Log("Cubo tocó un humanoide Tipo 2");
            EventManager.CuboTocoTipo2();
        }
    }
}
