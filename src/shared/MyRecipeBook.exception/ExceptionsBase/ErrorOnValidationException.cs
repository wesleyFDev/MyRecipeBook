using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.exception.ExceptionsBase
{
    
    public class ErrorOnValidationException : MyRecipeBookException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages)
        {
            _errors = errorMessages;
        }
    }
}
