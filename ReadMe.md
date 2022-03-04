.Net6 Exception filters template

If you rename or change path of project, it may be loaded not correctly.
You might receive "Error MSB4025: The Project File Could Not Be Loaded".
Thus, change name and path of project in .sln file. Then, Build changed project. Not rebuild!

To show swagger UI by default, open launchSettings and add launchURL:"swagger" to profile.

1) Create an exception in Application Exceptions folder.
   Specify ErrorCode inside.
2) throw it in code where needed.
3) In Program.cs add

builder.Services.AddMvc(options =>
{
    options.AddErrorFilters();
});

and 

app.Use(async (ctx, next) =>
{
    ctx.Request.EnableBuffering();
    await next.Invoke();
}); 

4) Add new FilterAttribute. Derive it Most likely from BasePayloadFilterAttribute. Or from BaseExceptionFilterAttribute.
5) Don`t forget to register attribute in Dependencies.cs AddErrorFilters extension method.
6) The order of registration matters.
   Firstly the flow will enter first attribute OnException method. 
   If context.Exception check will not pass, flow will enter second going attribute. One-by-one.
   When context.Exception check passes, it goes inside SetResponse method in base class. 
  
   
