using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using VoterInformation.Models;
using VoterInformation.SystemDAL;

namespace VoterInformation.Controllers
{
    public class VoterController : Controller
    {
        // GET: Voter
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Voter/Query

        public ActionResult Query()
        {
            return View();
        }


        // GET: /Voter/Lookup

        public ActionResult Lookup()
        {
            string streetName = Request.Params["street"];

            if (streetName.IsNullOrWhiteSpace())
            {
                return View("Query");
            }

            List<VoterModel> votersList= new VoterDAL().getVoterByStreet(streetName);

            return View("Lookup", votersList);
        }
    }
}