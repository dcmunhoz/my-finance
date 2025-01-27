using Common.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Common.Api.ApiBaseController;

public abstract class ApiBaseController : ControllerBase
{
    protected IActionResult CreateResponseOnPost<TValue>(IResult<TValue> result, string redirectUrl)
    {
        if (result.HasErrors)
        {
            if (result.Errors.Count == 1)
                return BadRequest(new ErrorResponse
                {
                    Title = result.Errors.First().Title,
                    Message = result.Errors.First().Message
                });
            
            return BadRequest(new ErrorResponse
            {
                Title = "Ocorreram erros.",
                Details = result.Errors.Select(s => new ErrorDetailsResponse
                {
                    Title = s.Title,
                    Message = s.Message
                })
            });
        }

        return Created(redirectUrl, result.Value);
    }
    
    protected IActionResult CreateResponseOnPut<TValue>(IResult<TValue> result)
    {
        if (result.HasErrors)
        {
            if (result.Errors.Count == 1)
                return BadRequest(new ErrorResponse
                {
                    Title = result.Errors.First().Title,
                    Message = result.Errors.First().Message
                });
            
            return BadRequest(new ErrorResponse
            {
                Title = "Ocorreram erros.",
                Details = result.Errors.Select(s => new ErrorDetailsResponse
                {
                    Title = s.Title,
                    Message = s.Message
                })
            });
        }

        return Ok(result.Value);
    }

    protected IActionResult CreateResponseOnGet<TValue>(TValue value)
    {
        if (value is null)
            return NotFound(new ErrorResponse
            {
                Title = "Não encontrado.",
                Message = "O recurso solicitado não foi encontrado.",
            });

        return Ok(value);
    }
}