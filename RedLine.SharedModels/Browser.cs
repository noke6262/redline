using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "Browser")]
[DataContract(Name = "Entity9", Namespace = "Entity")]
public class Browser
{
	[ProtoMember(1, Name = "Name")]
	[DataMember(Name = "Id1")]
	public string Name { get; set; }

	[ProtoMember(2, Name = "Profile")]
	[DataMember(Name = "Id2")]
	public string Profile { get; set; }

	[DataMember(Name = "Id3")]
	[ProtoMember(3, Name = "Credentials")]
	public IList<LoginPair> Credentials { get; set; }

	[DataMember(Name = "Id4")]
	[ProtoMember(4, Name = "Autofills")]
	public IList<Autofill> Autofills { get; set; }

	[DataMember(Name = "Id5")]
	[ProtoMember(5, Name = "CreditCards")]
	public IList<CreditCard> CreditCards { get; set; }

	[DataMember(Name = "Id6")]
	[ProtoMember(6, Name = "Cookies")]
	public IList<Cookie> Cookies { get; set; }

	[ProtoMember(7, Name = "AccountDetails")]
	[DataMember(Name = "TreeObject8")]
	public AccountDetails AccountDetails { get; set; }

	public bool IsEmpty()
	{
		bool result = true;
		IList<LoginPair> credentials = Credentials;
		if (credentials != null && credentials.Count > 0)
		{
			result = false;
		}
		IList<Autofill> autofills = Autofills;
		if (autofills != null && autofills.Count > 0)
		{
			result = false;
		}
		IList<CreditCard> creditCards = CreditCards;
		if (creditCards != null && creditCards.Count > 0)
		{
			result = false;
		}
		IList<Cookie> cookies = Cookies;
		if (cookies != null && cookies.Count > 0)
		{
			result = false;
		}
		return result;
	}
}
