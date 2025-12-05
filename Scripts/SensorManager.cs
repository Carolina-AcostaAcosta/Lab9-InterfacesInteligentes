using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class SensorManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text accelText;
    public TMP_Text gyroText;
    public TMP_Text gravText;
    public TMP_Text attitudeText;
    public TMP_Text linearAccelText;
    public TMP_Text magneticText;
    public TMP_Text lightText;
    public TMP_Text pressureText;
    public TMP_Text proximityText;
    public TMP_Text humidityText;
    public TMP_Text tempText;
    public TMP_Text stepText;

    void Start()
    {
        // Habilitar sensores si existen
        if (Accelerometer.current != null) InputSystem.EnableDevice(Accelerometer.current);
        if (Gyroscope.current != null) InputSystem.EnableDevice(Gyroscope.current);
        if (GravitySensor.current != null) InputSystem.EnableDevice(GravitySensor.current);
        if (AttitudeSensor.current != null) InputSystem.EnableDevice(AttitudeSensor.current);
        if (LinearAccelerationSensor.current != null) InputSystem.EnableDevice(LinearAccelerationSensor.current);
        if (MagneticFieldSensor.current != null) InputSystem.EnableDevice(MagneticFieldSensor.current);
        if (LightSensor.current != null) InputSystem.EnableDevice(LightSensor.current);
        if (PressureSensor.current != null) InputSystem.EnableDevice(PressureSensor.current);
        if (ProximitySensor.current != null) InputSystem.EnableDevice(ProximitySensor.current);
        if (HumiditySensor.current != null) InputSystem.EnableDevice(HumiditySensor.current);
        if (AmbientTemperatureSensor.current != null) InputSystem.EnableDevice(AmbientTemperatureSensor.current);
        if (StepCounter.current != null) InputSystem.EnableDevice(StepCounter.current);
    }

    void Update()
    {
        // Movimiento (Vector3)
        // Usamos el operador ternario (? :) para comprobar si es null antes de leer
        accelText.text = "Acelerómetro: " + (Accelerometer.current != null ? Accelerometer.current.acceleration.ReadValue().ToString("F2") : "No disponible");
        
        gyroText.text = "Giroscopio: " + (Gyroscope.current != null ? Gyroscope.current.angularVelocity.ReadValue().ToString("F2") : "No disponible");
        
        gravText.text = "Gravedad: " + (GravitySensor.current != null ? GravitySensor.current.gravity.ReadValue().ToString("F2") : "No disponible");
        
        linearAccelText.text = "Acel. Lineal: " + (LinearAccelerationSensor.current != null ? LinearAccelerationSensor.current.acceleration.ReadValue().ToString("F2") : "No disponible");
        
        magneticText.text = "Campo Magnético: " + (MagneticFieldSensor.current != null ? MagneticFieldSensor.current.magneticField.ReadValue().ToString("F2") + " µT" : "No disponible");

        attitudeText.text = "Attitude: " + (AttitudeSensor.current != null ? AttitudeSensor.current.attitude.ReadValue().ToString("F2") : "No disponible");

        lightText.text = "Luz: " + (LightSensor.current != null ? LightSensor.current.lightLevel.ReadValue().ToString("F0") + " lux" : "No disponible");
        
        pressureText.text = "Presión: " + (PressureSensor.current != null ? PressureSensor.current.atmosphericPressure.ReadValue().ToString("F1") + " hPa" : "No disponible");
        
        proximityText.text = "Proximidad: " + (ProximitySensor.current != null ? ProximitySensor.current.distance.ReadValue().ToString("F1") + " cm" : "No disponible");
        
        humidityText.text = "Humedad: " + (HumiditySensor.current != null ? HumiditySensor.current.relativeHumidity.ReadValue().ToString("F1") + " %" : "No disponible");
        
        tempText.text = "Temperatura: " + (AmbientTemperatureSensor.current != null ? AmbientTemperatureSensor.current.ambientTemperature.ReadValue().ToString("F1") + " °C" : "No disponible");
  
        stepText.text = "Pasos: " + (StepCounter.current != null ? StepCounter.current.stepCounter.ReadValue().ToString() : "No disponible");
    }

    void OnDisable()
    {
        if (Accelerometer.current != null) InputSystem.DisableDevice(Accelerometer.current);
        if (Gyroscope.current != null) InputSystem.DisableDevice(Gyroscope.current);
        if (GravitySensor.current != null) InputSystem.DisableDevice(GravitySensor.current);
        if (AttitudeSensor.current != null) InputSystem.DisableDevice(AttitudeSensor.current);
        if (LinearAccelerationSensor.current != null) InputSystem.DisableDevice(LinearAccelerationSensor.current);
        if (MagneticFieldSensor.current != null) InputSystem.DisableDevice(MagneticFieldSensor.current);
        if (LightSensor.current != null) InputSystem.DisableDevice(LightSensor.current);
        if (PressureSensor.current != null) InputSystem.DisableDevice(PressureSensor.current);
        if (ProximitySensor.current != null) InputSystem.DisableDevice(ProximitySensor.current);
        if (HumiditySensor.current != null) InputSystem.DisableDevice(HumiditySensor.current);
        if (AmbientTemperatureSensor.current != null) InputSystem.DisableDevice(AmbientTemperatureSensor.current);
        if (StepCounter.current != null) InputSystem.DisableDevice(StepCounter.current);
    }
}