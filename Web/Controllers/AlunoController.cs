﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Repository;
using ApplicationService;

namespace Web.Controllers
{
    public class AlunoController : Controller
    {

        private AlunoServices Services { get; set; }

        public AlunoController(AlunoServices services) 
        {
            this.Services = services;
        }


        // GET: AlunoController
        public ActionResult Index()
        {

            return View(this.Services.GetAll());
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(Guid id)
        {
            var aluno = this.Services.GetAlunoById(id);
            return View(aluno);
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            try
            {
                this.Services.Save(aluno); 

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("APP_ERROR", ex.Message);
                return View(aluno);
            }
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var aluno = this.Services.GetAlunoById(id);
            return View(aluno);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Aluno aluno)
        {
            try
            {
                this.Services.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
