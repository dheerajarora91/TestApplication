using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApplication.Business.Helpers
{
    public class DateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateTime = (DateTime)value;
            if (dateTime > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
