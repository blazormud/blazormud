using System;

namespace BlazorMUD.Client.Pages.Admin
{
    public partial class ErrorTest
    {

        protected static void GenerateError()
        {
            throw new Exception();
        }
    }
}
