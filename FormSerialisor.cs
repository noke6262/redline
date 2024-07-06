using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

public static class FormSerialisor
{
	public static void Serialise(Control c, string XmlFileName)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(XmlFileName, Encoding.Default);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteStartElement("ChildForm");
		smethod_0(xmlTextWriter, c);
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
		xmlTextWriter.Close();
	}

	private static void smethod_0(object xmlSerialisedForm, object c)
	{
		foreach (Control control in ((Control)c).Controls)
		{
			if (control is Label)
			{
				continue;
			}
			((XmlWriter)xmlSerialisedForm).WriteStartElement("Control");
			((XmlWriter)xmlSerialisedForm).WriteAttributeString("Type", control.GetType().ToString());
			((XmlWriter)xmlSerialisedForm).WriteAttributeString("Name", control.Name);
			if (control is TextBox)
			{
				((XmlWriter)xmlSerialisedForm).WriteElementString("Text", ((TextBox)control).Text);
			}
			else if (!(control is ComboBox))
			{
				if (control is ListBox)
				{
					ListBox listBox = (ListBox)control;
					if (listBox.SelectedIndex == -1)
					{
						((XmlWriter)xmlSerialisedForm).WriteElementString("SelectedIndex", "-1");
					}
					else
					{
						for (int i = 0; i < listBox.SelectedIndices.Count; i++)
						{
							((XmlWriter)xmlSerialisedForm).WriteElementString("SelectedIndex", listBox.SelectedIndices[i].ToString());
						}
					}
				}
				else if (control is CheckBox)
				{
					((XmlWriter)xmlSerialisedForm).WriteElementString("Checked", ((CheckBox)control).Checked.ToString());
				}
			}
			else
			{
				((XmlWriter)xmlSerialisedForm).WriteElementString("Text", ((ComboBox)control).Text);
				((XmlWriter)xmlSerialisedForm).WriteElementString("SelectedIndex", ((ComboBox)control).SelectedIndex.ToString());
			}
			((XmlWriter)xmlSerialisedForm).WriteElementString("Visible", ((bool)typeof(Control).GetMethod("GetState", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(control, new object[1] { 2 })).ToString());
			if (control.HasChildren)
			{
				if (!(control is SplitContainer))
				{
					smethod_0(xmlSerialisedForm, control);
				}
				else
				{
					smethod_0(xmlSerialisedForm, ((SplitContainer)control).Panel1);
					smethod_0(xmlSerialisedForm, ((SplitContainer)control).Panel2);
				}
			}
			((XmlWriter)xmlSerialisedForm).WriteEndElement();
		}
	}

	public static void Deserialise(Control c, string XmlFileName)
	{
		if (!File.Exists(XmlFileName))
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(XmlFileName);
		foreach (XmlNode childNode in xmlDocument.ChildNodes[1].ChildNodes)
		{
			smethod_1(c, childNode);
		}
	}

	private static void smethod_1(object currentCtrl, object n)
	{
		string value = ((XmlNode)n).Attributes["Name"].Value;
		string value2 = ((XmlNode)n).Attributes["Type"].Value;
		Control[] array = ((Control)currentCtrl).Controls.Find(value, searchAllChildren: true);
		if (array.Length == 0)
		{
			return;
		}
		Control control = (Control)smethod_2(array, currentCtrl);
		if (control == null || !(control.GetType().ToString() == value2))
		{
			return;
		}
		switch (value2)
		{
		case "System.Windows.Forms.TextBox":
			((TextBox)control).Text = ((XmlNode)n)["Text"].InnerText;
			break;
		case "System.Windows.Forms.CheckBox":
			((CheckBox)control).Checked = Convert.ToBoolean(((XmlNode)n)["Checked"].InnerText);
			break;
		case "System.Windows.Forms.ListBox":
		{
			ListBox listBox = (ListBox)control;
			XmlNodeList xmlNodeList = ((XmlNode)n).SelectNodes("SelectedIndex");
			for (int i = 0; i < xmlNodeList.Count; i++)
			{
				listBox.SelectedIndex = Convert.ToInt32(xmlNodeList[i].InnerText);
			}
			break;
		}
		case "System.Windows.Forms.ComboBox":
			((ComboBox)control).Text = ((XmlNode)n)["Text"].InnerText;
			((ComboBox)control).SelectedIndex = Convert.ToInt32(((XmlNode)n)["SelectedIndex"].InnerText);
			break;
		}
		control.Visible = Convert.ToBoolean(((XmlNode)n)["Visible"].InnerText);
		if (!((XmlNode)n).HasChildNodes || !control.HasChildren)
		{
			return;
		}
		foreach (XmlNode item in ((XmlNode)n).SelectNodes("Control"))
		{
			smethod_1(control, item);
		}
	}

	private static object smethod_2(object ctrl, object currentCtrl)
	{
		Control result = null;
		for (int i = 0; i < ((Array)ctrl).Length; i++)
		{
			if (((Control)((object[])ctrl)[i]).Parent.Name == ((Control)currentCtrl).Name || (currentCtrl is SplitContainer && ((Control)((object[])ctrl)[i]).Parent.Parent.Name == ((Control)currentCtrl).Name))
			{
				result = (Control)((object[])ctrl)[i];
				break;
			}
		}
		return result;
	}
}
