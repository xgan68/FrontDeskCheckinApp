using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginVO
{
    public string WristBandID { get; set; }
    public string UWBTagID { get; set; }

    public LoginVO(string _wristBandID, string _uwbTagID)
    {
        WristBandID = _wristBandID;
        UWBTagID = _uwbTagID;
    }
}
