using System;
using System.Text;
using UnityEngine;
using Unity.WebRTC;
using Unity.RenderStreaming;

public class WebBrowserInputData : WebBrowserInputChannelReceiver
{
    RTCDataChannel channel;

    public override void SetChannel(string connectionId, RTCDataChannel channel)
    {
        this.channel = channel;
        base.SetChannel(connectionId, channel);
        channel.OnMessage = bytes => {
            string str = Encoding.Default.GetString(bytes);
            Debug.Log(str);
        };
    }

    public void SendData(string msg)
    {
        
        channel.Send(msg);
    }
}