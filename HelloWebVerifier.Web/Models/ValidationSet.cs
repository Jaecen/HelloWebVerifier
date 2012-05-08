using System;
using System.Collections.Generic;

namespace HelloWebVerifier.Web.Models
{
	public class ValidationSet
	{
		public string Subtype { get; protected set; }
		public IEnumerable<Card> Cards { get; protected set; }

		public ValidationSet(string subtype, IEnumerable<Card> cards)
		{
			Subtype = subtype;
			Cards = cards;
		}

		public bool IsValid()
		{
			return false;
		}

		public static IEnumerable<ValidationSet> GetValidationSets()
		{
			yield return new ValidationSet("angel",
				new[]
				{
					new Card("Angel of Glory's Rise", "White"),
					new Card("Angel of Flight Alabaster", "White"),
					new Card("Angel of Jubilation", "White"),
					new Card("Angelic Overseer", "White"),
					new Card("Archangel", "White"),
					new Card("Avacyn, Angel of Hope", "White"),
					new Card("Requiem Angel", "White"),
					new Card("Emancipation Angel", "White"),
					new Card("Goldnight Redeemer", "White"),
					new Card("Herald of War", "White"),
					new Card("Restoration Angel", "White"),
					new Card("Seraph of Dawn", "White"),
					new Card("Voice of the Provinces", "White"),
					new Card("Bruna, Light of Alabaster", "White/Blue"),
					new Card("Gisela, Blade of Goldnight", "White/Red"),
					new Card("Sigarda, Host of Herons", "White/Green"),
				});
		}
	}
}