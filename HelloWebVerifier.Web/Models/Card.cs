using System;

namespace HelloWebVerifier.Web.Models
{
	public class Card
	{
		public string Name { get; protected set; }
		public string Color { get; protected set; }

		public Card(string name, string color)
		{
			Name = name;
			Color = color;
		}
	}
}