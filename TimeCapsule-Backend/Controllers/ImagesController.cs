using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using TimeCapsule_Backend;

namespace WebRole1.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Image
        public string get(int ownerId)
        {
            using (TimeCapsuleDBDataContext db = new TimeCapsuleDBDataContext())
            {
                var imgList = db.Images.Where(l => l.OwnerId == ownerId);

                return JsonConvert.SerializeObject(imgList);
            }

        }

        public string getImagesInLocation(string city)
        {
            using (TimeCapsuleDBDataContext db = new TimeCapsuleDBDataContext())
            {
                var imgList = db.getImagesForLocation(city);
                return JsonConvert.SerializeObject(imgList);
            }
        }

        public string getImagesByUsername(string username)
        {
            using (TimeCapsuleDBDataContext db = new TimeCapsuleDBDataContext())
            {
                var imgList = from image in db.Images
                              join person in db.Persons on image.OwnerId equals person.id
                              where person.Username == username
                              select image;

                return JsonConvert.SerializeObject(imgList);

            }
        }
    }
}
