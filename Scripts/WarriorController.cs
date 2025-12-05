using UnityEngine;
using UnityEngine.InputSystem;

public class WarriorController : MonoBehaviour
{
    public float minLatitude = 28.4825f; 
    public float maxLatitude = 28.4836f;
    public float minLongitude = -16.3211f; 
    public float maxLongitude = -16.3226f;

    public float speedFactor = 5.0f; // Multiplicador de velocidad
    public float rotationSmoothing = 2.0f; // Para el Slerp

    private bool isGPSReady = false;
    private bool isInsideArea = true; 

    void Start()
    {
        UnityEngine.Input.location.Start();
        UnityEngine.Input.compass.enabled = true;

        if (UnityEngine.InputSystem.Accelerometer.current != null)
            InputSystem.EnableDevice(UnityEngine.InputSystem.Accelerometer.current);
    }

    void Update()
    {
        // Comprobar estado del GPS
        CheckGPSStatus();

        if (!isInsideArea) return;

        float targetHeading = UnityEngine.Input.compass.trueHeading;
        Quaternion targetRotation = Quaternion.Euler(0, targetHeading, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothing);

        MoveWithAccelerometer();
    }

    void MoveWithAccelerometer()
    {
        if (UnityEngine.InputSystem.Accelerometer.current == null) return;

        Vector3 accel = UnityEngine.InputSystem.Accelerometer.current.acceleration.ReadValue();
        
        float moveInput = -accel.z;
        if (Mathf.Abs(moveInput) < 0.1f) moveInput = 0;

        Vector3 movement = transform.forward * moveInput * speedFactor * Time.deltaTime;
        
        transform.position += movement;
    }

    void CheckGPSStatus()
    {
        // Si el servicio ha fallado o no ha iniciado, salimos
        if (UnityEngine.Input.location.status != LocationServiceStatus.Running) return;

        isGPSReady = true;

        // Obtener datos actuales
        float lat = UnityEngine.Input.location.lastData.latitude;
        float lon = UnityEngine.Input.location.lastData.longitude;

        if (lat >= minLatitude && lat <= maxLatitude && 
            lon >= minLongitude && lon <= maxLongitude)
        {
            isInsideArea = true;
        }
        else
        {
            isInsideArea = false;
            Debug.Log("¡Fuera de la zona GPS! Motor detenido.");
        }
    }
    
    void OnDisable()
    {
        if (UnityEngine.InputSystem.Accelerometer.current != null)
            InputSystem.DisableDevice(UnityEngine.InputSystem.Accelerometer.current);
            
        UnityEngine.Input.location.Stop();
    }
    
    void OnGUI()
    {
       // Interfaz básica para depuración en el móvil
        GUI.color = Color.black;
        GUI.Label(new Rect(20, 20, 600, 40), $"Estado GPS: {isGPSReady} | Dentro Zona: {isInsideArea}");
        
        if (isGPSReady)
        {
            GUI.Label(new Rect(20, 50, 600, 40), $"Lat: {UnityEngine.Input.location.lastData.latitude}");
            GUI.Label(new Rect(20, 80, 600, 40), $"Lon: {UnityEngine.Input.location.lastData.longitude}");
        }
        
        GUI.Label(new Rect(20, 110, 600, 40), $"Brújula: {UnityEngine.Input.compass.trueHeading}");
    }
}