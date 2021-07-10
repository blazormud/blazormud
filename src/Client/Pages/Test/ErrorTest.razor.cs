using System;

namespace BlazorMUD.Client.Pages.Test
{
    public partial class ErrorTest
    {

        protected static void GenerateError()
        {
            throw new Exception();
        }
    }
}
