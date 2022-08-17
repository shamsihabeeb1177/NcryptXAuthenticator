using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NcryptXAuthenticator.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly INodeServices nodeServices;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel (INodeServices nodeServices, ILogger<IndexModel> logger)
        
        {
            this.nodeServices = nodeServices;
            _logger = logger;
        }

        private const string NODE_SCRIPT = "./node/test.js";

        public void OnGet()
        {
            nodeServices.InvokeAsync<Task>(NODE_SCRIPT);
        }
    }
}
