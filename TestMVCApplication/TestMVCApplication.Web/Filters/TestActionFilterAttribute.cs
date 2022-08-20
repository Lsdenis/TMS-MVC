using Microsoft.AspNetCore.Mvc.Filters;

namespace TestMVCApplication.Web.Filters;

public class TestActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var a = 5;
    }
}