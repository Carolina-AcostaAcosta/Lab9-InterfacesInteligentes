using UnityEngine;

public class SphereBehavior : MonoBehaviour {
  public enum Tipo { Tipo1, Tipo2 }
	public Tipo tipo;
  public Transform esferaObjetivoTipo2;
  public Transform cilindro;
  public float velocidad = 1f;
	public float distanciaStop = 0.1f;

  private bool debeMoverse = false;
  private Transform seguirObjetivo = null;

  private void OnEnable() {
    EventManager_Ej1.OnCuboTocaCilindro += ResponderAlEvento;
  }

  private void OnDisable() {
    EventManager_Ej1.OnCuboTocaCilindro -= ResponderAlEvento;
  }

  private void Update() {
    if (!debeMoverse) {
      return;
    }

		if (seguirObjetivo != null) {
			Vector3 targetPos = seguirObjetivo.position;
      transform.position = Vector3.MoveTowards(transform.position, targetPos, velocidad * Time.deltaTime);
      if (Vector3.Distance(transform.position, targetPos) <= distanciaStop) {
        debeMoverse = false;
        seguirObjetivo = null;
      }
		}
  }

  private void ResponderAlEvento() {
    Debug.Log($"{name} recibió el evento de colisión");

    if (tipo == Tipo.Tipo1 && esferaObjetivoTipo2 != null) {
			seguirObjetivo = esferaObjetivoTipo2;
			debeMoverse = true;
    } else if (tipo == Tipo.Tipo2 && cilindro != null) {
      seguirObjetivo = cilindro;
			debeMoverse = true;
    } else {
			Debug.LogWarning($"{name}: no hay target asignado para tipo {tipo}");
		}
  }
}
