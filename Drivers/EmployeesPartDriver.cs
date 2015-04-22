using Futurify.Training.Employees.Models;
using Futurify.Training.Employees.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Title.Models;
namespace Futurify.Training.Employees.Drivers
{
    public class EmployeesPartDriver : ContentPartDriver<EmployeesPart>
    {
        protected override string Prefix
        {
            get
            {
                return "EmployeesPart";
            }
        }
        protected override DriverResult Display(
         EmployeesPart part, string displayType, dynamic shapeHelper)
        {
            var viewmodel = new EmployeeViewModel();
            viewmodel.Name = part.As<TitlePart>().Title;
            viewmodel.Age = part.Age;
            viewmodel.Address = part.Adress;
            return ContentShape("Parts_Employees", () => shapeHelper.Parts_Employees(
                Model: viewmodel));
        }

        //GET
        protected override DriverResult Editor(
            EmployeesPart part, dynamic shapeHelper) //hàm thêm mới
        {
            var viewmodel = new EmployeeViewModel();
            viewmodel.Name = part.As<TitlePart>().Title;
            viewmodel.Age = part.Age;
            viewmodel.Address = part.Adress;
            return ContentShape("Parts_Employees_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Employees",
                    Model: viewmodel,
                    Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(  
            EmployeesPart part, IUpdateModel updater, dynamic shapeHelper) // hàm sửa 
        {
            var viewmodel = new EmployeeViewModel();
            updater.TryUpdateModel(viewmodel, Prefix, null, null); // truy update nghĩa là lấy dữ liệu từ trên xuống
            part.Adress = viewmodel.Address;

            return Editor(part, shapeHelper);
        }
    }
}