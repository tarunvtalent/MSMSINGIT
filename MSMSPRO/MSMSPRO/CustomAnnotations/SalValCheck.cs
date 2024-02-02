using System;
using System.ComponentModel.DataAnnotations;

namespace MSMSPRO.CustomAnnotations
{
    public class SalValCheck :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int Salary = Convert.ToInt32(value);
            if (Salary % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
