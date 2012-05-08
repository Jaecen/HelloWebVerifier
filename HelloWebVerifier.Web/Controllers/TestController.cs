using System;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using HelloWebVerifier.Web.Models;

namespace HelloWebVerifier.Web.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
			var validationSets = ValidationSet.GetValidationSets()
				.Select(vs => vs.Subtype);

            return View(validationSets);
        }

		[HttpPost]
		public ActionResult Validate(string serviceUrl, string subtype)
		{
			try
			{
				System.Json.JsonArray cards;

				using(var client = new HttpClient())
				{
					client.BaseAddress = new Uri(serviceUrl);

					string setUrlPath = String.Format("subtype/{0}", Uri.EscapeUriString(subtype));
					var response = client.GetAsync(setUrlPath).Result;
					response.EnsureSuccessStatusCode();

					cards = response.Content.ReadAsAsync<System.Json.JsonArray>().Result;
				}

				var validationSet = ValidationSet.GetValidationSets()
					.Where(vs => vs.Subtype.Equals(subtype, StringComparison.InvariantCultureIgnoreCase))
					.FirstOrDefault();

				if(validationSet == null)
					throw new Exception(String.Format("Validation set for subtype \"{0}\" does not exist", subtype));

				if(cards.Count != validationSet.Cards.Count())
					return View(new ValidationResult(false, "Card count mismatch"));

				// This is backwards. If the target set contains the same card twice, this will still pass.
				foreach(var card in cards)
				{
					string name = card["name"].ReadAs<string>();
					string color = card["color"].ReadAs<string>();

					if(!validationSet.Cards.Any(c => c.Name == name && c.Color == color))
						return View(new ValidationResult(false, String.Format("Card mismatch on \"{0}\" \"{1}\"", name, color)));
				}

				return View(new ValidationResult(true, null));
			}
			catch(Exception exception)
			{
				return View(new ValidationResult(false, String.Format("Exception: {0}", exception)));
			}
		}
    }
}
