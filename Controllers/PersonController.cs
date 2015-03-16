using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NVS_PRA2_B.Models;
using System.Xml.Serialization;
using System.IO;
using System.Web;

namespace NVS_PRA2_B.Controllers
{
    public class PersonController : ApiController
    {
        string mapPath = System.Web.HttpContext.Current.Server.MapPath("~/personData.xml");
        private static XmlSerializer serial = new XmlSerializer(typeof(List<Person>));
        List<Person> persList;

        public PersonController()
        {
            if (File.Exists(mapPath))
            {
                using (FileStream f = new FileStream(mapPath, FileMode.OpenOrCreate))
                {

                    persList = (List<Person>)serial.Deserialize(f);
                }
            }
            else
            {
                persList = new List<Person>();
            }
        }

        private void updateXML()
        {
            using (FileStream f = new FileStream(mapPath, FileMode.Create))
            {
                serial.Serialize(f, persList);
            }
        }

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return persList;
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            return persList.Find(person => person.id == id);
        }

        // POST: api/Person
        public void Post([FromBody]Person pers)
        {
            persList.Add(pers);
            updateXML();
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]Person pers)
        {
            int x = persList.FindIndex(person => person.id == id);
            persList[x] = pers;
            updateXML();
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            persList.Remove(persList.Find(person => person.id == id));
            updateXML();
        }
    }
}
