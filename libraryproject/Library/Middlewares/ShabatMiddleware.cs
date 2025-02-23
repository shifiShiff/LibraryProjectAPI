namespace Library.Api.Middlewares
{
    public class ShabatMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabatMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("middleware start");
            bool shabat = false;
            if (shabat)
            {
                Console.WriteLine("shaaaaaabbat!!!!!!!!!!!!!");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            else
            {
                await _next(context);
            }
            Console.WriteLine("middleware end");

        }


    }
}
