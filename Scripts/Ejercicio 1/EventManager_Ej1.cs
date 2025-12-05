using System;
using UnityEngine;

public static class EventManager_Ej1 {
  public static event Action OnCuboTocaCilindro;

  public static void LanzarEventoColision() {
    Debug.Log("Evento lanzado: Cubo ha tocado el cilindro.");
    OnCuboTocaCilindro?.Invoke();
  }
}
