using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
//using Internal;
using System;
//using System.Diagnostics;
//using System.Numerics;

public class RobotSocket : MonoBehaviour
{
    Thread thread;
    public int port = 25000;
    public string server = "10.211.56.4";
    TcpClient client;

    void Start()
    {
        ThreadStart ts = new ThreadStart(Connection);
        thread = new Thread(ts);
        thread.Start();
    }

    void SendIncorrect()
    {
        SendData("ans/incorrect");
    }

    void SendCorrect()
    {
        SendData("ans/correct");
    }

    void SendDance()
    {
        SendData("dance");
    }

    void SendData(String message)
    {
        try
        {
            using TcpClient client = new TcpClient(server, port);
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            Debug.Log("Sent Data");

        }
        catch (ArgumentNullException e)
        {
            Debug.Log("ArgumentNullException: " + e);
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e);
        }

    }

    void Connection()
    {
        SendDance();
    }
}