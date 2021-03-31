using FrontEnd.Infrastructure.Gateway;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService gatewayService;

        public GatewayController(IGatewayService gatewayService)
        {
            this.gatewayService = gatewayService;
        }

        [HttpGet("{apiName}/{*endpoint}")]
        public async Task<IActionResult> GetAsync(string apiName, string endpoint)
        {
            try
            {
                var url = await gatewayService.BuildUrlAsync(apiName, endpoint);
                var response = await gatewayService.RequestAsync<object>(apiName, url);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("{apiName}/{*endpoint}")]
        public async Task<IActionResult> PostAsync(string apiName, string endpoint)
        {
            try
            {
                var url = await gatewayService.BuildUrlAsync(apiName, endpoint);
                var response = await gatewayService.RequestAsync<object>(apiName, url);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{apiName}/{*endpoint}")]
        public async Task<IActionResult> PutAsync(string apiName, string endpoint)
        {
            try
            {
                var url = await gatewayService.BuildUrlAsync(apiName, endpoint);
                var response = await gatewayService.RequestAsync<object>(apiName, url);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{apiName}/{*endpoint}")]
        public async Task<IActionResult> DeleteAsync(string apiName, string endpoint)
        {
            try
            {
                var url = await gatewayService.BuildUrlAsync(apiName, endpoint);
                var response = await gatewayService.RequestAsync<object>(apiName, url);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}