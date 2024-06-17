using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataTracker : MonoBehaviour
{
    

    [SerializeField] private Spawner spawner;
    [SerializeField] private string testName;
    private static string fileTestName = "";
    [SerializeField] private FPSCounter fpsCounter;
    [SerializeField] private List<int> results;

    [SerializeField] private int testTime;

    [Header("GravityTest")]
    [SerializeField] GravityChanger gravityChanger;

    private void Start()
    {
        fileTestName = testName;
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Data/");

        results = new List<int>();        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gravityChanger != null) gravityChanger.ChangeGravity = true;
            
            StartCoroutine(Timer());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            WriteToTxt();
        }
    }


    IEnumerator Timer()
    {
        for (int j = 0; j < 3; j++)
        {

            spawner.Spawn();
            fpsCounter.ResetCounter();
                for (int i = 0; i < testTime; i++)
                {
                    yield return new WaitForSeconds(1);
                    results.Add(fpsCounter.GetCountedFrames());
                    fpsCounter.ResetCounter();
                }
            WriteToTxt();
            spawner.DestroyAll();
            results.Clear();
            yield return new WaitForSeconds(2);
        }

        Debug.Log("done - " + spawner.objects);
    }


    string averages = Application.streamingAssetsPath + $"/Data/" + $"Data-Averages-Test-{fileTestName}.txt";

    void WriteToTxt()
    {
        string txtDocName = Application.streamingAssetsPath + "/Data/" + $"FPS-{testName}-{spawner.objects}-objects.txt";

        //Create file
        if (!File.Exists(txtDocName))
        {
            File.WriteAllText(txtDocName, $"FPS over {testTime} for test {testName}\n\n");
        }

        int totalFps = 0;
        //Add all tries to file
        for (int i = 0; i < results.Count; i++)
        {
            File.AppendAllText(txtDocName, results[i].ToString() + "\n");
            totalFps += results[i];
        }

        File.AppendAllText(txtDocName, "\n");

        //Get average
        File.AppendAllText(txtDocName, "Average: " + (totalFps / testTime).ToString());
        File.AppendAllText(txtDocName, "\n\n");

        addToAverages(totalFps);
    }

    void addToAverages(int totalFps)
    {
        if (!File.Exists(averages))
        {
            File.WriteAllText(averages, $"Average FPS each test - {fileTestName}\n\n");
        }

        string content = $"Average {spawner.objects} - {totalFps / testTime} \n";
        File.AppendAllText(averages, content);
    }
}
