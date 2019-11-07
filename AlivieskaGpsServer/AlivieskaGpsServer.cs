/*
Copyright (C) 2018 Wampa842

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using MSCLoader;
using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Net;
using System.Threading;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

namespace AlivieskaGpsServer
{
	public class WebServer
	{
		/*
		The WebServer class is from here: https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server

		The MIT License (MIT)

		Copyright (c) 2013 David's Blog (www.codehosting.net) 

		Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
		associated documentation files (the "Software"), to deal in the Software without restriction, 
		including without limitation the rights to use, copy, modify, merge, publish, distribute, 
		sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
		furnished to do so, subject to the following conditions:

		The above copyright notice and this permission notice shall be included in all copies or 
		substantial portions of the Software.

		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
		INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
		PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
		FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
		OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
		DEALINGS IN THE SOFTWARE.
		*/

		private readonly HttpListener listener = new HttpListener();
		private readonly Action<HttpListenerRequest, HttpListenerResponse> responseMethod;

		public bool IsClosed { get; private set; } = false;
		public HttpListenerPrefixCollection Prefixes => listener.Prefixes;

		public WebServer(string[] prefixes, Action<HttpListenerRequest, HttpListenerResponse> method)
		{
			if (!HttpListener.IsSupported)
				throw new NotSupportedException("HttpListener is not supported");
			if (prefixes == null)
				throw new ArgumentException("prefixes");
			if (method == null)
				throw new ArgumentException("method");
			foreach (string s in prefixes)
				listener.Prefixes.Add(s);
			responseMethod = method;
			listener.Start();
			ModConsole.Print("Server created");
		}

		public WebServer(Action<HttpListenerRequest, HttpListenerResponse> method, params string[] prefixes) : this(prefixes, method) { }

		public void Run()
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				try
				{
					while (listener.IsListening)
					{
						ThreadPool.QueueUserWorkItem(c =>
						{
							var ctx = c as HttpListenerContext;
							try
							{
								responseMethod(ctx.Request, ctx.Response);
							}
							catch { }
							finally
							{
								ctx.Response.OutputStream.Close();
							}
						}, listener.GetContext());
					}
				}
				catch { }
			});
		}

		public void Stop()
		{
			listener.Stop();
			listener.Close();
		}
	}

	public class AlivieskaGpsServer : Mod
	{
		public override string ID => "AlivieskaGpsServer";
		public override string Name => "Alivieska GPS server";
		public override string Author => "Wampa842 & Linj";
		public override string Version => "1.0.5";
		public override bool UseAssetsFolder => false;
        public override bool LoadInMenu => false;

        private string _serverConfigPath;
		private int _port = 8080;
		private bool _autoStart = true;
		private bool _outputJson = false;

		private GameObject _car;    // The Satsuma or whatever other GameObject needs to be tracked

        private GameObject _player; // The Player

        private GameObject _train; // The Train

        //Time In Game
        private GameObject _sun;
        private FsmFloat _rot;
        private Transform _transH, _transM;
        /// Based on the Sun's rotation, returns whether it's the afternoon.
        public bool IsAfternoon => (_rot.Value > 330.0f || _rot.Value <= 150.0f);

        /// Hour in day, 0 to 12 float.
        public float Hour12F => ((360.0f - _transH.localRotation.eulerAngles.y) / 30.0f + 2.0f) % 12;
        /// Hour in day, 0 to 24 float.
        public float Hour24F => IsAfternoon ? Hour12F + 12.0f : Hour12F;
        /// Minute in hour, 0 to 60 float.
        public float MinuteF => (360.0f - _transM.localRotation.eulerAngles.y) / 6.0f;
        /// Hour in day, 0 to 11 integer.
        public int Hour12 => Mathf.FloorToInt(Hour12F);
        /// Hour in day, 0 to 23 integer.
        public int Hour24 => Mathf.FloorToInt(Hour24F);
        /// Minute in hour, 0 to 59 integer.
        public int Minute => Mathf.FloorToInt(MinuteF);


        private void _loadConfig()
		{
			if (!File.Exists(_serverConfigPath))
			{
				File.CreateText(_serverConfigPath);
				_saveConfig();
			}
			else
			{
				using (StreamReader reader = new StreamReader(_serverConfigPath))
				{
					while (!reader.EndOfStream)
					{
						string[] tok = reader.ReadLine().Split(' ');
						if (tok.Length > 1)
						{
							switch (tok[0])
							{
								case "port":
									int.TryParse(tok[1], NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out _port);
									break;
								case "autostart":
									bool.TryParse(tok[1].Trim().ToLowerInvariant(), out _autoStart);
									break;
								case "output":
									_outputJson = tok[1].Trim().ToLowerInvariant() == "json";
									break;
								default:
									break;
							}
						}
					}
				}
			}
		}

		private void _saveConfig()
		{
			using (StreamWriter writer = new StreamWriter(_serverConfigPath))
			{
				writer.WriteLine("port " + _port.ToString(NumberFormatInfo.InvariantInfo));
				writer.WriteLine("autostart " + _autoStart.ToString().ToLowerInvariant());
				writer.WriteLine("output " + (_outputJson ? "json" : "xml"));
			}
		}

		public string GetJsonContent()
		{
			float x = _car.transform.position.x;
			float y = _car.transform.position.y;
			float z = _car.transform.position.z;
            float px = _player.transform.position.x;
            float py = _player.transform.position.y;
            float pz = _player.transform.position.z;
            float tx;
            float ty;
            float tz;
            if (_train != null)
            {
                tx = _train.transform.position.x;
                ty = _train.transform.position.y;
                tz = _train.transform.position.z;
            } else
            {
                tx = -100;
                ty = -100;
                tz = -100;
            }
			float heading = _car.transform.eulerAngles.y;
            float pheading = _player.transform.eulerAngles.y;
            string time12 = string.Format("{0:0}h{1:00}", this.Hour24, this.Minute);
            string time24 = string.Format("{0:0}h{1:00}", this.Hour12, this.Minute);

            return string.Concat("{", string.Format(@"""x"":{0},""y"":{1},""z"":{2},""time24"":{3},""time12"":{4},""heading"":{5},""pheading"":{6},""px"":{7},""py"":{8},""pz"":{9},""tx"":{10},""ty"":{11},""tz"":{12}", x, y, z, time24, time12, heading, pheading, px, py, pz, tx, ty, tz), "}");
		}

		public string GetXmlContent()
		{
			XmlDocument doc = new XmlDocument();
			doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "no"));
			doc.AppendChild(doc.CreateElement("GpsData"));

			XmlElement node;
			node = doc.CreateElement("X");
			node.InnerText = _car.transform.position.x.ToString(CultureInfo.InvariantCulture);
			doc.DocumentElement.AppendChild(node);

			node = doc.CreateElement("Y");
			node.InnerText = _car.transform.position.y.ToString(CultureInfo.InvariantCulture);
			doc.DocumentElement.AppendChild(node);

			node = doc.CreateElement("Z");
			node.InnerText = _car.transform.position.z.ToString(CultureInfo.InvariantCulture);
			doc.DocumentElement.AppendChild(node);

			node = doc.CreateElement("Heading");
			node.InnerText = _car.transform.eulerAngles.y.ToString(CultureInfo.InvariantCulture);
			doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("PHeading");
            node.InnerText = _player.transform.eulerAngles.y.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("time24");
			node.InnerText = string.Format("{0:0}h{1:00}", this.Hour24, this.Minute).ToString(CultureInfo.InvariantCulture);
			doc.DocumentElement.AppendChild(node);

			node = doc.CreateElement("time12");
			node.InnerText = string.Format("{0:0}h{1:00}", this.Hour12, this.Minute).ToString(CultureInfo.InvariantCulture);
			doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("PX");
            node.InnerText = _player.transform.position.x.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("PY");
            node.InnerText = _player.transform.position.y.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("PZ");
            node.InnerText = _player.transform.position.z.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("TX");
            node.InnerText = _train.transform.position.x.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("TY");
            node.InnerText = _train.transform.position.y.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            node = doc.CreateElement("TZ");
            node.InnerText = _train.transform.position.z.ToString(CultureInfo.InvariantCulture);
            doc.DocumentElement.AppendChild(node);

            return doc.OuterXml;
		}

		public void GetContent(HttpListenerRequest request, HttpListenerResponse response)
		{
			string responseString;
			if(Array.Exists(request.Url.Segments, e => e.ToLowerInvariant().Contains("json")))
			{
				responseString = GetJsonContent();
				response.ContentType = "application/json";
			}
			else if(Array.Exists(request.Url.Segments, e => e.ToLowerInvariant().Contains("xml")))
			{
				responseString = GetXmlContent();
				response.ContentType = "application/xml";
			}
			else
			{
				if(_outputJson)
				{
					responseString = GetJsonContent();
					response.ContentType = "application/json";
				}
				else
				{
					responseString = GetXmlContent();
					response.ContentType = "application/xml";
				}
			}
			byte[] buffer = Encoding.UTF8.GetBytes(responseString);
			response.Headers.Add("Access-Control-Allow-Origin", request.Headers["Origin"]);
			response.ContentLength64 = buffer.Length;
			response.OutputStream.Write(buffer, 0, buffer.Length);
		}

		public WebServer Server;

		public void StartServer(bool loadConfigFile = true)
		{
			if (loadConfigFile)
			{
				_loadConfig();
			}
			if (Server == null)
			{
				try
				{
					ModConsole.Print("Creating server...");
					Server = new WebServer(GetContent, $"http://*:{_port}/");
					Server.Run();
				}
				catch (HttpListenerException ex)
				{
					ModConsole.Error("Could not create server:\n" + ex.ToString());
				}
			}
			ModConsole.Print("Server is running");
		}

		public void StopServer()
		{
			try
			{
				ModConsole.Print("Stopping server");
				if (Server != null)
				{
					Server.Stop();
					Server = null;
				}
				ModConsole.Print("Server is not running");
			}
			catch (Exception ex)
			{
				ModConsole.Error("Could not stop server:\n" + ex.ToString());
			}
			ModConsole.Print("Server stopped");
		}

        public class GpsCommand : ConsoleCommand
        {
			public override string Name => "gps";
			public override string Help => "GPS server - see 'gps help' for details";

            private AlivieskaGpsServer _mod;

            private const string _helpString =
				"AlivieskaGpsServer\n" +
				"Copyright (c) Wampa842 2018 (github.com/wampa842)\n\n" +
				"Usage:\n" +
				"  gps [-p <port>|--port <port>] <command>\n" +
				"where <command> is:" +
				"  start: starts listening on the default or specified port\n" +
				"  stop: halts the server\n" +
				"  restart: stops and then starts the server while reloading the configuration file\n" +
				"  write [xml] [json]: writes the response string to a file, in XML or JSON format\n" +
				"  help: displays this message\n\n" +
				"This mod runs a small HTTP web server that displays the current position and heading of the Satsuma, either in XML or in JSON format.\n" +
				"The data is served on localhost's specified port, or 8080 by default.";

			public GpsCommand(AlivieskaGpsServer sender)
			{
				this._mod = sender;
			}

			public override void Run(string[] args)
			{
				// Make sure the command is executed with arguments.
				if (args.Length < 1)
				{
					ModConsole.Error("Incorrect number of arguments. See 'gps help' for details.");
					return;
				}

				// Print the help text
				if (Array.Exists(args, e => e.ToLowerInvariant() == "help" || e == "-?"))
				{
					ModConsole.Print(_helpString);
					return;
				}

				// When starting or restarting, try to find -p and try to validate the following argument as a port number
				if (Array.Exists(args, e => e.ToLowerInvariant() == "start" || e.ToLowerInvariant() == "restart"))
				{
					int p;
					if ((p = Array.IndexOf(args, "-p")) >= 0 || (p = Array.IndexOf(args, "--port")) >= 0)
					{
						if (args.Length >= p + 1 && int.TryParse(args[p + 1], out int portNumber) && portNumber <= 65535 && portNumber >= 1)
						{
							_mod._port = portNumber;
						}
						else ModConsole.Print(_helpString);
					}
				}

				// Restart
				if (Array.Exists(args, e => e.ToLowerInvariant() == "restart"))
				{
					_mod.StopServer();
					_mod.StartServer();
					return;
				}

				// Start
				if (Array.Exists(args, e => e.ToLowerInvariant() == "start"))
				{
					_mod.StartServer();
					return;
				}

				// Stop
				if (Array.Exists(args, e => e.ToLowerInvariant() == "stop"))
				{
					_mod.StopServer();
					return;
				}

				// Write to file
				if (Array.Exists(args, e => e.ToLowerInvariant() == "write"))
				{
					if (Array.Exists(args, e => e.ToLowerInvariant() == "json"))
					{
						using (StreamWriter writer = new StreamWriter(Path.Combine(ModLoader.GetModConfigFolder(_mod), "out.json")))
						{
							writer.Write(_mod.GetJsonContent());
						}
					}
					else if (Array.Exists(args, e => e.ToLowerInvariant() == "xml"))
					{
						using (StreamWriter writer = new StreamWriter(Path.Combine(ModLoader.GetModConfigFolder(_mod), "out.xml")))
						{
							writer.Write(_mod.GetXmlContent());
						}
					}
					else
					{
						using (StreamWriter writer = new StreamWriter(Path.Combine(ModLoader.GetModConfigFolder(_mod), "out.json")))
						{
							writer.Write(_mod.GetJsonContent());
						}
						using (StreamWriter writer = new StreamWriter(Path.Combine(ModLoader.GetModConfigFolder(_mod), "out.xml")))
						{
							writer.Write(_mod.GetXmlContent());
						}
					}
					ModConsole.Print("Completed writing - check the mod's config folder.");
					return;
				}

				// If this point is reached, there were no valid commands to execute.
				ModConsole.Error("Invalid arguments. See 'gps help' for details.");
			}
		}

		public override void OnLoad()
		{
			_serverConfigPath = Path.Combine(ModLoader.GetModConfigFolder(this), "server.cfg");
			_loadConfig();
			ConsoleCommand.Add(new GpsCommand(this));
			_car = GameObject.Find("SATSUMA(557kg, 248)");
            _player = GameObject.Find("PLAYER");
            _train = GameObject.Find("train");

            _sun = GameObject.Find("SUN/Pivot");
            _rot = _sun.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmFloat("Rotation");

            _transH = GameObject.Find("SuomiClock/Clock/hour/NeedleHour").transform;
            _transM = GameObject.Find("SuomiClock/Clock/minute/NeedleMinute").transform;

            StartServer();
		}

		public override void OnSave()
		{
			StopServer();
		}
    }
}