using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing.Common;
using ZXing;
using UnityEngine.UI;


public class QRGenerateManger : MonoBehaviour
{
    public static void GenerateQRImage(RawImage QRCodeImage, string content, int width, int height)
    {
        EncodingOptions options = null;
        BarcodeWriter writer = new BarcodeWriter();
        options = new EncodingOptions
        {
            Width = width,
            Height = height,
            Margin = 1,
        };
        options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
        writer.Format = BarcodeFormat.QR_CODE;
        writer.Options = options;
        Color32[] colors = writer.Write(content);
        
        Texture2D texture = new Texture2D(width, height);
        texture.SetPixels32(colors);
        texture.Apply();
        QRCodeImage.texture = texture;
    }
}
