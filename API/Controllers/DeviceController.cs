using API.DTOs;
using API.Helper;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class DeviceController : ControllerBase
	{
		protected DeviceControl device;

		public DeviceController(DataContext dataContext)
		{
			device = new DeviceControl(dataContext);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var result = device.GetAllDevice();

			return Ok(result);
		}

		/// <summary>
		/// Get Status of User
		/// </summary>
		/// <returns></returns>
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			string status = device.GetDevice(id);
			return Ok(status);
		}

		/// <summary>
		/// Post new Status
		/// </summary>
		/// <param name="Device"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post([FromBody]Devices Device)
		{
			bool status = device.UpdateDeviceStatus(Device);
			return Ok(status);
		}

	}
}
