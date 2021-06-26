using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WepApp.Models;

namespace WepApp.Controllers
{
    public class Device2Controller : ApiController
    {
        device2Entities dv = new device2Entities();
        public IHttpActionResult getdevice()
        {

            var results = dv.Newdevices.ToList();
            return Ok(results);
        }

        [HttpPost]
        public IHttpActionResult dvinsert(Newdevice dvinsert)
        {
            dv.Newdevices.Add(dvinsert);
            dv.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetDeviceid(int id)
        {
            Device2Class dvdetails = null;
            dvdetails = dv.Newdevices.Where(x => x.Deviceid == id).Select(x => new Device2Class()
            {
                Deviceid = x.Deviceid,
                Devicename = x.Devicename,
                Temperature = x.Temperature,
                Humidity = x.Humidity,
            }).FirstOrDefault<Device2Class>();
            if (dvdetails == null)
            {
                return NotFound();
            }
            return Ok(dvdetails);
        }

        public IHttpActionResult Put(Device2Class dc)
        {
            var updatedv = dv.Newdevices.Where(x => x.Deviceid == dc.Deviceid).FirstOrDefault<Newdevice>();
            if (updatedv != null)
            {
                updatedv.Deviceid = dc.Deviceid;
                updatedv.Devicename = dc.Devicename;
                updatedv.Temperature = dc.Temperature;
                updatedv.Humidity = dc.Humidity;
                dv.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var dvdel = dv.Newdevices.Where(x => x.Deviceid == id).FirstOrDefault();
            dv.Entry(dvdel).State = System.Data.Entity.EntityState.Deleted;
            dv.SaveChanges();
            return Ok();
        }
    }
}
