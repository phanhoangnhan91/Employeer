using Futurify.Training.Employees.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Futurify.Training.Employees.Controllers
{
    public class EmployeesController : Controller, IUpdateModel
    {
        IOrchardServices _services;
        public Orchard.ContentManagement.IContentManager _cms { get; set; }
        public dynamic Shape { get; set; }

        public EmployeesController(IShapeFactory shapeFactory, IOrchardServices services)
        {
            Shape = shapeFactory;
            _services = services;
            _cms = _services.ContentManager;
        }

        public ActionResult Index()
        {
            _cms = _services.ContentManager;
            var employees = _cms.Create("Employees", VersionOptions.Draft);
            var model = _cms.BuildEditor(employees);
            return View("Employees", (object)model);
            //return new ShapeResult(this, model);
        }

        public ActionResult DisplayEmployees()
        {
            // lấy danh sách các employee
            var lst = _cms.Query(VersionOptions.Published, "Employees").List();
            // buildDisplay để tạo ra ds các shap
            var lstemployees = lst.Select(t => _cms.BuildDisplay(t)); // duyệt từng t trong lst sau đó buildDisplay từng thằng t

            // hiện các sharp này ra bên ngoài 
            return new ShapeResult(this, Shape.EmployeesMain(List: lstemployees));
        }

        public ActionResult SaveEmployees(int id)
        {
            var emPloyees = _cms.Get(id, VersionOptions.AllVersions);
            _cms.UpdateEditor(emPloyees, this);
            _cms.Publish(emPloyees);
            return RedirectToAction("DisplayEmployees");
            //var model = _cms.UpdateEditor(emPloyees, this,  );
            //return null;
           // return View("Employees", (object)model);
        }

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties)
        {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage)
        {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}