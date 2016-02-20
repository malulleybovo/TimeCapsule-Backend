using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;

namespace WebRole1.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Location
        public DataContractJsonSerializer get(string name)
        {
            TimeCapsuleDBDataContext db = new TimeCapsuleDBDataContext();

            IEnumerable<Location> locList = db.where();

            DataContractJsonSerializer serializer;

            return View();
        }
    }
}