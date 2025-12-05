using UnityEngine;

public class HumanoideBehavior : MonoBehaviour
{
    public enum Tipo { Tipo1, Tipo2 }
    public Tipo tipo;

    [Header("Referencias")]
    public Transform escudoTipo1; // destino fijo para tipo1
    public Transform[] escudosTipo2; // destinos posibles para tipo2
    public Transform puntoOrientacionTipo2;
    public float velocidad = 3f;

    private bool debeMoverse = false;
    private Transform destino;

    private void OnEnable()
    {
        // EventManager.OnCuboTocaTipo1 += ResponderEventoTipo1;
        // EventManager.OnCuboTocaTipo2 += ResponderEventoTipo2;
        EventManagerProximidad.OnCuboCercaReferencia += ResponderProximidad;
    }

    private void OnDisable()
    {
        // EventManager.OnCuboTocaTipo1 -= ResponderEventoTipo1;
        // EventManager.OnCuboTocaTipo2 -= ResponderEventoTipo2;
        EventManagerProximidad.OnCuboCercaReferencia -= ResponderProximidad;
    }

    private void ResponderProximidad()
    {
        if (tipo == Tipo.Tipo1 && escudoTipo1 != null)
        {
            transform.position = escudoTipo1.position;
            Debug.Log($"{name} (Tipo1) se teletransporta al escudo");
        }
        else if (tipo == Tipo.Tipo2 && puntoOrientacionTipo2 != null)
        {
            Vector3 direccion = (puntoOrientacionTipo2.position - transform.position).normalized;
            if (direccion != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(direccion);
            Debug.Log($"{name} (Tipo2) se orienta hacia el punto de referencia");
        }
    }

    private void Update()
    {
        if (debeMoverse && destino != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino.position,
                velocidad * Time.deltaTime
            );
        }
    }

    private void ResponderEventoTipo1()
    {
        if (tipo == Tipo.Tipo2 && escudosTipo2.Length > 0)
        {
            destino = escudosTipo2[Random.Range(0, escudosTipo2.Length)];
            debeMoverse = true;
        }
    }

    private void ResponderEventoTipo2()
    {
        if (tipo == Tipo.Tipo1 && escudoTipo1 != null)
        {
            destino = escudoTipo1;
            debeMoverse = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Escudo"))
        {
            Renderer rend = GetComponentInChildren<Renderer>();
            if (rend != null)
                rend.material.color = Random.ColorHSV();
        }
    }
}
