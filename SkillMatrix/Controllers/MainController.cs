using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace SkillMatrix.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        protected ICollection<string> ErrorMessages = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Messages", ErrorMessages.ToArray() }
            }));

        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                AddProcessingError(error.ErrorMessage);
            }

            return CustomResponse();

        }

        protected bool IsValidOperation()
        {
            return !ErrorMessages.Any();
        }

        protected void AddProcessingError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        protected void ClearErrorMessages()
        {
            ErrorMessages.Clear();
        }
    }
}
