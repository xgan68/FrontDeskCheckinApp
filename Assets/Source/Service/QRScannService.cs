using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class QRScanService
{

    public static Action<string> QRCodeScanSuccess;
    public static Action<int, string> QRCodeIDBindCallback;


    public static QRScanManager Instance;

    private string m_gameID;
    Text t;
    //  public Renderer PlaneRender;

    public void Init()
    {
        //Instance = this;

        // Initialize EasyCodeScanner
        EasyCodeScanner.Initialize();

        //Register on Actions
        EasyCodeScanner.OnScannerMessage += onScannerMessage;
        EasyCodeScanner.OnScannerEvent += onScannerEvent;
        EasyCodeScanner.OnDecoderMessage += onDecoderMessage;

        QRScanManager.QRCodeScanSuccess += OnQRCodeScanSuccess;

        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        //t = GetComponentInChildren<Text>();
    }

    void OnDestroy()
    {

        //Unregister
        EasyCodeScanner.OnScannerMessage -= onScannerMessage;
        EasyCodeScanner.OnScannerEvent -= onScannerEvent;
        EasyCodeScanner.OnDecoderMessage -= onDecoderMessage;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void Scan()
    {
        //OnQRCodeScanSuccess("123451234a");

        EasyCodeScanner.launchScanner(false, "FRAXINUS", -1, false);
    }

    public void UpdateGameSessionID(string id)
    {
        m_gameID = id;
    }

    //Callback when returns from the scanner
    void onScannerMessage(string data)
    {
        Debug.Log("EasyCodeScannerExample - onScannerMessage data=:" + data);
        QRCodeScanSuccess(data);
        t.text = data;
    }

    //Callback which notifies an event
    //param : "EVENT_OPENED", "EVENT_CLOSED"
    void onScannerEvent(string eventStr)
    {
        Debug.Log("EasyCodeScannerExample - onScannerEvent:" + eventStr);
    }

    //Callback when decodeImage has decoded the image/texture 
    void onDecoderMessage(string data)
    {
        Debug.Log("EasyCodeScannerExample - onDecoderMessage data:" + data);

        //post data to server
        //bring up welcome window
    }

    private void OnQRCodeScanSuccess(string ID)
    {
        //NetworkController.Instance.PostQRCodeID(ID, QRCodeIDBindCallback);
        Debug.Log("band_id: " + ID + " game_id: " + m_gameID);
        WWWForm form = new WWWForm();
        form.AddField("band_id", ID);
        form.AddField("game_id", m_gameID);

        NetworkController1.Instance.Post<ServerMessage>(NetworkController1.BIND_WRIST_BAND_URL, form, QRCodeScanCallback);
    }

    private void QRCodeScanCallback(ServerMessage response)
    {
        QRCodeIDBindCallback(response.err_code, response.err_msg);
    }
}