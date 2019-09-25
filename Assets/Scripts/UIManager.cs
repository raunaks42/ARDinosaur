using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;

public class UIManager : MonoBehaviour
{
    public RecordManager recordManager;
    // Start is called before the first frame update
    void Start()
    {   }
    // Update is called once per frame
    void Update()
    {   }

    int count = 0;
    public void VideoRecording(){
        if(count%2==0){
        recordManager.StartRecord();
        count++;
        }
        else{
        recordManager.StopRecord();
        count++;
        }

    }
}
