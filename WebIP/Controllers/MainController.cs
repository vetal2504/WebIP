using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebIP.Models;

namespace WebIP.Controllers
{
    public class MainController : Controller
    {
        IPContext db = new IPContext();
        // GET: Main
        public ActionResult ViewIP(string net)
        {
            var all = db.AllAddress.Where(p => p.Network == net);
            ViewBag.Net = net;
            ViewBag.IP = all;
            return View();
        }
        [HttpGet]
        public ActionResult EnterNetwork()
        {
            var all = db.Networkings;
            ViewBag.Net = all;
            return View();
        }
        [HttpGet]
        public ActionResult AddNetwork()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult AddNetwork(Networking net)
        {
            try
            {
                db.Networkings.Add(net);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string s = ex.InnerException.ToString();
            }
            
            return Redirect("/Main/EnterNetwork/");
        }

        public ActionResult EditNetwork(string net)
        {
            ViewBag.Addreses = db.AllAddress;
            ViewBag.Net = net;
            return View();
        }

        [HttpGet]
        public ActionResult EditAddress(string net, int add, string client, string information)
        {
            ViewBag.Net = net;
            ViewBag.Add = add;
            ViewBag.Client = client;
            ViewBag.Information = information;
            return View();
        }

        [HttpGet]
        public ActionResult AddAddress(string net, int add, string client, string information)
        {
            ViewBag.Net = net;
            ViewBag.Add = add;
            ViewBag.Client = client;
            ViewBag.Information = information;
            return View();
        }

        [HttpPost]
        public RedirectResult AddAddress(IP_address ip)
        {
            db.AllAddress.Add(ip);
            db.SaveChanges();
            return Redirect("/Main/ViewIP?net=" + ip.Network);
        }

        [HttpPost]
        public RedirectResult UpdateAddress(IP_address ip)
        {
            var add = db.AllAddress.Where(i => i.Address == ip.Address && i.Network == ip.Network).FirstOrDefault();
            if (add != null)
            {
                db.AllAddress.Remove(add);
            }
            if (ip.Name == null)
            {
                db.SaveChanges();
            }
            else
            {
                IP_address newAdd = new IP_address() {Address = ip.Address, Network = ip.Network, Name = ip.Name, Information = ip.Information};
                db.AllAddress.Add(newAdd);
            }
            return Redirect("/Main/ViewIP?net=" + ip.Network);
        }
    }
}