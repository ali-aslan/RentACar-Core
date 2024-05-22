using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails:ProblemDetails
{
    public BusinessProblemDetails(string details)
    {
        Title = "Rule Violation";
        Detail=details;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://blabla.com/probs/business";
        
    }
}
