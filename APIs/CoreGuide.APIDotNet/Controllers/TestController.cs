﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoreGuide.APIDotNet.Controllers
{
    public class TestController : ApiController
    {

        static HttpClient _client = new HttpClient();

        #region Bad - dead lock
        [HttpGet]
        public IHttpActionResult Bad()
        {
            var result = BadExample();
            return Ok(result);
        }

        string BadExample()
        {
            var message = BadGet().GetAwaiter().GetResult();
            return message;
        }

        async Task<string> BadGet()
        {
            var result = await _client.GetStringAsync("https://www.google.com");
            return result;
        }
        #endregion

        #region Good - no dead lock
        [HttpGet]
        public IHttpActionResult Good()
        {
            var result = GoodExample();
            return Ok(result);
        }

        string GoodExample()
        {
            var message = GoodGet().GetAwaiter().GetResult();
            return message;
        }

        async Task<string> GoodGet()
        {
            var result = await _client.GetStringAsync("https://www.google.com").ConfigureAwait(false);
            return result;
        } 
        #endregion
    }
}