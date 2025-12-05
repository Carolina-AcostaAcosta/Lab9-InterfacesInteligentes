using UnityEngine;

public class CollisionNotifier : MonoBehaviour {
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Cubo")) {
      Debug.Log("Cilindro ha detectado al cubo");
      EventManager_Ej1.LanzarEventoColision();
    }
  }
}
