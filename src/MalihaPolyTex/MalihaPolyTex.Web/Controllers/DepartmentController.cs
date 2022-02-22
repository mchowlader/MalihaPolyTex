﻿using Autofac;
using MalihaPolyTex.Academy.Utilities;
using MalihaPolyTex.Web.Models;
using MalihaPolyTex.Web.Models.DepartmentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateDepartmentModel>();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateDepartmentModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CerateDepartmentAsync();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Department dosen't create.");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            var model = _scope.Resolve<DataDepartmentModel>();
            return View(model);
        }

        public async Task<JsonResult> GetDepartmentData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<DataDepartmentModel>();
            var data = await model.DepartmentListAsync(dataTable);

            return Json(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<EditDepartmentModel>();
            if(ModelState.IsValid)
            {
                try
                {
                    await model.LoadDepartmentDataAsync(id);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Department dosen't Load.");
                }
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDepartmentModel model)
        {
            if(ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.UpdateDepartmentAsync();
            }
            return RedirectToAction(nameof(Data));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<DataDepartmentModel>();

            await model.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Data));
        }
        public IActionResult Enroll()
        {
            var model = _scope.Resolve<EnrollModel>();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                try
                {
                    await model.EnrollStudentAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Enroll failed");
                }
            }
            return View(model);
        }
    }
}