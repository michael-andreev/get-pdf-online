using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrecizeSoft.GetPdfOnline.Domain.Contracts;

namespace PrecizeSoft.GetPdfOnline.Api.MvcCoreApp.Models
{
    public class ModelStateWrapper : IValidationDictionary
    {

        private ModelStateDictionary modelState;

        public ModelStateWrapper(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        #region IValidationDictionary Members

        public void AddError(string key, string errorMessage)
        {
            modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return modelState.IsValid; }
        }

        #endregion
    }
}
