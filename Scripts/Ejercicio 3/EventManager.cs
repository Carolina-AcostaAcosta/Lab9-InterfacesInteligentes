using System;
using UnityEngine;

public static class EventManager
{
  public static event Action OnCuboTocaTipo1;
  public static event Action OnCuboTocaTipo2;

  public static event Action OnEscudoTipo1EspecialRecogido;
  public static event Action OnPuntosPositivos;
  public static event Action OnDoscientosPuntos;

  public static void CuboTocoTipo1() => OnCuboTocaTipo1?.Invoke();
  public static void CuboTocoTipo2() => OnCuboTocaTipo2?.Invoke();
  public static void EscudoTipo1EspecialRecogido() => OnEscudoTipo1EspecialRecogido?.Invoke();

  public static void PuntosPositivos() => OnPuntosPositivos?.Invoke();
  public static void DoscientosPuntos() => OnDoscientosPuntos?.Invoke();
}
