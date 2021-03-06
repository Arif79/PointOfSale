﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.DAL;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.Controllers
{
    public class ExpenseItemController : Controller
    {
        ExpenseItemDAL expenseItemDa = new ExpenseItemDAL();
        ExpenseItemVM ModelVm = new ExpenseItemVM();

        // GET: ExpenseItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = expenseItemDa.GetExpenseItemSelectList();
            ModelVm.Code = expenseItemDa.GetExpenseItemCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseItemVM itemVm)
        {
            itemVm.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (expenseItemDa.IsExpenseItemSaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = expenseItemDa.GetExpenseItemSelectList();
            return View(ModelVm);
        }
    }
}