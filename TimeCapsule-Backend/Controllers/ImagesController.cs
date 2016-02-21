using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Http;
using System.IO;
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

                JavaScriptSerializer ser = new JavaScriptSerializer();

                return ser.Serialize(imgList);
            }

        }

        public string getImagesInLocation(string city)
        {
            using (TimeCapsuleDBDataContext db = new TimeCapsuleDBDataContext())
            {
                var imgList = db.getImagesForLocation(city);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(imgList);
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

                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(imgList);

            }
        }
    }
}
