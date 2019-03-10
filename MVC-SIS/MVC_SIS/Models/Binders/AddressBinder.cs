using Exercises.Models.Data;
using Exercises.Models.Repositories;
using Exercises.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.Binders
{
    public class AddressBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var addressVM = new AddressVM();
            Address address = new Address();
            address.State = StateRepository.Get(request.Form["Student.Address.State.StateAbbreviation"]);
            address.Street1 = request.Form["Student.Address.Street1"];
            address.Street2 = request.Form["Student.Address.Street2"];
            throw new Exception(address.State.StateName);
            throw new NotImplementedException();
        }
    }
}