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
using System.Drawing;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Globalization;

namespace AlivieskaGpsClient
{
	// Data received from the GPS server
	public class GpsData
	{
		private readonly MainForm _form;
		
		public Size Size = new Size(4200, 3350);
		public PointF Center = new PointF(-0.0585f, 0.041f);

		public PointF MapPosition
		{
			get
			{
				return new PointF(this.X / this.Size.Width + this.Center.X, -this.Z / this.Size.Height + this.Center.Y);
			}
		}

        public PointF PlayerPosition
        {
            get
            {
                return new PointF(this.PX / this.Size.Width + this.Center.X, -this.PZ / this.Size.Height + this.Center.Y);
            }
        }

        public PointF TrainPosition
        {
            get
            {
                return new PointF(this.TX / this.Size.Width + this.Center.X, -this.TZ / this.Size.Height + this.Center.Y);
            }
        }

        public GpsData(MainForm form)
		{
			this._form = form;
		}

        // Car
		public float X = 0;         // West-east position
		public float Y = 0;         // Height above lake Peräjärvi
		public float Z = 0;         // North-south position
        public float Heading = 0;   // Angle from north in degrees

        //World
        public string time24 = "";     // TimeIn24h
        public string time12 = "";     // TimeIn12h

        // Player
        public float PX = 0;         // West-east position
        public float PY = 0;         // Height above lake Peräjärvi
        public float PZ = 0;         // North-south position
        public float PHeading = 0;   // Angle from north in degrees

        // Train
        public float TX = 0;         // West-east position
        public float TY = 0;         // Height above lake Peräjärvi
        public float TZ = 0;         // North-south position

        public string ResponseString;   // The raw string received from the server
		public bool Success = false;    // Indicates whether the request was successful
		public HttpStatusCode Status;   // The status code of the response

		private XmlDocument _doc = new XmlDocument();
		//<GpsData>
		//	<X>1009.916</X>
		//	<Y>-0.8313327</Y>
		//	<Z>-738.0518</Z>
		//	<Heading>10</Heading>
		//	<Speed>30</Speed>
		//	<Time>0</Time>
		//</GpsData>

		private readonly HttpClient _client = new HttpClient();
		public async Task Get(string url)
		{
			HttpResponseMessage response = await _client.GetAsync(url);
			Success = response.IsSuccessStatusCode;
			Status = response.StatusCode;
			if (response.IsSuccessStatusCode)
			{
				ResponseString = await response.Content.ReadAsStringAsync();
				_doc.LoadXml(ResponseString);
				float.TryParse(_doc.DocumentElement["X"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out X);
				float.TryParse(_doc.DocumentElement["Y"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out Y);
				float.TryParse(_doc.DocumentElement["Z"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out Z);
				float.TryParse(_doc.DocumentElement["Heading"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out Heading);
                time24 = _doc.DocumentElement["time24"].InnerText;
                time12 = _doc.DocumentElement["time12"].InnerText;
                float.TryParse(_doc.DocumentElement["PX"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out PX);
                float.TryParse(_doc.DocumentElement["PY"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out PY);
                float.TryParse(_doc.DocumentElement["PZ"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out PZ);
                float.TryParse(_doc.DocumentElement["PHeading"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out PHeading);

                float.TryParse(_doc.DocumentElement["TX"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out TX);
                float.TryParse(_doc.DocumentElement["TY"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out TY);
                float.TryParse(_doc.DocumentElement["TZ"].InnerText.Trim(), NumberStyles.Float, NumberFormatInfo.InvariantInfo, out TZ);
            }
			_form.UpdateGpsData();
		}
	}
}
