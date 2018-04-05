using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlockChain.Models;
using WebBlockChain.ViewModels;

namespace WebBlockChain.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;
        public HomeController(IRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Auhorization()
        {
            AuthorizationViewModel modal = new AuthorizationViewModel
            {
                Users= repository.AllUsers().ToList()
            };

            return View(modal);
        }
        public ActionResult Index(int UserId)
        {
            IndexViewModel model = new IndexViewModel();
            model.User = repository.FindUser(UserId);
            model.Users = repository.AllUsers().Where(x=>x.UserId!=UserId).ToList();
            model.Currensies = repository.AllCurrency().ToList();
            model.Transactions = repository.AllTransaction().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateTransaction(int UserId, int SelectedUser, string Currensy, double Count)
        {
            Transaction transaction = new Transaction
            {
                BuyerId = SelectedUser,
                SellerId = UserId,
                Currensy = Currensy,
                Count=Count,
                Time = DateTime.Now,
                InTheBlock = false
            };
            bool result=repository.AddTransaction(transaction);
            return RedirectToAction("Index", new {UserId } );
        }
        [HttpPost]
        public ActionResult StartMining(int userId)
        {
                bool result=repository.MakeBlock(userId);
                return Json(result);                    
        }
        public ActionResult Details()
        {
            DetailsViewModel model = new DetailsViewModel();
            model.BlockChains = repository.AllBlocks().ToList();
            model.Transactions = repository.AllTransaction().Where(x => x.InTheBlock == false).ToList();
            return View(model);
        }

    }
}