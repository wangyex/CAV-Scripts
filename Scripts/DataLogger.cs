using System.IO;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; // Target GameObject to log
    //[SerializeField] private string fileName = "log.csv"; // Default file name
    [SerializeField] private float logInterval = 0.5f; // Log every 0.5 seconds

    private float timer = 0.0f;
    //private string fullPath;
    [SerializeField] private string fullPath = "/Users/ywang426/Desktop/log.csv";  // Replace 'yourusername' with your actual username

    public FloatVariable BlyncSensorSpeed;
    public FloatVariable BlyncTurnAngle;

    float BlyncSpeed;
    float turnAngle;
    void Start()
    {
        //SetupFilePath();
        
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
        // Create file with header if it does not exist
        if (!File.Exists(fullPath))
        {
            WriteData("Time,PosX,PosY,PosZ,Speed,BlyncSpeed,SteeringAngle\n");
        }
        else
        {
            Debug.Log("File already exists. Continuing to append data to: " + fullPath);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        turnAngle = BlyncTurnAngle.value - 30f;
        BlyncSpeed = BlyncSensorSpeed.value;
        
        if (timer >= logInterval)
        {
            timer = 0f;
            LogData();
        }
    }



    private void LogData()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned.");
            return;
        }
        
        Vector3 position = targetObject.transform.position;
        Rigidbody rb = targetObject.GetComponent<Rigidbody>();
        float speed = rb ? rb.velocity.magnitude : 0;
        float speed_in_ft = speed * 3.4f;

        string data = Time.time.ToString("F3") + "," +
                      position.x.ToString("F3") + "," +
                      position.y.ToString("F3") + "," +
                      position.z.ToString("F3") + "," +
                      speed_in_ft.ToString("F3") + ","+
                      turnAngle.ToString("F3") + ","+
                      BlyncSpeed.ToString("F3") + "\n";

        WriteData(data);
    }

    private void WriteData(string data)
    {
        try
        {
            File.AppendAllText(fullPath, data);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to write data: " + ex.Message);
        }
    }
}
