using UnityEngine;
using System.Collections;

public class Story_Master : MonoBehaviour {

    public int currentLine;
    public string[] lines;
    public float[] pauseTimes;

    public delegate void GeneralEventHandler();

    public event GeneralEventHandler EventStartStory;
    public event GeneralEventHandler EventStopStory;

    public void CallEventStartStory()
    {
        EventStartStory();
    }

    public void CallEventStopStory()
    {
        EventStopStory();
    }


}
