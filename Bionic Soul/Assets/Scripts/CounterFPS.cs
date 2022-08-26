using UnityEngine;
using TMPro;

public class CounterFPS : MonoBehaviour
{
    public TextMeshProUGUI FpsText;
    private float time;
    private float pollingTime = 3f;
    private int frameCount;

    void Update()
    {
        //DontDestroyOnLoad(FpsText);
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + "FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
