using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplom.Controllers
{
    public class ListController : Controller
    {
        DiplomEntities1 db = new DiplomEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ListCPU()
        {
            return PartialView(await db.Cpus.ToListAsync());
        }
        public async Task<ActionResult> ListMB()
        {
            return PartialView(await db.MotherBoards.ToListAsync());
        }
        public async Task<ActionResult> ListRAM()
        {
            return PartialView(await db.Rams.ToListAsync());
        }
        public async Task<ActionResult> ListVideo()
        {
            return PartialView(await db.VideoCards.ToListAsync());
        }
        public async Task<ActionResult> ListBox()
        {
            return PartialView(await db.Boxes.ToListAsync());
        }
        public async Task<ActionResult> ListAudio()
        {
            return PartialView(await db.AudioCards.ToListAsync());
        }
        public async Task<ActionResult> ListHDD()
        {
            return PartialView(await db.HDDs.ToListAsync());
        }
        public async Task<ActionResult> ListPower()
        {
            return PartialView(await db.Powers.ToListAsync());
        }
        public async Task<ActionResult> ListProvider()
        {
            return PartialView(await db.Manufacturers.ToListAsync());
        }
        public async Task<ActionResult> ListShop()
        {
            return PartialView(await db.Shops.ToListAsync());
        }
        public ActionResult ListOrder()
        {
            return PartialView();
        }
        public async Task<ActionResult> ListOrderM()
        {
            return PartialView(await db.OrdersM.ToListAsync());
        }
        public async Task<ActionResult> ListOrderS()
        {
            return PartialView(await db.OrderS.ToListAsync());
        }
        public ActionResult ListReport()
        {
            return PartialView();
        }
        public async Task<ActionResult> ListReportM()
        {
            return PartialView(await db.OrdersM.ToListAsync());
        }
        public async Task<ActionResult> ListReportS()
        {
            return PartialView(await db.OrderS.ToListAsync());
        }
    }
}