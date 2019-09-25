using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Recorder;

public class UIManager : MonoBehaviour
{
    public RecordManager recordManager;
    // Start is called before the first frame update
    void Start()
    {}
    // Update is called once per frame
    void Update()
    {}

     public void startVideoRecording(){
        recordManager.StartRecord();
    }
    public void stopVideoRecording(){
        recordManager.StopRecord();
    }




}
