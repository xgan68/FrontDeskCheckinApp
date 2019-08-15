﻿using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class QRScanManager : MonoBehaviour {

    public static Action<string> QRCodeScanSuccess;

	string dataStr;
	Text t;
	//	public Renderer PlaneRender;
	
	void Start () {
		dataStr = "";
		
		// Initialize EasyCodeScanner
		EasyCodeScanner.Initialize();
		
		//Register on Actions
		EasyCodeScanner.OnScannerMessage += onScannerMessage;
		EasyCodeScanner.OnScannerEvent += onScannerEvent;
		EasyCodeScanner.OnDecoderMessage += onDecoderMessage;

        QRScanManager.QRCodeScanSuccess += OnQRCodeScanSuccess;

        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        t = GetComponentInChildren<Text> ();
	}
	
	void OnDestroy() {
		
		//Unregister
		EasyCodeScanner.OnScannerMessage -= onScannerMessage;
		EasyCodeScanner.OnScannerEvent -= onScannerEvent;
		EasyCodeScanner.OnDecoderMessage -= onDecoderMessage;
	}
	
	void Update() {
		
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			Application.Quit();
		}
		
	}

	public void Scan()
	{
		EasyCodeScanner.launchScanner(false, "FRAXINUS", -1, false);
	}

	
	//Callback when returns from the scanner
	void onScannerMessage(string data){
		Debug.Log("EasyCodeScannerExample - onScannerMessage data=:"+data);
        QRCodeScanSuccess(data);
        t.text = data;
//		dataStr = data;
	}
	
	//Callback which notifies an event
	//param : "EVENT_OPENED", "EVENT_CLOSED"
	void onScannerEvent(string eventStr){
		Debug.Log("EasyCodeScannerExample - onScannerEvent:"+eventStr);
	}
	
	//Callback when decodeImage has decoded the image/texture 
	void onDecoderMessage(string data){
		Debug.Log("EasyCodeScannerExample - onDecoderMessage data:"+data);
		dataStr = data;

        //post data to server
        //bring up welcome window
	}

    private void OnQRCodeScanSuccess(string ID)
    {
        NetworkController.Instance.PostQRCodeID(ID,OnQRCodeIDBinded);
    }

    private void OnQRCodeIDBinded(int errorCode, string errorMsg)
    { 
        
    }
}