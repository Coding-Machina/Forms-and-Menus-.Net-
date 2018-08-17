using MongoDbEg2.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDbEg2.Models;
using System.Threading.Tasks;

namespace MongoDbEg2.Controllers
{
    public class HomeController : Controller
    {
        Democontext ctx = new Democontext();
        public ActionResult Index()
        {
            return View(ctx.Batch.AsQueryable());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Batch NewBatch)
        {
            ctx.Batch.InsertOne(NewBatch);
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<ActionResult> Schedule(string id, Schedule newschedule)
        //{
        //    var batch = ctx.Batch.Find(p => p.Id == id).FirstOrDefault();
        //    int hours = 0;
        //    if(batch != null)
        //    {
        //        hours = batch.HoursTaken;
        //    }

        //    //hours += newschedule.Hours;
        //    var modification = Builders<Batch>.Update.Push(r => r.schedule, newschedule)
        //        .Inc("HoursTaken", newschedule.Hours);
        //or
        //var modification = Builders<Batch>.Update.Push(r => r.schedule, newschedule)
        //        .Set("HoursTaken", hours);
        //    await ctx.Batch.UpdateOneAsync(r => r.Id == id, modification);
        //    return RedirectToAction("Index");
        //}


        [HttpPost]
        public ActionResult Schedule(string id, Schedule newschedule)
        {
            var modi = Builders<Batch>.Update.Push(r => r.schedule, newschedule)
                .Inc("HoursTaken", newschedule.Hours);
            ctx.Batch.UpdateOne(r => r.Id == id, modi);
            return RedirectToAction("Index");
        }

        public ActionResult ScheduleList(string id)
        {
            List<Schedule> obj = ctx.Batch.Find(p => p.Id == id).FirstOrDefault().schedule;
            return View(obj);
        }

        public ActionResult Delete(string id)
        {
            return View(ctx.Batch.Find(p => p.Id == id).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, Batch batch)
        {
            ctx.Batch.DeleteOne(p => p.Id == id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            return View(ctx.Batch.Find(p => p.Id == id).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, Batch batch)
        {
            ctx.Batch.ReplaceOne(p => p.Id == id, batch);
            return RedirectToAction("Index");
        }
    }
}