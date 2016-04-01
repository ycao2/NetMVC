﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Employee employee)
        {
            //Employee employee = new Employee();
            //TryUpdateModel(employee);

            if (ModelState.IsValid)
            {

                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                   new EmployeeBusinessLayer();
            Employee employee =
                   employeeBusinessLayer.Employees.Single(emp => emp.ID == id);

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                          new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID == id);
            UpdateModel(employee,null, null, new string[] {"Name"});

            if (ModelState.IsValid)
            {
                
                employeeBusinessLayer.SaveEmmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }


    }
}
