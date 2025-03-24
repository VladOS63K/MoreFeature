using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MB.Web;

namespace MoreFeature
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public async Task StartServer(string ipAddress, int webSocketPort, int filePort)
        {
            Console.WriteLine("Starting WebSocket server...");

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add($"http://{ipAddress}:{webSocketPort}/");
            listener.Start();

            Console.WriteLine("Starting file server...");

            SimpleWebServer fileServer = new SimpleWebServer($"http://{ipAddress}:{filePort}/", "ui/");
            fileServer.Start();

            Console.WriteLine("All servers started. Waiting for connections...");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    ProcessWebSocketRequest(context);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Close();
                }
            }
        }

        private async Task ProcessWebSocketRequest(HttpListenerContext context)
        {
            HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
            WebSocket socket = webSocketContext.WebSocket;

            // Handle incoming messages
            byte[] buffer = new byte[2048];
            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string receivedMessage = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Received message: {receivedMessage}");
                    string response = "error";
                    byte[] responseBuffer = new byte[2048];
                    if (receivedMessage == "list")
                    {
                        string listJson = File.ReadAllText("json\\" + Properties.Program.Default.DefaultJson);
                        response = listJson;
                    }
                    responseBuffer = Encoding.UTF8.GetBytes(response);
                    await socket.SendAsync(new ArraySegment<byte>(responseBuffer, 0, responseBuffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    this.Close();
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await StartServer("localhost", 8800, 8000);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Stream faviconStream = await webView21.CoreWebView2.GetFaviconAsync(Microsoft.Web.WebView2.Core.CoreWebView2FaviconImageFormat.Png);
            if (faviconStream == Stream.Null) return;
            Bitmap img = (Bitmap)Image.FromStream(faviconStream);
            this.Icon = Icon.FromHandle(img.GetHicon());
        }
    }
}
