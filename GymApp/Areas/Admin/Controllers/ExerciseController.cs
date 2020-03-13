using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GymApp.DataAccess.Repository.IRepository;
using GymApp.Models;
using GymApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExerciseController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ExerciseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Exercise exercise = new Exercise();
            if(id==null)
            {
                // this is for create a category
                return View(exercise);
            }
            // this is for editing
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            exercise = _unitOfWork.SP_Call.OneRecord<Exercise>(SD.Proc_Exercise_Get, parameter);

            if (exercise ==null)
            {
                return NotFound();
            }
            return View(exercise);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Exercise exercise)
        {
            if(ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Name", exercise.Name);

                if(exercise.Id ==0)
                {
                    _unitOfWork.SP_Call.Execute(SD.Proc_Exercise_Create, parameter);
                }
                else
                {
                    parameter.Add("@Id", exercise.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_Exercise_Update, parameter);

                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);

        }

        // API calls
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SP_Call.List<Exercise>(SD.Proc_Exercise_GetAll, null);
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            var objFromDb = _unitOfWork.SP_Call.OneRecord<Exercise>(SD.Proc_Exercise_Get, parameter);
            if(objFromDb==null)
            {
                return Json(new { success = false, message = "Error while deleteing" });
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_Exercise_Delete, parameter);
            _unitOfWork.Save();
            return Json(new { success = true, message = " Deleted from Database" });
        }

        #endregion


    }
}