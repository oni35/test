using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Library
{
    public class SalaryValidator : ValidationAttribute
    {
        #region Constructors
        public SalaryValidator() : base()
        {
            ErrorMessage = "Le salaire doit être compris entre 0 et 100000";
        }
        #endregion

        #region Functions
        public override bool IsValid(object value)
        {
            bool result = false;

            //try{}
            if (float.TryParse(value.ToString(), out float data))
            {
                if (data >= 0 || data <= 100000)
                {
                    result = true;
                }
            }
            return result;

            /*catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
            #endregion
        }
    }
}
