using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;
using BatimetryApp.GeoserverApi;
using Newtonsoft.Json;

namespace BatimetryApp.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			var client = new WebClient {Credentials = new NetworkCredential("client", "!horsesHaveLongNoses")};
			//var res = client.DownloadString(@"http://ec2-54-93-174-198.eu-central-1.compute.amazonaws.com/geoserver/rest/layers.json");
			//var deserialized = JsonConvert.DeserializeObject<LayersCollection>(res);
			//var layersDictionary = new Dictionary<string, string>();
			//foreach (var layerData in deserialized.Layers.Layer)
			//{
			//	var result = client.DownloadString(layerData.Href);
			//}
			//ViewData["layers"] = deserialized.Layers.Layer.ToDictionary(layer => layer.Name, layer => layer.Href);
			//@"http://ec2-54-93-87-113.eu-central-1.compute.amazonaws.com/geoserver/wms?request=GetCapabilities&service=WMS&version=1.0.0");
			var res =
				client.DownloadString(
					@"http://127.0.0.1:8080/geoserver/wms?request=GetCapabilities&service=WMS&version=1.0.0");
			var doc = XDocument.Parse(res);
			var layers =
				doc.Root.Element("Capability").Element("Layer").Descendants().Where(element => element.Name == "Layer").ToList();
			var serializer = new XmlSerializer(typeof (Layer));
			var objLayers = layers.Select(element => (Layer) serializer.Deserialize(element.CreateReader())).ToList();
			ViewData["layers"] = objLayers;
			return View();
		}
	}
}