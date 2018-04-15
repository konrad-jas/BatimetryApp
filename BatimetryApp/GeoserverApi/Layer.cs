using System.Collections.Generic;
using System.Xml.Serialization;

namespace BatimetryApp.GeoserverApi
{
	//public class Layer
	//{
	//	public string Name { get; set; }
	//	public string Href { get; set; }
	//}

	//public class LayersCollection
	//{
	//	public LayersCol Layers { get; set; } 
	//}

	//public class LayersCol
	//{
	//	public List<Layer> Layer { get; set; } 
	//}

	public class Layer
	{
		public string Name { get; set; }
		public string Title { get; set; }
		[XmlElement("LatLonBoundingBox")]
		public BoundingBox BoundingBox { get; set; }
	}

	public class BoundingBox
	{
		[XmlAttribute("minx")]
		public string MinX { get; set; }
		[XmlAttribute("miny")]
		public string MinY { get; set; }
		[XmlAttribute("maxx")]
		public string MaxX { get; set; }
		[XmlAttribute("maxy")]
		public string MaxY { get; set; }
	}
}