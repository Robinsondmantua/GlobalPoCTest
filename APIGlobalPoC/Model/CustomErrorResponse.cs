using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public class CustomErrorResponse
    {
		public string Message { get; set; }
		
		public CustomErrorResponse(string message)
		{
			Message = message; 
		}
	}
}
