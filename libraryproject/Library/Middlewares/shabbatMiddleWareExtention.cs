namespace Library.Api.Middlewares
{
    public static class shabbatMiddleWareExtention
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder app)
        { 
            return app.UseMiddleware<ShabatMiddleware>();
        }
    }
}
