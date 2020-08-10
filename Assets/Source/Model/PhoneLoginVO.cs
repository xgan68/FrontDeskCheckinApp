using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneLoginVO
{
    public string phoneNumber { get; set; }
    public string verifyCode { get; set; }

    public PhoneLoginVO(string _phoneNumber, string _verifyCode)
    {
        phoneNumber = _phoneNumber;
        verifyCode = _verifyCode;
    }

    public PhoneLoginVO()
    {
        phoneNumber = "";
        verifyCode = "";
    }
}
