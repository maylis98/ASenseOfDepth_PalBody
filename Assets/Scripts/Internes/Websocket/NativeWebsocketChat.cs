
//using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NativeWebSocket;
using System;
using System.Text;
using TMPro;


// https://github.com/endel/NativeWebSocket

public class NativeWebsocketChat : MonoBehaviour
{
    public string hostname;
    public int port = 2567;
    public TextMeshProUGUI txt;

    WebSocket websocket;


    async void Start()
    {
        websocket = new WebSocket("ws://" + hostname + ":" + port);

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {

/*            Debug.Log(bytes.Length);
            Debug.Log(bytes[0]);*/
            //string str = Convert.ToString(bytes);
            //string str = BitConverter.ToString(bytes);
            //string str = Encoding.Default.GetString(bytes);

            //Debug.Log(str);

            // getting the message as a string
             var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage! " + message);

            if (txt)
            {
                txt.text = message;
                //txt.text += "\n" + message;

                switch (message)
                {
                    //Game Manager
                    case "pal is here":
                        FindObjectOfType<MenuManager>().showPalBody();
                        break;
                    case "restart":
                        FindObjectOfType<LevelLoader>().Restart();
                        break;
                    case "credits":
                        FindObjectOfType<LevelLoader>().LoadNextLevel();
                        break;

                    //Intro Manager
                    case "start intro":
                        //FindObjectOfType<TimelineManager>().startTimeline(0);
                        break;
                    case "risks":
                        FindObjectOfType<IntroTextManager>().showText(0);
                        break;
                    case "diver":
                        FindObjectOfType<IntroTextManager>().showText(1);
                        FindObjectOfType<IntroTextManager>().hideText(0);
                        break;
                    case "first dialogue is end":
                        FindObjectOfType<IntroTextManager>().hideText(1);
                        /*FindObjectOfType<TimelineManager>().endTimeline(0);
                        FindObjectOfType<TimelineManager>().startTimeline(1);*/
                        break;
                    case "second dialogue is end":
                        FindObjectOfType<TimelineManager>().endTimeline(1);
                        break;
                    case "open capsule":
                        FindObjectOfType<CapsuleManager>().IsTouched();
                        break;
                    case "open capsule 2":
                        FindObjectOfType<Capsule2Manager>().IsTouched();
                        break;

                    //Main Manager
                    case "end of memory":
                        FindObjectOfType<EmitterOrder>().ARSceneEnd(true);
                        break;
                    case "player move":
                        FindObjectOfType<EmitterOrder>().SendInputdata(true);
                        break;
                    case "player static":
                        FindObjectOfType<EmitterOrder>().SendInputdata(false);
                        break;
                    case "player back":
                        FindObjectOfType<EmitterOrder>().SendBackwards(true);
                        break;
                    default:
                        break;
                }
            }


        };

        // Keep sending messages at every 1.0s
        //InvokeRepeating("SendWebSocketMessage", 0.0f, 1.0f);

        // waiting for messages
        await websocket.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
    }

    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText("plain text message");
        }
    }

    private async void OnApplicationQuit()
    {
        if (websocket != null && websocket.State == WebSocketState.Open)
        {
            await websocket.Close();
        }
    }


    async public void SendChatMessage(string message)
    {

        if (websocket.State == WebSocketState.Open)
        {
            Debug.Log("Sending " + message);

            // Sending bytes
            //await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText(message);
        }

    }
}
