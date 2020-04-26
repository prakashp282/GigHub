using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    //inherits from ValidationAttribute
    public class FutureDate : ValidationAttribute
    {
        //overrides IsValid from ValidationAttributes
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "dd/MM/yyyy", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out dateTime );
            return (isValid && dateTime > DateTime.Now);
            

        }
    }
}